# Desafio backend.

## Requisitos não funcionais 
- A aplicação foi construida com .Net utilizando C#.
- Foi utilizado MongoDB

## Aplicação Desenvolvida
Foi desenvolvido parte de uma aplicação para gerenciar o aluguel de motos e entregadores.

O que foi desenvolvido:
- Todas as rotas de motos
- Todas as rotas de locação
- Implementação do banco de dados - MongoDB
- Aplicação rodando com Docker
- Início da implementação da Locação - Criação do Model

O que ficou pendente:
- Implementação do sistema de mensageria por RabbitMq
- Regras específicas de negócio provindas de todas as rotas
- Tratamento de erros
- Documentação básica no Swagger

## Como rodar a aplicação

1. Clone o repositório e vá para a pasta em do projeto
```sh
git clone https://github.com/G2454/Desafio-BackEnd.git
cd LocacaoMoto
```
2. Faça o build do Docker Image
```sh
docker build -t locacao-motos .
```
3. Rode o container substituindo o AtlasURI abaixo com as credenciais fornecidas ao iniciar um novo cluster - CMD
```sh
docker run -p 8080:8080 -e MongoDBSettings__AtlasURI="mongodb+srv://<user>:<password>@cluster0.rh6sdot.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0" -e MongoDBSettings__DatabaseName="LocacaoMotoDB" locacao-motos
```
4. Acesse o Swagger na seguinte URL:
http://localhost:8080/api-docs

