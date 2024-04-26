# Arima

library(tidyverse)
library(fpp2)     # loads 'forecast'
library(ggplot2)

WWWusage %>% Arima(order=c(3,1,0)) %>% forecast(h=20) %>% autoplot

fit <- ets(window(WWWusage, end=60))
fit
fc <- forecast(WWWusage, model=fit)
fc















# Fit model to first few years of AirPassengers data

#air.model <- Arima(window(AirPassengers,end=1956+11/12),order=c(0,1,1),
#                   seasonal=list(order=c(0,1,1),period=12),lambda=0)

air.model <- Arima(AirPassengers,order=c(0,1,1),lambda=0)
air.model

fc = forecast(object = air.model, h=48)
plot(fc)
lines(AirPassengers)
fc


# Apply fitted model to later data
air.model2 <- Arima(window(AirPassengers,start=1957),model=air.model)
# Forecast accuracy measures on the log scale.
# in-sample one-step forecasts.
accuracy(air.model)
# out-of-sample one-step forecasts.
accuracy(air.model2)
# out-of-sample multi-step forecasts
accuracy(forecast(air.model,h=48,lambda=NULL),
         log(window(AirPassengers,start=1957)))
