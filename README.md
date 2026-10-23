# Sistema de Eleição

## Descrição
Sistema de eleição desenvolvido em C# com .NET 10, utilizando uma aplicação de console e testes unitários com xUnit.

Projeto acadêmico da disciplina Garantia da Qualidade de Software.

## Funcionalidades
- Cadastro de candidatos com nome e número.
- Validação de números de candidatos duplicados.
- Registro de eleitores por CPF ou título simulado.
- Registro de votos.
- Bloqueio de votos duplicados.
- Contabilização de votos válidos, brancos e nulos.
- Apuração dos votos e identificação do vencedor ou empate.

## Tecnologias utilizadas
- C#
- .NET 10
- xUnit
- Git
- GitHub

## Como executar

Abra o terminal na pasta principal do projeto e execute:

```bash
dotnet run --project SistemaEleicao.Console/SistemaEleicao.Console.csproj
```

## Como executar os testes

```bash
dotnet test
```

## Menu do sistema

1. Cadastrar candidato
2. Registrar eleitor
3. Votar
4. Apurar votos
0. Sair

## Regras de negócio

- Dois candidatos não podem possuir o mesmo número.
- Um eleitor não pode votar mais de uma vez.
- Votos em números inexistentes são considerados nulos.
- O número zero representa um voto em branco.
- O sistema permite registrar um eleitor automaticamente no primeiro voto.
- A apuração identifica o candidato com mais votos e informa empates.

## Controle de versão

O projeto utiliza Git e segue o padrão Conventional Commits para organizar seu histórico de desenvolvimento.

## Finalidade

Atividade acadêmica desenvolvida para praticar programação orientada a objetos, regras de negócio, testes unitários e versionamento de código.