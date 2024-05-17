namespace QRCoder.Payloads;

public abstract class Payload
{
    public abstract override string ToString();

    public virtual int Version { get { return -1; } }
    public virtual QRCodeGenerator.ECCLevel EccLevel { get { return QRCodeGenerator.ECCLevel.M; } }
    public virtual QRCodeGenerator.EciMode EciMode { get { return QRCodeGenerator.EciMode.Default; } }
}
