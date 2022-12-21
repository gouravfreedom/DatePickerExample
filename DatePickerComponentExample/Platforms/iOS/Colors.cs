using CoreGraphics;
using UIKit;

namespace DT.iOS.DatePickerDialog
{
    internal static class Colors
    {
        private static readonly bool _supportDarkTheme = UIDevice.CurrentDevice.CheckSystemVersion(13, 0);

        public static CGColor[] GradientBackground()
        {
            if (_supportDarkTheme)
            {
                return new[]
                {
                    FromHex(0xDADADE).CGColor,
                    FromHex(0xDADADE).CGColor,
                    FromHex(0xDADADE).CGColor,
                };
            }
            else
            {
                return new[]
                {
                    FromHex(0xDADADE).CGColor,
                    FromHex(0xEAEAEE).CGColor,
                    FromHex(0xDADADE).CGColor,
                };
            }
        }

        public static UIColor Separator()
        {
            if (_supportDarkTheme)
                return FromHex(0xD1D1D6);
            else
                return FromHex(0xD1D1D6);
        }

        public static UIColor Text()
        {
            if (_supportDarkTheme)
                return FromHex(0x3993F8);
            else
                return FromHex(0x3993F8);
        }

        public static UIColor Accent()
        {
            if (_supportDarkTheme)
                return FromHex(0x3993F8);
            else
                return FromHex(0x3993F8);
        }

        private static UIColor FromHex(int color, int alpha = 255)
        {
            var red = (color >> 16) & 0xFF;
            var green = (color >> 8) & 0xFF;
            var blue = color & 0xFF;
            return UIColor.FromRGBA(red, green, blue, alpha);
        }
    }
}
