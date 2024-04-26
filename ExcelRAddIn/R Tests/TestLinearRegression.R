#
# Linear Regression
# file:///D:/TEMP/Books/Mathematics%20&%20Statistics/Linear%20Models%20With%20R%20-%20Faraway.pdf
# pp34ff
#

library(tidyverse)
library(faraway)

# Galapagos Dataset
# View(gala)
# write.csv(gala, file='D:/Development/Projects/C#/Office/PredictiveAnalytics/Data/GalapagosData.csv')

# Model
mdl <- lm (Species ~ Area + Elevation + Nearest + Scruz + Adjacent, data=gala)
mdl
summary(mdl)

summary(mdl$model)

anova(mdl)
aov(mdl)



# X and y
x <- model.matrix (~ Area + Elevation + Nearest + Scruz + Adjacent, gala)
y <- gala$Species

# t() does transpose and %*% does matrix multiplication. 
# solve(A) computes inverse A, while solve(A, b) solves Ax=b
xtxi <- solve(t(x) %*% x) # inverse(XTX)

# Coefficient estimates (B-hat) using inverse(XTX)XTy
xtxi %*% t(x) %*% y


solve(crossprod(x, x), crossprod(x, y))

# Get names from the model
names(mdl)

# Get names from the model summary
mdls <- summary(mdl)
names(mdls)






