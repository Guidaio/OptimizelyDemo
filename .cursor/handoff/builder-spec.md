# Builder spec — Atividade A (Git)

**Nivel:** 3  
**Status:** proposta — aguarda `[Builder] APROVADO`  
**Data:** 2026-07-12  
**Plano:** A → B → C → … (usuario aprovou sequencia)

## Objetivo

Inicializar repositorio git na raiz, `.gitignore` na raiz, historico logico por fase (Fases 0–3 + fix hosts), configurar remote e push.

## Pre-requisitos

- Git instalado e no PATH
- Usuario fornece URL do remote (GitHub/GitLab) **antes do push**
- **Nao commitar:** `bin/`, `obj/`, `App_Data/`, credenciais em texto claro

## Higiene minima (nesta atividade)

Antes do primeiro commit, **redigir** em `.cursor/handoff/builder-return.md`:
- Remover senha e email em texto claro; substituir por `(ver README local / criar no primeiro run)`
- Manter usuario `admin` ou `(configurado no Register)`

README operacional completo fica para **Atividade B**.

## 1. Criar `.gitignore` na raiz

Unificar regras de `src/OptimizelyDemo/.gitignore` + raiz:

```
# Build
bin/
obj/
artifacts/

# CMS / DB local
App_Data/
*license.config
modules/

# IDE / OS
.vs/
.vscode/
.idea/
*.user
.DS_Store
thumbs.db

# Node (futuro)
node_modules/

# Secrets locais (Atividade B)
.env
.env.*
secrets/
```

Manter `src/OptimizelyDemo/.gitignore` (pode espelhar ou referenciar raiz).

## 2. `git init` na raiz

```powershell
cd C:\Users\guisi\source\repos\OptimizelyDemo
git init
git branch -M main
```

## 3. Commits retroativos (ordem obrigatoria)

> Historico **logico**: cada commit adiciona o escopo da fase. Arquivos que evoluiram entre fases entram no commit da fase que **introduziu** a feature; alteracoes posteriores entram no commit da fase seguinte.

### Commit 1 — `chore: workspace e agentes Cursor`

```
.cursor/rules/
.cursor/handoff/          # builder-return ja redigido
docs/DEMO_ROADMAP.md
AGENTS.md
CURSOR.md
README.md                   # raiz, se existir
.gitignore                  # raiz
```

### Commit 2 — `feat(cms): fase 0 — scaffold CMS empty`

```
src/OptimizelyDemo.sln
src/OptimizelyDemo/OptimizelyDemo.csproj
src/OptimizelyDemo/Program.cs
src/OptimizelyDemo/Startup.cs              # so MapContent(); sem MapGet
src/OptimizelyDemo/appsettings.json
src/OptimizelyDemo/appsettings.Development.json
src/OptimizelyDemo/nuget.config
src/OptimizelyDemo/Properties/launchSettings.json   # versao inicial ok
src/OptimizelyDemo/README.md
src/OptimizelyDemo/Resources/
src/OptimizelyDemo/.gitignore
src/.gitkeep                             # se existir
```

**Nao incluir ainda:** Models/, Controllers/, Views/, Business/, wwwroot/

### Commit 3 — `feat(cms): fase 1 — Home/Standard + init start page`

```
src/OptimizelyDemo/Models/Pages/
src/OptimizelyDemo/Controllers/
src/OptimizelyDemo/Views/_ViewImports.cshtml
src/OptimizelyDemo/Views/HomePage/Index.cshtml      # view minima
src/OptimizelyDemo/Views/StandardPage/Index.cshtml  # view minima
src/OptimizelyDemo/Business/Initialization/SiteContentInitialization.cs
```

**Estado do init neste commit:** versao Fase 1 com **dois hosts** (Primary `:5001` + Edit `:5000`). Reconstruir a partir de `review-notes.md` Fase 1 se necessario — Commit 4 corrige.

### Commit 4 — `fix(cms): hosts dev — admin estavel em :5001`

Apenas diff em:

```
src/OptimizelyDemo/Business/Initialization/SiteContentInitialization.cs  # unico Primary HTTP :5001
src/OptimizelyDemo/Properties/launchSettings.json                        # prioriza :5001
```

### Commit 5 — `feat(cms): fase 2 — Hero block + content area`

```
src/OptimizelyDemo/Models/Blocks/HeroBlock.cs
src/OptimizelyDemo/Models/Pages/HomePage.cs           # MainContentArea
src/OptimizelyDemo/Views/HomePage/Index.cshtml        # + Content Area
src/OptimizelyDemo/Views/Shared/Blocks/HeroBlock.cshtml
```

### Commit 6 — `feat(cms): fase 3 — layout e templates`

```
src/OptimizelyDemo/Views/Shared/_Layout.cshtml
src/OptimizelyDemo/Views/_ViewStart.cshtml
src/OptimizelyDemo/Views/HomePage/Index.cshtml        # versao final com layout
src/OptimizelyDemo/Views/StandardPage/Index.cshtml    # versao final
src/OptimizelyDemo/Views/Shared/Blocks/HeroBlock.cshtml  # versao final BEM
src/OptimizelyDemo/wwwroot/css/site.css
src/OptimizelyDemo/Properties/launchSettings.json     # so http://localhost:5001
```

## 4. Validacao pos-commits

```powershell
git log --oneline          # 6 commits na ordem acima
git status                 # clean (ignorando bin/obj)
dotnet build src/OptimizelyDemo.sln   # HEAD compila
```

## 5. Remote e push

**So apos usuario informar URL:**

```powershell
git remote add origin <URL>
git push -u origin main
```

Se remote ja existir, `git remote set-url origin <URL>`.

## Criterio de aceite

| # | Criterio |
|---|----------|
| 1 | `.git/` na raiz; branch `main` |
| 2 | `.gitignore` raiz ignora bin/obj/App_Data |
| 3 | 6 commits na ordem da tabela |
| 4 | Nenhuma credencial/senha no historico |
| 5 | `dotnet build` OK no HEAD |
| 6 | Push concluido (se URL fornecida) |

## Entrega

Atualizar `.cursor/handoff/builder-return.md`:

- Comandos executados
- Hash dos 6 commits (`git log --oneline`)
- URL do remote + confirmacao de push
- Pendencias para Atividade B (README, credenciais)

## Fora de escopo

- Projeto de testes (Atividade C)
- README operacional completo (Atividade B)
- Tag v0.3.0 (Atividade E)

## Proximo

Atividade B — higiene + README operacional.
