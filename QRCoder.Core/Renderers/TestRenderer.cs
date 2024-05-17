using QRCoder;
using QRCoder.Renderers;

public class TestRenderer : Renderer<TestRenderSettings, int>
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
}

public class TestRenderSettings : RenderSettings
{

}