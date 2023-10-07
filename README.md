# Modelando Domínios Ricos

Repositório contendo implementação do curso "Modelando Domínios Ricos", do balta.io.

### Conceitos abordados
- Relembrar conceitos de OOP
- Aprender e aplicar DDD (Domain-Driven Design)
- Aprender o conceito de CQRS (Command Query Responsibility Segregation)
- Aprender os conceitos de SOLID e Clean Code
- Evitar corrupção no código
- Evitar a obsessão por tipos primitivos no seu código
- Aprender Design by Contracts
- Implementar Fail-Fast Validations
- Entender e implementar o Repository Pattern
- Aprender a testar Entidades e Value Objects
- Aprender a testar Handlers e Queries

### TODO
- Melhorar validadores de Entities e Value Objects
- Adicionar testes para validadores de todos Entities e Value Objects
- Refatorar SubscriptionHandler, extraindo fluxos para métodos, para reaproveitar código.
- Remover dependência de IEmailService do SubscriptionHandler e adicionar nesse fluxo chamada para um Handler específico para envio de e-mail.
