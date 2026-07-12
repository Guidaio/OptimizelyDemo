# Demo Roadmap — Optimizely CMS

## Fase 0 — Setup
- Instalar templates Optimizely (.NET)
- Criar projeto CMS em `src/`
- Rodar local + license dev (Optimizely)
- Confirmar admin + site renderizando

## Fase 1 — Modelagem basica
- Content type: Home Page
- Content type: Standard Page
- Propriedades: Title, MainBody, MetaTitle, MetaDescription

## Fase 2 — Blocos
- Block: Hero (Title, Subtitle, Image, CTA text/link)
- Content Area na Home para blocos

## Fase 3 — Templates
- Razor template Home
- Razor template Standard Page
- Partial do Hero block

## Fase 4 — Integracao leve
- Servico .NET injetado no template (ex: footer com ano/ambiente)
- Ou API read simples consumida no render

## Fase 5 — Revisao
- Reviewer: modelagem, SOLID, anti-patterns CMS
- Consultant: mapear o que aprendeu vs Umbraco

## Referencia Umbraco -> Optimizely

| Umbraco | Optimizely |
|---------|------------|
| Document Type | Content Type |
| Property | Property |
| Template | View / Template |
| Content node | Content item |
| Block List / Grid | Content Area / Blocks |
