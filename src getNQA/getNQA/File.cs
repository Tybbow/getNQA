using System;
using System.IO;
using System.Collections.Generic;
using getNQAFunc;
using getNQAstruct;

namespace getNQAfile
{
	public static class ft_file
	{

		public static string readfile(string path)
		{
			string tmp = null;
			if (fileexist(path))
				tmp = File.ReadAllText(path, System.Text.Encoding.UTF8);
			return (tmp);
		}

		public static string readlastline(string path)
		{
			string tmp = null;
			string[] index;

			foreach (string line in File.ReadLines(path))
				tmp = line;
			if (string.IsNullOrEmpty(tmp))
				return (null);
			index = tmp.Split(';');
			if (index[2] == "Starttime")
				return ("1/1/1970");
			return (index[2]);
		}

		public static int readlastlinenum(string path)
		{
			string tmp = null;
			string[] index;

			foreach (string line in File.ReadLines(path))
				tmp = line;
			if (string.IsNullOrEmpty(tmp))
				return (0);
			index = tmp.Split(';');
			if (index[3] == "Lifetime")
				return (0);
			return (Int32.Parse(index[3]));
		}

		public static void writebegin(string path, string content)
		{
			File.WriteAllText(path, content);
			File.AppendAllText(path, "\n");
		}

		public static void writeFileudp(List<ft_struct.elementudp> list, List<ft_struct.tmp> listtmp)
		{
			int result;
			int parttmp = 0;
			int j = 0;
			int i = 0;
			foreach (ft_struct.tmp part in listtmp)
			{
				parttmp = part.numtime;
				foreach (ft_struct.elementudp aPart in list)
				{
					j++;
					result = DateTime.Compare(part.elTime, aPart.elTime);
					if (result < 0 && part.elIP == aPart.elIP && (parttmp == aPart.elLifetime || parttmp == 0))
					{
						i++;
						File.AppendAllText(part.path, aPart.ToString());
						File.AppendAllText(part.path, "\n");
						parttmp = aPart.elLifetime;
					}
				}
			}
			ft_function.displayColor("info", string.Format("Elements numbers: {0}", j));
			ft_function.displayColor("info", string.Format("Elements add in file: {0}", i));
			ft_function.displayColor("green", "Fetch NQA Success !!\n");
		}

		public static void writeFileicmp(List<ft_struct.elementicmp> list, List<ft_struct.tmp> listtmp)
		{
			int result;
			int parttmp = 0;
			int j = 0;
			int i = 0;
			foreach (ft_struct.tmp part in listtmp)
			{
				parttmp = part.numtime;
				foreach (ft_struct.elementicmp aPart in list)
				{
					j++;
					result = DateTime.Compare(part.elTime, aPart.elTime);
					if (result < 0 && part.elIP == aPart.elIP && (parttmp == aPart.elLifetime || parttmp == 0))
					{
						i++;
						File.AppendAllText(part.path, aPart.ToString());
						File.AppendAllText(part.path, "\n");
						parttmp = aPart.elLifetime;
					}
				}
			}
			ft_function.displayColor("info", string.Format("Elements numbers: {0}", j));
			ft_function.displayColor("info", string.Format("Elements add in file: {0}", i));
			ft_function.displayColor("green", "Fetch NQA Success !!\n");
		}

		public static void writeFiletcp(List<ft_struct.elementtcp> list, List<ft_struct.tmp> listtmp)
		{
			int result;
			int parttmp = 0;
			int j = 0;
			int i = 0;
			foreach (ft_struct.tmp part in listtmp)
			{
				parttmp = part.numtime;
				foreach (ft_struct.elementtcp aPart in list)
				{
					j++;
					result = DateTime.Compare(part.elTime, aPart.elTime);
					if (result < 0 && part.elIP == aPart.elIP && (parttmp == aPart.elLifetime || parttmp == 0))
					{
						i++;
						File.AppendAllText(part.path, aPart.ToString());
						File.AppendAllText(part.path, "\n");
						parttmp = aPart.elLifetime;
					}
				}
			}
			ft_function.displayColor("info", string.Format("Elements numbers: {0}", j));
			ft_function.displayColor("info", string.Format("Elements add in file: {0}", i));
			ft_function.displayColor("green", "Fetch NQA Success !!\n");
		}
		private static void createfile(string path)
		{
			File.Create(path);
		}

		public static bool fileexist(string path)
		{
			if (File.Exists(path))
				return (true);
			return (false);
		}
	}
}
