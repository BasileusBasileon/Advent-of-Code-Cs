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

			Day3B(lines, Day3A(lines));
		}

		private IEnumerable<string> ParseInput()
		{
			IEnumerable<string> lines = File.ReadLines(@"S:\Users\Nils\source\repos\Advent of Code Cs\Advent of Code Cs\Inputs\Day3_Input.txt", Encoding.UTF8);
			return lines;
		}

		private int Day3A(string[] lines)
		{
			int trees = CountTrees(lines, 3, 1);

			Console.WriteLine($"\nThe solution to Day3A is {trees}.");

			return trees;
		}

		private void Day3B(string[] lines, int treesR3D1)
		{
			int treesR1D1 = CountTrees(lines, 1, 1);
			int treesR5D1 = CountTrees(lines, 5, 1);
			int treesR7D1 = CountTrees(lines, 7, 1);
			int treesR1D2 = CountTrees(lines, 1, 2);

			Console.WriteLine($"\nThe solution to Day3B is {(long)treesR1D1 * treesR3D1 * treesR5D1 * treesR7D1 * treesR1D2}.");
		}

		private static int CountTrees(string[] lines, int right, int down)
		{
			Console.WriteLine($"Right: {right}, Down: {down}");

			int x = right;
			int lenght = lines[0].Length;
			int trees = 0;

			for (int y = down; y < lines.Length; y += down)
			{
				if (lines[y].ElementAt(x % lenght) == '#')
					trees++;
				x += right;
			}

			return trees;
		}
	}
}
