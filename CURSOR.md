# Optimizely Demo — porta de entrada

Workspace para aprender **Optimizely CMS** (.NET) na pratica, com multi-agent no Cursor.

## Agentes

| Agente | Prefixo | Funcao |
|--------|---------|--------|
| Orchestrator | `[Orchestrator]` | Spec, roadmap, diagnostico (read-only) |
| Builder | `[Builder] APROVADO` | Implementacao aprovada |
| Reviewer | `[Reviewer]` | Revisao tecnica e de CMS (read-only) |
| Consultant | `[Consultant]` | Teoria CMS/Optimizely, duvidas, entrevista |

Detalhe: `AGENTS.md`

## Comecar

1. Abra esta pasta como workspace no Cursor
2. Leia `.cursor/handoff/ACTIVE.md`
3. Novo chat com prefixo do agente + prompt em `.cursor/handoff/prompts/`

## Demo (objetivo)

Projeto pequeno em `src/` com:
- Content types (Home, Standard Page, Hero Block)
- Templates Razor
- Start page + blocos editaveis
- Um exemplo de integracao .NET simples

Nao precisa ser producao. Foco: entender modelagem, admin e renderizacao.
