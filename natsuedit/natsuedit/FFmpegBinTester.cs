using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public class FFmpegBinTester
	{
		public static void doTest()
		{
			using (WorkingDir wd = new WorkingDir())
			{
				string mwFile = wd.makePath("muon.wav");
				string redirFile = wd.makePath();

				File.Copy(muonWavFile, mwFile);

				ProcessTools.runOnBatch(
					"ffprobe.exe " + mwFile + " 2> " + redirFile,
					FFmpegBin.i.getBinDir()
					);

				if (hasAudioStream(redirFile) == false)
					throw new Exception("ffmpeg test error");
			}
		}

		private static bool hasAudioStream(string file)
		{
			foreach (string line in FileTools.readAllLines(file, Encoding.ASCII))
				if (line.Contains("Stream") && line.Contains("Audio:"))
					return true;

			return false;
		}

		private static string muonWavFile
		{
			get
			{
				string file = "muon_wav.dat";

				if (File.Exists(file) == false)
					file = @"..\..\..\..\doc\muon_wav.dat";

				file = FileTools.makeFullPath(file);
				return file;
			}
		}
	}
}
