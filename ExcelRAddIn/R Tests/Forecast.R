# Forecast

library(tidyverse)
library(fpp2)     # loads 'forecast'

# WWWusage %>% forecast %>% plot

fit <- ets(WWWusage)
# fit <- ets(window(WWWusage, end=60))
fc <- forecast(WWWusage, model=fit)

autoplot(fit)

fit
accuracy(fit)
summary(fit)


fc <- forecast(WWWusage)
autoplot(fc)
fc
summary(fc)

ETS1 = ets(WWWusage, damped = TRUE, additive.only = FALSE, lambda = "auto", biasadj = FALSE, 
           opt.crit = "lik", nmse = 3, bounds = "both", ic = "aic", restrict = FALSE, 
           allow.multiplicative.trend = FALSE, use.initial.values = FALSE)
ETS1
