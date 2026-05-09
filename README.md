# Clyvo Care API - Monitoramento Preditivo de Pets

## Descrição do Projeto
O Clyvo Care é uma solução de monitoramento de saúde para animais de estimação, integrando dados de sensores (peso, temperatura, batimentos) para prever possíveis riscos à saúde. Esta API foi desenvolvida em .NET 10 para gerenciar tutores, pets e logs históricos de saúde.

## Instruções de Instalação e Execução
1. **Pré-requisitos:** SDK do .NET 10 e acesso ao banco de dados Oracle.
2. **Configuração:** No arquivo `appsettings.json`, insira sua connection string do Oracle.
3. **Migrações:** Execute os comandos abaixo no Console do Gerenciador de Pacotes para criar as tabelas:
   - `Update-Database`
4. **Execução:** Execute o projeto através do Visual Studio (F5) ou via comando `dotnet run`.

## Documentação das Rotas
A documentação interativa está disponível via **Swagger** em: `https://localhost:[PORTA]/swagger`

### Endpoints Principais:
- **Usuários:** - `POST /api/Usuarios`: Cadastra um novo tutor.
- **Pets:**
  - `POST /api/Pets`: Cadastra um animal vinculado a um tutor.
  - `GET /api/Pets/especie/{especie}`: Filtra pets por espécie.
- **Logs de Saúde:**
  - `POST /api/LogsSaude`: Registra novos sinais vitais (IA/IoT).
  - `GET /api/LogsSaude/pet/{petId}`: Histórico completo de saúde de um pet.
