using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolStripCustomizer.ColorTables;

namespace ToolStripCustomizer
{
    public static class ToolStripRender
    {
		static readonly Font _window_font;
        static ToolStripProfessionalRenderer _render;

		static ToolStripRender()
		{
			var file = @"custom_font.txt";
			try
			{
				if (File.Exists(file))
				{
					var fonts = File.ReadAllText(file).Split(',');
					float size;
					if (fonts.Length == 2 && float.TryParse(fonts[1], out size))
					{
						_window_font = new Font(fonts[0], size, FontStyle.Regular, GraphicsUnit.Pixel);
					}
				}
				else
					throw new Exception();
			}
			catch
			{
				_window_font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
			}
		}

		public static Font Window_Font { get { return _window_font; } }

		public static ToolStripProfessionalRenderer Render
        {
            get
            {
                if (_render == null)
                {
                    _render = new ToolStripProfessionalRenderer(new VS2012LightColorTable());
                }
                return _render;
            }
        }

		public static void SetRender(ToolStrip toolStrip)
		{
			toolStrip.Renderer = Render;
			toolStrip.Font = Window_Font;
		}
    }
}
