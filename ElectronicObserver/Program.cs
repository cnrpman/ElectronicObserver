using ElectronicObserver.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicObserver {
	static class Program {

		public static readonly System.Drawing.Font Window_Font = ToolStripCustomizer.ToolStripRender.Window_Font;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			Utility.Configuration.Instance.Load();
			ToolStripCustomizer.ToolStripRender.RendererTheme = (ToolStripCustomizer.ToolStripRenderTheme)Utility.Configuration.Config.UI.ThemeID;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new FormMain() );
		}
	}
}
