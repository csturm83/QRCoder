using QRCoder.Payloads;

namespace QRCoder;

// TODO: Defaults?

public class QRCode
{
    public static QRCodeData Create(Payload payload)
    {
        // Use payload.DefaultSettings
        throw new NotImplementedException();
    }

    public static QRCodeData Create(Payload payload, QRCodeGenerator.ECCLevel eccLevel)
    {
        // Start with payload.DefaultSettings, update eccLevel, check with payload.IsPayloadSpecificationMet
        QRCodeSettings settings = payload.DefaultSettings;
        settings.EccLevel = eccLevel;
        if (!payload.IsPayloadSpecificationMet(settings))
        {
            // throw Exception
        }
        throw new NotImplementedException();
    }

    public static QRCodeData Create(Payload payload, QRCodeSettings settings)
    {
        // Start with input parameter settings, check with payload.IsPayloadSpecificationMet
        if (!payload.IsPayloadSpecificationMet(settings))
        {
            // throw Exception
        } 
        throw new NotImplementedException();
    }

    public static QRCodeData Create(string plainText, QRCodeSettings settings)
    {
        throw new NotImplementedException();
    }

    // TODO: potentially add Create overload with single string plainText parameter that uses QRCodeSettings.PayloadDefault ??
    // TODO: If so, maybe rename QRCodeSettings.PayloadDefault to QRCodeSettings.Default or QRCodeSettings.DefaultSettings ??

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