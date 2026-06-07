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
    let lastCall = 0;
    const THROTTLE_MS = 250;

    document.addEventListener("mousemove", () => {
        const now = Date.now();
        if (now - lastCall < THROTTLE_MS) return;
        lastCall = now;

        dotnetHelper.invokeMethodAsync("MostrarHeaderTemporariamente");
    });
};

window._ensurePdfJs = async (pdfJsUrl) => {
    if (window.pdfjsLib) return;
    return new Promise((resolve, reject) => {
        const s = document.createElement('script');
        s.src = pdfJsUrl;
        s.onload = () => resolve();
        s.onerror = (e) => reject(e);
        document.head.appendChild(s);
    });
};

window.initPdfViewer = async (canvasId, pdfUrl) => {
    try {
        // CDN urls (adjust versions if needed)
        const pdfJsUrl = "https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.16.105/pdf.min.js";
        const pdfWorkerUrl = "https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.16.105/pdf.worker.min.js";

        await window._ensurePdfJs(pdfJsUrl);

        if (window.pdfjsLib && window.pdfjsLib.GlobalWorkerOptions)
            window.pdfjsLib.GlobalWorkerOptions.workerSrc = pdfWorkerUrl;

        const canvas = document.getElementById(canvasId);
        if (!canvas) return;

        const ctx = canvas.getContext('2d');

        const loadingTask = window.pdfjsLib.getDocument(pdfUrl);
        const pdf = await loadingTask.promise;

        const viewer = {
            pdf,
            canvas,
            ctx,
            currentPage: 1,
            scale: 1.2,
            rendering: null,
            async renderPage(pageNumber) {
                const page = await this.pdf.getPage(pageNumber);
                const viewport = page.getViewport({ scale: this.scale });
                this.canvas.width = Math.floor(viewport.width);
                this.canvas.height = Math.floor(viewport.height);
                const renderContext = {
                    canvasContext: this.ctx,
                    viewport: viewport
                };
                this.rendering = page.render(renderContext).promise;
                await this.rendering;
                this.rendering = null;
            },
            async next() {
                if (this.currentPage >= this.pdf.numPages) return;
                this.currentPage++;
                await this.renderPage(this.currentPage);
            },
            async prev() {
                if (this.currentPage <= 1) return;
                this.currentPage--;
                await this.renderPage(this.currentPage);
            },
            async zoomIn() {
                this.scale = Math.min(this.scale + 0.2, 5);
                await this.renderPage(this.currentPage);
            },
            async zoomOut() {
                this.scale = Math.max(this.scale - 0.2, 0.4);
                await this.renderPage(this.currentPage);
            },
            async goTo(pageNumber) {
                if (pageNumber < 1 || pageNumber > this.pdf.numPages) return;
                this.currentPage = pageNumber;
                await this.renderPage(this.currentPage);
            },
            async destroy() {
                try {
                    // cancel rendering if any
                    if (this.rendering && this.rendering.cancel) this.rendering.cancel();
                } catch { }
                try { this.pdf = null; } catch { }
                // clear canvas
                this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
            }
        };

        window._pdfViewer = viewer;
        await viewer.renderPage(viewer.currentPage);
    } catch (ex) {
        console.error("initPdfViewer error:", ex);
    }
};

window.pdfViewerPrev = () => window._pdfViewer ? window._pdfViewer.prev() : null;
window.pdfViewerNext = () => window._pdfViewer ? window._pdfViewer.next() : null;
window.pdfViewerZoomOut = () => window._pdfViewer ? window._pdfViewer.zoomOut() : null;
window.pdfViewerZoomIn = () => window._pdfViewer ? window._pdfViewer.zoomIn() : null;
window.pdfViewerDestroy = () => window._pdfViewer ? window._pdfViewer.destroy() : null;