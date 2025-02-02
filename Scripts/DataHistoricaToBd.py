import pyodbc
import pandas as pd
import os

# Configuración de la conexión a la base de datos
server = 'MATHI\SQLEXPRESS'
database = 'FinancialData'
username = 'sa'
password = '1314'
connection_string = f'DRIVER={{SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

# Conectar a la base de datos
conn = pyodbc.connect(connection_string)
cursor = conn.cursor()
conn.commit()

# Ruta de los archivos Excel
excel_dir = ".\\DatosHistoricos"

# Leer y cargar cada archivo Excel a la base de datos
for file in os.listdir(excel_dir):
    if file.endswith(".xlsx"):
        file_path = os.path.join(excel_dir, file)
        data = pd.read_excel(file_path)

        for index, row in data.iterrows():
            # Obtener CompanyId basado en el Ticker
            cursor.execute("SELECT CompanyId FROM Companies WHERE Ticker = ?", row['Ticker'])
            company = cursor.fetchone()

            if company:
                company_id = company[0]
            else:
                # Insertar la empresa si no existe y obtener su nuevo CompanyId
                cursor.execute("INSERT INTO Companies (Ticker) OUTPUT INSERTED.CompanyId VALUES (?)", row['Ticker'])
                company_id = cursor.fetchone()[0]
                conn.commit()

            # Insertar los datos en StockPrices, manejando duplicados
            try:
                cursor.execute("""
                    INSERT INTO StockPrices (CompanyId, TradeDate, [Open], [High], [Low], [Close], AdjClose, Volume)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?)
                """, company_id, row['Date'], row['Open'], row['High'], row['Low'], row['Close'], row['Close'], row['Volume'])
                
                conn.commit()
            except pyodbc.IntegrityError:
                print(f"Registro duplicado para {row['Ticker']} en {row['Date']}, omitiendo...")

print(f"\nDatos cargados a la base de datos con éxito!\n")

# Cerrar la conexión
cursor.close()
conn.close()
