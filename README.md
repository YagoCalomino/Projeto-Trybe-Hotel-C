# Trybe Hotel - Fase C

Boas-vindas ao repositório do projeto Trybe Hotel - Fase C

Para realizar o projeto, atente-se a cada passo descrito a seguir, e se tiver **qualquer dúvida**, nos envie no _Slack_ da turma! #vqv 🚀

Aqui, você vai encontrar os detalhes de como estruturar o desenvolvimento do seu projeto a partir desse repositório, utilizando uma branch específica e um _Pull Request_ para colocar seus códigos.

## Termos e acordos

Ao iniciar este projeto, você concorda com as diretrizes do [Código de Conduta e do Manual da Pessoa Estudante da Trybe](https://app.betrybe.com/learn/student-manual/codigo-de-conduta-da-pessoa-estudante).

## Entregáveis
---

<details>
<summary><strong>🤷🏽‍♀️ Como entregar</strong></summary>

Para entregar o seu projeto você deverá criar um _Pull Request_ neste repositório.

Lembre-se que você pode consultar nosso conteúdo sobre [Git & GitHub](https://app.betrybe.com/learn/course/5e938f69-6e32-43b3-9685-c936530fd326/module/fc998c60-386e-46bc-83ca-4269beb17e17/section/fe827a71-3222-4b4d-a66f-ed98e09961af/day/1a530297-e176-4c79-8ed9-291ae2950540/lesson/2b2edce7-9c49-4907-92a2-aa571f823b79) e nosso [Blog - Git & GitHub](https://blog.betrybe.com/tecnologia/git-e-github/) sempre que precisar!

</details>
  
<details>
<summary><strong>🧑‍💻 O que deverá ser desenvolvido</strong></summary>

Sua empresa do coração começou a desenvolver um software de booking de várias redes de hotéis.
Sua missão é continuar o desenvolvimento dessa API. O tech lead fechou um contrato com uma empresa que fornece informações geográficas baseadas em informações de endereço. Essa empresa irá fornecer uma API e com isso permitirá que as pessoas usuárias possam buscar os hotéis mais próximos baseando-se em um endereço. Entretanto, para que isso seja implementado, algumas refatorações deverão ser feitas no projeto principal antes de comportar essa nova funcionalidade. Nessa fase, sua missão será refatorar o projeto para comportar essa funcionalidade e desenvolvê-la.

</details>
  
<details>
  <summary><strong>📝 Habilidades a serem trabalhadas </strong></summary>

Neste projeto, verificamos se você é capaz de:

- Entender do funcionamento do ASP.NET e como ele se integra ao C#.
- Refatorar uma API.
- Realizar o consumo de APIs externas.


</details>


## Orientações
---

<details>
  <summary><strong>‼️ Antes de começar a desenvolver</strong></summary><br />

  1. Clone o repositório

  - Use o comando: `git clone git@github.com:tryber/csharp-034-csharp-projeto-trybe-hotel-fase-c.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd csharp-034-csharp-projeto-trybe-hotel-fase-c`

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.
  
  3. Crie uma branch a partir da branch `master`

  - Verifique se você está na branch `master`
    - Exemplo: `git branch`
  - Se não estiver, mude para a branch `master`
    - Exemplo: `git checkout master`
  - Agora crie uma branch à qual você vai submeter os `commits` do seu projeto
    - Você deve criar uma branch no seguinte formato: `nome-de-usuario-nome-do-projeto`
    - Exemplo: `git checkout -b joaozinho-csharp-034-csharp-projeto-trybe-hotel-fase-c`

  4. Adicione as mudanças ao _stage_ do Git e faça um `commit`

  - Verifique que as mudanças ainda não estão no _stage_
    - Exemplo: `git status` (deve aparecer listada a pasta _joaozinho_ em vermelho)
  - Adicione o novo arquivo ao _stage_ do Git
    - Exemplo:
      - `git add .` (adicionando todas as mudanças - _que estavam em vermelho_ - ao stage do Git)
      - `git status` (deve aparecer listado o arquivo _joaozinho/README.md_ em verde)
  - Faça o `commit` inicial
    - Exemplo:
      - `git commit -m 'iniciando o projeto x'` (fazendo o primeiro commit)
      - `git status` (deve aparecer uma mensagem tipo essa: _nothing to commit_ )

  5. Adicione a sua branch com o novo `commit` ao repositório remoto

  - Usando o exemplo anterior: `git push -u origin joaozinho-csharp-034-csharp-projeto-trybe-hotel-fase-c`

  6. Crie um novo `Pull Request` _(PR)_

  - Vá até a página de _Pull Requests_ do [repositório no GitHub](https://github.com/tryber/csharp-034-csharp-projeto-trybe-hotel-fase-c/pulls)
  - Clique no botão verde _"New pull request"_
  - Clique na caixa de seleção _"Compare"_ e escolha a sua branch **com atenção**
  - Coloque um título para a sua _Pull Request_
    - Exemplo: _"Cria tela de busca"_
  - Clique no botão verde _"Create pull request"_
  - Adicione uma descrição para o _Pull Request_ e clique no botão verde _"Create pull request"_
  - **Não se preocupe em preencher mais nada por enquanto!**
  - Volte até a [página de _Pull Requests_ do repositório](https://github.com/tryber/csharp-0x-projeto-trybe-hotel/pulls) e confira que o seu _Pull Request_ está criado

</details>

<details>
  <summary><strong>⌨️ Durante o desenvolvimento</strong></summary><br/>

  - Faça `commits` das alterações que você fizer no código regularmente

  - Lembre-se sempre de, após um (ou alguns) `commits`, atualizar o repositório remoto

  - Os comandos que você utilizará com mais frequência são:
    1. `git status` _(para verificar o que está em vermelho - fora do stage - e o que está em verde - no stage)_
    2. `git add` _(para adicionar arquivos ao stage do Git)_
    3. `git commit` _(para criar um commit com os arquivos que estão no stage do Git)_
    4. `git push -u origin nome-da-branch` _(para enviar o commit para o repositório remoto na primeira vez que fizer o `push` de uma nova branch)_
    5. `git push` _(para enviar o commit para o repositório remoto após o passo anterior)_

</details>

<details>
  <summary><strong>🤝 Depois de terminar o desenvolvimento (opcional)</strong></summary><br/>

  Para sinalizar que o seu projeto está pronto para o _"Code Review"_, faça o seguinte:

  - Vá até a página **DO SEU** _Pull Request_, adicione a label de _"code-review"_ e marque seus colegas:

    - No menu à direita, clique no _link_ **"Labels"** e escolha a _label_ **code-review**;

    - No menu à direita, clique no _link_ **"Assignees"** e escolha **o seu usuário**;

    - No menu à direita, clique no _link_ **"Reviewers"** e digite `students`, selecione o time `tryber/students-sd-034-csharp`.

  Caso tenha alguma dúvida, [aqui tem um vídeo explicativo](https://vimeo.com/362189205).

</details>

<details>
  <summary><strong>🕵🏿 Revisando um pull request</strong></summary><br />

  Use o conteúdo sobre [Code Review](https://app.betrybe.com/course/real-life-engineer/code-review) para te ajudar a revisar os _Pull Requests_.

</details>

<details>
  <summary><strong>🎛 Linter</strong></summary><br />

  Usaremos o [NetAnalyzer](https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/overview) para fazer a análise estática do seu código.

  Este projeto já vem com as dependências relacionadas ao _linter_ configuradas no arquivo `.csproj`.

  O analisador já é instalado pelo plugin da `Microsoft C#` no `VSCode`. Para isso, basta fazer o download do [plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) e instalá-lo.
</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

  O .NET já possui sua própria plataforma de testes.
  
  Este projeto já vem configurado e com suas dependências.

  ### Executando todos os testes

  Para executar os testes com o .NET, execute o comando dentro do diretório do seu projeto `src`!

  ```
  dotnet test
  ```

  ### Executando um teste específico

  Para executar um teste específico, basta executar o comando `dotnet test --filter Name~TestReq01`.

  :warning: **Importante:** o comando irá executar testes cujo nome contém `TestReq01`.

  :warning: **O avaliador automático não necessariamente avalia seu projeto na ordem em que os requisitos aparecem no readme. Isso acontece para deixar o processo de avaliação mais rápido. Então, não se assuste se isso acontecer, ok?**

  ### Outras opções para testes
  - Algumas opções que podem lhe ajudar são:
    -  `-?|-h|--help`: exibe a descrição completa de como utilizar o comando.
    -  `-t|--list-tests`: lista todos os testes, ao invés de executá-los.
    -  `-v|--verbosity <LEVEL>`: define o nível de detalhe na resposta dos testes.
      - `q | quiet`
      - `m | minimal`
      - `n | normal`
      - `d | detailed`
      - `diag | diagnostic`
      - Exemplo de uso: 
         ```
           dotnet test -v diag
         ```
         ou
         ```            
           dotnet test --verbosity=diagnostic
         ``` 
</details>

## Requisitos do projeto

Você está desenvolvendo uma API que será utilizada em uma aplicação de booking de várias redes de hotéis.

Na primeira fase deste projeto, você desenvolveu algumas rotas de entidades acerca de cidades, hotéis e quartos. Na segunda fase, você construiu rotas para o cadastro e login de pessoas clientes e o cadastro de reservas. Agora, você irá desenvolver uma funcionalidade para buscar os hotéis mais próximos de acordo com um endereço.

No intuito de auxiliar o desenvolvimento, o time de produto já disponibilizou o diagrama de entidade-relacionamento atualizado e o time de DevOps disponibilizou um container na qual você poderá utilizar um banco de dados.

O sistema está dividido em diretórios específicos para auxiliar na organização e desenvolvimento do projeto.

- `Controllers/`: Este diretório armazena os arquivos com as lógicas dos controllers da aplicação. Os métodos a serem desenvolvidos estão prontos mas sem implementação alguma, o que você desenvolverá ao longo do projeto.
<br />

- `Models/`: Este diretório armazena os arquivos com as models do banco de dados. Você já desenvolveu as models `City`, `Hotel`, `Room`, `User` e `Bokking` que serão as instruções para as tabelas `Cities`, `Hotels`, `Rooms`, `Users` e `Bookings`.
<br />

- `DTO/`: Este diretório armazena as classes de DTO. Algumas rotas esperam as `responses` baseadas nestes DTOs. Você pode conferir isso pelo requisito do projeto e pelo retorno dos métodos dos `repositories`.
<br />

- `Repository/`: Este diretório armazena as lógicas que farão a interação com o banco de dados. Os métodos de cada requisito já estão criados e você deverá incluir a implementação de cada um desses métodos respeitando o retorno do DTO. Além disso, você terá o arquivo `TrybeHotelContext` com o contexto para a conexão com o banco de dados. Todos os `repository` e o `context` possuem interfaces que estão nesse diretório e fornecem o contrato para essas classes. Caso você precise criar um novo método para interação com o banco de dados que não esteja mapeado, você pode livremente criar esse novo método na `repository` mas sem se esquecer de escrever o contrato deste método na interface referente.
<br />

- `Services`: Este diretório armazena os serviços responsáveis pela geração de token e pelo serviço geográfico.

<details id='der'>
  <summary><strong>🎲 Banco de Dados</strong></summary>
  <br/>

  Para o desenvolvimento, o time de produto disponibilizou um *Diagrama de Entidade-Relacionamento (DER)* para construir a modelagem do banco de dados. Com essa imagem você já consegue saber:
  - Como nomear suas tabelas e colunas;
  - Quais são os tipos de suas colunas;
  - Relações entre tabelas.

    ![banco de dados](img/der.png)

  O diagrama infere 05 tabelas:
  - ***Cities***: tabela que armazenará um conjunto de cidades nas quais os hotéis estão localizados (já desenvolvida).
  - ***Hotels***: tabela que armazenará os hotéis da nossa aplicação. Note que informamos o `CityId`, atributo que armazenará o id da cidade (já desenvolvida).
  - ***Rooms***: tabela que armazenará os quartos de cada hotel da nossa aplicação. Note que informamos o `HotelId`, atributo que armazenará o id do hotel (já desenvolvida).
  - ***Users***: tabela que armazenará as pessoas usuárias do sistema.
  - ***Bookings***: tabela que armazenará as reservas de quartos de hotéis. Note que informamos os atributos `UserId`, que armazenará o id da pessoa usuária e `RoomId`, que armazenará o id do quarto reservado.

  Acerca dos relacionamentos, pelo diagrama de entidade-relacionamento temos:
  - Uma cidade pode ter vários hotéis.
  - Um hotel pode ter vários quartos.
  - Uma pessoa usuária pode ter várias reservas.
  - Um quarto pode ter várias reservas.

  ⚠️ **Você poderá criar migrations para visualizar o banco de dados**

</details>

<details>
<summary><strong>🐳 Docker</strong></summary><br />

Para auxiliar no desenvolvimento, este projeto possui um arquivo do docker compose para subir um serviço do banco de dados `Azure Data Studio`. Este banco de dados possui a mesma arquitetura do `SQL Server`.

Para subir o serviço, utilize o comando:

```shell
docker-compose up -d --build
```

Para conectar ao seu sistema de gerenciamento de banco de dados, utilize as seguintes credenciais:

- `Server`: localhost
- `User`: sa
- `Password`: TrybeHotel12!
- `Database`: TrybeHotel
- `Trust server certificate`: true

Para criar o contexto do banco de dados na sua aplicação, utilize como connection string:

```csharp
var connectionString = "Server=localhost;Database=TrybeHotel;User=SA;Password=TrybeHotel12!;TrustServerCertificate=True";
```

⚠️ ** Essa connection string poderá ser utilizada no requisito 1 **

</details>

<details id='refatorando'>
  <summary>Continuando o projeto Trybe Hotel</summary>

Você já iniciou o projeto da nossa aplicação e portanto, todas as funcionalidades podem ser trazidas para não duplicar o funcionamento. Isso será muito importante, especialmente no que diz respeito ao banco de dados. Algumas models do seu banco de dados anterior serão referenciadas nas models agora, portanto, vamos trazer as funcionalidades anteriores.

Mas como fazemos isso:

Após clonar o repositório deste projeto, apenas copie e cole as funcionalidades que você construiu anteriormente:

- `Controllers`: copie todos os arquivos do diretório `Controllers` do projeto anterior e cole no diretório `Controllers` deste projeto, com exceção do arquivo `CityController.cs`. Neste arquivo, copie apenas as implementações dos métodos `GetCities()` e `PostCities()`.
- `Dto`: copie todos os arquivos do diretório `Dto` do projeto anterior e cole no diretório `Dto` deste projeto.
- `Models`: copie os arquivos referentes às models `City`, `Hotel`, `Room`, `User` e `Booking` do projeto anterior e cole no diretório `Models` deste projeto.
- `Repository`: copie os arquivos `RoomRepository`, `HotelRepository`, `UserRepository` e `BookingRepository` do projeto anterior e cole no diretório `Repository` deste projeto. Não copie as interfaces. Para o arquivo `CityRepository`, não substitua o arquivo. Apenas copie apenas as implementações dos métodos `GetCities()` e `AddCity()`. Para o arquivo `TrybeHotelContext`, não o substitua. Apenas adicione os `DBSets` e implemente os métodos `OnConfiguring()` e `OnModelCreating()`.
- `Migrations`: Se você possui um diretório de migrations, significa que você criou migrations no projeto anterior. Não copie este diretório e crie migrations novas porque a instância do banco de dados no container não será o mesmo.
- `Services`: copie todos os arquivos do diretório `Services` do projeto anterior e cole no diretório `Services` deste projeto.
- `Testes`: No projeto de testes, você pode copiar a funcionalidade do arquivo `src/TrybeHotel.Test/IntegrationTest.cs`.

</details>


### 1. Adicione o atributo State na model City

<details>
  <summary><strong>Mais informações:</strong></summary>

  <details>
    <summary>Refatore a model <code>City</code></summary>
    <br />
City representará as cidades da aplicação e deverá conter os seguintes campos:

- `CityId`: Chave primária (int)
- `Name`: string
- `State`: string

Você deverá apenas adicionar o atributo `State` na model e aplicar as mudanças no banco de dados utilizando migrations.

Em caso de dúvidas, consulte o [diagrama de entidade-relacionamento](#der)
  </details>

<br />

**O que será testado:**

- Será testado que a model `City` possui o novo atributo.

</details>


### 2. Refatore o endpoint POST /city

<details>
  <summary><strong>Mais informações:</strong></summary>

  - Refatore o endpoint POST /city de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json
  {
	  "cityId": 1,
	  "name": "Rio de Janeiro",
    "state": "RJ"
  }
  ```
 - Implemente a refatoração no método `AddCity()` do arquivo `src/TrybeHotel/Repository/CityRepository.cs`.
 - A sua repository retorna um tipo `CityDto` que deverá ser refatorada no arquivo `src/TrybeHotel/Dto/CityDto.cs`. A sua classe de DTO deve seguir o formato da response da requisição, ou seja, apenas adicione o atributo `state`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.

**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 3. Desenvolva o endpoint PUT /city

<details>
  <summary><strong>Mais informações:</strong></summary>

- Este endpoint será responsável por atualizar os dados de uma cidade existente.
- Implemente a lógica da sua controller no método `PutCity()` do arquivo `src/TrybeHotel/Controllers/CityController.cs`.
- Implemente a lógica de interação ao banco de dados no método `UpdateCity()` do arquivo `src/TrybeHotel/Repository/CityRepository.cs`.
- A sua repository retorna um tipo `CityDto` que deverá ser implementado no arquivo `src/TrybeHotel/Dto/CityDto.cs`. A sua classe de DTO deve seguir o formato da response da requisição.

👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.

- O endpoint deve ser acessível através da URL `/city` e deve ser do tipo `PUT`;
- O corpo da requisição deve seguir o padrão abaixo

```json
{
  "CityId": 1,
	"Name": "Rio de Janeiro",
  "State": "RJ"
}
```

- A resposta deve ser o status `200`.
- O corpo da resposta deve seguir o formato abaixo:

```json
{
	"CityId": 1,
	"Name": "Rio de Janeiro",
  "State": "RJ"
}
```

**O que será testado:**

- Será testado que, quando solicitada a requisição, a mesma atualize no banco de dados e retorne de acordo com o modelo.
- Será testado que o status de retorno será `200`.
- Será testado que o corpo da resposta segue o padrão esperado.

</details>


### 4. Refatore o endpoint GET /city

<details>
  <summary><strong>Mais informações:</strong></summary>

  - Refatore o endpoint GET /city de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json
  [
    {
  	  "cityId": 1,
	    "name": "Rio de Janeiro",
      "state": "RJ"
    },
    /* ... */
  ]
  ```
 - Implemente a refatoração no método `GetCities()` do arquivo `src/TrybeHotel/Repository/CityRepository.cs`.
 - A sua repository retorna um tipo `CityDto` que deverá ser refatorada no arquivo `src/TrybeHotel/Dto/CityDto.cs`. A sua classe de DTO deve seguir o formato da response da requisição, ou seja, apenas adicione o atributo `state`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.

**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 5. Refatore o endpoint GET /hotel

<details>
  <summary><strong>Mais informações:</strong></summary>

- Refatore o endpoint GET /hotel de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json
  [
    {
  	  "hotelId": 1,
		  "name": "Trybe Hotel SP",
		  "address": "Avenida Paulista, 1400",
		  "cityId": 1,
		  "cityName": "São Paulo",
      "state": "SP"
    },
    /* ... */
  ]
  ```
 - Implemente a refatoração no método `GetHotels()` do arquivo `src/TrybeHotel/Repository/HotelRepository.cs`.
 - A sua repository retorna um tipo `HotelDto` que deverá ser refatorada no arquivo `src/TrybeHotel/Dto/HotelDto.cs`. A sua classe de DTO deve seguir o formato da response da requisição, ou seja, apenas adicione o atributo `state`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.

**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 6. Refatore o endpoint POST /hotel

<details>
  <summary><strong>Mais informações:</strong></summary>

- Refatore o endpoint POST /hotel de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json
  {
  	"hotelId": 1,
		"name": "Trybe Hotel SP",
		"address": "Avenida Paulista, 1400",
		"cityId": 1,
		"cityName": "São Paulo",
    "state": "SP"
  }
  ```
 - Implemente a refatoração no método `AddHotel()` do arquivo `src/TrybeHotel/Repository/HotelRepository.cs`.
 - A sua repository retorna um tipo `HotelDto` que deverá ser refatorada no arquivo `src/TrybeHotel/Dto/HotelDto.cs`. A sua classe de DTO deve seguir o formato da response da requisição, ou seja, apenas adicione o atributo `state`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.

**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 7. Refatore o endpoint GET /room

<details>
  <summary><strong>Mais informações:</strong></summary>


- Refatore o endpoint GET /room de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json
  [
    {
    	"roomId": 1,
		  "name": "Suite básica",
		  "capacity": 2,
		  "image": "image suite",
		  "hotel": {
    	  "hotelId": 1,
			  "name": "Trybe Hotel SP",
			  "address": "Avenida Paulista, 1400",
			  "cityId": 1,
			  "cityName": "São Paulo",
        "state": "SP"
		  }
    }
  ]
  ```
 - Implemente a refatoração no método `GetRooms()` do arquivo `src/TrybeHotel/Repository/RoomRepository.cs`.
 - A sua repository retorna um tipo `RoomDto` que não precisará ser refatorada, pois a mesma funciona a partir do DTO `HotelDto`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.

**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 8. Refatore o endpoint POST /room

<details>
  <summary><strong>Mais informações:</strong></summary>

- Refatore o endpoint POST /room de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json
  
  {
    "roomId": 1,
		"name": "Suite básica",
		"capacity": 2,
		"image": "image suite",
		"hotel": {
       "hotelId": 1,
			 "name": "Trybe Hotel SP",
			 "address": "Avenida Paulista, 1400",
			 "cityId": 1,
			 "cityName": "São Paulo",
       "state": "SP"
		}
  }
  
  ```
 - Implemente a refatoração no método `AddRoom()` do arquivo `src/TrybeHotel/Repository/RoomRepository.cs`.
 - A sua repository retorna um tipo `RoomDto` que não precisará ser refatorada, pois a mesma funciona a partir do DTO `HotelDto`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.

**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.


</details>


### 9. Refatore o endpoint POST /booking

<details>
  <summary><strong>Mais informações:</strong></summary>


- Refatore o endpoint POST /booking de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json

  {
  	"bookingId": 1,
  	"checkIn": "2030-08-27T00:00:00",
  	"checkOut": "2030-08-28T00:00:00",
  	"guestQuant": 1,
  	"room": {
		  "roomId": 1,
		  "name": "Suite básica",
		  "capacity": 2,
		  "image": "image suite",
		  "hotel": {
  			"hotelId": 1,
			  "name": "Trybe Hotel RJ",
			  "address": "Avenida Atlântica, 1400",
			  "cityId": 1,
			  "cityName": "Rio de Janeiro",
        "state": "RJ"
		  }
	  }
  }
  ```

 - Implemente a refatoração no método `Add()` do arquivo `src/TrybeHotel/Repository/BookingRepository.cs`.
 - A sua repository retorna um tipo `BookingResponse` que não precisará ser refatorada, pois a mesma funciona a partir do DTO `RoomDto`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.


**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 10. Refatore o endpoint GET /booking

<details>
  <summary><strong>Mais informações:</strong></summary>


- Refatore o endpoint GET /booking de modo que a response da API siga o seguinte formato em caso de sucesso:

  ```json

  {
  	"bookingId": 1,
  	"checkIn": "2030-08-27T00:00:00",
  	"checkOut": "2030-08-28T00:00:00",
  	"guestQuant": 1,
  	"room": {
		  "roomId": 1,
		  "name": "Suite básica",
		  "capacity": 2,
		  "image": "image suite",
		  "hotel": {
  			"hotelId": 1,
			  "name": "Trybe Hotel RJ",
			  "address": "Avenida Atlântica, 1400",
			  "cityId": 1,
			  "cityName": "Rio de Janeiro",
        "state": "RJ"
		  }
	  }
  }
  ```

 - Implemente a refatoração no método `Add()` do arquivo `src/TrybeHotel/Repository/BookingRepository.cs`.
 - A sua repository retorna um tipo `BookingResponse` que não precisará ser refatorada, pois a mesma funciona a partir do DTO `RoomDto`.

  👀 De olho na dica: Monte o retorno do seu repository com os conhecimentos de LINQ e DTO já obtidos.
  👀 De olho na dica 2: Todas as outras funcionalidades implementadas nas fases anteriores deverão ser mantidas.


**O que será testado:**

- Será testado que a response da API segue o padrão solicitado.

</details>


### 11. Desenvolva o endpoint GET /geo/status

<details>
  <summary><strong>Mais informações:</strong></summary>

  - Este endpoint será responsável por conferir o status da api externa responsável pela geolocalização.
  - O endpoint deve ser acessível através da URL `/geo/status` e deve ser do tipo `GET`.
  - O corpo da requisição é vazio.
  - A origem das informações na API externa será por um `GET` pela URL `https://nominatim.openstreetmap.org/status.php?format=json`.
  - Você poderá verificar o funcionamento da API através de uma requisição na URL.
  - Você pode checar mais informações da API na sua [documentação aqui](https://nominatim.org/release-docs/latest/api/Status/).
  - A API externa retorna como response, em caso de sucesso, um status code `200` e um objeto `JSON` no seguinte formato:

  ```json
  {
      "status": 0,
      "message": "OK",
      "data_updated": "2020-05-04T14:47:00+00:00",
      "software_version": "3.6.0-0",
      "database_version": "3.6.0-0"
  }
  ```

   ***Headers***

   - Para realizar a requisição, você deverá adicionar 02 headers, para aceitar respostas do tipo `json` e para ter um `User-Agent` tal como um navegador ou outra ferramenta de requisição à APIs REST:

  ```csharp
  requestMessage.Headers.Add("Accept", "application/json");
  requestMessage.Headers.Add("User-Agent", "aspnet-user-agent");
  ``` 

  - Desenvolva a lógica de realizar uma request externa na API implementando o método `GetGeoStatus()` no arquivo `src/TrybeHotel/Services/GeoService.cs`.
  - Se a request não retornar uma resposta com um caso de sucesso, retorne um `default(Object)`.
  - Desenvolva a lógica de sua controller no método `GetStatus()` no arquivo `src/TrybeHotel/Controllers/GeoController.cs`.
  - Na lógica de sua controller, faça a requisição ao método desenvolvido na camada `Service`.
  - A response da sua controller deve ser um status `200` com a response abaixo, exatamente igual à response da API externa:

   ```json
  {
      "status": 0,
      "message": "OK",
      "data_updated": "2020-05-04T14:47:00+00:00",
      "software_version": "3.6.0-0",
      "database_version": "3.6.0-0"
  }
  ```

  👀 De olho na dica: Você não precisa desenvolver nenhum DTO neste requisito pois o objeto da sua response será igual ao objeto da response de sua API externa.

**O que será testado:**

- Será testado que é possível obter os dados da API externa.

</details>


### 12. Desenvolva o endpoint GET /geo/address

<details>
  <summary><strong>Mais informações:</strong></summary>

  <details>
    <summary>Funcionamento da controller</summary>

  - Este endpoint será responsável por trazer os hotéis ordenados por distância de um endereço (ordem crescente de distância).
  - O endpoint deve ser acessível através da URL `/geo/address` e deve ser do tipo `GET`.
  - O corpo da requisição deve seguir o padrão abaixo:

  ```json
  {
    "Address":"Rua Arnaldo Barreto",
	  "City":"Campinas",
	  "State":"SP"
  }
  ```

  - A resposta em caso de sucesso deverá ser um status `200`.
  - O corpo da resposta deve seguir o formato abaixo:

  ```json
    [
	    {
		    "hotelId": 2,
		    "name": "Trybe Hotel SP",
		    "address": "Avenida Paulista, 2000",
		    "cityName": "São Paulo",
		    "state": "SP",
		    "distance": 82
	    },
	    {
		    "hotelId": 1,
		    "name": "Trybe Hotel RJ",
		    "address": "Avenida Atlântica, 1400",
		    "cityName": "Rio de Janeiro",
		    "state": "RJ",
		    "distance": 399
	    },
      /* ... */
    }
  ```

  - A implementação da controller deverá ser feita no método `GetHotelsByLocation()` do arquivo `src/TrybeHotel/Controllers/GeoController.cs`
  - O corpo da requisição deverá seguir o DTO `GeoDto` que deverá ser implementado no arquivo `src/TrybeHotel/DTO/GeoDto.cs`.
  - O corpo da resposta deverá ser um array de objetos do DTO `GeoDtoHotelResponse` que deverá ser implementado no arquivo `src/TrybeHotel/DTO/GeoDto.cs`.
  - A sua controller deverá chamar a service `GeoService` a ser implementada no arquivo `src/TrybeHotel/Services/GeoService.cs`.

  </details>

  <details>
    <summary>Funcionamento da Service</summary>

  <br />
    A service `GeoService` será implementada através de 03 métodos com as seguintes funções:
  
  - Obter a latitude e longitude de um endereço através do método `GetGeoLocation()`.
  - Calcular a distância em km entre duas posições através do método `CalculateDistance()`. Cada posição terá sua latitude e longitude.
  - Obter a distância entre o endereço informado e todos os hotéis do sistema através do método `GetHotelsByGeo()`.

<details>
  <summary>Obter latitude e longitude de um endereço</summary>
  <br />

  - Você deverá implementar um método que irá trazer a latitude e longitude de um determinado endereço.
  - A implementação deverá ser criada no método `GetGeoLocation()` do arquivo `src/TrybeHotel/Services/GeoService.cs`.
  - Esse método tem como parâmetro de entrada um objeto que respeita a `DTO` `GeoDto` implementada durante o funcionamento da controller.
  - Esse método tem como parâmetro de saída um objeto que respeita a `DTO` `GeoDtoResponse` implementada no arquivo `src/TrybeHotel/Dto/GeoDto.cs`.
    
    <br />
    
  - Essas informações deverão ser obtidas através de uma request na API externa.
  - A origem das informações na API externa será por um `GET` pela URL `https://nominatim.openstreetmap.org/search?street=seu-endereço&city=sua-cidade&country=Brazil&state=seu-estado&format=json&limit=1`.
  - Você poderá verificar o funcionamento da API através de uma requisição na URL.
  - Você pode checar mais informações da API na sua [documentação aqui](https://nominatim.org/release-docs/latest/api/Search/).
  - Requisição de exemplo: `https://nominatim.openstreetmap.org/search?street=Av Djalma Batista&city=Manaus&country=Brazil&state=AM&format=json&limit=1`.

***Parâmetros***

  - O endereço da URL possui alguns parâmetros referentes ao seu endereço de pesquisa.
  - Todos os parâmetros são query params.
  - Os parâmetros são:

    - `street=<housenumber> <streetname>`
    - `city=<city>`
    - `state=<state>`
    - `country=Brazil`

    <br />
  - O parâmetro `country` deverá ser fixo com o valor `Brazil`.
  - Os parâmetros `stret`, `city` e `state` deverão utilizar os valores da `DTO` de entrada `GeoDto`.

  <br />

 ***Headers***

   - Para realizar a requisição, você deverá adicionar 02 headers:

  ```csharp
  requestMessage.Headers.Add("Accept", "application/json");
  requestMessage.Headers.Add("User-Agent", "aspnet-user-agent");
  ``` 

  ***Response***

  - A API externa responderá um objeto no seguinte formato:

  ```json
  [
	  {
  		"place_id": 261870502,
		  "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
		  "osm_type": "way",
		  "osm_id": 805583646,
		  "boundingbox": [
  			"-3.1142087",
			  "-3.1132952",
			  "-60.0235945",
			  "-60.023573"
		  ],
		  "lat": "-3.1136717",
		  "lon": "-60.0235911",
		  "display_name": "Avenida Djalma Batista, São Geraldo, Manaus, Região Geográfica Imediata de Manaus, Região Geográfica Intermediária de Manaus, Amazonas, Região Norte, 69000-000, Brasil",
		  "class": "highway",
		  "type": "secondary",
		  "importance": 0.61
	  }
  ]
  ```

  - Caso a resposta não seja um status code de sucesso, ou caso o endereço não seja encontrado, retorne do seu método:

  ```csharp
  return default(GeoDtoResponse);
  ```

  - Caso a API externa retorne um objeto válido, retorne de acordo com um array do tipo `GeoDtoResponse[]`.
  - A `GeoDtoResponse` será um objeto que terá apenas os dois atributos importantes dessa api: `lat` e `lon`.

</details>

<details>
    <summary>Calcular a distância entre duas posições</summary>


   - A funcionalidade que calcula a distância entre duas posições já está implementada no método `CalculateDistance()` do arquivo `src/TrybeHotel/Services/GeoService.cs`.
   - Você deverá fazer uso desse método para obter a distância.

   ***Parâmetros de entrada***

   - `string latitudeOrigin` - Latitude da posição de origem.
   - `string longitudeOrigin` - Longitude da posição de origem.
   - `string latitudeDestiny` - Latitude da posição de destino.
   - `string longitudeDestiny` - Longitude da posição de destino.

   👀 De olho na dica: O método já converte de `string` para valores numéricos. Você pode apenas enviar os valores obtidos da API externa.

   ***Saída***

   - `int` - Valor inteiro que representará a distância entre os dois pontos em kilômetros.
      
</details>


<details>
  <summary>Obter a distância entre o endereço informado e todos os hotéis</summary>
  <br />

  - Você deverá implementar essa funcionalidade no método `GetHotelsByGeo()` do arquivo `src/TrybeHotel/Services/GeoService.cs`.
  - Este método terá como parâmetros de entrada:
      - `GeoDto geoDto`: um objeto do tipo `GeoDto`.
      - `IHotelRepository repository`: a repository do banco de dados que será recebida pela camada controller.
  - Este método terá como saída uma lista do tipo `GeoDtoHotelResponse`, `DTO` implementada no arquivo `src/TrybeHotel/DTO/GeoDto.cs`.

  <br />
  - Neste requisito, utilize o `repository` para buscar todos os hotéis.
  - Utilize o método `GetGeoLocation()` para obter a latitude e longitude do endereço informado.
  - Utilize o método `GetGeoLocation()` para obter a latitude e longitude dos hotéis do banco de dados pelo endereço dos mesmos.
  - Utilize o método `CalculateDistance()` para calcular a distância entre o endereço informado e um hotel.
  - Com esse passos, popule uma lista do tipo `GeoDtoHotelResponse` para ser o retorno de seu método.

</details>

<br />

**O que será testado:**

- Será testado que a rota pode buscar os hotéis em ordem crescente de distância a partir de um endereço informado. 

</details>



<details>
  <summary><strong>🗣 Nos dê feedbacks sobre o projeto!</strong></summary><br />

Ao finalizar e submeter o projeto, não se esqueça de avaliar sua experiência preenchendo o formulário. 
**Leva menos de 3 minutos!**

[FORMULÁRIO DE AVALIAÇÃO DE PROJETO](https://be-trybe.typeform.com/to/ZTeR4IbH#cohort_hidden=CH34-CSHARP&template=betrybe/csharp-0x-projeto-trybe-hotel-fase-c)

</details>

<details>
  <summary><strong>🗂 Compartilhe seu portfólio!</strong></summary><br />

  Você sabia que o LinkedIn é a principal rede social profissional e que compartilhar aprendizados lá é muito importante para quem deseja construir uma carreira de sucesso? Compartilhe este projeto no seu LinkedIn, marque o perfil da Trybe (@trybe) e mostre para a sua rede toda a sua evolução.

</details>
