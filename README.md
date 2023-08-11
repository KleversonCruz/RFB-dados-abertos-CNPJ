# Extrator de Dados de CNPJ da Receita Federal Brasileira

Este projeto consiste em uma aplicação desenvolvida em .NET 7 que tem como objetivo extrair dados públicos de CNPJs (Cadastro Nacional da Pessoa Jurídica) da Receita Federal Brasileira. A aplicação realiza o download dos arquivos disponibilizados pela Receita, extrai as informações, converte os dados para um formato adequado e os armazena em um banco de dados.

Fonte dos dados: [dadosabertos.rfb.gov.br/CNPJ](https://dadosabertos.rfb.gov.br/CNPJ/)

Layout dos arquivos: [cnpj-metadados.pdf](https://www.gov.br/receitafederal/dados/cnpj-metadados.pdf)

## Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [PostgreSQL 15](https://www.postgresql.org/download/)

## Como Usar

1. Configure as informações de conexão com o banco de dados no arquivo de configuração `appsettings.json`.
2. Realize o build da aplicação CLI.
3. Execute o comando `init` para inicializar o banco de dados.
4. Execute o comando `seed` para começar o processo de extração.

A aplicação realizará o download dos arquivos, extrairá os dados e salvará no banco de dados configurado. Esse procedimento pode demorar dependendo da infraestrutura na qual está sendo executado. Também é possível utilizar o comando `seed --partial` para baixar apenas informações essenciais dos CNPJs.