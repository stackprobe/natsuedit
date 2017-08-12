using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class ExtensionsOptions
	{
		private List<string[]> _extOptions = new List<string[]>();

		public ExtensionsOptions()
		{
			foreach (string line in FileTools.readAllLines(resFile, StringTools.ENCODING_SJIS))
			{
				int index = line.IndexOf('=');

				if (index == -1)
					throw null;

				string ext = "." + line.Substring(0, index);
				string option = line.Substring(index + 1);

				_extOptions.Add(new string[] { ext, option });
			}
		}

		public string resFile
		{
			get
			{
				string file = "extensions_options.dat";

				if (File.Exists(file) == false)
					file = @"..\..\..\..\doc\extensions_options.dat";

				file = FileTools.makeFullPath(file);
				return file;
			}
		}

		public string getOption(string ext)
		{
			int index = getIndex(ext);

			if (index == -1)
			{
				index = getIndex(".*");

				if (index == -1)
					throw null;
			}
			return _extOptions[index][1];
		}

		private int getIndex(string ext)
		{
			for (int index = 0; index < _extOptions.Count; index++)
				if (StringTools.equalsIgnoreCase(_extOptions[index][0], ext))
					return index;

			return -1; // not found
		}
	}
}
