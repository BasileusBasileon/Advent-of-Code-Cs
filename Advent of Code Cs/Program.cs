using Advent_of_Code_Cs.Days;
using System;

namespace Advent_of_Code_Cs
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("What Day should be executed?");
			char day = Console.ReadKey().KeyChar;

			switch (day)
			{
				case '1':
					new Day1();
					break;
				case '2':
					new Day2();
					break;
				case '3':
					new Day3();
					break;
				default:
					Console.WriteLine("\nThat's not a valid number you doofus.");
					break;
			}

			Console.ReadKey();
		}
	}
}