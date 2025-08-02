<a href="https://www.flaticon.com/free-icons/notepad" title="notepad icons">Notepad icons created by Freepik - Flaticon</a>

# External links
Excel-DNA: https://excel-dna.net/docs/introduction
R.NET: https://github.com/rdotnet/rdotnet and https://rdotnet.github.io/rdotnet/

# Issues

## AddIn
[] Date conversion utilities for R <-> Excel? (Use case: Time Series Forecasting In R: From Moving Averages To Seasonal ARIMA | R-bloggers)
[] Extend the ExcelRAddIn menu bar to support a greater variety of functionality. Provide a separate 'Data Science' menu bar?

## Lib


## Control

## Tests

# Wishlist
[x] Provide a set of useful wrapper functions around the "Forecast" package (https://cran.r-project.org/web/packages/forecast/forecast.pdf) functions.
[x] Provide a wrapper API around the 'lm' (and 'glm') function.

ggplot2
[] Investigate inserting a plot directly into Excel rather than via the clipboard.
[] additional testing
[] add support for more geoms
[] add up/down control to the list of geoms ==> in progress
[] consider adding a simplified 'wizard' interface.
[] Add support for 'annotate': https://ggplot2.tidyverse.org/reference/annotate.html

Messages in the REnvironmentPanel:
[] add support for copying and viewing long messages in a message box ? or a tooltip?
[] add support for clearing messages

# Changes
## 23/05/2023

## 03/06/2023
[x] update handling of evaluated script items

## 04/06/2023
[x] check NativeUtility for paths
[x] list vs data frame output
[x] add project markdown document
[x] check in initial revision

## 11/06/2023
[x] Function to recursively evaluate the script results.

## 24/06/2023
Check support for the following:
[x] expression.IsLanguage()
[x] expression.IsList()
[x] expression.IsDataFrame()
[x] expression.IsMatrix()
[x] expression.IsVector()
[x] expression.IsFactor()
[x] expression.IsFunction()
[x] expression.IsSymbol()

## 25/06/2023
[x] add support for complex numbers (summary and contents) and for complex matrix
- check the ordering of the IsXYZType functions: DataFrame vs list?
Ordering: DataFrame, Factor, Function, List, Matrix, Vector, Symbol

## 26/06/2023
[x] Move the EngineWrapper into a separate library (RDotNetProxy)
[x] Add support for reporting messages to the list view (if there is one)
[x] Add testing framework

## 29/06/2023
[x] NumericVectorSummary
[x] IntegerVectorSummary
[x] CharacterVectorSummary
[x] LogicalVectorSummary
[x] FactorSummary

## 02/07/2023
[x] refactor 'object' output into a generic function
[x] re-test and check results
[x] refactor the list contents processing; add tests for list contents
[] add support for Symbol/Language pairlist contents?

VSTO+Excel-DNA : https://groups.google.com/g/exceldna/c/9zeb1mdxOzw

## 10/08/2023
[x] Move ExcelRAddIn to Obsolete
[x] Recreate Excel-DNA only project
[x] Add single function call for testing
[x] Add support for settings
- Add support for logging (in debug?)
[x] Add R.NET etc
[x] Add custom ribbon
[x] Add custom task pane (if possible)
https://github.com/Sven-Bo/excel-add-in-tutorial-template


## 13/08/2023
[x] Show Task Pane at startup
[x] Add API functions to create objects

## 21/08/2023
[OK] GetContents(DynamicVector v
[OK] GetContents(IntegerVector v
[OK] GetContents(LogicalVector v
[OK] GetContents(CharacterVector v,
[OK] GetContents(ComplexVector v,
- all these are the same (except complex vector that gets a complex number as a string)

[OK] GetContents(NumericMatrix m,
[OK] GetContents(ComplexMatrix m,
[OK] GetContents(CharacterMatrix m,
- all these are the same (except complex vector that gets a complex number as a string)
Similar to above.

- implement generic GetVectorContents function
- implement generic GetMatrixContents function

Types
------
Language
DataFrame
List
	GetContents(GenericVector v,  --> this is a list
Matrix
Factor
Vector
Symbol
Function

## 22/08/2023
[OK] List processing
[OK] Factor processing
[OK] Language
[OK] Function
[OK] Symbol
[OK] Make GetSummary functions into generics for both Vector and Matrix types

## 24/08/2023
Rebuild project from scratch
Add new testing environment
Details
[OK] - create a new solution file for the ExcelRAddIn (re-use the existing)
[OK] - add a class library RDotNetProxy: move the REngineWrapper.cs into library. this just contains the REngineWrapper.cs
[OK] - add reference to the project RDotNetProxy
[OK] - add test framework RDotNetProxyTest: NUnit (or XUnit)
[OK] - add tests. Rebuild and test.

## 25/08/2023
[OK] - add HostType enumeration
[OK] - add separate functions for GetContentsAsObject and GetContentsAsString depending on the host.
[OK] - Refactor

Spreadsheet that emulates all data analysis functions in Excel

Anova: Single Factor
Anova: Two-Factor with Replication
Anova: Two-Factor without Replication
Correlation
Covariance
Descriptive Statistics
Exponential Smoothing
F-Test Two-Sample for Variances
Fourier Analysis
Histogram
Moving Average
Random Number Generation
Rank and Percentiles
Regression
Sampling
t-Test: Paired Two Sample for Means
t-Test: Two-Sample Assuming Equal Variances
t-Test: Two-Sample Assuming Unequal Variances
z-Test: Two-Sample for Means

## 03/09/2023
[x] RScriptAddIn: update handling of lists from GetContentsAsString(); this should return names or a single line: 'List of ...'
[x] Clean up document tests
[x] Check in changes

## 08/09/2023 - 10/09/2023
[OK] Consider refactoring CreateXXXVector/Matrix to be CreateVector/Matrix(name, type, values)
- type = string, Complex, int, bool, double
[OK] RScriptAddIn: update handling of lists from GetContentsAsString(); this should return names or a single line: 'List of ...'
NOTE: This works slightly differently from the RStudio output. Consider if this is acceptable.
[OK] Add 'About' button to both applications; Add common about box (?) => this adds no information to the projects so scratch it.
[OK] Refactor the RScriptControl and the FormSettings. Both sould be in a separate libary that is used in common between the RScriptAddIn and the ExcelRAddIn
- Add support for WPF Script control ==> possible issue calling the CustomTaskPane constructor in the Excel.DNAIntegration?? This must work for both the Excel-DNA and VSTO components.

[OK] Refactor Globals.ThisAddIn.REnvironmentControl -> to use accessor or AddMessage local function wrapper
[OK] Add support for processing rm() in RScriptAddIn
[OK] Persist configuration settings from the ExcelRAddIn
[] Investigate Graphics stuff

## 11/09/2023
[OK] Refactor list output as string - this should output the correct indexes / names (including in embedded lists
[OK] Output from lm still not correct: Call (language); Terms (formula with 3 symbols);
=> use deparse to return a single string composed of the language elements
[OK] Update ExcelRAddIn object output for both language and symbol types 
[OK] Update the Excel output to handle NaNs correctly (i.e. blank cells)

## 12/09/2023 - 13/09/2023
[OK] Fix broken tests
[OK] List of 0 (like XLEVELS) --> this should return an empty string in GetContentsAsString/GetContentsAsObject
[OK] Handle evaluation for RObjectType = S4
[OK] Check the function evaluation with GetContentsAsObject/GetContentsAsString
[] Check for 'ExcelDna.Integration.ExcelEmpty' when evaluating matrices with empty cells. This is difficult to get rid of as it is part of the converter(...) logic. (What is the default value for an empty cell of type TOutput? default(TOutput) produces some garbage). Furthermore, if the empty input cell is filled the output is updated correctly.
Ideally the cells should be blank (double, int, chars, etc) or possibly disallow this completely.
[] NOTE: when you do the following: l[[1]] = 10, this is an assignment but the whole expression appears in the environment; it should be only the symbol 'l' ...

[OK] Update the Word test document(s)
	Word - RScriptAddIn
	[OK] Rename R-Tests -> RScriptAddInTests.docx
	[OK] Advanced R - Samples.docx add to -> RScriptAddInTests.docx
	[OK] Delete Advanced R - Samples.docx
	[OK] Update RScriptAddInTests.docx

## 14/09/2023
[OK] Check Excel tests
	[OK] Merge the Excel test files for the basic types and the S3 and S4 types
	[OK] R Types Tests.xlsx			- Basic tests of R types in Excel
	[OK] ExcelR AddIn Tests.xlsx		- Tests of core R functionality in Excel
	[OK] Excel Data Analysis.xlsx	- Tests of data analysis and modelling functions in Excel

[OK] Handle RObjectType = Environment. This lists out the names of the symbols in the attached environment for both GetContentsAsObject/GetContentsAsString.
[OK] Correct issue with creating a vector from column names with spaces: these need to be quoted, so in the environment we need to search for the trimmed (unquoted) object.

## 15/09/2023
- testing: 
ExcelRAddIn: vector and matrix creation, rm() function,
RScriptAddIn: output from list, output from formula
[x] TestLanguageContents
[x] TestDataFrameContents
[x] TestListContents
[x] TestIntegerMatrixContents
[x] TestDoubleMatrixContents
[x] TestMatrixAccessContents
[x] TestCharacterMatrixContents
[x] TestComplexMatrixContents
[x] TestFactorContents
[x] TestNumericVectorContents
[x] TestDynamicVectorContents
([] TestIntegerVectorContents)
[x] TestLogicalVectorContents
[x] TestComplexVectorContents
[x] TestSymbolVectorContents
[x] TestSymbolContents = TestFunctionContents
[] TestS4ClassContents
[] TestEnvironmentContents

[] Investigate Graphics stuff

## 17/09/2023
[OK] Issue with dates: as.date('...') => need to handle dates:
	Summary: Date type and format
	GetContentsAsString: returns a string array of formatted dates
	GetContentsAsObject: returns a string array of formatted dates

[OK] Note that single values are added to the summary without type and indexes; add test
[OK] Add tests for GetContentsAsObject/GetContentsAsString
[OK] Add support for creating a data frame from a table.
[OK] Replace Assert.IsTrue with Assert.AreEqual - the reported error is more detailed and informative.

## 18/09/2023
[OK] Add enumerated type for R types used in Excel - currently the enum is in the Excel-DNA layer. This is because the RTypes (as strings) include C# keywords (e.g. 'double'). This means that mapping from string (using Enum.TryParse()) doesn't work well. 
[OK] Add TypeInfo class to wrap up type and rclass...
[x] Add test case(s) for data frame creation to the spreadsheet

Core
[x] Unit Tests

RScriptAddIn
[x] R-Session.docx
[x] RScriptAddInTests.docx

ExcelRAddIn
[x] R Types Tests.xlsx			- Basic tests of R types in Excel
[x] ExcelR AddIn Tests.xlsx		- Tests of core R functionality in Excel
[x] Excel Data Analysis.xlsx	- Tests of data analysis and modelling functions in Excel

## 20/09/2023 - 21/09/2023
[OK] Add extra parameters to Evaluate function: - results -> summary or full or suppress (returns OK or FAILED)
[OK] Merge the RScriptAddIn project with the ExcelRAddIn in a single solution: 
		
## 22/09/2023

[OK] Add Readme.md to the project

## 01/10/2023
[] Issue with CreateComplexMatrix(matrix).
// NOTE The call to the base ctor is specified incorrectly
// line 111, C:\Users\adam_\AppData\Local\Temp\MetadataAsSource\2b4382f34fb14c828e29b569c0d4a54c\DecompilationMetadataAsSourceFileProvider\92e76432b2af44f6881f0596eb34e6c8\ComplexMatrix.cs
// SymbolicExpressionType.CharacterVector  <-- should be ComplexVector

[] In Repro, add a test function (to be referenced on github) to illustrate the issue
	CreateComplexVectorIssue()
Note: this doesn't work in exactly the same way as the issue we see since we cast the symbolic expression to a ComplexMatrix in the GetSummary function
[] Submit a bug report to R.NET: check through the 93 issues first.
[] Add REngineExtensionTest.cs to RDotNet.Tests
	CreateCharacterVector(this REngine engine, int length)
	CreateComplexVector(this REngine engine, int length)
	CreateIntegerVector(this REngine engine, int length)
	CreateLogicalVector(this REngine engine, int length)
	CreateNumericVector(this REngine engine, int length)
	CreateRawVector(this REngine engine, int length)
	CreateCharacterVector(this REngine engine, IEnumerable<string> vector)
	CreateComplexVector(this REngine engine, IEnumerable<Complex> vector)
	CreateIntegerVector(this REngine engine, IEnumerable<int> vector)
	CreateLogicalVector(this REngine engine, IEnumerable<bool> vector)
	CreateNumericVector(this REngine engine, IEnumerable<double> vector)
	CreateRawVector(this REngine engine, IEnumerable<byte> vector)
	CreateCharacter(this REngine engine, string value)
	CreateComplex(this REngine engine, Complex value)
	CreateLogical(this REngine engine, bool value)
	CreateNumeric(this REngine engine, double value)
	CreateInteger(this REngine engine, int value)
	CreateRaw(this REngine engine, byte value)
	CreateCharacterMatrix(this REngine engine, int rowCount, int columnCount)
	CreateComplexMatrix(this REngine engine, int rowCount, int columnCount)
	CreateIntegerMatrix(this REngine engine, int rowCount, int columnCount)
	CreateLogicalMatrix(this REngine engine, int rowCount, int columnCount)
	CreateNumericMatrix(this REngine engine, int rowCount, int columnCount)
	CreateRawMatrix(this REngine engine, int rowCount, int columnCount)
	CreateCharacterMatrix(this REngine engine, string[,] matrix)
	CreateComplexMatrix(this REngine engine, Complex[,] matrix)		<-- BUG
	CreateIntegerMatrix(this REngine engine, int[,] matrix)
	CreateLogicalMatrix(this REngine engine, bool[,] matrix)
	CreateNumericMatrix(this REngine engine, double[,] matrix)
	CreateRawMatrix(this REngine engine, byte[,] matrix)
	CreateDataFrame

## 02/10/2023 - 05/10/2023
[OK] Add spreadsheet for PCA, LDA and forecasting: merge Discriminant Analysis.xlsx, Principal Component Analysis.xlsx and Time Series Forecasting.xlsx.
[OK] Create website based on Jekyll theme: https://www.youtube.com/watch?v=qZsgPgGdOzQ&t=994s
[OK] Add 'post' to blog articles
[OK] Make the Office365 AddIns repository public and update references
[OK] Add links to r-bloggers and update category in posts (this is for rss feeds)
[OK] Link the posts to RBloggers


## 26/03/2024
- implement simple moving average (from the Forecast package).
NOTE: since you know what APIs you are wrapping, and hence what their library/package dependencies are, you may as well use the model (ma, lm) to lookup some (static) model details, and use this information to 'bootstrap' the API calls.
e.g. =LinearModelling.LM(...) - load tidyverse, MASS, ...

## 28/03/2024
- added provisional result set handling. This needs to be extended to coerce results into data frames by default (?)
- added ses. How do you handle 'null' double values from Excel/Excel-DNA? => if they are not supplied then they are passed in as 0. e.g. alpha = 0.0 does not produce the same results as omitting alpha. Detect this (how?) and omit from the parameters passed in the script.
- when creating a vector/matrix can you detect automatically the correct R-type?

## 29/03/2024
- add function to determine RType when creating a vector, if none is provided. This can be extended to matrix creation and to data frame creation.

## 30/03/2024
- extend the handling of default vector, matrix and data frame creation.
- add support for holt, and hw
- add in an accuracy measure that returns a df by default

## 31/03/2024
- add improved support for getting sub-keys from nested models: modelName$key1$key2, and optionally return as df.
Refactored classes into: Script (functions relating to RScript), Model (functions relating to the model: name, results, accuracy) and Forecast functions (SMA, SES, HOLT, HW).

## 02/04/2024
- add support for building parameter list from an input 2D object array. This simplifies the handling of optional parameters (but has the disadvantage that parameter names are not documented as part of the API).

## 03/04/2024
- add support for improved handling of model parameters to new models

Forecast and Arima functions
- need to be able to create a list? to handle seasonal: e.g. seasonal=list(order=c(0,1,1),period=12)
- need to be able to handle order=c(0,1,1)

For the above cases we handle passing a vector using c(...); and for a script use ^.

## 06/04/2024
- add support for lm and results

## 12/04/2024
- add generic function to retrieve parameter information
- add generic function evaluation with retrieved parameters

## 16/04/2024
- add support for glm (logistic regression) and results
The following can be handled via the generic function interface:
	- window function
	- diff function
	- frequency function => handle time series objects and dates better
- How to handle the 'seasonal' specification ==> this is handled as a script(let)?

## 23/04/2024
- Updated the panel to use WPF controls instead of Windows Forms
NOTE: the settings dialog box still requires a windows form. This is not a WPF project, so the only solution here would be to create another WPF user control (containing text boxes for home and path and button handling logic, and okay and cancel buttons).
- Added key 'packages' to the app.config. This is a  list of default libraries to load

## 24/04/2024
- move the loading of default packages into a separate function; check the reporting is consistent.
- add support for managing the package list via the settings dialog box (display, add and remove, + icon)
- check that loading and saving of default packages works; disable the remove button if the list is empty
- ensure that after remove, a single item is selected if any and the text box is updated
- check that the package list works for both add-ins
- add the icon to the package item

## 25/04/2024
- Updated the REnvironmentPanel (a WPF user control) to properly use binding for both the messages list and the environment list. Refactored the code to incorporate a proper MVVM organisation.

## 27/07/2024
- Updated the REnvironmentPanel Messages list view to include a header.

## 31/07/2024
- Added 'Create Plot' helper function to produce ggplot script for visualisations.
- consider how to handle multiple 'geoms' ?

## 17/08/2024
- added AestheticSettings property class and added it to data property grid

## 19/08/2024
- Added support for FormAestheticSettings as a separate property grid.
- Added support for multiple geoms

## 20/08/2024
- added support for bool to (unquoted) TRUE/FALSE values
- corrected issue with adding sub-item text in geoms list view
- check class hierarchy
- added support for: 
	geom_abline
	geom_hline : yintercept
	geom_vline : xintercept
- added support for boxplot: 
	notch = T/F, varwidth = T/F, outliers = T/F
	How to handle outlier specification? (outlier colour/fill/shape/size/stroke/alpha)
- added support for dotplot

Testing
- Created a new workbook: GGPlot Tests.xlsx. Add a separate worksheet for each geom type.
Datasets: AirPassengers, diamonds, mpg, mtcars

## 21/08/2024
- check how 'stat_' functions work: not currently supported by this script generator.
- added to aes: xmin, xmax, ymin, ymax, xend, yend. https://ggplot2.tidyverse.org/reference/aes_position.html
- added support for coords
- added support for scales, separated both x and y scales: https://ggplot2.tidyverse.org/reference/scale_continuous.html
- added two 'scales' panels: x and y scales
- added support for some themes attributes

## 22/08/2024
- added support for Facets

## 26/08/2024
- updated AestheticSettings with additional attributes

## 27/08/2024
- removed: 'mapping = ', ('data = ', ?)
- move the linetype, width etc settings into a basic settings.
- Redo 'BasicSettings' class as a separate (serialisable) class.
- allowed AestheticSettings to inherit from this.

## 14/11/2024
[x] Updated RibbonController.cs - new Office 365 icons
[x] Updated TaskPaneManager.cs - check show hide functionality
[x] REnvironmentControlLibrary: updated the icons (assets) and the environment.cs
[x] REnvironmentControlLibrary: updated the REnvironmentPanel.xaml - list view background
[x] Code cleanup - remove unnecessary usings and go through error list

## 01/08/2025
[x] Update and restructure the documents and project notes


