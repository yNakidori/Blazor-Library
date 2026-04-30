window.readerFullscreen = () => {
    const el = document.querySelector('.reader-shell');

    if (!el) return;

    if (!document.fullscreenElement) {
        el.requestFullscreen();
    } else {
        document.exitFullscreen();
    }
};

window.readerMouseWatcher = (dotnetHelper) => {

    let timer;

    document.addEventListener("mousemove", () => {

        clearTimeout(timer);

        dotnetHelper.invokeMethodAsync(
            "MostrarHeaderTemporariamente");

        timer = setTimeout(() => { }, 3000);
    });
};