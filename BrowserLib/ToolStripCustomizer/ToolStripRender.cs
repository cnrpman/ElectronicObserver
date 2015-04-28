using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolStripCustomizer.ColorTables;

namespace ToolStripCustomizer
{
    public static class ToolStripRender
    {
        static ToolStripProfessionalRenderer _render;

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
    }
}
