# 🐾 Clyvo Care API - Monitoramento Preditivo de Saúde Animal

O **Clyvo Care** é uma plataforma de Backend desenvolvida para revolucionar o acompanhamento veterinário. Através da coleta de dados biométricos em tempo real, a API permite que tutores e clínicas monitorem sinais vitais de pets, possibilitando a detecção precoce de anomalias através de análise de dados.

---

## 🛠️ Tecnologias Utilizadas

* **Runtime:** .NET 10 (ASP.NET Core API)
* **Banco de Dados:** Oracle Database (via Entity Framework Core)
* **Documentação:** Swagger / OpenAPI
* **Padrão de Projeto:** DTO (Data Transfer Objects) e Repository-like pattern via Controllers.

---

## 🚀 Instruções de Instalação e Execução

1.  **Clonar o Repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/ClyvoCare.API.git](https://github.com/seu-usuario/ClyvoCare.API.git)
    ```
2.  **Configurar Banco de Dados:**
    As credenciais de acesso ao Oracle já estão configuradas no `appsettings.json`. Certifique-se de estar conectado à rede necessária para o acesso ao banco.
3.  **Aplicar Migrations:**
    No Console do Gerenciador de Pacotes do Visual Studio, execute:
    ```powershell
    Update-Database
    ```
4.  **Rodar a Aplicação:**
    Pressione `F5` ou utilize o comando `dotnet run`.

---

## 📖 Documentação dos Endpoints (Swagger)

Abaixo, a explicação de como utilizar cada funcionalidade disponível na interface do Swagger:

### 👤 Usuários (Tutores)
* `GET /api/Usuarios`: Lista todos os tutores cadastrados no sistema.
* `GET /api/Usuarios/{id}`: Busca os detalhes de um tutor específico.
* `POST /api/Usuarios`: Realiza o cadastro de um novo tutor. **Requisito:** Validação de e-mail e senha (mínimo 6 caracteres).
* `PUT /api/Usuarios/{id}`: Atualiza informações de cadastro.
* `DELETE /api/Usuarios/{id}`: Remove um tutor do sistema.

### 🐶 Pets
* `POST /api/Pets`: Vincula um novo animal de estimação a um tutor existente.
* `GET /api/Pets/especie/{especie}`: **Filtro Parametrizado** para buscar todos os animais de uma determinada espécie (ex: "Gato").
* `GET /api/Pets/tutor/{usuarioId}`: Lista todos os pets pertencentes a um tutor específico.
* `GET /api/Pets/busca/{nome}`: Busca pets por parte do nome (ideal para dashboards de busca).

### 🩺 Logs de Saúde (Monitoramento)
* `POST /api/LogsSaude`: Recebe dados biométricos (Peso, Temperatura, Batimentos). É o ponto de entrada para sensores IoT e predições de IA.
* `GET /api/LogsSaude/pet/{petId}`: Retorna o histórico cronológico de saúde de um pet, permitindo a visualização de tendências e alertas médicos.

---

## 🧠 Diferencial de IA e Negócio
A estrutura da tabela `TB_CC_LOG_SAUDE` foi projetada para suportar funções analíticas de banco de dados. Os dados coletados servem como base para modelos de **Machine Learning** que podem prever crises de saúde animal antes que os sintomas se tornem visíveis, garantindo o bem-estar e a longevidade dos pets.

---

## ✒️ Integrantes
* **Seu Nome / RM**
* **Nome do Colega (se houver) / RM**
