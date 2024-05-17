namespace QRCoder.Renderers;

public abstract class Renderer<TRenderSettings, T> : IRenderer where TRenderSettings:RenderSettings
    {
        protected QRCodeData QrCodeData { get; set; }

        protected Renderer() {
        }

        protected Renderer(QRCodeData data) {
            QrCodeData = data;
        }

        public void SetQRCodeData(QRCodeData data) {
            QrCodeData = data;
        }

        public abstract T Render(TRenderSettings settings);

    }
