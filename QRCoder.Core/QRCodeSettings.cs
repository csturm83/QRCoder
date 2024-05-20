namespace QRCoder;

public class QRCodeSettings
{
    public const int AutoDetectVersion = -1;

    public static QRCodeSettings PayloadDefault => new QRCodeSettings
    {
        EccLevel = QRCodeGenerator.ECCLevel.M,
        ForceUtf8 = false,
        Utf8BOM = false,
        EciMode = QRCodeGenerator.EciMode.Default,
        RequestedVersion = AutoDetectVersion
    };

    public QRCodeGenerator.ECCLevel EccLevel { get; set; }
    public bool ForceUtf8 { get; set; }
    public bool Utf8BOM { get; set; }
    public QRCodeGenerator.EciMode EciMode { get; set; }
    public int RequestedVersion { get; set; }
}
