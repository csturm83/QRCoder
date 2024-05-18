namespace QRCoder.Renderers;

public class PngByteRendererSettings : RenderSettings
{
    public int PixelsPerModule { get; set; }
    public byte[] DarkColorRgba { get; set; }
    public byte[] LightColorRgba { get; set; }
    public bool DrawQuietZones { get; set; }
}
