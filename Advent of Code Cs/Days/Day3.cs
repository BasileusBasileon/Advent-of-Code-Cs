using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_Cs.Days
{
	public class Day3
	{
		public Day3()
		{
			string[] lines = ParseInput().ToArray();

			Day3A(lines);
		}

		private IEnumerable<string> ParseInput()
		{
			IEnumerable<string> lines = File.ReadLines(@"S:\Users\Nils\source\repos\Advent of Code Cs\Advent of Code Cs\Inputs\Day3_Input.txt", Encoding.UTF8);
			return lines;
		}

		private void Day3A(string[] lines)
		{
			int x = 3;
			int lenght = lines[0].Length;
			int trees = 0;

			for (int y = 1; y < lines.Length; y++)
			{
				if (lines[y].ElementAt(x % lenght) == '#')
					trees++;
				x += 3;
			}

			Console.WriteLine($"\nThe solution to Day3A is {trees}.");
		}
	}
}
