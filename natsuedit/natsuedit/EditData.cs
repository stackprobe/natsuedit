﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Charlotte
{
	public class EditData
	{
		public MediaData md;
		public AudioEditData a;
		public VideoEditData v;

		private string _lastSavedFile;

		public EditData(MediaData md)
		{
			this.md = md;

			a = new AudioEditData(this);
			v = new VideoEditData(this);

			_lastSavedFile = md.getOriginalFile();
		}

		public string getLastSavedFile()
		{
			return _lastSavedFile;
		}

		public void saveFile(string file)
		{
			try
			{
				BusyDlg.perform(delegate
				{
					doSave(file);
				});

				_lastSavedFile = file;
			}
			catch (Exception e)
			{
				FailedOperation.caught(e);
			}
		}

		private void doSave(string file)
		{
			string extNew = Path.GetExtension(file);

			if (Gnd.i.movieExtensions.contains(extNew) == false)
				throw new FailedOperation("保存先ファイル名は不明な拡張子です。");

			using (WorkingDir wd = new WorkingDir())
			{
				string wavFile = wd.makePath("1.wav");
				string midFile = wd.makePath("2") + extNew;

				Gnd.i.progressMessage.post("音声ファイルを生成しています...");

				CTools.csvFileToWavFile(md.getWavCsvFile(), wavFile, md.getWavHz(), wd.makePath("wr_wav_stdout.txt"));

				Gnd.i.progressMessage.post("映像ファイルを生成しています...");

				string imgDir = md.getImageDir();
				string vImgExt = Consts.V_IMG_EXT;

				if (Gnd.i._映像をJPEGで保存する)
				{
					string imgDirNew = wd.makePath();

					Directory.CreateDirectory(imgDirNew);

					foreach (string vImgFile in Directory.GetFiles(imgDir))
					{
						string wFile = Path.Combine(imgDirNew, Path.GetFileNameWithoutExtension(vImgFile)) + Consts.V_IMG_JPEG_EXT;

						using (Image bmp = Bitmap.FromFile(vImgFile))
						using (EncoderParameters eps = new EncoderParameters(1))
						using (EncoderParameter ep = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)Gnd.i._映像をJPEGで保存する時の画質))
						{
							eps.Param[0] = ep;
							ImageCodecInfo ici = GetICI(ImageFormat.Jpeg);
							bmp.Save(wFile, ici, eps);
						}
					}
					imgDir = imgDirNew;
					vImgExt = Consts.V_IMG_JPEG_EXT;
				}

				Gnd.i.progressMessage.post("動画ファイルを生成しています...");

				ProcessTools.runOnBatch(
					"ffmpeg.exe -r " + md.getTargetVideoStream().fps + " -i " + imgDir + "\\%%010d" + vImgExt + " -i " + wavFile + " -map 0:0 -map 1:0 " + Gnd.i.extensionsOptions.getOption(extNew) + " " + midFile + " 2> " + wd.makePath("wr_movie_stderr.txt"),
					FFmpegBin.i.getBinDir()
					);

				if (File.Exists(midFile) == false)
					throw new FailedOperation("動画ファイルの生成に失敗しました。");

				File.Copy(midFile, file, true);

				Gnd.i.progressMessage.post(""); // 完了
			}
		}

		private static ImageCodecInfo GetICI(ImageFormat imgFmt)
		{
			return (from ici in ImageCodecInfo.GetImageEncoders() where ici.FormatID == imgFmt.Guid select ici).ToList()[0];
		}

		public void quickSave(MediaSavedData dest)
		{
			a.quickSave(dest);
			v.quickSave(dest);

			dest.addString(_lastSavedFile);
		}

		public void quickLoad(MediaSavedData src)
		{
			a.quickLoad(src);
			v.quickLoad(src);

			_lastSavedFile = src.readString();
		}
	}
}
