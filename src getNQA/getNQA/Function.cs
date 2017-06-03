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
			Console.Write(str);
		}
	}
}
