using QRCoder.Payloads;

namespace QRCoder.Renderers;

public abstract class Renderer<TRenderer, TRenderSettings, T> : IRenderer<TRenderSettings, T>
        where TRenderSettings : RenderSettings 
        where TRenderer : IRenderer<TRenderSettings, T>, new()
{
    // TODO: static convenience method for each QRCode.Create overload
    public static TRenderer Create(Payload payload, QRCodeSettings settings)
    {
        return QRCode.Create(payload, settings)
            .RenderAs<TRenderer>();
    }
    protected QRCodeData QrCodeData { get; set; }

    protected Renderer()
    {
    }

    protected Renderer(QRCodeData data)
    {
        QrCodeData = data;
    }

    public void SetQRCodeData(QRCodeData data)
    {
        QrCodeData = data;
    }

    public abstract T Render(TRenderSettings settings);

}
