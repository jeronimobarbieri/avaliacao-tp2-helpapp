# 📘 Avaliação Técnica – Clean Architecture + Azure SQL

Este repositório contém minha entrega referente à avaliação técnica baseada no repositório original do professor:  
[https://github.com/victoricoma/avaliacao-tp2-helpapp](https://github.com/victoricoma/avaliacao-tp2-helpapp)

---

## ✅ Objetivo

Este projeto tem como objetivo implementar os repositórios Category e Product seguindo os padrões da Clean Architecture, aplicar a migration Initial e conectar a aplicação a uma instância local do SQL Server, utilizando o SQL Server Management Studio (SSMS) para gerenciamento.

---

## 🚀 Funcionalidades implementadas

✅ Repositórios CategoryRepository e ProductRepository criados e implementados.

✅ Configurações EntityTypeConfiguration para as entidades Category e Product.

✅ Injeção de dependência configurada na DependencyInjectionAPI.

✅ Migration Initial criada, utilizando HasData() para inserção de dados iniciais de categorias.

✅ Banco de dados criado no SQL Server via SSMS.

✅ Migration aplicada com sucesso no banco de dados usando o console do Visual Studio 2022.

---

# 🔧 Comandos utilizados

## Criação da migration

Add-Migration Initial

## Aplicação no banco de dados local

Update-Databse

# 🔗 String de conexão (mascarada)

"ConnectionStrings": {
"DefaultConnection": "Data Source=JUNIOR\\SQLEXPRESS;Initial Catalog=avaliacao_dbhelpapp;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True"
}

# ☁️ Configuração no Banco de Dados Local

O comando CREATE DATABASE foi usado para a criação do banco de dados

Banco de dados nomeado: avaliacao_dbhelpapp

Migration aplicada com sucesso diretamente do Visual Studio Terminal

# 🖼️ Prints de evidência (opcional)

Insira prints aqui comprovando:

Testes funcionando
![Testes Corretos](https://github.com/user-attachments/assets/2ba8cdf9-c578-49a7-9ad2-7c67ef6dba0b)


Aplicação bem-sucedida da migration no banco de dados local
![Add-Migration](https://github.com/user-attachments/assets/8a7dd7e6-90c4-42cd-a435-b292567e7d41)

Diagrama Banco de Dados
![Avaliacao_DbHelpApp](https://github.com/user-attachments/assets/59726947-89d5-4b93-bec4-b97b66a06c84)

Tabelas e dados populados
![Tabela Banco de Dados](https://github.com/user-attachments/assets/6a278f00-7ef3-4adb-8300-5271a98f6969)



# 👨‍💻 Dados do aluno

Nome: Jerônimo Barbieri Junior
Curso: Desenvolvimento de Software Multiplataforma – 3º Semestre

Professor: Victor Icoma

Branch da entrega: avaliacao-jeronimobarbieri

## 🧱 Estrutura da aplicação

HelpApp.sln
┣ 📂 HelpApp.API
┣ 📂 HelpApp.Application
┣ 📂 HelpApp.Domain
┣ 📂 HelpApp.Infra.Data
┃ ┣ 📂 Context
┣ ┣ 📂 EntityConfiguration
┣ ┣ 📂 Migrations
┃ ┃ 📂 Repositories
┃ 📂 HelpApp.Infra.IoC


# 📝 Observações

Todos os campos obrigatórios foram preenchidos no HasData().

A classe DesignTimeDbContextFactory foi usada para facilitar o debug de erros durante o desenvolvimento.

As migrations foram aplicadas diretamente no SQL Server local com sucesso.

```
