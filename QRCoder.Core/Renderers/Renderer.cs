using QRCoder.Payloads;

namespace QRCoder.Renderers;

public abstract class Renderer<TRenderSettings, T> : IRenderer where TRenderSettings:RenderSettings
    {
        // TODO: static convenience method for each QRCode.Create overload
        public static TRenderer Create<TRenderer>(Payload payload, QRCodeSettings settings) where TRenderer : Renderer<TRenderSettings, T>, IRenderer, new()
        {
            return QRCode.Create(payload, settings)
                .RenderAs<TRenderer>();
        }
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
