# Accessible Public Services Portal — Sample

**Portfolio sample by Hari Krishna Kosana — Senior Full Stack .NET Engineer**
GitHub: https://github.com/Kosanah · LinkedIn: https://www.linkedin.com/in/hari-jdsabnj9652

A full-stack sample that shows the exact mix this kind of enterprise role asks for:
.NET + C# on the back end, and a front end you can actually use with a keyboard
and a screen reader. It is a **demonstration project with fictional public-service
data — not client work, not a State of Iowa system, and it contains no real
citizen or client data.**

## What it demonstrates, mapped to the role

| Role weight | In this repo |
|---|---|
| .NET / C# ~40% | ASP.NET Core MVC + Web API, EF Core, SQL Server, services, validation, secure coding |
| Front-end / UI / UX ~40% | HTML5, Sass, JavaScript, Bootstrap + a small token-based design system, responsive layouts, reusable components |
| Middleware / APIs ~10% | REST API for service requests, request logging / error-handling middleware, JSON responses |
| SQL Server ~10% | EF Core `DbContext`, migrations-ready model, indexed queries, parameterized queries only |
| Accessibility — core, across all of it | WCAG 2.1 AA patterns: skip link, semantic landmarks, labels, focus visible, 4.5:1+ contrast, keyboard-operable modal and tabs, `aria-live` status, axe + manual test checklist in `docs/ACCESSIBILITY.md` |

## What it is

A citizen-facing portal where a user can:
1. Browse public services (cards, filterable, keyboard navigable)
2. Submit a service request through a labelled, validated form with clear errors
3. Track a request by reference number
4. Use the whole flow without a mouse, and with a screen reader announcing status changes

Back end: `src/AccessiblePortal/` — ASP.NET Core 8, MVC + API controllers,
EF Core + SQL Server.
Front end: Bootstrap 5 for layout, plus `wwwroot/scss/` — design tokens and
components that sit *on top of* Bootstrap. That distinction matters: Bootstrap
is a component library/framework; the token layer in `docs/DESIGN-SYSTEM.md`
is the design-system part — colours, spacing, type, focus, and component
variants owned in one place so every team ships the same UI.

## Run it

```bash
# Requires .NET 8 SDK and SQL Server (LocalDB works for the sample)
dotnet restore
dotnet ef database update   # or let the app create the dev database
dotnet run --project src/AccessiblePortal
# Open https://localhost:5001
```

Set the connection string in `appsettings.json` (`ConnectionStrings:DefaultConnection`).
No secrets are committed — use User Secrets / environment variables in real use.

## Front-end / UI work to look at first

- `src/AccessiblePortal/Views/Shared/_Layout.cshtml` — skip link, landmarks, nav
- `src/AccessiblePortal/Views/Services/Index.cshtml` — service cards, filter, request form
- `src/AccessiblePortal/wwwroot/scss/_tokens.scss` — design tokens
- `src/AccessiblePortal/wwwroot/scss/_components.scss` — button, card, form, alert, modal
- `src/AccessiblePortal/wwwroot/js/accessibility.js` — focus trap, keyboard tabs, live regions

## Accessibility — honest scope

This sample implements WCAG 2.1 AA *patterns* and documents how to test them
(axe DevTools, keyboard-only pass, and a screen-reader pass — see
`docs/ACCESSIBILITY.md`). It does **not** claim a WCAG certification, formal
WCAG training credential, or production accessibility audit. Those are
separate credentials; what you can verify here is the code and the checklist.

## Back-end work to look at first

- `src/AccessiblePortal/Controllers/ServicesController.cs` — MVC, validation, PRG pattern
- `src/AccessiblePortal/Controllers/ServicesApiController.cs` — REST API, middleware-friendly responses
- `src/AccessiblePortal/Data/AppDbContext.cs` — SQL Server, EF Core
- `src/AccessiblePortal/Services/ServiceRequestService.cs` — business rules, no SQL strings
- `src/AccessiblePortal/Middleware/RequestLoggingMiddleware.cs` — logging, no sensitive data logged
- `azure-pipelines.yml` — Azure DevOps CI/CD: restore, build, test, publish

## Tests

```bash
dotnet test
```

`tests/AccessiblePortal.Tests/ServiceRequestTests.cs` covers validation,
status transitions, and the reference-number format. Accessibility is tested
in the browser with axe + manual checks, not by unit tests alone — see the docs.

## Related experience (from my resume, not from this sample)

- Booked By (2025–now): multi-tenant SaaS, .NET 10, React, PostgreSQL, Redis
- Mayo Clinic (2024): healthcare APIs, FHIR/HL7, HIPAA-aware services, Angular, Azure
- Delta Airlines (2021–2023): high-volume booking/operations APIs, Kafka, Redis, Azure
- State of PA (2019–2021): government enterprise apps, React, AWS, SQL Server
- Wells Fargo, Vodafone: banking and telecom enterprise platforms

## License

MIT — sample code only.
