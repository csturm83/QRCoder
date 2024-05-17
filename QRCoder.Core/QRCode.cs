using QRCoder.Payloads;

namespace QRCoder;

// TODO: Defaults?

public class QRCode
{
    public static QRCodeData Create(Payload payload)
    {
        throw new NotImplementedException();
    }

    public static QRCodeData Create(Payload payload, QRCodeGenerator.ECCLevel eccLevel)
    {
        throw new NotImplementedException();
    }

    public static QRCodeData Create(Payload payload, QRCodeSettings settings)
    {
        throw new NotImplementedException();
    }

    public static QRCodeData Create(string plainText, QRCodeSettings settings)
    {
        throw new NotImplementedException();
    }

    // private static QRCodeData Create(BitArray bitArray, ECCLevel eccLevel, int version)
    // {
    //     throw new NotImplementedException();
    // }
}

// public QRCodeData CreateQrCode(Payload payload)
// public QRCodeData CreateQrCode(Payload payload, ECCLevel eccLevel)
// public QRCodeData CreateQrCode(string plainText, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1)
// public QRCodeData CreateQrCode(byte[] binaryData, ECCLevel eccLevel)
// private static QRCodeData GenerateQrCode(BitArray bitArray, ECCLevel eccLevel, int version)