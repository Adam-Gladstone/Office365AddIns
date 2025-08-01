"""
portfolio_analysis.py

"""

import warnings

# Pandas & NumPy
import pandas as pd
import numpy as np

# Yfinance to retrieve financial data
import yfinance as yf

warnings.filterwarnings("ignore")


def benchmark_returns(benchmark: str, start_date: str, end_date: str) -> dict:

    # Obtain benchmark data with yfinance
    benchmark_df = yf.download(benchmark, start=start_date, end=end_date)

    # Obtain 'Adjusted Close'. If not available, use 'Close'.
    benchmark_df = benchmark_df["Adj Close"].fillna(benchmark_df["Close"])

    # Computing benchmark returns
    benchmark_returns = benchmark_df.pct_change()

    results = {"benchmark returns": benchmark_returns}

    return results


def portfolio_returns(
        ticker_values: dict, start_date: str, end_date: str
) -> dict:

    # Obtaining tickers data with yfinance
    df: pd.DataFrame = yf.download(
        tickers=list(ticker_values.keys()), start=start_date, end=end_date
    )

    # Checking if there is data available in the given date range
    if isinstance(df.columns, pd.MultiIndex):
        missing_data_tickers = []
        for ticker in ticker_values.keys():
            first_valid_index = df["Adj Close"][ticker].first_valid_index()
            if (
                first_valid_index is None
                or first_valid_index.strftime("%Y-%m-%d") > start_date
            ):
                missing_data_tickers.append(ticker)

        if missing_data_tickers:
            raise ValueError(
                f"No data available for the following tickers starting from {start_date}: {', '.join(missing_data_tickers)}"
            )
            return
    else:
        # For a single ticker, simply check the first valid index
        first_valid_index = df["Adj Close"].first_valid_index()
        if (
            first_valid_index is None
            or first_valid_index.strftime("%Y-%m-%d") > start_date
        ):
            raise ValueError(
                f"No data available for the ticker starting from {start_date}"
            )
            return

    # Calculating portfolio value
    total_portfolio_value = sum(ticker_values.values())

    # Calculating the weights for each security in the portfolio
    ticker_weights = {
        ticker: value / total_portfolio_value for ticker,
        value in ticker_values.items()
    }

    # Checking if dataframe has MultiIndex columns
    if isinstance(df.columns, pd.MultiIndex):
        df = df["Adj Close"].fillna(
            df["Close"]
        )  # If 'Adjusted Close' is not available, use 'Close'

    # Checking if there are more than just one security in the portfolio
    if len(ticker_weights) > 1:
        weights = list(ticker_weights.values())  # Obtaining weights
        weighted_returns = df.pct_change().mul(
            weights, axis=1
        )  # Computed weighted returns
        port_returns = weighted_returns.sum(
            axis=1
        )  # Sum weighted returns to build portfolio returns
    # If there is only one security in the portfolio...
    else:
        df = df["Adj Close"].fillna(
            df["Close"]
        )  # Obtaining 'Adjusted Close'. If not available, use 'Close'
        port_returns = df.pct_change()  # Computing returns without weights

    results = {
        "weights": ticker_weights, 
        "data": df, 
        "portfolio returns": port_returns
        }

    return results


def portfolio_vs_benchmark(
    port_returns: pd.Series, benchmark_returns: pd.Series, risk_free_rate: float
) -> dict:
    """
    This function calculates and displays the cumulative returns, annualized volatility, and Sharpe Ratios
    for both the portfolio and the benchmark. It provides a side-by-side comparison to assess the portfolio's
    performance relative to the benchmark.

    Parameters:
    - port_returns (pd.Series): A Pandas Series containing the daily returns of the portfolio.
    - benchmark_returns (pd.Series): A Pandas Series containing the daily returns of the benchmark.

    Returns:
    """

    # Computing the cumulative returns for the portfolio and the benchmark
    portfolio_cumsum = (((1 + port_returns).cumprod() - 1) * 100).round(2)
    benchmark_cumsum = (((1 + benchmark_returns).cumprod() - 1) * 100).round(2)

    # Computing the annualized volatility for the portfolio and the benchmark
    port_vol = ((port_returns.std() * np.sqrt(252)) * 100).round(2)
    benchmark_vol = ((benchmark_returns.std() * np.sqrt(252)) * 100).round(2)

    # Computing Sharpe Ratio for the portfolio and the benchmark
    excess_port_returns = port_returns - risk_free_rate / 252
    port_sharpe = (
        excess_port_returns.mean() / port_returns.std() * np.sqrt(252)
    ).round(2)
    excess_benchmark_returns = benchmark_returns - risk_free_rate / 252
    benchmark_sharpe = (
        excess_benchmark_returns.mean() / benchmark_returns.std() * np.sqrt(252)
    ).round(2)

    results = {
        "portfolio cumulative returns": portfolio_cumsum,
        "benchmark cumulative returns": benchmark_cumsum,
        "portfolio volatility": port_vol,
        "benchmark volatility": benchmark_vol,
        "excess portfolio returns": excess_port_returns,
        "portfolio sharpe ratio": port_sharpe,
        "excess benchmark returns": excess_benchmark_returns,
        "benchmark sharpe ratio": benchmark_sharpe,
    }

    return results


def perform_portfolio_analysis(
    df: pd.DataFrame, ticker_weights: dict, risk_free_rate: float
) -> dict:
    """
    This function takes historical stock data and the weights of the securities in the portfolio,
    It calculates individual security returns, cumulative returns, volatility, and Sharpe Ratios.

    Parameters:
    - df (pd.DataFrame): DataFrame containing historical stock data with securities as columns.
    - tickers_weights (dict): A dictionary where keys are ticker symbols (str) and values are their
        respective weights (float)in the portfolio.

    Returns:

    Notes:
    """

    # Starting DataFrame and Series
    individual_cumsum = pd.DataFrame()
    individual_vol = pd.Series(dtype=float)
    individual_sharpe = pd.Series(dtype=float)
    individual_cumprod = pd.Series(dtype=float)

    # Iterating through tickers and weights in the tickers_weights dictionary
    for ticker, weight in ticker_weights.items():
        if ticker in df.columns:  # Confirming that the tickers are available
            individual_returns = df[
                ticker
            ].pct_change()  # Computing individual daily returns for each ticker
            
            individual_cumsum[ticker] = (
                (1 + individual_returns).cumprod() - 1
            ) * 100  # Computing cumulative returns over the period for each ticker
            
            vol = (
                individual_returns.std() * np.sqrt(252)
            ) * 100  # Computing annualized volatility
            individual_vol[ticker] = vol  # Adding annualized volatility for each ticker
            individual_excess_returns = (
                individual_returns - risk_free_rate / 252
            )  # Computing the excess returns
            sharpe = (
                individual_excess_returns.mean()
                / individual_returns.std()
                * np.sqrt(252)
            ).round(
                2
            )  # Computing Sharpe Ratio
            individual_sharpe[ticker] = sharpe  # Adding Sharpe Ratio for each ticker

    results = {
        "individual cumulative returns": individual_cumsum,
        "individual volatility": individual_vol,
        "individual Sharpe ratio": individual_sharpe,
    }

    return results


"""
tickers = {
    'SAN.MC' : (780 * 4.3015),
    'BBVA.MC' : (326 * 8.8260),
    'MAP.MC' : (1521 * 2.4420),
    'REP.MC' : (230 * 11.7300),
    'AENA.MC' : (17 * 203.2000)
}

portfolio_results = portfolio_returns(tickers, '2019-11-28', '2024-11-28')
benchmark_results = benchmark_returns('^IBEX', '2019-11-28', '2024-11-28')

port_returns = portfolio_results['portfolio returns']
benchmark_returns = benchmark_results['benchmark returns']

comparative_results = portfolio_vs_benchmark(port_returns, benchmark_returns, 0.01)
print(comparative_results)

df = portfolio_results['data']
ticker_weights = portfolio_results['weights']
analysis_results = perform_portfolio_analysis(df, ticker_weights, 0.01)
print(analysis_results)
"""
