const lstMenuItemHeader = document.querySelectorAll(".my-main-menu-item");
let currDataUrl = window.location.pathname;

lstMenuItemHeader.forEach(menuItemHeader => {
    if (currDataUrl === menuItemHeader.dataset.url) {
        removeActiveMenuItemHeader();
        addActiveMenuItemHeader(menuItemHeader);
    }
});

function addActiveMenuItemHeader(menuItemHeader) {
    menuItemHeader.classList.add("active");
}

function removeActiveMenuItemHeader() {
    lstMenuItemHeader.forEach(menuItemHeader => menuItemHeader.classList.remove("active"));
}