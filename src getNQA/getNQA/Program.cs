using System;
using Renci.SshNet;
using System.IO;
using System.Text;
using System.Threading;
using getNQAdisplay;
using getNQAFunc;
using getNQAParse;
using getNQAcheck;

namespace getNQA
{

	class MainClass
	{
		public static string user = string.Empty;
		public static string pass = string.Empty;
		public static string[] host = {null};
		public static string hostNow;
		public static int port = 0;
		public static int time = 0;
		public static int verbose = 0;
		public static int version = 0;
		public static string path = string.Empty;
		public static string file = string.Empty;
		public static string mentry = string.Empty;

		public static void Start()
		{
			string result = string.Empty;
			int i = 0;
			int j = 0;
			StringBuilder tmpNQA = new StringBuilder();

			while (i < host.Length)
			{
				hostNow = host[i];
				ft_display.displayArgs();
				try
				{
					var sshclient = new SshClient(hostNow, port, user, pass);
					sshclient.Connect();
					ft_function.displayColor("green", "Success Connexion.");
					ft_function.displayColor("green", "Getting NQA statistics...");
					var shellStream = sshclient.CreateShellStream("dump", 0, 0, 0, 0, 10240);
					Thread.Sleep(1000);
					string read = shellStream.Read();
					if (read.Contains("ENTER"))	
						shellStream.Write("\x59");
					result = SendCommand(shellStream, "dis nqa stat");
					tmpNQA.AppendLine(result);
					while (ft_check.checkmore(shellStream, j++, tmpNQA))
						shellStream.Write("\x20");
					result = tmpNQA.ToString();
					ft_parse.Parse(result, verbose);
					ft_function.displayColor("green", "End Of Connexion... !");
					ft_function.displayColor("green", "Time now : " + DateTime.Now.ToString());
					ft_function.displayColor("green", "Next Sequence in : " + time + " minute(s)");
					ft_display.displayEnd();
					sshclient.Disconnect();
					sshclient.Dispose();

				}
				catch (Exception)
				{
					ft_function.displayColor("red", "Unknow error for connect on the server " + host[i]);
					ft_function.displayColor("red", "Are you sure of your request ??? Oo' ...");
				}
				i++;
			}
			Thread.Sleep(time * 60 * 1000);
			Start();
		}


		private static string ReadPassword()
		{
			string password = "";
			ConsoleKeyInfo info = Console.ReadKey(true);
			while (info.Key != ConsoleKey.Enter)
			{
				if (info.Key != ConsoleKey.Backspace)
				{
					Console.Write("*");
					password += info.KeyChar;
				}
				else if (info.Key == ConsoleKey.Backspace)
				{
					if (!string.IsNullOrEmpty(password))
					{
						password = password.Substring(0, password.Length - 1);
						int pos = Console.CursorLeft;
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
						Console.Write(" ");
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
					}
				}
				info = Console.ReadKey(true);
			}
			Console.WriteLine();
			return password;
		}


		public static bool getArgs(string[] args)
		{
			int i = 0;

			while (i < args.Length)
			{
				if (args[i] == "-u" || args[i] == "--user")
					user = (args[i + 1]);
				if (args[i] == "-p" || args[i] == "--password")
					pass = args[i + 1];
				if (args[i] == "-h" || args[i] == "--host")
					host = args[i + 1].Split(',');
				if (args[i] == "-po" || args[i] == "--port")
					Int32.TryParse(args[i + 1], out port);
				if (args[i] == "-t" || args[i] == "--time")
					Int32.TryParse(args[i + 1], out time);
				if (args[i] == "-f" || args[i] == "--file")
					file = args[i + 1];
				if (args[i] == "-v" || args[i] == "--verbose")
					Int32.TryParse(args[i + 1], out verbose);
				if (args[i] == "--version")
				{
					version = 1;
					return (false);
				}
				path = null;
				i++;
			}
			port = (port == 0) ? 22 : port;
			time = (time == 0) ? 60 : time;
			if (file != string.Empty)
				return true;
			if (host[0] == null || user == string.Empty)
				return false;
			if (string.IsNullOrEmpty(pass))
			{
				Console.WriteLine("");
				ft_function.displayColorLine("yellow", "Enter Your Password : ");
				pass = ReadPassword();
				Console.WriteLine();
			}
			return (true);
		}

		private static string SendCommand(ShellStream stream, string customCMD)
		{
			var strAnswer = new StringBuilder();

			var reader = new StreamReader(stream);
			var writer = new StreamWriter(stream);
			writer.AutoFlush = true;
			WriteStream(customCMD, writer, stream);

			strAnswer.AppendLine(ReadStream(reader));

			var answer = strAnswer.ToString();
			return answer.Trim();
		}

		private static void WriteStream(string cmd, StreamWriter writer, ShellStream stream)
		{
			writer.WriteLine(cmd);
			Thread.Sleep(500);
			while (stream.Length == 0)
				Thread.Sleep(500);
		}

		private static string ReadStream(StreamReader reader)
		{
			var result = new StringBuilder();

			string line;
			while ((line = reader.ReadLine()) != null)
				result.AppendLine(line);
			return result.ToString();
		}

		public static int Main(string[] args)
		{
			if (getArgs(args))
			{
				if (file != string.Empty)
				{
					string tmp = null;
					if (File.Exists(file))
					{
						tmp = File.ReadAllText(file);
						ft_function.displayColorLine("green", "Read all text in" + file + "\n");
						ft_parse.Parse(tmp, verbose);
					}
					else
						ft_function.displayColor("red", "Your file not exist, or can't read !");
				}
				else
					Start();
			}
			else
			{
				if (version == 0)
					ft_display.displayUsage();
				else
					ft_display.displayVersion();
			}
			return (0);
		}
	}
}
	