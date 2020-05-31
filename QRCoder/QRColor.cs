using System;
namespace QRCoder
{
    internal static class ColorTranslator
    {
        public static byte[] ToRgbByteArray(Color c)
        {
            return new[] { c.R, c.G, c.B };
        }

        public static string ToHtml(Color c) 
        {
            return $"#{c.R.ToString("X2", null)}{c.G.ToString("X2", null)}{c.B.ToString("X2", null)}";
        }

        public static Color FromHtml(string htmlColor)
        {
            if ((htmlColor == null) || (htmlColor.Length == 0))
                throw new ArgumentException("Color must be specified.", nameof(htmlColor));
            // #RRGGBB or #RGB
            if (htmlColor[0] != '#' ||
                htmlColor.Length != 7 && htmlColor.Length != 4)
            {
                throw new ArgumentException("Color must be formatted #RRGGBB or #RGB.", nameof(htmlColor));
            }
            if (htmlColor.Length == 7)
            {
                return new Color
                {
                    R = Convert.ToByte(htmlColor.Substring(1, 2), 16),
                    G = Convert.ToByte(htmlColor.Substring(3, 2), 16),
                    B = Convert.ToByte(htmlColor.Substring(5, 2), 16)
                };
            }
            else
            {
                return new Color
                {
                    R = Convert.ToByte($"{htmlColor[1]}{htmlColor[1]}", 16),
                    G = Convert.ToByte($"{htmlColor[2]}{htmlColor[2]}", 16),
                    B = Convert.ToByte($"{htmlColor[3]}{htmlColor[3]}", 16)
                };
            }
        }
    }

    internal struct Color
    {
        public static readonly Color Black = new Color(0, 0, 0);

        public static readonly Color White = new Color(255, 255, 255);

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public byte R { get; set; }

        public byte G { get; set; }

        public byte B { get; set; }
    }

    internal struct Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }
    }

}
