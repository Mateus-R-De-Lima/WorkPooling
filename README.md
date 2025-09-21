# WorkPooling

Este projeto foi desenvolvido com o objetivo de aprender e explorar o uso das bibliotecas Quartz.NET e Hangfire para agendamento e execução de tarefas em segundo plano em aplicações .NET.

## 🚀 Tecnologias Utilizadas

- **Quartz.NET**: Uma biblioteca robusta para agendamento de tarefas em segundo plano, permitindo a definição de cronogramas complexos e controle preciso sobre a execução das tarefas. Ideal para cenários que exigem agendamentos recorrentes ou baseados em expressões CRON.

- **Hangfire**: Uma solução simples e eficaz para processamento de tarefas em segundo plano em aplicações .NET, com suporte a tarefas recorrentes, execução atrasada e um painel web para monitoramento.

## 🧪 Objetivo do Projeto

O principal objetivo deste repositório é servir como um estudo prático para entender as diferenças, vantagens e desvantagens entre o Quartz.NET e o Hangfire, implementando ambos em um cenário de agendamento de tarefas.

## 📂 Estrutura do Repositório

- **WorkPooling.API**: API principal que expõe endpoints para interação com as tarefas agendadas.
- **WorkPooling.Hangfire**: Implementação de tarefas utilizando o Hangfire.
- **WorkPooling.Quartz**: Implementação de tarefas utilizando o Quartz.NET.
- **WorkPooling.Services**: Serviços compartilhados entre as implementações.
- **WorkPooling.Work**: Lógica de negócios relacionada às tarefas.

## ⚙️ Como Executar

1. Clone este repositório:
   ```bash
   git clone https://github.com/Mateus-R-De-Lima/WorkPooling.git
   cd WorkPooling
   ```

2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

3. Execute a aplicação:
   ```bash
   dotnet run --project WorkPooling.API
   ```

4. Acesse a API em `http://localhost:5000`.

## 📚 Aprendizados

- Compreensão das diferenças entre Quartz.NET e Hangfire, como facilidade de uso, flexibilidade e suporte a agendamentos complexos.
- Implementação de tarefas recorrentes e atrasadas com ambas as bibliotecas.
- Exploração de painéis de monitoramento e estratégias de persistência de dados.

