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



