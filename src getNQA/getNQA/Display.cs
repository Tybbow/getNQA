﻿using System;
using getNQAFunc;

namespace getNQAdisplay
{
	public static class ft_display
	{
		public static void displayPlusGreen()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("[+] ");
			Console.ResetColor();
		}

		public static void displayPlusRed()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[+] ");
			Console.ResetColor();
		}

		public static void displayPlusYellow()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("[+] ");
			Console.ResetColor();
		}

		public static void displayEnd()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine();
			Console.WriteLine("******************************************************");
			Console.WriteLine();
			Console.WriteLine("******************************************************");
			Console.WriteLine();
			Console.WriteLine("******************************************************");
			Console.WriteLine();
			Console.ResetColor();
		}

		public static void displayArgs()
		{
			ft_function.displayColor("green", "User : " + getNQA.MainClass.user);
			ft_function.displayColor("green", "Pass : ********** ;)");
			ft_function.displayColor("green", "Host : " + getNQA.MainClass.host);
			ft_function.displayColor("green", "Port : " + getNQA.MainClass.port);
			ft_function.displayColor("green", "Time : " + getNQA.MainClass.time);
			ft_function.displayColor("green", "Time now : " + DateTime.Now.ToString());
			Console.WriteLine();
		}

		public static int displayerror(string error)
		{
			switch (error)
			{
				case "arguments":
					Console.WriteLine("Arguments invalides !");
					break;
				case "connect":
					Console.WriteLine("Connect Error !!");
					break;
				default:
					Console.WriteLine("Unexpected error !!");
					break;
			}
			Console.WriteLine("Exit Program.");
			return 0;
		}

		public static void displayUsage()
		{
			Console.WriteLine("Usage : getNQA [Options...]");
			Console.WriteLine("\t-u,  --user  \t: username");
			Console.WriteLine("\t-p,  --password : password");
			Console.WriteLine("\t-h,  --host \t: host to connect");
			Console.WriteLine("\t-po, --port \t: port ssh -- default 22");
			Console.WriteLine("\t-t,  --time \t: time in minutes, to get a NQA router -- default 60 minutes");
			Console.WriteLine("");
			Console.WriteLine(" examples :");
			Console.WriteLine("\tgetNQA -u user -p password -h example.net");
			Console.WriteLine("\tgetNQA -u user -p password -h example.net -p 4500 -t 5");
			Console.WriteLine();
			Console.WriteLine("\tYou can leave the field password empty for Security.");
			Console.WriteLine("\tgetNQA -u user -h example.net");
			Console.WriteLine("");
		}
	}
}
