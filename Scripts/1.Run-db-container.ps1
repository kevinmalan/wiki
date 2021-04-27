$Password = 'DevDbP@ssword'

docker run `
--name "wiki-db-container" `
-e "ACCEPT_EULA=Y" `
-e "SA_PASSWORD=$Password" `
-p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu