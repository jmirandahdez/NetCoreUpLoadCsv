# NetCore 2.0 Upoload Csv to database Sqlserver

El siguiente proyecyo esta desarrollador en NetCore 2.0 y tiene como funcionalidad exponer un Api que recibe un archivo CSV y lo carga en la BD por primera vez, respetando catalogos y tabla transaccional.

## Bd SqlServer 2017 con Docker.
Para la generación de la bd despues de instalar [Docker](https://docs.docker.com/install/)  ejecutar:

`docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Admin/1234' -p 1433:1433 -d microsoft/mssql-server-linux:2017-latest`

Conectarse a la bd con las credenciales:
User: sa
Pwd: Admin/1234

Y generar una nueva base de datos llamada: SuperStore

## Instalar liquibase
Despues de instalar [Liquibase](http://download.liquibase.org/)

Colocarse dentro del directorio: liquibase y ejecutar el siguiente comando:

`liquibase --changeLogFile="changesets/db.changelog-master.xml" update`

## Aplicación NetCore
Compilar y ejecutar aplicación contenida en ManageSales, la cual expondra una api para cargar el archivo de la siguiente manera:

Post: http://localhost:5000/api/values
Key: upload
Value: File(archivo)
