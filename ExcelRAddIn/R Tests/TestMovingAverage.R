library(tidyverse)
library(fpp2) 
library(dplyr)
library(zoo)
library(plotrix)

#create data frame
df <- data.frame(day=c(1:27),
                 sales=c(855.0, 847.0, 1000.0, 
                         635.0, 346.0, 2146.0, 
                         1328.0, 1322.0, 3124.0, 
                         1012.0, 1280.0, 2435.0, 
                         1016.0, 3465.0, 1107.0, 
                         1172.0, 3432.0, 836.0, 
                         142.0, 345.0, 2603.0, 
                         739.0, 716.0, 880.0, 
                         1008.0, 112.0, 361.0 ))

#view data frame
df

#calculate 3-day rolling average
df = df %>%
  mutate(ma3 = rollmean(sales, k=3, fill=NA, align='right'))

df

se <- function(x) sd(x)/sqrt(length(x))

se(df$ma3[3:27])
std.error(df$ma3[3:27])

plot(df$sales)
df$ma3b = ma(df$sales, order=3, centre = FALSE)
#ma(df$sales, order=3, centre = FALSE)
plot(df$ma3b)
lines(df$ma3b,col="red")

summary(df$ma3b)
names(summary(df$ma3b))
s = summary(df$ma3b)
dfresult = as.data.frame.numeric(summary(df$ma3b))
dfresult
