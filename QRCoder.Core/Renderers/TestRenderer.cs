using QRCoder;
using QRCoder.Payloads;
using QRCoder.Renderers;

internal class TestRenderer : Renderer<TestRenderer, TestRenderSettings, byte[]>
{
    public TestRenderer()
    {
    }

    public TestRenderer(QRCodeData data) : base(data)
    {
    }

    public override byte[] Render(TestRenderSettings settings)
    {
        throw new NotImplementedException();
    }

    // TODO: other variations of overloads that call into the static Create<> method
    public static byte[] Render(Payload payload, QRCodeSettings qrSettings, TestRenderSettings settings)
    {
        return Create(payload, qrSettings).Render(settings);
    }

    private static void SampleTest()
    {
        Payload payload = null!;
        QRCodeSettings qrSettings = null!;
        TestRenderSettings renderSettings = null!;

        // three-step rendering
        byte[] rendered3 = QRCode.Create(payload, qrSettings)
            .RenderAs<TestRenderer>()
            .Render(renderSettings);

        // two-step rendering
        byte[] rendered2 = TestRenderer.Create(payload, qrSettings)
            .Render(renderSettings);

        // one-shot rendering
        byte[] rendered1 = TestRenderer.Render(payload, qrSettings, renderSettings);
    }
}

public class TestRenderSettings : RenderSettings
{

}