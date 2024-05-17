namespace QRCoder;

public class QRCodeSettings
{
    QRCodeGenerator.ECCLevel EccLevel { get; set; }
    bool ForceUtf8 { get; set; }
    bool Utf8BOM { get; set; }
    QRCodeGenerator.EciMode EciMode { get; set; }
    int RequestedVersion { get; set; }
}
