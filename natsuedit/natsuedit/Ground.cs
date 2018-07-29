using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Charlotte
{
	public class Gnd
	{
		private static Gnd _i = null;

		public static Gnd i
		{
			get
			{
				if (_i == null)
					_i = new Gnd();

				return _i;
			}
		}

		private Gnd()
		{ }

		// ---- conf data ----

		public int rFileSizeWarning_MB = 500;

		public void loadConf()
		{
			try
			{
				List<string> lines = new List<string>();

				foreach (string line in FileTools.readAllLines(getConfFile(), StringTools.ENCODING_SJIS))
					if (line != "" && line[0] != ';')
						lines.Add(line);

				int c = 0;

				// items >

				rFileSizeWarning_MB = IntTools.toInt(lines[c++], 1);

				// < items
			}
			catch
			{ }
		}

		private string getConfFile()
		{
			return Path.Combine(Program.selfDir, Path.GetFileNameWithoutExtension(Program.selfFile) + ".conf");
		}

		// ---- saved data ----

		public string ffmpegDir = ""; // "" == 未設定
		public string lastOpenedFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "movie.mp4"); // ダミー
		public int mainWin_L;
		public int mainWin_T;
		public int mainWin_W = -1; // -1 == MainWin_LTWH 未定義
		public int mainWin_H;
		public bool mainWinMaximized = false;
		public Color selectingColor = Color.FromArgb(128, 0, 255, 255);
		public Color selectColor = Color.FromArgb(128, 0, 0, 255);
		public bool _ファイルを閉じるとき保存するか確認しない = false;
		public bool _起動時にffmpegのパスを設定する = false;

		public void loadData()
		{
			try
			{
				string[] lines = File.ReadAllLines(getDataFile(), Encoding.UTF8);
				int c = 0;

				// items >

				ffmpegDir = lines[c++];
				lastOpenedFile = lines[c++];
				mainWin_L = int.Parse(lines[c++]);
				mainWin_T = int.Parse(lines[c++]);
				mainWin_W = int.Parse(lines[c++]);
				mainWin_H = int.Parse(lines[c++]);
				mainWinMaximized = StringTools.toFlag(lines[c++]);
				selectingColor = IntTools.toColor(int.Parse(lines[c++]));
				selectColor = IntTools.toColor(int.Parse(lines[c++]));
				_ファイルを閉じるとき保存するか確認しない = StringTools.toFlag(lines[c++]);
				_起動時にffmpegのパスを設定する = StringTools.toFlag(lines[c++]);

				// < items
			}
			catch
			{ }
		}

		public void saveData()
		{
			try
			{
				List<string> lines = new List<string>();

				// items >

				lines.Add(ffmpegDir);
				lines.Add(lastOpenedFile);
				lines.Add("" + mainWin_L);
				lines.Add("" + mainWin_T);
				lines.Add("" + mainWin_W);
				lines.Add("" + mainWin_H);
				lines.Add(StringTools.toString(mainWinMaximized));
				lines.Add("" + IntTools.toInt(selectingColor));
				lines.Add("" + IntTools.toInt(selectColor));
				lines.Add(StringTools.toString(_ファイルを閉じるとき保存するか確認しない));
				lines.Add(StringTools.toString(_起動時にffmpegのパスを設定する));

				// < items

				File.WriteAllLines(getDataFile(), lines, Encoding.UTF8);
			}
			catch
			{ }
		}

		private string getDataFile()
		{
			return Path.Combine(Program.selfDir, Path.GetFileNameWithoutExtension(Program.selfFile) + ".dat");
		}

		// ----

		public Logger logger = new Logger();
		public MovieExtensions movieExtensions = new MovieExtensions();
		public ExtensionsOptions extensionsOptions = new ExtensionsOptions();
		public string bootOpenFile = null; // null == ファイルを開かない。
		public MediaData md = null; // null == 未オープン
		public PostBox<string> progressMessage = new PostBox<string>();
		public PostBox<string> progressOptionalMessage = new PostBox<string>();
		public bool cancelled = false;
		public NamedEventPair mediaDataSync = new NamedEventPair();
		public bool mediaDataCancelled;
		public MediaSavedData qsd = null; // null == 未クイックセーブ
	}
}
