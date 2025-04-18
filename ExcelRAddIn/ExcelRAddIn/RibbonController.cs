﻿using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;
using REnvironmentControlLibrary;
using REnvironmentControlLibrary.ViewModel;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Range = Microsoft.Office.Interop.Excel.Range;


namespace ExcelRAddIn
{
    [ComVisible(true)]
    public class RibbonController : ExcelRibbon
    {
        //
        // MSO button images: https://bert-toolkit.com/imagemso-list.html
        //  and: https://codekabinett.com/download/Microsoft-Office-2016_365-imageMso-Gallery.pdf
        //

        public override string GetCustomUI(string RibbonID)
        {
            return @"
    <customUI xmlns='http://schemas.microsoft.com/office/2006/01/customui' loadImage='LoadImage'>
      <ribbon>
        <tabs>
          <tab id='tab1' label='R AddIn'>
            <group id='group1' label='R Tools'>
              <button id='buttonTaskPane' label='Show/Hide Task Pane' size='large' imageMso='HideTaskPanes' onAction='OnButtonShowHideClicked' />
              <button id='buttonCreatePlot' label='Create Plot...' size='large' imageMso='ChartInsert' onAction='OnButtonCreatePlotClicked'/>
              <button id='buttonSettings' label='Settings...' size='large' imageMso='AssetSettings' onAction='OnButtonSettingsClicked'/>
            </group >
          </tab>
        </tabs>
      </ribbon>
    </customUI>";
        }

        public void OnButtonCreatePlotClicked(IRibbonControl control)
        {
            //https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/walkthrough-office-programming
            Microsoft.Office.Interop.Excel.Application xlApp = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;

            Range current = xlApp.ActiveCell;
            if (current == null)
                return;

            FormPlotSettings formPlotSettings = new FormPlotSettings();

            DialogResult result = formPlotSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                PlotViewModel plot = formPlotSettings.PlotViewModel;

                current.Value = plot.GetScript();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public void OnButtonSettingsClicked(IRibbonControl control)
        {
            //
            // D:\Development\Projects\C#\Office\ExcelRAddIn\ExcelRAddIn\bin\Debug\ExcelRAddIn-AddIn64.xll.config
            //
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            string home = settings["R_HOME"].Value;
            string path = settings["R_PATH"].Value;
            string packages = settings["packages"].Value;

            FormEnvironmentSettings environmentSettings = new FormEnvironmentSettings(home, path, packages);

            DialogResult result = environmentSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                settings["R_HOME"].Value = environmentSettings.Home;
                settings["R_PATH"].Value = environmentSettings.Path;
                settings["packages"].Value = environmentSettings.Packages;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public void OnButtonShowHideClicked(IRibbonControl control)
        {
            TaskPaneManager.ShowHideTaskPane();
        }
    }
}
