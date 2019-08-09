using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public static class FFmpeg
	{
		public static bool isFFmpegDir(string dir)
		{
			return getFFmpegFile(dir) != null;
		}

		private static string getFFmpegFile(string dir)
		{
			if (Directory.Exists(dir) == false)
				return null;

			foreach (string file in FileTools.lssFiles(dir))
				if (StringTools.equalsIgnoreCase(Path.GetFileName(file), "ffmpeg.exe"))
					return file;

			return null; // not found
		}

		public static string getBinDir()
		{
			if (Gnd.i.ffmpegDir == "")
				throw new Exception("ffmpeg のパスが指定されていません。");

			string file = getFFmpegFile(Gnd.i.ffmpegDir);

			if (file == null)
				throw new Exception("ffmpeg のパスに問題があります。");

			return Path.GetDirectoryName(file);
		}
	}
}
