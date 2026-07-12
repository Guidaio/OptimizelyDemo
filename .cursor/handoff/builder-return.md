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
db74015 feat(cms): fase 3 — layout e templates
c93f4c7 feat(cms): fase 2 — Hero block + content area
0fb81eb fix(cms): hosts dev — admin estavel em :5001
2276052 feat(cms): fase 1 — Home/Standard + init start page
eac2e6f feat(cms): fase 0 — scaffold CMS empty
888a434 chore: workspace e agentes Cursor
```

> O commit seguinte (`docs: …`) so atualiza este return/ACTIVE; historico logico das fases permanece nos 6 acima.

## Remote / push

| Item | Valor |
|------|-------|
| URL | https://github.com/Guidaio/OptimizelyDemo |
| Remote | `origin` → `https://github.com/Guidaio/OptimizelyDemo.git` |
| Branch | `main` tracking `origin/main` |
| Push | **OK** |

## Validacao

| Check | Resultado |
|-------|-----------|
| 6 commits de fase na ordem | OK |
| `dotnet build src/OptimizelyDemo.sln` | OK |
| Sem senha/email admin no historico | OK |

## Pendencias Atividade B

- README operacional completo
- Documentar armazenamento local de credenciais (fora do git)
