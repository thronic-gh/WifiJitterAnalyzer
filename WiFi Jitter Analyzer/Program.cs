using System;
using System.Windows.Forms;

namespace WiFi_Jitter_Analyzer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form1 mainfrm = new Form1(args);
			Application.Run(mainfrm);
		}
	}
}
