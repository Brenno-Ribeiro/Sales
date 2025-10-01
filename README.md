# Sales

## Aviso Técnico
Durante a configuração inicial, encontramos problemas de compatibilidade com o **ReportViewer**, pois a versão utilizada no projeto não é totalmente compatível com o **Visual Studio 2026** e **.NET 9**. Este é um ponto importante a ser considerado.

---

## Pré-requisitos

Antes de iniciar o projeto, você precisará ter instalado em sua máquina:

- [Docker](https://www.docker.com/get-started)
- [Visual 2026](https://visualstudio.microsoft.com/insiders/)

## Passo a Passo para Rodar o Projeto

1. **Clonar o repositório**  
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd <NOME_DO_PROJETO>


2. **Subir o ambiente Docker**  
   Certifique-se de que o Docker está rodando na sua máquina. Em seguida, execute o comando na raiz do projeto para subir o banco

```bash
docker compose up -d

```

3. **Rodar o projeto no Visual Studio 2026** 
Por questões de compatibilidade com o ReportViewer o mesmo não roda em ambiente docker. 

