# Office365 AddIns - Project Notes

## General
NOTE: The results handling still seems poor.
When you get back a model, you get back a large list (lm produces 10/11, one of the ARIMA models produces 19, glm produces 30 items etc): how can you present the data better? perhaps a more useful summary? The RScriptAddIn for Word simply unrolls all the list items. This is not really feasible in the 'tabular' world of Excel.
==> function mapping and some text file with placeholders (like the old ee.dat)
"lm" --> lm.txt
	Call
	Residuals
	Coefficients
	Summary

## Publishing

\ExcelRAddIn
\RScriptAddIn
	Key password: T3stKey12!

### 02/08/2025
- Release builds of both ExcelRAddIn and RSCriptAddIn
- 'Publish' RSCriptAddIn - this updates the VSTO distribution and manifest
- Check in changes

Download the master.zip file
Unpack the Publish to a known location: D:\Office365\...
	Publish
		ExcelRAddIn
		RSCriptAddIn

Check installation and tests

Review all test files:
- D:\Development\Projects\C#\Office\Office365 AddIns\ExcelRAddIn\Tests
- D:\Development\Projects\C#\Office\Office365 AddIns\RScriptAddIn\Tests

Organise and structure; clean up etc. Decide which are just for local testing and which are worth publishing and for reference.
Check in to a releaseable directory eg. 
	D:\Office365\Publish\ExcelRAddInTests
	D:\Office365\Publish\RSCriptAddInTests



Download the Office365AddIns-master.zip
Right-click and select Properties. Check Unblock. Click OK.
Find the Publish directory and copy the contents locally.
In the Publish directory there are two sub-directories:
	ExcelRAddIn
	RScriptAddIn
In the ExcelRAddIn, find the file: ExcelRAddIn-AddIn64.xll
Double-click to start Excel and install the add-in.
Ignore the Micorsoft Excel Security Notice: Select 'Enable this add-in for this session only'.
Excel starts and the add-in is loaded.
For ease-of-use in the future, go to File > Options. Select Trust Center, then Trusted Locations.
Add the Publish directory to the Trusted User Locations. Check the box 'Subfolders of this location are also trusted'.
Click OK, OK, OK to return to Excel.
Open a new blank workbook.
On the R AddIn menu, select Settings. Set the R Home and the R Path directories. Set up the packages to load (e.g. tidyverse, dplyr, forecast, ggplot2, ggthemes, and so on). Click OK.
In cell B2 enter:
	x <- rnorm(100)
In cell D2 enter:
	=RScript.Evaluate(b2)
The first evaluation will initialise the R environment and load any default libraries. Showing the Task Pane displays the initialisation sequence and highlights any problems. The variable 'x' and a summary of its contents should appear in the environment window.
TROUBLESHOOTING NOTE: recently the 'stats' library is not loaded when R is initialised. To workaround this, add the 'stats' library to the list of libraries loaded at startup; and/or evaluate the R script in cell B1:
	library(stats)
Use the following: =TRANSPOSE(RScript.Evaluate(B1))
If you want to suppress the output of the library load, add TRUE as the second parameter.
Re-evaluate the script in B2

























