Homer Imovel Viewer
===================

Esse projeto é um exemplo de uma Aplicação formada por Fronend Mobile e Backend API
		
	- FRONTEND: foi desenvolvido todo em usando linguagem Kotlin e usando IDE IntelliJ IDEA Community Edition

		* Usando acesso a API através RESTFull client HTTP Retrofit e OkHttp ambos da SquareUp
		* Unsado também a lib Material Design para android
		
	- BACKEND: responsável por fornecer API que alimenta o front. Foi desenvolvido em DotNet Core 5.0
	
		* Utilizada IDE Visual Studio 2019 Community
		* Arquitura uma simples DDD (Domain Driven Design) para persistir os dados. 
		* Banco de dados utilizado é o MySQL;
	
Obs.
===
	* Para rodar:
		- Altere no Backend a connectionString do arquivo appsettings.json de acordo com suas configurações;
		- Altere no Frontend no arquivo RestUtils.kt a constante "apiUrl" de acordo com a sua necessidade;
		- Criar o banco de dados com base no script mencionado aqui;

		
Script do Banco de Dados MySQL
==============================

	* No arquivo "homerdb.sql" tem os script para criar e insert´s para dados fictícios nas tabelas
	* Na connectionString da API (backend) precisa informar o usuário e senha de conexão com o banco de dados mysql
	
	* Se preferir também pode ser utilizado o "MariaDB" como motor de banco de dados que também funciona;



