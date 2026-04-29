window.readerFullscreen = () => {
    const el = document.querySelector('.reader-shell');

    if (!el) return;

    if (!document.fullscreenElement) {
        el.requestFullscreen();
    } else {
        document.exitFullscreen();
    }
};