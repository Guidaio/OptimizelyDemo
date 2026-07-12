# Review notes — Fase 3 (Templates)

**Data:** 2026-07-12  
**Agente:** Reviewer  
**Fontes:** `.cursor/handoff/builder-spec.md` (Fase 3), `.cursor/handoff/builder-return.md`, `src/OptimizelyDemo/Views/`, `wwwroot/css/site.css`, `Properties/launchSettings.json`  
**Veredito:** aprovado

> Historico: Fase 0 aprovada 2026-07-10; Fase 1 e Fase 2 aprovadas 2026-07-12.

## Resumo

Entrega Fase 3 unifica Home e Standard via `_Layout` + `_ViewStart`, elimina shell HTML duplicado, evolui partial Hero com markup semantico e CSS leve, e alinha `launchSettings` a `:5001` apenas. Dividas das Fases 1–2 (views duplicadas, Hero barebones, `:5000` no profile) quitadas. Sem vazamento para integracao Fase 4.

## Criterios (solicitados)

| # | Criterio | Evidencia | Status |
|---|----------|-----------|--------|
| 1 | `_Layout` reutilizado por Home e Standard | `Views/_ViewStart.cshtml` → `_Layout`; `HomePage/Index.cshtml` e `StandardPage/Index.cshtml` so conteudo em `<article>` | OK |
| 2 | Sem HTML duplicado | Unico `<!DOCTYPE>` / `<html>` em `Views/Shared/_Layout.cshtml`; page views sem shell | OK |
| 3 | Partial Hero elaborado (markup + CSS) | `Views/Shared/Blocks/HeroBlock.cshtml` — section BEM (`hero`, `hero__title`, `hero__cta`, `hero__media`); estilos em `wwwroot/css/site.css` | OK |
| 4 | Escopo respeitado (sem integracao Fase 4) | Sem novos services/APIs/content types; footer estatico no layout; CSS proprio leve (sem Bootstrap) | OK |
| 5 | Regressao: build, site :5001, admin pos-login | `dotnet build` 0 erros; smoke `GET /` 200 + `site-header` + `site.css`; `GET /css/site.css` 200; `GET /Optimizely/CMS` 302 → `http://localhost:5001/Util/Login` (sem `:5000`) | OK |

## Criterios spec (builder-spec.md)

| # | Criterio | Status |
|---|----------|--------|
| 1 | `_Layout` existe e reutilizado | OK |
| 2 | Home template dedicado | OK — Title, MainBody, MainContentArea |
| 3 | Standard template dedicado | OK — Title + MainBody via layout |
| 4 | Partial Hero elaborado | OK |
| 5 | Sem HTML duplicado | OK |
| 6 | Compila e sobe | OK |
| 7 | Admin + site OK | OK — regressao em :5001 revalidada |

## Templates / CMS

- **`_Layout`:** meta SEO via cast `SitePageData` (MetaTitle → Title → Name); header com brand + link Admin; footer minimo; `~/css/site.css`.
- **Home / Standard:** `PropertyFor` em Title/MainBody — on-page edit preservado.
- **Hero partial:** `Layout = null` — correto para block view (evita duplo shell).
- **`launchSettings.json`:** apenas `http://localhost:5001` — atende sugestao Reviewer Fase 2.
- **Hosts application:** nao alterados nesta fase (Primary HTTP `:5001` da Fase 2 permanece) — coerente com spec.

## Anti-patterns / divida (nao bloqueantes)

1. **CTA no Hero** usa `href="@Model.CtaLink"` direto (nao `PropertyFor`) — aceitavel para link; titulo/subtitulo/imagem mantem `PropertyFor`.
2. **Footer estatico** — proposital; Fase 4 pode injetar servico (ambiente/ano).
3. **NU1902 MailKit** — transitivo; inalterado.
4. Credenciais demo no `builder-return.md` — mesmo aviso fases anteriores.

## Escopo

Dentro do escopo Fase 3. Fora de escopo respeitado (sem integracao .NET, sem novos types/blocks, sem design system pesado).

## Ajustes pedidos ao Builder

Nenhum. Nada a refazer.

## Proximo (Orchestrator)

- Spec Fase 4 — integracao leve (.NET service no template ou API read simples).
