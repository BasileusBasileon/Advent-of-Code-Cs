﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_Cs.Days
{
	public class Day2
	{
		public Day2()
		{
			IEnumerable<string> lines = ParseInput();

			Day2A(lines);
		}

		private IEnumerable<string> ParseInput()
		{
			IEnumerable<string> lines = File.ReadLines(@"S:\Users\Nils\source\repos\Advent of Code Cs\Advent of Code Cs\Inputs\Day2_Input.txt", Encoding.UTF8);
			return lines;
		}

		private static void Day2A(IEnumerable<string> lines)
		{
			Regex pwRegex = new Regex(@"(\d+)-(\d+) (\w): (\w+)");
			int valids = 0;

			foreach (string line in lines)
			{
				Match match = pwRegex.Match(line);

				int count = match.Groups[4].Value.Count(c => c == match.Groups[3].Value.ElementAt(0));
				if (count >= int.Parse(match.Groups[1].Value) && count <= int.Parse(match.Groups[2].Value))
					valids++;
			}


			Console.WriteLine($"\nThe solution to Day2A is {valids}.");
		}
	}
}
