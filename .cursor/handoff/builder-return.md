# Builder return — Atividade A (Git)

**Status:** concluido  
**Data:** 2026-07-12  
**Agente:** Builder (nivel 3)

## Credenciais admin (repo publico)

| Campo | Valor |
|-------|-------|
| Usuario | `admin` (ou criar no `/Util/Register` no primeiro run) |
| Senha / email | *(ver README local / criar no primeiro run — nao versionar)* |

## Commits (`git log --oneline`)

```
6368658 feat(cms): fase 3 — layout e templates
c93f4c7 feat(cms): fase 2 — Hero block + content area
0fb81eb fix(cms): hosts dev — admin estavel em :5001
2276052 feat(cms): fase 1 — Home/Standard + init start page
eac2e6f feat(cms): fase 0 — scaffold CMS empty
888a434 chore: workspace e agentes Cursor
```

## Remote / push

| Item | Valor |
|------|-------|
| URL | https://github.com/Guidaio/OptimizelyDemo |
| Remote | `origin` → `https://github.com/Guidaio/OptimizelyDemo.git` |
| Branch | `main` tracking `origin/main` |
| Push | **OK** — `git push -u origin main` concluido |

## Validacao

| Check | Resultado |
|-------|-----------|
| 6 commits na ordem | OK |
| `git status` clean | OK apos este return |
| `dotnet build src/OptimizelyDemo.sln` | OK |
| Sem senha/email admin no historico | OK (scrub em `builder-spec` via filter-branch) |

## Comandos principais

```powershell
git init; git branch -M main
# 6 commits por fase (ver log)
gh repo create Guidaio/OptimizelyDemo --public
git remote add origin https://github.com/Guidaio/OptimizelyDemo.git
git push -u origin main
```

## Pendencias Atividade B

- README operacional completo
- Documentar armazenamento local de credenciais (fora do git)
