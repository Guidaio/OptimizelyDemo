# Optimizely Demo

Site demo de **Optimizely CMS 13** (.NET 10) para aprendizado prático: content types, blocks, templates Razor e admin.

Repositório: https://github.com/Guidaio/OptimizelyDemo

## Pré-requisitos

| Requisito | Notas |
|-----------|--------|
| [.NET SDK 10+](https://dotnet.microsoft.com/download) | O projeto usa `net10.0` |
| SQL Server LocalDB | Instância `(LocalDb)\MSSQLLocalDB` (SQL Server 2017+ / Visual Studio) |
| Windows (este setup) | Fluxo documentado com LocalDB; Linux/macOS exige SQL externo ou Docker |
| Git | Opcional para clonar |
| [GitHub CLI `gh`](https://cli.github.com/) | Opcional |

Verificar:

```powershell
dotnet --list-sdks
sqllocaldb info MSSQLLocalDB
```

## Credenciais locais

Não versionamos senhas. Use o template:

```powershell
Copy-Item secrets\local.env.example secrets\local.env
# Edite secrets\local.env com usuario/email/senha do admin
```

- `secrets/local.env` fica **fora do git** (pasta `secrets/` ignorada, exceto o `.example`).
- A senha é a que **você** definir em `/Util/Register` na primeira subida.

## Como rodar

```powershell
cd C:\Users\guisi\source\repos\OptimizelyDemo   # ou o clone
sqllocaldb start MSSQLLocalDB
cd src\OptimizelyDemo
$env:ASPNETCORE_ENVIRONMENT = "Development"
dotnet restore
dotnet build
dotnet run --urls "http://localhost:5001" --no-launch-profile
```

Ou, com o perfil de launch (já aponta para `:5001`):

```powershell
cd src\OptimizelyDemo
dotnet run
```

### Banco de dados

Em Development, a connection string em `appsettings.Development.json` usa o catalog **OptimizelyDemo** no LocalDB. Na primeira subida o CMS cria o schema (`CreateDatabaseSchema`).

> O `.mdf` que vem em alguns templates pode ser incompatível com LocalDB antigo. Neste demo o banco é criado no LocalDB (sem anexar MDF do template).

## URLs

| Recurso | URL |
|---------|-----|
| Site (start page) | http://localhost:5001/ |
| Admin / Edit | http://localhost:5001/Optimizely/CMS |
| Login | http://localhost:5001/Util/Login |
| Registro do 1º admin | http://localhost:5001/Util/Register |

No CMS 13 o admin **não** é `/episerver` — use `/Optimizely/CMS`.

## Primeiro admin (`/Util/Register`)

1. Suba o site pela primeira vez.
2. Abra http://localhost:5001/ (pode redirecionar para Register) ou vá direto a `/Util/Register`.
3. Crie o usuário (ex.: `admin`), e-mail e senha **fortes**.
4. Guarde a senha em `secrets/local.env` (não no git).
5. Depois do primeiro admin, `/Util/Register` deixa de ficar disponível (SingleUserOnly).
6. Acesse http://localhost:5001/Optimizely/CMS e faça login.

## Estrutura útil

```
src/OptimizelyDemo/          # app CMS
  Models/Pages/              # HomePage, StandardPage
  Models/Blocks/             # HeroBlock
  Views/                     # templates + _Layout
  Business/Initialization/   # start page + hosts :5001
secrets/local.env.example    # template de credenciais
.cursor/                     # agentes Cursor (demo)
```

## Troubleshooting

### Porta 5001 em uso

```powershell
Get-NetTCPConnection -LocalPort 5001 -ErrorAction SilentlyContinue |
  ForEach-Object { Stop-Process -Id $_.OwningProcess -Force }
```

Ou use outra porta: `dotnet run --urls "http://localhost:5080" --no-launch-profile`  
(se mudar a porta, alinhe o host Primary em Settings > Applications ou no init).

### LocalDB parado / não encontrado

```powershell
sqllocaldb start MSSQLLocalDB
sqllocaldb info MSSQLLocalDB
```

Se o banco precisar ser recriado (cuidado — apaga dados locais):

```powershell
sqlcmd -S "(LocalDb)\MSSQLLocalDB" -Q "ALTER DATABASE [OptimizelyDemo] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [OptimizelyDemo]; CREATE DATABASE [OptimizelyDemo];"
```

### Admin redireciona para outra porta / HTTPS quebrado

Este demo configura **Primary** em `localhost:5001` (HTTP). Prefira sempre http://localhost:5001 para site e admin. Evite bookmarks em `:5000` como Edit host.

### Build falha com arquivo bloqueado

Pare o processo `OptimizelyDemo` / `dotnet` que esteja rodando e rode `dotnet build` de novo.

### SDK / target `net10.0`

Instale .NET SDK 10+ (`winget install Microsoft.DotNet.SDK.10`).

### License Optimizely

Em muitos setups locais o empty template sobe sem `*license.config`. Se aparecer tela de license, aplique a license de desenvolvimento da Optimizely (arquivo local, não versionar).

## Agentes Cursor

Workspace multi-agente: ver `CURSOR.md` e `AGENTS.md`. Handoff em `.cursor/handoff/ACTIVE.md`.

## Licença do código

Demo educacional — sem license de produção Optimizely incluída.
