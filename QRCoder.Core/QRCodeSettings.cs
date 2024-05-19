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

    QRCodeGenerator.ECCLevel EccLevel { get; set; }
    bool ForceUtf8 { get; set; }
    bool Utf8BOM { get; set; }
    QRCodeGenerator.EciMode EciMode { get; set; }
    int RequestedVersion { get; set; }
}
