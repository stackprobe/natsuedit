using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public class MediaSavedData : IDisposable
	{
		private WorkingDir _wd = new WorkingDir();

		public MediaSavedData()
		{
			// noop
		}

		private string getFile(long index)
		{
			return _wd.makePath(index + ".bin");
		}

		private long _addIdx = 0L;

		public void add(byte[] data)
		{
			File.WriteAllBytes(getFile(_addIdx++), data);
		}

		public void addString(string str)
		{
			add(Encoding.UTF8.GetBytes(str));
		}

		public void addInt(int value)
		{
			addString("" + value);
		}

		public void addByFile(string file)
		{
			File.Copy(file, getFile(_addIdx++));
		}

		private long _readIdx;

		public void readSeekSet()
		{
			_readIdx = 0L;
		}

		public byte[] read()
		{
			return File.ReadAllBytes(getFile(_readIdx++));
		}

		public string readString()
		{
			return Encoding.UTF8.GetString(read());
		}

		public int readInt()
		{
			return int.Parse(readString());
		}

		public void readByFile(string file)
		{
			File.Copy(getFile(_readIdx++), file, true);
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
