# Issues

## AddIn

## Lib

## Control

## Tests

# Wishlist
Provide a set of useful wrapper functions around the "Forecast" package (https://cran.r-project.org/web/packages/forecast/forecast.pdf) functions.
Provide a wrapper API around the 'lm' (and 'glm') function.

TO DO:
- Consider adding some notion of package or library/package: this would allow you to simply call a function via a wrapper and have the wrapper determine if a call to 'library(package)' is required. The package class could determine what the default model results should be (assuming you have a model)?

ggplot2
- Investigate inserting a plot directly into Excel rather than via the clipboard.
- additional testing
- add support for more geoms
- consider adding a simplified 'wizard' interface.

Messages in the REnvironmentPanel:
- add support for copying and viewing long messages in a message box ? or a tooltip?
- add support for clearing messages
- add up/down control to the list of geoms ==> in progress
- Add support for 'annotate': https://ggplot2.tidyverse.org/reference/annotate.html

Speculative:
- Generate the C# code from R.


# Changes
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
- Updated RibbonController.cs - new Office 365 icons
- Updated TaskPaneManager.cs - check show hide functionality
- REnvironmentControlLibrary: updated the icons (assets) and the environment.cs
- REnvironmentControlLibrary: updated the REnvironmentPanel.xaml - list view background

