using System;
using getNQAdisplay;

namespace getNQAFunc
{
	public static class ft_function
	{
		public static void displayColor(string color, string str)
		{
			if (color == "red")
				ft_display.displayPlusRed();
			if (color == "green")
				ft_display.displayPlusGreen();
			if (color == "yellow")
				ft_display.displayPlusYellow();
			if (color == "info")
				ft_display.displayPlusInfo();
			Console.WriteLine(str);
		}

		public static void displayColorLine(string color, string str)
		{
			if (color == "red")
				ft_display.displayPlusRed();
			if (color == "green")
				ft_display.displayPlusGreen();
			if (color == "yellow")
				ft_display.displayPlusYellow();
			if (color == "info")
				ft_display.displayPlusInfo();
			Console.Write(str);
		}

		public static void stringToHex(string hexstring)
		{
			foreach (char t in hexstring)
			{
				Console.Write(Convert.ToInt32(t).ToString("x2"));
				Console.Write(" ");
				if (Convert.ToInt32(t) == 0x0a)
					Console.Write('\n');
			}
		}
	}
}
