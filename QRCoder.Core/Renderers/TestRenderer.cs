using QRCoder;
using QRCoder.Payloads;
using QRCoder.Renderers;

internal class TestRenderer : Renderer<TestRenderSettings, int>
{
    public TestRenderer()
    {
    }

    public TestRenderer(QRCodeData data) : base(data)
    {
    }

    public override int Render(TestRenderSettings settings)
    {
        throw new NotImplementedException();
    }

    // TODO: other variations of overloads that call into the static Create<> method
    public static int Render(Payload payload, QRCodeSettings qrSettings, TestRenderSettings settings)
    {
        return Create<TestRenderer>(payload, qrSettings).Render(settings);
    }

    private static void SampleTest()
    {
        Payload payload = null!;
        QRCodeSettings qrSettings = null!;
        TestRenderSettings renderSettings = null!;

        // three-step rendering
        int rendered3 = QRCode.Create(payload, qrSettings)
            .RenderAs<TestRenderer>()
            .Render(renderSettings);

        // two-step rendering
        int rendered2 = TestRenderer.Create<TestRenderer>(payload, qrSettings)
            .Render(renderSettings);

        // one-shot rendering
        int rendered1 = TestRenderer.Render(payload, qrSettings, renderSettings);
    }
}

public class TestRenderSettings : RenderSettings
{

}