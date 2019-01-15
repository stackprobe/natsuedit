using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Charlotte.Tools;

namespace Charlotte
{
	public class Utils
	{
		public static int getIndexDigitFormat(string[] lines, string format)
		{
			for (int index = 0; index < lines.Length; index++)
				if (StringTools.toDigitFormat(lines[index], true) == format)
					return index;

			return -1; // not found
		}

		public static string getTokenDigitFormat(string[] lines, string format)
		{
			int index = getIndexDigitFormat(lines, format);

			if (index == -1)
				return null; // not found

			return lines[index];
		}

		/// <summary>
		/// PictureBox (pb) 上の座標から、pb.Image 上の座標に変換する。
		/// pb.SizeMode == PictureBoxSizeMode.Zoom であること。
		/// </summary>
		/// <param name="pb"></param>
		/// <param name="pbPt"></param>
		/// <param name="toRangeFlag"></param>
		/// <returns>null == 枠外 || 画像が設定されていない。</returns>
		public static XYPoint getPictureBoxPointToImagePoint(PictureBox pb, XYPoint pbPt, bool toRangeFlag = false)
		{
			Image img = pb.Image;

			if (img == null)
				return null;

			double w = (double)img.Width;
			double h = (double)img.Height;
			double screen_w = (double)pb.Width;
			double screen_h = (double)pb.Height;

			Rect imgRect = new Rect(w, h);
			Rect screenRect = new Rect(0, 0, screen_w, screen_h);

			imgRect.adjustInside(screenRect);

			double x = pbPt.x;
			double y = pbPt.y;

			x -= imgRect.l;
			y -= imgRect.t;
			x /= imgRect.w;
			y /= imgRect.h;

			if (toRangeFlag)
			{
				x = DoubleTools.toRange(x, 0.0, 1.0);
				y = DoubleTools.toRange(y, 0.0, 1.0);
			}
			else
			{
				if (DoubleTools.isRange(x, 0.0, 1.0) == false)
					return null;

				if (DoubleTools.isRange(y, 0.0, 1.0) == false)
					return null;
			}
			x *= img.Width;
			y *= img.Height;

			return new XYPoint(x, y);
		}

		public static string millisToTimeStamp(int millis)
		{
			int l = millis % 1000;
			millis /= 1000;
			int s = millis % 60;
			millis /= 60;
			int m = millis;

			return StringTools.zPad(m, 2) + ":" + StringTools.zPad(s, 2) + "." + StringTools.zPad(l, 3);
		}

		public static string toUIString(Color color)
		{
			return "(" + color.A + ", " + color.R + ", " + color.G + ", " + color.B + ")";
		}

		public static int videoFrameIndexToAudioWavCsvRowIndex(int videoFrameIndex)
		{
			if (Gnd.i.md == null)
				throw new Exception("No movie");

			int vHz = Gnd.i.md.getTargetVideoStream().fps;
			int aHz = Gnd.i.md.getWavHz();

			int audioWavCsvRowIndex = (int)(((long)videoFrameIndex * aHz) / vHz);

			return audioWavCsvRowIndex;
		}

		public static int getNumOfProcessor()
		{
			int ret = 1;

			try
			{
				ret = int.Parse(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS"));
				ret = IntTools.toRange(ret, 1, 128); // XXX
			}
			catch
			{ }

			return ret;
		}

		public static void fillRectangle(Graphics g, Rect rect, Color color)
		{
			// (rect.l, rect.t) から (rect.getR() - 1, rect.getB() - 1) の範囲を塗りつぶしたい。

			g.FillRectangle(
				new SolidBrush(color),
				IntTools.toInt(rect.l),
				IntTools.toInt(rect.t),
				IntTools.toInt(rect.w),
				IntTools.toInt(rect.h)
				);
		}

		public static void AntiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (Gnd.i.is初回起動())
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(Program.selfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == Program.selfFile.ToLower())
						{
							WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						WriteLog(e);
					}
				}
				WriteLog("awdss_3");
			}
			WriteLog("awdss_4");
		}

		public static void WriteLog(object message)
		{
			Gnd.i.logger.writeLine("" + message);
		}
	}
}
