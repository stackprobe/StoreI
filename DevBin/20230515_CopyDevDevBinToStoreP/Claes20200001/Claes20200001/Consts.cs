using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	public static class Consts
	{
		/// <summary>
		/// 入力ルートディレクトリのフォーマット
		/// -- {0} == devDirName
		/// </summary>
		public const string R_ROOT_DIR_FORMAT = @"C:\{0}";

		/// <summary>
		/// 出力ルートディレクトリのフォーマット
		/// -- {0} == devDirName
		/// -- {1} == alpha
		/// </summary>
		public const string W_ROOT_DIR_FORMAT = @"C:\home\GitHub\Store{1}\{0}";

		/// <summary>
		/// ソースディレクトリのローカル名のフォーマット(正規表現)
		/// </summary>
		public const string SRC_LOCAL_DIR_FORMAT = "^[A-Za-z]+20200001$";
	}
}
