# OptimizelyDemo (projeto CMS)

Aplicação Optimizely CMS 13 empty + modelagem do demo (Home, Standard, Hero, templates).

**Guia operacional completo (pré-requisitos, run, URLs, admin, LocalDB):** ver o [README na raiz do repositório](../../README.md).

## Run rápido

```powershell
sqllocaldb start MSSQLLocalDB
$env:ASPNETCORE_ENVIRONMENT = "Development"
dotnet run --urls "http://localhost:5001" --no-launch-profile
```

- Site: http://localhost:5001/
- Admin: http://localhost:5001/Optimizely/CMS
- Credenciais: copie `secrets/local.env.example` → `secrets/local.env` (na raiz do repo)

Template original Optimizely: pré-requisito .NET SDK 10+ e SQL LocalDB. Docker opcional não está habilitado neste demo.
