using System;
using static QRCoder.Base64QRCode;
using static QRCoder.QRCodeGenerator;

namespace QRCoder
{
    public class Base64QRCode : AbstractQRCode, IDisposable
    {
        private PngByteQRCode qr;

        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public Base64QRCode() {
            qr = new PngByteQRCode();
        }

        public Base64QRCode(QRCodeData data) : base(data) {
            qr = new PngByteQRCode(data);
        }

        public override void SetQRCodeData(QRCodeData data) {
            this.qr.SetQRCodeData(data);
        }

        public string GetGraphic(int pixelsPerModule)
        {
            return this.GetGraphic(pixelsPerModule, Color.Black, Color.White, true);
        }


        public string GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            return this.GetGraphic(pixelsPerModule, ColorTranslator.FromHtml(darkColorHtmlHex), ColorTranslator.FromHtml(lightColorHtmlHex), drawQuietZones, imgType);
        }

        private string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            byte[] pngBytes = qr.GetGraphic(pixelsPerModule, ColorTranslator.ToRgbByteArray(darkColor), ColorTranslator.ToRgbByteArray(lightColor));
            return Convert.ToBase64String(pngBytes);
        }

        

        public enum ImageType
        {
            Gif,
            Jpeg,
            Png
        }

    }

    public static class Base64QRCodeHelper
    {
        public static string GetQRCode(string plainText, int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new Base64QRCode(qrCodeData))
                return qrCode.GetGraphic(pixelsPerModule, darkColorHtmlHex, lightColorHtmlHex, drawQuietZones, imgType);
        }
    }
}
