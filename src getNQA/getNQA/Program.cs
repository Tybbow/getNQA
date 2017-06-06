using System;
using Renci.SshNet;
using System.Text.RegularExpressions;
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
		public static string host = "HostTest";
		public static int port = 0;
		public static int time = 0;
		public static string path = string.Empty;

		public static void Start()
		{
			
			ft_display.displayArgs();
			string result = string.Empty;
			int i = 0;
			StringBuilder tmpNQA = new StringBuilder();
			
			try
			{
				var sshclient = new SshClient(host, port, user, pass);
				sshclient.Connect();
				ft_function.displayColor("green", "Success Connect");
				ft_function.displayColor("green", "Get NQA statistics. !");
				var shellStream = sshclient.CreateShellStream("dump", 0, 0, 0, 0, 1024);
				Thread.Sleep(2000);
				string read = shellStream.Read();
				if (read.Contains("ENTER"))
					shellStream.Write("\x59");
				ft_function.displayColor("green", "\tUser : " + user);
				result = SendCommand(shellStream, "dis nqa stat");
				tmpNQA.AppendLine(result);
				while (ft_check.checkmore(shellStream, i++, tmpNQA))
					shellStream.Write("\x20");
				result = tmpNQA.ToString();
				ft_parse.Parse(result);
				ft_function.displayColor("green", "End Of Connect !");
				ft_function.displayColor("green", "Time now : " + DateTime.Now.ToString());
				ft_function.displayColor("green", "Next Sequence in : " + time + " minute(s)");
				ft_display.displayEnd();
				sshclient.Disconnect();
				sshclient.Dispose();

			}
			catch (Exception)
			{
				ft_function.displayColor("red", "Unknow error for connect on the server " + host);
				ft_function.displayColor("red", "Are you sure of your request ??? Oo' ...");
				ft_function.displayColor("red", "Try Again for test automatical !");
			}
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
						// remove one character from the list of password characters
						password = password.Substring(0, password.Length - 1);
						// get the location of the cursor
						int pos = Console.CursorLeft;
						// move the cursor to the left by one character
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
						// replace it with space
						Console.Write(" ");
						// move the cursor to the left by one character again
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
					}
				}
				info = Console.ReadKey(true);
			}
			// add a new line because user pressed enter at the end of their password
			Console.WriteLine();
			return password;
		}


		public static bool getArgs(string[] args)
		{
			int i = 0;

			while (i < args.Length - 1)
			{
				if (args[i] == "-u" || args[i] == "--user")
					user = (args[i + 1]);
				if (args[i] == "-p" || args[i] == "--password")
					pass = args[i + 1];
				if (args[i] == "-h" || args[i] == "--host")
					host = args[i + 1];
				if (args[i] == "-po" || args[i] == "--port")
					Int32.TryParse(args[i + 1], out port);
				if (args[i] == "-t" || args[i] == "--time")
					Int32.TryParse(args[i + 1], out time);
				path = null;
				i++;
			}
			port = (port == 0) ? 22 : port;
			time = (time == 0) ? 60 : time;
			if (string.IsNullOrEmpty(pass))
			{
				Console.WriteLine("");
				ft_function.displayColorLine("yellow", "Enter Your Password : ");
				pass = ReadPassword();
				Console.WriteLine();
			}
			if (user != string.Empty && pass != string.Empty && host != string.Empty)
				return true;
			return false;
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
			//string tmp = null;
			//Console.WriteLine("Normal");
			//tmp = File.ReadAllText("./ok.txt");
			//ft_parse.Parse(tmp);
			//Console.WriteLine("BTP");
			//tmp = File.ReadAllText("./ok1.txt");
			//ft_parse.Parse(tmp);
			if (args.Length >= 4)
			{
				if (getArgs(args))
				{
					while (true)
					{
						Start();
						Thread.Sleep(time * 60 * 1000);
					}
				}
			}
			else
				ft_display.displayUsage();
			return (0);
		}
	}
}
	