import yfinance as yf
import pandas as pd

# Lista de tickers (puedes ajustar o agregar más)
tickers = ['AAPL', 'GOOGL', 'AMZN', 'MSFT', 'TSLA', 'META', 'NVDA', 'PYPL', 'ADBE', 'INTC']

# Fechas de inicio y fin (ajusta según necesites)
start_date = "2020-01-01"
end_date = "2022-01-01"

# Descargar los datos de cada empresa y guardarlos en archivos separados
for ticker in tickers:
    # Descarga los datos históricos
    data = yf.download(ticker, start=start_date, end=end_date, multi_level_index=False, group_by='ticker')
    #Agrega columna ticker y fecha
    data['Ticker'] = ticker
    data['Date'] = data.index

    print(f"\nDescargando datos de {ticker}...")
    #print(data.head())

    if data.empty:
        print(f"No se encontraron datos para {ticker}.")
        continue

    #print(f"Columnas para {ticker}: {data.columns}")

    # Seleccionar las columnas necesarias
    value_vars = ['Open', 'High', 'Low', 'Close', 'Volume']
    data_selected = data[['Date', 'Ticker'] + value_vars[0:]]

    excel_file = f".\\DatosHistoricos\\{ticker}_datos.xlsx"
    data_selected.to_excel(excel_file, index=False)

print(f"\nDatos guardados con exito!\n")