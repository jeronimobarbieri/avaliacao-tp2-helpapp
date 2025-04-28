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

Métricas de correção
![Sucesso Métricas](https://github.com/user-attachments/assets/e39910a0-a249-47e7-9a91-8a5e8bf37b0c)



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
# 📜 Review Tradicional - Estrutura do Projeto - JeronimoBarbieri
🔹 1. HelpApp.Domain/Entities
O que vi:

Entidades Product.cs e Category.cs no domínio.

Ponto Positivo:

Entidades limpas, ainda sem anotações de frameworks (nada de [Key], [ForeignKey], etc.), o que é muito bom na ótica da Clean Architecture.

Cada entidade contém propriedades básicas, sem lógica embarcada, respeitando o conceito de modelos anêmicos simples.

Ponto a Melhorar:

Faltam validações internas:
Se o domínio é o coração da aplicação, deveria proteger seus próprios dados.
Exemplo clássico: não aceitar um produto sem nome ou uma categoria sem descrição.

📜 Comentário tradicional:
"Domínio sem validação é como portão sem cadeado: só espera a confusão entrar."

🔹 2. HelpApp.Domain.Test
O que vi:

ProductUnitTest.cs e CategoryUnitTest.cs estão presentes.

Ponto Positivo:

Organização clara: testes separados por entidade.

Estrutura de testes ajuda a validar o domínio.

Ponto a Melhorar:

Superficialidade:
Sem ver o conteúdo completo, parece ainda focar apenas em criação ou leitura, e não em regras de negócio (porque não há regras nas entidades).
Teste bom é aquele que tenta quebrar a entidade e garantir que ela resista bravamente.

📜 Comentário tradicional:
"Teste de botão liga-desliga é bonito, mas teste de tempestade é o que salva o navio."

🔹 3. HelpApp.Infra.Data/Repositories
O que vi:

ProductRepository.cs e CategoryRepository.cs implementados.

Ponto Positivo:

Agora existe interface para repositórios!

IProductRepository

ICategoryRepository

Ou seja: respeitaram a inversão de dependência que Clean Architecture exige:
"O domínio diz o que precisa ser feito, a infraestrutura decide como."

Ponto a Melhorar:

Interfaces ainda poderiam estar melhor agrupadas em uma pasta separada (Interfaces dentro do domínio, por exemplo), para manter a separação visual mais limpa.

E os métodos dentro dos repositórios deveriam ser só os essenciais: inserir, buscar, atualizar, deletar. Nada de colocar lógica de negócios ali!

📜 Comentário tradicional:
"Interface separada é como manual de instrução: se mistura com a máquina, confunde até o mecânico."

🔹 4. HelpApp.Infra.IoC
O que vi:

DependencyInjectionAPI.cs implementa corretamente a injeção dos repositórios via interfaces.

Ponto Positivo:

Agora está registrando as interfaces, não as implementações concretas diretamente!

Por exemplo:

csharp
Copiar
Editar
services.AddScoped<IProductRepository, ProductRepository>();
Exatamente o que Clean Architecture pede: quem consome nem precisa saber qual é a classe concreta.

O código de injeção está separado, organizado e claro.

Ponto a Melhorar:

Poderia, em uma versão ainda mais caprichada, separar injeções por responsabilidade (ApplicationServices, InfraServices, etc.) conforme o projeto crescer.

📜 Comentário tradicional:
"Injeção bem feita é como receita boa: ninguém vê o preparo, só sente o sabor."

🏛️ Resumo Tradicional da Avaliação

Critério	Avaliação
Entidades (pureza e independência)	8/10
Testes (estrutura e profundidade)	7/10
Repositórios (abstração e isolamento)	8,5/10
IoC (injeção correta e separação)	9/10
🎯 Nota Final: 8,5/10
Justificativa tradicional:

Estrutura de pastas melhor organizada e respeitando a inversão de dependência.

Domínio ainda poderia proteger melhor seus dados (validações internas).

Testes focados, mas poderiam ser mais desafiadores para as entidades.

IoC feito no padrão ideal.

📚 Resumo final no estilo clássico:
"Aqui a casa já tem alicerce, paredes, telhado e até cerca elétrica. Só falta colocar o alarme na porta (validação nas entidades) e pintar a casa (testes mais provocativos). No mais, trabalho de mestre de obras de respeito."
