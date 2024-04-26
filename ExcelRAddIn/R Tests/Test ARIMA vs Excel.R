# Test ARIMA
library(tidyverse)
library(forecast)

path = "D:/Development/Projects/C#/Office/Office365 AddIns/ExcelRAddIn/R Tests/avg_hits.csv"

data <- read.csv(path)

hitsts<-ts(data)

# order=c(1,0,0)
arima_model_book = arima(x = hitsts, order=c(0,1,1), method=("CSS"))

arima_model_book

predict(arima_model_book,n.ahead=3)

# order=c(1,0,0)
arima_model = Arima(hitsts, order=c(1,0,0), method=("CSS"))

arima_model

summary(arima_model)

predict(arima_model,n.ahead=3)

arima_auto = auto.arima(hitsts)
arima_auto
