using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public class CTools
	{
		private static string cToolsFile
		{
			get
			{
				string file = "CTools.exe";

				if (File.Exists(file) == false)
					file = @"..\..\..\..\Tools\CTools.exe";

				file = FileTools.makeFullPath(file);
				return file;
			}
		}

		private static void runCTools(string args)
		{
			ProcessTools.runOnBatch("CTools.exe " + args, Path.GetDirectoryName(cToolsFile));
		}

		public static int wavFileToCsvFile(string rFile, string wFile, string stdoutFile)
		{
			int hz;

			if (File.Exists(rFile) == false)
				throw new FileNotFoundException(rFile);

			using (WorkingDir wd = new WorkingDir())
			{
				string wHzFile = wd.makePath();

				runCTools("/W2C " + rFile + " " + wFile + " " + wHzFile + " > " + stdoutFile);

				if (File.Exists(wFile) == false)
					throw new FileNotFoundException(wFile);

				hz = int.Parse(File.ReadAllText(wHzFile, Encoding.ASCII));
			}
			if (IntTools.isRange(hz, 1, IntTools.IMAX) == false)
				throw new Exception(".wav ファイルのサンプリングレートを認識出来ません。" + hz);

			return hz;
		}

		public static void csvFileToWavFile(string rFile, string wFile, int hz, string stdoutFile)
		{
			if (File.Exists(rFile) == false)
				throw new FileNotFoundException(rFile);

			using (WorkingDir wd = new WorkingDir())
			{
				runCTools("/C2W " + rFile + " " + wFile + " " + hz + " > " + stdoutFile);
			}
			if (File.Exists(wFile) == false)
				throw new FileNotFoundException(wFile);
		}

		public static void cutFile(string file, long startPos, long endPos)
		{
			runCTools("/FCUT " + file + " " + startPos + " " + endPos);
		}
	}
}
