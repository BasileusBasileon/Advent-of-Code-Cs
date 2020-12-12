using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_Cs.Days
{
	public class Day1
	{
		public Day1()
		{
			int[] numbers = ParseInput();

			Day1A(numbers);

			Day2A(numbers);
		}

		private static int[] ParseInput()
		{
			IEnumerable<string> lines = File.ReadLines(@"S:\Users\Nils\source\repos\Advent of Code Cs\Advent of Code Cs\Inputs\Day1_Input.txt", Encoding.UTF8);
			int lineAmount = lines.Count();
			int[] numbers = new int[lineAmount];
			for (int i = 0; i < lineAmount; i++)
				numbers[i] = int.Parse(lines.ElementAt(i));
			return numbers;
		}

		private static void Day1A(int[] numbers)
		{
			foreach (int number in numbers)
			{
				int other = 2020 - number;
				if (numbers.Any(n => n == other))
				{
					Console.WriteLine($"\nThe solution to Day1A is {number} * {other} = {number * other}.");
					break;
				}
			}
		}

		private static void Day2A(int[] numbers)
		{
			foreach (int number in numbers)
			{
				foreach (int other in numbers)
				{
					if (number + other < 2020)
					{
						int other2 = 2020 - number - other;
						if (numbers.Any(n => n == other2))
						{
							Console.WriteLine($"\nThe solution to Day1B is {number} * {other} * {other2} = {number * other * other2}.");
							return;
						}
					}
				}
			}
		}
	}
}
