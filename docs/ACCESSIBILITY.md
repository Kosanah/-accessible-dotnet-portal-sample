# Accessibility — WCAG 2.1 AA patterns in this sample

## Implemented

- **1.1.1 Non-text content:** every form control has a `<label>`; tables have `<caption>` and `scope`; decorative elements have no alt text burden.
- **1.3.1 Info and relationships:** semantic `<header>`, `<nav aria-label>`, `<main>`, `<section aria-labelledby>`, headings in order, table headers.
- **1.4.3 Contrast (minimum):** body text 17.4:1, primary on white 10.4:1, muted text 7.0:1 — all above the 4.5:1 AA bar. See `_tokens.scss` for the checked values.
- **1.4.1 Use of colour:** errors are text + border, never colour alone.
- **2.1.1 Keyboard:** all actions are native buttons/links/inputs — no `div onclick`.
- **2.4.1 Bypass blocks:** skip link to `#main-content`, first in tab order.
- **2.4.3 Focus order / 2.4.7 Focus visible:** logical DOM order, 3px focus outline with offset, never `outline: none`.
- **3.3.1 / 3.3.2 Error identification & labels:** validation summary with `role="alert"` + per-field messages, `aria-describedby` hints.
- **4.1.3 Status messages:** success confirmation uses `aria-live="polite"`.

## How to test it (do all three — automated alone is not enough)

1. **axe DevTools:** run on Services, New, and Track pages. Target: 0 critical/serious issues. Fix in source, re-run, commit the fix — do not suppress axe rules without a comment explaining why.
2. **Keyboard-only pass:** Tab through every page, Shift+Tab back, Enter/Space to activate, Escape to close modals. No keyboard traps, no invisible focus.
3. **Screen-reader pass:** NVDA or JAWS — check skip link, headings list, form labels, error announcements, and the success live region. Note: this sample was built to these patterns; a production audit would still need a tester with assistive technology.

## What this does NOT claim

No accessibility certification (DHS Trusted Tester, IAAP WAS, CPACC) and no
formal WCAG training credential are claimed here. The value to verify is the
code above and this checklist — run axe and the keyboard pass yourself.
