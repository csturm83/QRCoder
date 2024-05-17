namespace QRCoder.Renderers;

public interface IRenderer
{
    void SetQRCodeData(QRCodeData data);
}

public interface IRenderer<TRenderSettings, T> where TRenderSettings : RenderSettings
{
    T Render(TRenderSettings settings);
}