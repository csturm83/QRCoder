﻿#if !NETSTANDARD1_3
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using static QRCoder.Base64QRCode;
using static QRCoder.QRCodeGenerator;

namespace QRCoder
{
    public class Base64QRCode : AbstractQRCode, IDisposable
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public Base64QRCode() {
        }

        public Base64QRCode(QRCodeData data) : base(data) {
        }

        public string GetGraphic(int pixelsPerModule)
        {
            return this.GetGraphic(pixelsPerModule, Color.Black, Color.White, true);
        }


        public string GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            return this.GetGraphic(pixelsPerModule, ColorTranslator.FromHtml(darkColorHtmlHex), ColorTranslator.FromHtml(lightColorHtmlHex), drawQuietZones, imgType);
        }

        public string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            if (imgType == ImageType.Png)
            {
                var pngCoder = new PngByteQRCode(QrCodeData);

                byte[] pngData;
                if (darkColor == Color.Black && lightColor == Color.White)
                {
                    pngData = pngCoder.GetGraphic(pixelsPerModule, drawQuietZones);
                }
                else
                {
                    byte[] darkColorBytes;
                    byte[] lightColorBytes;
                    if (darkColor.A != 255 || lightColor.A != 255)
                    {
                        darkColorBytes = new byte[] { darkColor.R, darkColor.G, darkColor.B, darkColor.A };
                        lightColorBytes = new byte[] { lightColor.R, lightColor.G, lightColor.B, lightColor.A };
                    }
                    else
                    {
                        darkColorBytes = new byte[] { darkColor.R, darkColor.G, darkColor.B };
                        lightColorBytes = new byte[] { lightColor.R, lightColor.G, lightColor.B };
                    }
                    pngData = pngCoder.GetGraphic(pixelsPerModule, darkColorBytes, lightColorBytes, drawQuietZones);
                }

                return Convert.ToBase64String(pngData, Base64FormattingOptions.None);
            }

#if SYSTEM_DRAWING
#pragma warning disable CA1416 // Validate platform compatibility
            var qr = new QRCode(QrCodeData);
            var base64 = string.Empty;
            using (Bitmap bmp = qr.GetGraphic(pixelsPerModule, darkColor, lightColor, drawQuietZones))
            {
                base64 = BitmapToBase64(bmp, imgType);
            }
            return base64;
#pragma warning restore CA1416 // Validate platform compatibility
#else
            throw new PlatformNotSupportedException("Only the PNG image type is supported on this platform.");
#endif
        }

#if SYSTEM_DRAWING
#if NET6_0_OR_GREATER
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
        public string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, Bitmap icon, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            var qr = new QRCode(QrCodeData);
            var base64 = string.Empty;
            using (Bitmap bmp = qr.GetGraphic(pixelsPerModule, darkColor, lightColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones))
            {
                base64 = BitmapToBase64(bmp, imgType);
            }
            return base64;
        }
#endif

#if SYSTEM_DRAWING
#if NET6_0_OR_GREATER
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
        private string BitmapToBase64(Bitmap bmp, ImageType imgType)
        {
            var base64 = string.Empty;
            ImageFormat iFormat;
            switch (imgType) {
                case ImageType.Png:
                    iFormat = ImageFormat.Png;
                    break;
                case ImageType.Jpeg:
                    iFormat = ImageFormat.Jpeg;
                    break;
                case ImageType.Gif:
                    iFormat = ImageFormat.Gif;
                    break;
                default:
                    iFormat = ImageFormat.Png;
                    break;
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bmp.Save(memoryStream, iFormat);
                base64 = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.None);
            }
            return base64;
        }
#endif

        public enum ImageType
        {
#if NET6_0_OR_GREATER
            [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
            Gif,
#if NET6_0_OR_GREATER
            [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
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

#endif