using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;
using System.Diagnostics;

namespace Charlotte
{
	public class FFmpegBin : IDisposable
	{
		public static FFmpegBin i = null;

		private WorkingDir _wd = new WorkingDir();
		private string _dir;
		private string _binDir;

		public FFmpegBin(string dir)
		{
			_dir = _wd.makePath();
			_binDir = Path.Combine(_dir, "bin");

			FileTools.copyDir(dir, _binDir);
		}

		public string getBinDir()
		{
			return _binDir;
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
