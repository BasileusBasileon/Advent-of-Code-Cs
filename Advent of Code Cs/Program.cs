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
				default:
					Console.WriteLine("\nThat's not a number you doofus.");
					break;
			}

			Console.ReadKey();
		}
	}
}