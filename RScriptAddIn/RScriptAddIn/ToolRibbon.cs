using System;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;

using RScriptAddIn.Properties;
using REngineWrapper;
using REnvironmentControlLibrary;
using System.Windows.Forms;

namespace RScriptAddIn
{
    public partial class ToolRibbon
    {
        private EngineWrapper engineWrapper = null;

        private void ToolRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.ToggleButtonShow.Label = (ToggleButtonShow.Checked) ? "Hide Task Pane" : "Show Task Pane";
        }

        private void ButtonRunScript_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if(engineWrapper == null) 
                {
                    AddMessage(MessageType.Information, "Initializing the R environment ...");

                    string path = Settings.Default.R_PATH;
                    string home = Settings.Default.R_HOME;

                    if (string.IsNullOrEmpty(home))
                        home = Environment.GetEnvironmentVariable("R_HOME");

                    if (string.IsNullOrEmpty(path))
                        path = Environment.GetEnvironmentVariable("R_PATH");

                    if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(home))
                    {
                        throw new Exception("R_HOME and/or path to R binaries are empty. Check the settings.");
                    }

                    engineWrapper = new EngineWrapper(path, home, HostType.Word);

                    AddMessage(MessageType.Information, "Successfully initialized the R environment");
                }

                //https://learn.microsoft.com/en-us/visualstudio/vsto/word-object-model-overview?view=vs-2022&tabs=csharp

                //
                // https://learn.microsoft.com/en-us/visualstudio/vsto/how-to-programmatically-insert-text-into-word-documents?view=vs-2022&tabs=csharp
                //
                Word.Document doc = (Word.Document)Globals.ThisAddIn.Application.ActiveDocument;
                Word.Selection sel = (Word.Selection)Globals.ThisAddIn.Application.Selection;
                string script = sel.Text.Trim();

                ScriptItem result = engineWrapper.Evaluate(script);
                if(result != null)
                {
                    switch (result.EvaluationType)
                    {
                        case EvaluationType.Unknown:
                        case EvaluationType.Exception:
                            InsertText(sel, result.Content);
                            break;

                        case EvaluationType.Empty:
                            {
                                string message = $"Empty expression from script: '{script.Substring(0, Math.Min(script.Length, 50))}'";
                                AddMessage(MessageType.Warning, message);
                            }
                            break;

                        case EvaluationType.Vector:
                        case EvaluationType.List:
                        case EvaluationType.Function:
                        case EvaluationType.Frame:
                        case EvaluationType.Matrix:
                        case EvaluationType.Language:
                        case EvaluationType.Factor:
                        case EvaluationType.Symbol:
                            AddItem(result);
                            break;
                        
                        case EvaluationType.Value:
                            InsertText(sel, result.Content);
                            break;

                        case EvaluationType.Remove:
                            {
                                string[] itemsToRemove = engineWrapper.ExtractParameters(result.Name);

                                long itemsRemoved = Globals.ThisAddIn.REnvironmentControl.RemoveEnvironmentItems(itemsToRemove);

                                string message = $"Removed {itemsRemoved} {((itemsRemoved != 1) ? "items" : "item")} from the environment";
                                AddMessage(MessageType.Information, message);
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    AddMessage(MessageType.Error, "Unsupported script operation.");
                }
            }
            catch (Exception exc)
            {
                AddMessage(MessageType.Error, exc.Message);
            }
        }

        private void InsertText(Word.Selection sel, string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                if (Globals.ThisAddIn.Application.Options.Overtype)
                {
                    Globals.ThisAddIn.Application.Options.Overtype = false;
                }

                // Test to see if selection is an insertion point.
                if (sel.Type == Word.WdSelectionType.wdSelectionIP)
                {
                }
                else if (sel.Type == Word.WdSelectionType.wdSelectionNormal)
                {
                    // Move to end of selection.
                    if (Globals.ThisAddIn.Application.Options.ReplaceSelection)
                    {
                        object direction = Word.WdCollapseDirection.wdCollapseEnd;
                        sel.Collapse(ref direction);
                    }
                    sel.TypeText(text);
                    sel.TypeParagraph();
                }
                else
                {
                    // Do nothing.
                }
            }
        }

        private void AddItem(ScriptItem result)
        {
            string name = result.Name.Trim();
            string contents = result.Content;
            Globals.ThisAddIn.REnvironmentControl.AddEnvironmentItem(name, contents);
        }

        private void AddMessage(MessageType type, string message)
        {
            Globals.ThisAddIn.REnvironmentControl.AddMessage(type, message);
        }

        private void UpdateLabel(object sender)
        {
            if (((RibbonToggleButton)sender).Checked)
            {
                this.ToggleButtonShow.Label = "Hide Task Pane";
            }
            else
            {
                this.ToggleButtonShow.Label = "Show Task Pane";
            }
        }

        private void ToggleButtonShow_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TaskPane.Visible = ((RibbonToggleButton)sender).Checked;
            UpdateLabel(sender);
        }

        private void ButtonSettings_Click(object sender, RibbonControlEventArgs e)
        {
            string home = Settings.Default.R_HOME;
            string path = Settings.Default.R_PATH;

            FormEnvironmentSettings settings = new FormEnvironmentSettings(home, path);

            DialogResult result = settings.ShowDialog();
            if (result == DialogResult.OK)
            {
                Settings.Default.R_HOME = settings.Home;
                Settings.Default.R_PATH = settings.Path;

                Settings.Default.Save();
            }
        }
    }
}
