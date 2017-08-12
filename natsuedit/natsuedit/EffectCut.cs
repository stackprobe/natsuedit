using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public class EffectCut
	{
		private int vCount;
		private int aCount;

		public void perform()
		{
			if (Gnd.i.md == null)
				return;

			if (Gnd.i.md.ed.a.selectEnd == -1) // ? ! 時間選択完了
				throw new FailedOperation("時間を選択して下さい。");

			Gnd.i.progressMessage.post("動画をカットしています...");

			vCount = Gnd.i.md.ed.v.getCount();
			aCount = Gnd.i.md.ed.a.getCount();

			if (vCount < 1)
				throw null;

			if (aCount < 1)
				throw null;

			int vStartIndex = Gnd.i.md.ed.a.selectBegin; // ここから
			int vEndIndex = Gnd.i.md.ed.a.selectEnd + 1; // この直前まで

			if (IntTools.isRange(vStartIndex, 0, vCount - 1) == false)
				throw null;

			if (IntTools.isRange(vEndIndex, 0, vCount) == false)
				throw null;

			if (vEndIndex <= vStartIndex)
				throw null;

			int aStartIndex = Utils.videoFrameIndexToAudioWavCsvRowIndex(vStartIndex); // ここから
			int aEndIndex = Utils.videoFrameIndexToAudioWavCsvRowIndex(vEndIndex); // この直前まで

			if (vEndIndex == vCount) // 映像の終端までなら、音声も終端までにする。
				aEndIndex = aCount;

			if (vStartIndex == 0 && vEndIndex == vCount)
				throw new FailedOperation("映像を空にすることは出来ません。");

			if (aStartIndex == 0 && aEndIndex == aCount)
				throw new FailedOperation("音声を空にすることは出来ません。");

			cutVideo(vStartIndex, vEndIndex);
			cutAudio(aStartIndex, aEndIndex);

			Gnd.i.progressMessage.post(""); // 完了
		}

		private void cutVideo(int startIndex, int endIndex)
		{
			Gnd.i.progressMessage.post("映像をカットしています...");

			for (int index = startIndex; index < endIndex; index++)
			{
				File.Delete(Gnd.i.md.ed.v.getFile(index));
			}
			int wIndex = startIndex;

			for (int index = endIndex; index < vCount; index++)
			{
				File.Move(
					Gnd.i.md.ed.v.getFile(index),
					Gnd.i.md.ed.v.getFile(wIndex)
					);

				wIndex++;
			}
		}

		private void cutAudio(int startIndex, int endIndex)
		{
			Gnd.i.progressMessage.post("音声をカットしています...");

			long startPos = (long)startIndex * 12L;
			long endPos = (long)endIndex * 12L;

			CTools.cutFile(Gnd.i.md.getWavCsvFile(), startPos, endPos);
		}
	}
}
