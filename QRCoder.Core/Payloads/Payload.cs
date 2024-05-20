namespace QRCoder.Payloads;

public abstract class Payload
{
    internal string ToPayloadStringInternal() => ToPayloadString();

    protected abstract string ToPayloadString();

    public virtual bool IsPayloadSpecificationMet(QRCodeSettings settings) => true;

    public virtual QRCodeSettings DefaultSettings { get => QRCodeSettings.PayloadDefault; }

    public virtual int Version { get { return -1; } }
    public virtual QRCodeGenerator.ECCLevel EccLevel { get { return QRCodeGenerator.ECCLevel.M; } }
    public virtual QRCodeGenerator.EciMode EciMode { get { return QRCodeGenerator.EciMode.Default; } }
}
