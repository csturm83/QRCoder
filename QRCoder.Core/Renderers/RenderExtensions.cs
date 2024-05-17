namespace QRCoder.Renderers;

public static class RenderExtensions
{
    public static TRenderer RenderAs<TRenderer>(this QRCodeData data)
        where TRenderer : IRenderer, new()
    {
        TRenderer renderer = new TRenderer();
        renderer.SetQRCodeData(data);
        return renderer;
    }
}
