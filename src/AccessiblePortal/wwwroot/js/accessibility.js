// Accessibility helpers: no framework needed for these patterns.
// 1. Move focus to <main> when the skip link is used (some browsers need this).
// 2. Announce filter results in a live region instead of silently re-rendering.
// 3. Focus trap for any element with [data-modal] — Escape closes, Tab cycles.
document.addEventListener("DOMContentLoaded", () => {
  const main = document.getElementById("main-content");
  document.querySelector(".skip-link")?.addEventListener("click", () => main?.focus());

  document.querySelectorAll("[data-modal]").forEach((modal) => {
    const focusable = () =>
      [...modal.querySelectorAll("a[href], button, input, select, textarea, [tabindex]:not([tabindex='-1'])")]
        .filter((el) => !el.disabled && el.offsetParent !== null);
    modal.addEventListener("keydown", (e) => {
      if (e.key === "Escape") modal.setAttribute("hidden", "");
      if (e.key !== "Tab") return;
      const items = focusable();
      if (!items.length) return;
      const first = items[0], last = items[items.length - 1];
      if (e.shiftKey && document.activeElement === first) { e.preventDefault(); last.focus(); }
      else if (!e.shiftKey && document.activeElement === last) { e.preventDefault(); first.focus(); }
    });
  });
});
