# Logistic Regression

library(tidyverse)
library(forecast)
library(mlogit)

data <- read.csv("purchases.csv") 

table(data$Purchase)

data$Purchase<-as.factor(data$Purchase)

Pchsdata<-mlogit.data(data, choice="Purchase", shape="wide")

mlogit.model<-mlogit(Purchase~1|Income+Age+ZipCode,data=Pchsdata,reflevel="1") 

summary(mlogit.model)

logit_model = glm(Purchase~Income+Age+ZipCode, family=binomial(link='logit'), data = data)

summary(logit_model)

anova(logit_model)
