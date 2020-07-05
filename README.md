# <h1>SensorMusicTeste</h1>

#Projeto consiste no desenvolvimento de uma aplicação backend que tem por objetivo disponibilizar musicas para o usuario de acordo com a temperatura da cidade natal, aplicando-se algumas regras.


<h5>Instruções para rodar o projeto</h6>

#Para rodar o projeto é necessário ter uma instância do Microsoft SqlServer e rodar o Script que está no diretório SensorMusic.Infra.Data\ScriptCreateBD\scriptSensorMusic.sql dessa forma será criado a estrutura do banco de dados

#Após roda o script é necessário configurar a string de conexão no arquivo de settings SensorMusic.Service\appsettings.json

#Com a estrutura de banco de dados criado e configurado basta rodar o projeto em SensorMusic.Services e utilizar a interface do Swagger


<h5>#Definição dos Métodos da API</h5>

<h5>User</h5>
{Post}
User{/api/User} - endpont para criar o usuário no banco de dados sendo necessário informar as seguintes informações no json 
{
  "name": "string",
  "email": "string",
  "password": "string",
  "notes": [
    {
      "note": "string"
    }
  ],
  "homeTown": "string"
}
parameter: x-api-version: 1
parameter: api-version: 1

<h5>Definições dos parametros</h5>
 name: nome do usuário,
 email: email de autenticação,
 password: senha do usuário,
 notes: pode adicionar uma lista de anotações,
 homeTown: a cidade natal do usuário,
 x-api-version: versão da api,
 api-version: versão da api,


<h5>Auth</h5>
{Post}
Auth{/auth} - endpoint para geração do token do usuário para utilizar os recursos da api com base no json
{
  "user": "fulano@gxxx.com",
  "password": "XXXXX"
}

<h5>Atravês do token gerado é necessário fazer a autenticação clicando no botão Authorize e adicionando "Bearer {CONTEUDO DO TOKEN}" e  clicar no botão Authorize, após isso o token está em sua sessão para utilizar</h5>

<h5>Spotify</h5>
{Post}
Spotify{/api/Spotify} - endpoint que vai pegar o token e nele contem informações do usuário e retornar uma lista de musicas baseado na temperatura da cidade natal do usuário aplica-se a seguinte regra de generos.


<h5>UserPasswordRecovery</h5>
{Post}
UserPasswordRecovery{/api/UserPasswordRecovery/AddPasswordRecovery} - endpoint para geração de um hash que servirá para gerar uma nova senha
{
  "email": "fulano@gxxx.com"
}

{Post}
UserPasswordRecovery{/api/UserPasswordRecovery/Reset} - endpoint para redefinição de senha
{
  "hash": "45646456464564"
  "newPassword": "1231231231"
}

<h3>Ferramentas, Conceitos e Tecnologias utilizadas<h3>
#Log de Requisições
#Dapper
#DDD
#JWT
#SQLServer
#Docker (está configurado o arquivo do docker)
#Consumo de API terceiros
#Swagger e Versionamento







