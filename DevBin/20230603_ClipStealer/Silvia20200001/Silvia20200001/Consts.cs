using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte
{
	public static class Consts
	{
		public const string OUTPUT_DIR = @"C:\temp";

#if DEBUG
		public readonly static string STOLE_SOUND_FILE = @"..\..\..\..\Resource\Stole.wav";
#else
		public readonly static string STOLE_SOUND_FILE = Path.Combine(ProcMain.SelfDir, "Stole.wav");
#endif

	}
}
