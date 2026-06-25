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

## Test Files
Review all test files:
- D:\Development\Projects\C#\Office\Office365 AddIns\ExcelRAddIn\Tests
- D:\Development\Projects\C#\Office\Office365 AddIns\RScriptAddIn\Tests

Organise and structure; clean up etc. Decide which are just for local testing and which are worth publishing and for reference.
Check in to a releaseable directory eg. 
	D:\Office365\Publish\ExcelRAddInTests
	D:\Office365\Publish\RSCriptAddInTests

Information about redistributing a VSTO
https://learn.microsoft.com/en-us/visualstudio/vsto/deploying-a-vsto-solution-by-using-windows-installer?view=vs-2022&source=recommendations

https://learn.microsoft.com/en-us/visualstudio/vsto/deploying-an-office-solution-by-using-clickonce?view=vs-2022&tabs=csharp
	Decide how you want to grant trust to the solution 
		--> Grant trust to Office solutions (https://learn.microsoft.com/en-us/visualstudio/vsto/granting-trust-to-office-solutions?view=vs-2022#Signing)
			--> Trust the solution by signing the application and deployment manifests

		All application and deployment manifests for Office solutions must be signed with a certificate that identifies the publisher. Certificates provide a basis for making trust decisions.
		A *temporary* certificate is created for you and granted trust at build time so the solution will run while you debug it. 
		If you publish a solution that is signed with a temporary certificate, the end user will be prompted to make a trust decision.

		If you sign the solution with a known and trusted certificate, the solution will automatically be installed without prompting the end user to make a trust decision. 
		- For more information about how to obtain a certificate for signing, see ClickOnce and Authenticode. After a certificate is obtained, the certificate must be explicitly trusted by adding it to the Trusted Publishers list. 
		- For more information, see How to: Add a trusted publisher to a client computer for ClickOnce applications.

		--> https://learn.microsoft.com/en-us/visualstudio/ide/how-to-sign-application-and-deployment-manifests?view=vs-2022
		Sign application and deployment manifests














