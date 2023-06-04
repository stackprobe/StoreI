using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using Charlotte.Commons;
using System.Media;

namespace Charlotte
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// none
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			this.ClipMonitorTimer.Enabled = true;
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.ClipMonitorEnded = true;
			this.ClipMonitorTimer.Enabled = false;
		}

		private bool ClipMonitorEnded = false;

		private void ClipMonitorTimer_Tick(object sender, EventArgs e)
		{
			if (this.ClipMonitorEnded) // 念のため
				return;

			{
				string text = Clipboard.GetText();

				if (!string.IsNullOrEmpty(text))
				{
					File.WriteAllText(NextOutputFilePath(".txt"), text, Encoding.UTF8);
					PostSteal();
					return;
				}
			}

			{
				Image image = Clipboard.GetImage();

				if (image != null)
				{
					image.Save(NextOutputFilePath(".png"), ImageFormat.Png);
					PostSteal();
					return;
				}
			}
		}

		private string NextOutputFilePath(string ext)
		{
			string file = Path.Combine(Consts.OUTPUT_DIR, SCommon.SimpleDateTime.Now().ToTimeStamp() + ext);
			file = SCommon.ToCreatablePath(file);
			return file;
		}

		private void PostSteal()
		{
			new SoundPlayer(Consts.STOLE_SOUND_FILE).Play();
			Clipboard.Clear();
			GC.Collect(); // 2bs
		}
	}
}
