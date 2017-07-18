using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Renci.SshNet;
using getNQA;

namespace getNQAcheck
{
	public static class ft_check
	{

		public static bool checkmore(ShellStream shellStream, int i, StringBuilder tmpNQA)
		{
			string tmp = string.Empty;

			tmp = shellStream.Expect(new Regex((@"More")), new TimeSpan(0, 0, 5));
			Thread.Sleep(200);
			if (i == 0)
				return (true);
			if (tmp != null)
			{
				tmpNQA.AppendLine(tmp);
				return (true);
			}
			return (false);
		}

		public static string checkpath(string path, string ip, string sonde)
		{
			if (string.IsNullOrEmpty(path))
			{
				if (string.IsNullOrEmpty(ip))
					return (Application.StartupPath + "/NQA_" + sonde + "_" + MainClass.hostNow + ".csv");
				return (Application.StartupPath + "/NQA_" + sonde + "_" + ip + "_" + MainClass.hostNow + ".csv");
			}
			else
				return (path);
		}
	}
}
