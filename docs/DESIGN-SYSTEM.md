# Design system vs. component library vs. framework

A question this role asks about directly, so here is the distinction as
implemented in this repo:

- **Framework (Bootstrap 5 here):** gives you layout, grid, and ready components. You can ship fast, but every team that only uses Bootstrap ends up looking slightly different.
- **Component library:** a set of reusable components (button, card, modal) — what Bootstrap also provides, and what `_components.scss` extends.
- **Enterprise design system:** the layer *above* that — tokens + rules + components owned centrally: colours, type scale, spacing, focus behaviour, and usage guidance. In this repo that layer is `wwwroot/scss/_tokens.scss` + `_components.scss` + this doc. A team adopting it does not pick its own primary colour or focus style; it uses the token.

## Working within one, independently

1. Use tokens, never hard-coded colours/spacing in a view.
2. Use the system component first; only build a new variant if the system has no equivalent, and propose it back to the system.
3. When the system rolls out a new version, update tokens in one place — views should not need edits.
4. Accessibility is part of the token contract: contrast and focus are token values, not per-page decisions.

## Modernization note

This sample is built with current ASP.NET Core 8 / Bootstrap 5 patterns, not
legacy Web Forms patterns. Where a legacy environment still has MVC/Web Forms
pages, the same approach applies: wrap the old page in the new token layer
first (so it looks and focuses consistently), then migrate behaviour page by page.
