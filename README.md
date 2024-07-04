# Teste Técnico ASP.NET

Para executar o Projeto você precisa seguir os seguintes passos:

1. Execute o script que fica em ```CRUD.Data/scripts/script.sql``` no banco de dados do SQL Server
2. Alterar a connectionString no arquivo ```CRUD.Clube/Web.config```. Basta alterar os valores em ```???```
```
	<connectionStrings>
		<add name="connDBATLETA" connectionString="User ID=???; Password=???; Server=???; Database=DBCLUBE;" providerName="System.Data.SqlClient"/>
	</connectionStrings>
```
3. Colocar como página principal ```Default.aspx``` no Visual Studio
4. Execute o sistema com o projeto ```CRUD.Clube``` como principal  no Visual Studio
