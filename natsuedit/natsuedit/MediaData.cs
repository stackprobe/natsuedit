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
	public class MediaData : IDisposable
	{
		private string _origFile;
		private string _ext;
		private WorkingDir _wd = new WorkingDir();
		private string _duplFile;
		private string _imgDir;
		private string _wavFile;
		private string _wavCsvFile;
		private int _wavHz;

		public MediaData(string file)
		{
			try
			{
				_origFile = file;
				_ext = Path.GetExtension(file);

				if (Gnd.i.movieExtensions.contains(_ext) == false)
					throw new FailedOperation("指定されたファイルは動画ファイルではありません。");

				// サイズ・チェック
				{
					long fileSize = new FileInfo(file).Length;

					if (Gnd.i.rFileSizeWarning_MB * 1000000L < fileSize)
					{
						if (BusyDlg.self == null)
							throw null; // never

						Gnd.i.mediaDataSync.waitForMillis(0); // clear
						Gnd.i.mediaDataCancelled = false;

						BusyDlg.self.BeginInvoke((MethodInvoker)delegate
						{
							if (MessageBox.Show(
								"指定されたファイルは、けっこうデカいようです。\n" +
								"このソフトは数分～数十分程度の短い動画の編集を想定しています。\n" +
								"デカすぎる動画ファイルを読み込むと作業ファイルがディスクの空き領域を使い果たしてしまうかもしれません。\n" +
								"あと、多分もの凄く時間が掛かります。\n" +
								"続行しますか？",
								Program.APP_TITLE + " / 警告",
								MessageBoxButtons.OKCancel,
								MessageBoxIcon.Warning
								) != DialogResult.OK
								)
								Gnd.i.mediaDataCancelled = true;

							Gnd.i.mediaDataSync.set();
						});

						Gnd.i.mediaDataSync.waitForMillis(-1);

						if (Gnd.i.mediaDataCancelled)
							throw new Cancelled();
					}
				}

				_duplFile = _wd.makePath() + _ext;
				_imgDir = _wd.makePath();
				_wavFile = _wd.makePath() + ".wav";
				_wavCsvFile = _wd.makePath() + ".csv";

				Directory.CreateDirectory(_imgDir);

				loadFile();

				Gnd.i.lastOpenedFile = file;
			}
			catch (Exception e)
			{
				_wd.Dispose();
				_wd = null;

				throw new ExceptionCarrier(e);
			}
		}

		public class AudioStream
		{
			public int mapIndex;

			public void quickSave(MediaSavedData dest)
			{
				dest.addInt(mapIndex);
			}

			public void quickLoad(MediaSavedData src)
			{
				mapIndex = src.readInt();
			}
		}

		public class VideoStream
		{
			public int mapIndex;
			public int fps;
			public int w;
			public int h;

			public void quickSave(MediaSavedData dest)
			{
				dest.addInt(mapIndex);
				dest.addInt(fps);
				dest.addInt(w);
				dest.addInt(h);
			}

			public void quickLoad(MediaSavedData src)
			{
				mapIndex = src.readInt();
				fps = src.readInt();
				w = src.readInt();
				h = src.readInt();
			}
		}

		private List<AudioStream> _audioStreams = new List<AudioStream>();
		private List<VideoStream> _videoStreams = new List<VideoStream>();

		private AudioStream _targetAudioStream;
		private VideoStream _targetVideoStream;

		public EditData ed;

		private void loadFile()
		{
			string redirFile = _wd.makePath();

			Gnd.i.progressMessage.post("入力ファイルをコピーしています...");

			File.Copy(_origFile, _duplFile);

			Gnd.i.progressMessage.post("入力ファイルのフォーマットを調べています...");

			ProcessTools.runOnBatch(
				"ffprobe.exe " + _duplFile + " 2> " + redirFile,
				FFmpegBin.i.getBinDir()
				);

			foreach (string fLine in FileTools.readAllLines(redirFile, Encoding.ASCII))
			{
				string line = fLine.Trim();

				if (line.StartsWith("Stream"))
				{
					List<string> sInts = StringTools.tokenize(line, StringTools.DIGIT, true, true);
					int mapIndex = int.Parse(sInts[1]);

					List<string> tokens = StringTools.tokenize(line, " ,", false, true);

					if (line.Contains("Audio:"))
					{
						AudioStream stream = new AudioStream();

						stream.mapIndex = mapIndex;

						_audioStreams.Add(stream);
					}
					else if (line.Contains("Video:"))
					{
						VideoStream stream = new VideoStream();

						stream.mapIndex = mapIndex;

						{
							int index = ArrayTools.indexOf<string>(tokens.ToArray(), "fps", StringTools.comp);

							if (index == -1)
								throw new Exception("映像ストリームの秒間フレーム数を取得出来ませんでした。");

							stream.fps = IntTools.toInt(double.Parse(tokens[index - 1]));
						}

						{
							string token = Utils.getTokenDigitFormat(tokens.ToArray(), "9x9");

							if (token == null)
								throw new Exception("映像ストリームの画面サイズを取得出来ませんでした。");

							List<string> s_wh = StringTools.tokenize(token, StringTools.DIGIT, true, true);

							stream.w = int.Parse(s_wh[0]);
							stream.h = int.Parse(s_wh[1]);
						}

						if (IntTools.isRange(stream.fps, 1, IntTools.IMAX) == false)
							throw new FailedOperation("映像ストリームの秒間フレーム数を認識出来ません。" + stream.fps);

						if (IntTools.isRange(stream.w, 1, IntTools.IMAX) == false)
							throw new FailedOperation("映像ストリームの画面の幅を認識出来ません。" + stream.w);

						if (IntTools.isRange(stream.h, 1, IntTools.IMAX) == false)
							throw new FailedOperation("映像ストリームの画面の高さを認識出来ません。" + stream.h);

						_videoStreams.Add(stream);
					}
					else
					{
						// "Data:" とか
					}
				}
			}

			if (_audioStreams.Count == 0)
				throw new FailedOperation("音声ストリームがありません。");

			if (_videoStreams.Count == 0)
				throw new FailedOperation("映像ストリームがありません。");

			_targetAudioStream = _audioStreams[0];
			_targetVideoStream = _videoStreams[0];

			// ---- Audio Stream ----

			Gnd.i.progressMessage.post("音声ストリームを取り出しています...");

			ProcessTools.runOnBatch(
				"ffmpeg.exe -i " + _duplFile + " -map 0:" + _targetAudioStream.mapIndex + " -ac 2 " + _wavFile + " 2> " + _wd.makePath("mk_wav_stderr.txt"),
				FFmpegBin.i.getBinDir()
				);

			Gnd.i.progressMessage.post("音声ストリームを展開しています...");

			_wavHz = CTools.wavFileToCsvFile(_wavFile, _wavCsvFile, _wd.makePath("mk_wav-csv_stdout.txt"));

			// 1 <= 音声の長さ < IMAX

			{
				long size = new FileInfo(_wavCsvFile).Length;

				if (size % 12L != 0)
					throw new Exception("wav-csv data size error");

				long count = size / 12L;

				if (count == 0L)
					throw new FailedOperation("音声ストリームに最初のサンプリング値がありません。");

				if (IntTools.IMAX <= count)
					throw new FailedOperation("音声ストリームが長過ぎます。");
			}

			// ---- Video Stream ----

			Gnd.i.progressMessage.post("映像ストリームを展開しています...");

			ProcessTools.runOnBatch(
				"ffmpeg.exe -i " + _duplFile + " -map 0:" + _targetVideoStream.mapIndex + " -r " + _targetVideoStream.fps + " -f image2 -vcodec " + Consts.V_IMG_VCODEC + " " + _imgDir + "\\%%010d" + Consts.V_IMG_EXT + " 2> " + _wd.makePath("mk_img_stderr.txt"),
				FFmpegBin.i.getBinDir()
				);

			// 1 <= 映像の長さ < IMAX

			if (File.Exists(_imgDir + "\\0000000001" + Consts.V_IMG_EXT) == false)
				throw new FailedOperation("映像ストリームに最初のフレームがありません。");

			if (File.Exists(_imgDir + "\\1000000001" + Consts.V_IMG_EXT))
				throw new FailedOperation("映像ストリームが長過ぎます。");

			// ----

			Gnd.i.progressMessage.post(""); // 完了

			ed = new EditData(this);

			// VIDEO_W/H_MIN/MAX
			{
				Image img = ed.v.getImage(0);

				if (img.Width < Consts.VIDEO_W_MIN)
					throw new FailedOperation("映像の幅が小さ過ぎます。" + img.Width);

				if (Consts.VIDEO_W_MAX < img.Width)
					throw new FailedOperation("映像の幅が大き過ぎます。" + img.Width);

				if (img.Height < Consts.VIDEO_H_MIN)
					throw new FailedOperation("映像の高さが小さ過ぎます。" + img.Height);

				if (Consts.VIDEO_H_MAX < img.Height)
					throw new FailedOperation("映像の高さが大き過ぎます。" + img.Height);
			}

			// AUDIO_HZ_MIN/MAX
			{
				int hz = this._wavHz;

				if (hz < Consts.AUDIO_HZ_MIN)
					throw new FailedOperation("音声ストリームのサンプリング周波数が小さ過ぎます。" + hz);

				if (Consts.AUDIO_HZ_MAX < hz)
					throw new FailedOperation("音声ストリームのサンプリング周波数が大き過ぎます。" + hz);
			}
		}

		public AudioStream getTargetAudioStream()
		{
			return _targetAudioStream;
		}

		public VideoStream getTargetVideoStream()
		{
			return _targetVideoStream;
		}

		public string getImageDir()
		{
			return _imgDir;
		}

		public string getOriginalFile()
		{
			return _origFile;
		}

		public int getWavHz()
		{
			return _wavHz;
		}

		public string getWavCsvFile()
		{
			return _wavCsvFile;
		}

		public string getExt()
		{
			return _ext;
		}

		public MediaSavedData quickSave()
		{
			MediaSavedData dest = new MediaSavedData();

			_targetAudioStream.quickSave(dest);
			_targetVideoStream.quickSave(dest);
			ed.quickSave(dest);

			dest.addString(_origFile);
			dest.addString(_ext);
			dest.addString(_duplFile);
			dest.addInt(_wavHz);

			return dest;
		}

		public void quickLoad(MediaSavedData src)
		{
			src.readSeekSet();

			_targetAudioStream.quickLoad(src);
			_targetVideoStream.quickLoad(src);
			ed.quickLoad(src);

			_origFile = src.readString();
			_ext = src.readString();
			_duplFile = src.readString();
			_wavHz = src.readInt();
		}

		public void Dispose()
		{
			if (_wd != null)
			{
				_wd.Dispose();
				_wd = null;
			}
		}
	}
}
