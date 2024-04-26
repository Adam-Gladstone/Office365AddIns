# https://stackoverflow.com/questions/11885207/get-all-parameters-as-list

library(tidyverse)
library(forecast)

library(pkgload)

Functions = names(pkg_env("forecast"))
as.data.frame(Functions)

args(forecast.ets)
l_args = as.list(args(forecast.ets))
l_args

# WWWusage
ets('WWWusage')


formals(forecast.ets)
f_args = as.pairlist(formals(forecast.ets))
f_args

v_args = as.vector(formals(forecast.ets), "pairlist")
v_args

u = unlist(formals(forecast.ets))
u

window

typeof(l_args$level)
class(l_args$level)


# load a package
# get a list of functions
# for each function get a list of args
# generate a CS stub of the form: public static object[,] ...


names(as.list(args(forecast.ets)))
names(as.list(args(window)))
names(as.list(args(frequency)))
names(as.list(args(lm)))
names(as.list(args(hw)))
names(as.list(args(ma)))
