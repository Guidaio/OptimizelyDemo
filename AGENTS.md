# Agentes — Optimizely Demo

Entrada: `CURSOR.md`

## Papeis

| Agente | Funcao | Prefixo | Rule |
|--------|--------|---------|------|
| Orchestrator | Spec, roadmap, diagnostico | `[Orchestrator]` | orchestrator-agent |
| Builder | Codigo e config Optimizely | `[Builder] APROVADO` | builder-agent |
| Reviewer | Revisao pos-build | `[Reviewer]` | reviewer-agent |
| Consultant | Teoria CMS/Optimizely | `[Consultant]` | consultant-agent |

Contrato: `.cursor/rules/base-contract.mdc`

## Handoff

| Arquivo | Funcao |
|---------|--------|
| `.cursor/handoff/ACTIVE.md` | Estado ativo — Read primeiro |
| `docs/DEMO_ROADMAP.md` | Fases do demo |
| `builder-spec.md` | Spec para Builder (nivel 3) |
| `builder-return.md` | Retorno do Builder |
| `review-notes.md` | Notas do Reviewer |

## Niveis Builder

| Nivel | Entrada |
|-------|---------|
| 2 | `[Builder] APROVADO — <frase>` |
| 3 | Spec em `builder-spec.md` |

## Fluxo tipico

1. **Consultant** — entender conceito (content type, block, template)
2. **Orchestrator** — spec da fase + criterio de aceite
3. **Builder** — implementa
4. **Reviewer** — valida modelagem, codigo, anti-patterns CMS
