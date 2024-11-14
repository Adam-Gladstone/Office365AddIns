# -*- coding: utf-8 -*-

"""
equity_financials_alt.py

Alternative approach to retrieving key indicators for stocks.
This script is run from the ExcelRAddIn (using Reticulate) and therefore
returns the indicators directly in Excel (no need to post-process a csv file).

Trailing PE < 25                    trailingPE
Forward PE < 15	                    forwardPE
* Debt /Equity < 35%	                debtToEquity -- not available
EPS Growth > 15%	                earningsGrowth
PEG Ratio < 1.2	                    pegRatio
Market Cap < $5bn (convert to €)    marketCap

"""
# Static Checking Tools
# -----------------------------------------------------
# flake8               Ok
# mypy                 Ok
# black                Ok
# -----------------------------------------------------

import pandas as pd
import yfinance as yf


def get_value(info: dict, key: str) -> float:
    """Retrieve a value from the dictionary or 0 if it doesn't exist"""
    if key in info.keys():
        return info[key]
    return float(0.0)


def get_key_indicators(ticker: str) -> list:
    """Retrieve key indicators for ticker"""

    tk: dict = yf.Ticker(ticker)
    info: dict = tk.info

    # with open('./Ticker Info 31-10-2024.txt', 'w') as f:
    #     print(info, file=f)

    indicators: list = [
        ticker,
        get_value(info, "trailingPE"),
        get_value(info, "forwardPE"),
        get_value(info, "earningsGrowth"),
        get_value(info, "pegRatio"),
        get_value(info, "marketCap"),
    ]

    return indicators


def get_all_indicators(tickers: list) -> pd.DataFrame:
    """Retrieve all indicators as a data frame"""

    rows: list = []
    headers: list = [
        "ticker",
        "trailingPE",
        "forwardPE",
        "earningsGrowth",
        "pegRatio",
        "marketCap",
    ]

    for ticker in tickers:
        rows.append(get_key_indicators(ticker))

    df = pd.DataFrame(rows, columns=headers)
    return df


# tickers = ['SAN.MC', 'BBVA.MC', 'REP.MC', 'MAP.MC', 'AENA.MC']
# print(get_all_indicators(tickers))
