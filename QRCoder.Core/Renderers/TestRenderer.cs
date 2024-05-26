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

    private static void SampleTest()
    {
        Payload payload = null!;
        QRCodeSettings qrSettings = null!;
        TestRenderSettings renderSettings = null!;

        // 'traditional' three-step rendering
        QRCodeData qrData = QRCode.Create(payload, qrSettings);
        TestRenderer renderer = new TestRenderer(qrData);
        byte[] renderedt3 = renderer.Render(renderSettings);

        // fluent three-step rendering
        byte[] rendered3 = QRCode.Create(payload, qrSettings)
            .RenderAs<TestRenderer>()
            .Render(renderSettings);

        // fluent two-step rendering
        byte[] rendered2 = TestRenderer.Create(payload, qrSettings)
            .Render(renderSettings);

        // one-shot rendering
        byte[] rendered1 = TestRenderer.Render(payload, qrSettings, renderSettings);
    }
}

public class TestRenderSettings : RenderSettings
{

}