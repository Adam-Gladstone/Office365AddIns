################################################################################
## https://cran.r-project.org/web/packages/reticulate/vignettes/calling_python.html
##
## Calling Python from R
##
################################################################################

library(reticulate)

PythonPath = "C:/Users/adam_/AppData/Local/Programs/Python/Python312"
use_python(PythonPath)

os <- import("os")
os$listdir(".")

yf <- import("yfinance")

PythonScript = "D:/Development/Projects/C#/Office/Office365 AddIns/ExcelRAddIn/Python Scripts/key_indicators.py" 

source_python(PythonScript)

san_ki = get_key_indicators('SAN.MC')
bbva_ki = get_key_indicators('BBVA.MC')

tickers = c('SAN.MC', 'BBVA.MC', 'REP.MC', 'MAP.MC', 'AENA.MC')


get_all_indicators(tickers)


