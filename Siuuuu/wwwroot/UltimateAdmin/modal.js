const triggers = document.querySelectorAll("[data-modeltrigger]");
const dialogs = document.querySelectorAll("dialog");
const mainWrapper = document.getElementById("main-wrapper");

triggers.forEach(function (el) {
  el.addEventListener("click", () => {
    const getTarget = el.getAttribute("data-target");
    const target = document.querySelector(`[data-name="${getTarget}"]`);
    if (target.hasAttribute("open")) {
      target.close();
      mainWrapper.removeAttribute("inert");
    } else {
      target.showModal();
      mainWrapper.setAttribute("inert", "true");
    }
  });
});

/* Check for click in backdrop */
dialogs.forEach(function (el) {
  el.addEventListener("click", ({ target: dialog }) => {
    if (dialog.nodeName === "DIALOG") {
      dialog.close("dismiss");
      mainWrapper.removeAttribute("inert");
    }
  });
});
