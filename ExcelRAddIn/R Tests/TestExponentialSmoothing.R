# Exponential Smoothing

# SES in R
# loading the required packages
library(tidyverse)
library(fpp2) 

# create training and validation 
# of the Google stock data
goog.train <- window(goog, end = 900)
goog.test <- window(goog, start = 901)
goog

# removing the trend
goog.dif <- diff(goog.train)
autoplot(goog.dif)
goog.dif

# reapplying SES on the filtered data
ses.goog.dif <- ses(goog.dif,
                    alpha = .2, 
                    h = 100)
autoplot(ses.goog.dif)

# 
gallons = c(113, 50, 67, 98, 160, 112, 14, 10, 63, 33, 99, 109, 140, 51, 200, 178, 138, 134, 165, 132, 142)
gallons = as.ts(gallons)

autoplot(gallons)

# gallons <- diff(gallons)
# autoplot(gallons)

ses.gallons = ses(gallons, initial = 'simple', alpha = 0.0, h = 2)
autoplot(ses.gallons)
ses.gallons


sales = c(3,5,9,20,12,17,22,23,51,41,56,75,60,75,88)
sales = as.ts(sales)
autoplot(sales)

# sales <- diff(sales, differences = 2)
# sales
# autoplot(sales)

ses.sales = ses(sales, initial = 'simple', alpha = 0.4, h = 5)
summary(ses.sales)
autoplot(ses.sales)
ses.sales

customers = c(802.89, 975.20, 894.33, 821.13, 844.40, 891.14, 932.95, 884.53, 1190.78, 1178.55, 1327.99, 1793.10, 2277.52, 2061.47, 2510.57, 2679.46, 2928.95, 3284.12, 3524.85, 3797.93, 4494.27, 5741.95, 6449.15, 7638.72, 7473.46, 7731.15, 7608.86, 8214.85, 8006.64, 8315.51, 8546.66, 9408.75, 9178.26)
customers = as.ts(customers)
autoplot(customers)

# customers <- diff(customers, differences = 1)
# customers
# autoplot(customers)

des.customers = holt(customers, initial = 'simple', alpha = 0.95, beta = 0.21)
summary(des.customers)
autoplot(des.customers)
des.customers

autoplot(airmiles)
fcast <- holt(airmiles)
summary(fcast)


df <- read.csv('Data/candy_production.csv', header=TRUE)
head(df)

WWWusage %>% forecast %>% plot
fit <- ets(window(WWWusage, end=60))
fc <- forecast(WWWusage, model=fit)



