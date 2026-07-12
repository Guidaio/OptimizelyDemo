# Builder return — Atividade B (README + secrets)

**Status:** concluido  
**Data:** 2026-07-12  
**Agente:** Builder (nivel 2/3)

## O que foi feito

| Path | Descricao |
|------|-----------|
| `README.md` (raiz) | Guia operacional: pre-requisitos, run, URLs, Register, troubleshooting |
| `src/OptimizelyDemo/README.md` | Ponte para o README raiz + run rapido |
| `secrets/local.env.example` | Template de credenciais (sem senha real) |
| `.gitignore` | `secrets/*` com excecao `!secrets/local.env.example` |

## Credenciais

- Exemplo versionado: `secrets/local.env.example`
- Arquivo local (nao git): `secrets/local.env` (usuario copia e preenche)
- Admin: criar em `/Util/Register` no primeiro run; usuario tipico `admin`

## Validacao sugerida

```powershell
Test-Path secrets\local.env.example   # True
git check-ignore -v secrets/local.env  # deve ignorar se existir
dotnet build src/OptimizelyDemo.sln
```

## Commit / push

- Mensagem: `docs: README operacional e template de credenciais locais`
- Branch: `main` → `origin/main`

## Pendencias

- Atividade C — testes
