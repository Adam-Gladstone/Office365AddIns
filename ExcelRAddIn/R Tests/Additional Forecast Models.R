# Forecast

library(tidyverse)
library(fpp2)     # loads 'forecast'

plot(wineind)
sm <- ma(wineind,order=12)
lines(sm,col="red")
sm

nile.fcast <- meanf(Nile, h=10)
nile.fcast
plot(nile.fcast)

gold.fcast <- rwf(gold[1:60], h=50)
gold.fcast
plot(gold.fcast)
plot(naive(gold,h=50),include=200)
plot(snaive(wineind))

fcast <- splinef(uspop,h=5)
fcast
plot(fcast)
summary(fcast)

nile.fcast <- thetaf(Nile)
nile.fcast
plot(nile.fcast)

y <- rpois(20,lambda=.3)
fcast <- croston(y)
plot(fcast)

frequency(austourists)

m1 = hw(austourists, h=10)
m1

austourists


