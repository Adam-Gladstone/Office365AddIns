################################################################################
## https://cran.r-project.org/web/packages/reticulate/vignettes/calling_python.html
##
## Calling Python from R
##
################################################################################

library(reticulate)
library(rjson)

PythonPath = "C:/Users/adam_/AppData/Local/Programs/Python/Python314"
use_python(PythonPath)

os <- import("os")
os$listdir(".")

yf <- import("yfinance")

## PythonScript = "D:/Development/Projects/C#/Office/Office365 AddIns/ExcelRAddIn/Python Scripts/key_indicators.py" 
## PythonScript = "D:/Development/Projects/C#/Office/Office365 AddIns/ExcelRAddIn/Python Scripts/equity_financials_alt.py" 
PythonScript = "D:/Development/Projects/Office/Publish/ExcelRAddInTests/Scripts/ticker_data.py"

# source_python(PythonScript, parent.frame(), FALSE)
source_python(PythonScript)

san_ki = get_key_indicators('SAN.MC')
bbva_ki = get_key_indicators('BBVA.MC')

tickers = c('SAN.MC', 'BBVA.MC', 'REP.MC', 'MAP.MC', 'AENA.MC')
fields = c('exDividendDate', 'dividendRate')


## get_all_indicators(tickers)

# THIS IS A PANDAS OBJECT
obj = get_ticker_data(tickers, fields)
obj
class(obj)
typeof(obj)

names(obj)

# THESE ARE PANDAS SERIES
obj$Ticker
obj$exDividendDate
obj$dividendRate

json_obj = obj$to_json(orient='records')
res = do.call(rbind.data.frame,lapply(fromJSON(json_obj), as.data.frame))
class(res)
res

obj$transpose()

env_obj = as.environment(obj)
env_obj

robj = py_to_r(obj)
as.data.frame(robj)
class(robj)
typeof(robj)
robj$transpose()


# Test
friend.data <- data.frame(
  friend_id = c(1:5), 
  friend_name = c("Sachin", "Sourav", 
                  "Dravid", "Sehwag", 
                  "Dhoni"),
  stringsAsFactors = FALSE
)
class(friend.data)

# Test
# check out reticulate v1.35.0
devtools::load_all(".")

df <- data.frame(
  row.names = c("s1", "s2"),
  group = c("a", "b")
)
py_to_r(r_to_py(df))
#    group
# s1     a
# s2     b

library(anndata)

py_to_r(r_to_py(df)) # works as intended
#    group
# s1     a
# s2     b


pd <- import("pandas")
df <- pd$DataFrame(data = list(a = 1:5, b = letters[1:5]))
print(df)
r_df <- py_to_r(df)
print(r_df)


