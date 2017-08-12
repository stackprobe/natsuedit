using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class MovieExtensions
	{
		private string[] _exts;

		public MovieExtensions()
		{
			List<string> buff = new List<string>();

			foreach (string line in FileTools.readAllLines(resFile, Encoding.ASCII))
			{
				buff.Add("." + line); // "ext" -> ".ext"
			}
			_exts = buff.ToArray();
		}

		public bool contains(string ext)
		{
			return ArrayTools.contains<string>(_exts, ext, StringTools.compIgnoreCase);
		}

		public int indexOf(string ext)
		{
			return ArrayTools.indexOf<string>(_exts, ext, StringTools.compIgnoreCase);
		}

		public string resFile
		{
			get
			{
				string file = "movie_extensions.dat";

				if (File.Exists(file) == false)
					file = @"..\..\..\..\doc\movie_extensions.dat";

				file = FileTools.makeFullPath(file);
				return file;
			}
		}

		/// <summary>
		/// 例) "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*"
		/// </summary>
		/// <returns></returns>
		public string getFilter()
		{
			StringBuilder buff = new StringBuilder();

			foreach (string ext in _exts)
			{
				buff.Append(ext.Substring(1).ToUpper());
				buff.Append("ファイル(*");
				buff.Append(ext);
				buff.Append(")|*");
				buff.Append(ext);
				buff.Append("|");
			}
			buff.Append("すべてのファイル(*.*)|*.*");

			return buff.ToString();
		}
	}
}
