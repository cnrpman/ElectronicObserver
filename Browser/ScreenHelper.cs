using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Browser
{
    static class ScreenHelper
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDC(
            string lpszDriver, // driver name
            string lpszDevice, // device name
            string lpszOutput, // not used; should be NULL
            Int64 lpInitData // optional printer data
        );
        [DllImport("gdi32.dll")]
        static extern uint GetDeviceCaps(
        IntPtr hdc, // handle to DC
        int nIndex // index of capability
        );
        [DllImport("user32.dll")]
        static extern bool SetProcessDPIAware();

        const int DRIVERVERSION = 0;
        const int TECHNOLOGY = 2;
        const int HORZSIZE = 4;
        const int VERTSIZE = 6;
        const int HORZRES = 8;
        const int VERTRES = 10;
        const int BITSPIXEL = 12;
        const int PLANES = 14;
        const int NUMBRUSHES = 16;
        const int NUMPENS = 18;
        const int NUMMARKERS = 20;
        const int NUMFONTS = 22;
        const int NUMCOLORS = 24;
        const int PDEVICESIZE = 26;
        const int CURVECAPS = 28;
        const int LINECAPS = 30;
        const int POLYGONALCAPS = 32;
        const int TEXTCAPS = 34;
        const int CLIPCAPS = 36;
        const int RASTERCAPS = 38;
        const int ASPECTX = 40;
        const int ASPECTY = 42;
        const int ASPECTXY = 44;
        const int SHADEBLENDCAPS = 45;
        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int SIZEPALETTE = 104;
        const int NUMRESERVED = 106;
        const int COLORRES = 108;
        const int PHYSICALWIDTH = 110;
        const int PHYSICALHEIGHT = 111;
        const int PHYSICALOFFSETX = 112;
        const int PHYSICALOFFSETY = 113;
        const int SCALINGFACTORX = 114;
        const int SCALINGFACTORY = 115;
        const int VREFRESH = 116;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;
        const int BLTALIGNMENT = 119;

        static Dpi _dpi;
        public static Dpi GetSystemDpi()
        {
            if (_dpi == null)
            {
                SetProcessDPIAware(); //重要
                IntPtr screenDC = GetDC(IntPtr.Zero);
                uint dpi_x = GetDeviceCaps(screenDC, /*DeviceCap.*/LOGPIXELSX);
                uint dpi_y = GetDeviceCaps(screenDC, /*DeviceCap.*/LOGPIXELSY);
                //_scaleUI.X = dpi_x / 96.0;
                //_scaleUI.Y = dpi_y / 96.0;
                _dpi = new Dpi(dpi_x, dpi_y);
                ReleaseDC(IntPtr.Zero, screenDC);
            }
            return _dpi;
        }
    }
}
