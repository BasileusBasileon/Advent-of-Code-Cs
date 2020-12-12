using System;
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
		public struct Password
		{
			public Password(string text, char checker, int min, int max)
			{
				Text = text;
				Checker = checker;
				Min = min;
				Max = max;
			}

			public string Text;
			public char Checker;
			public int Min;
			public int Max;
		}

		private static Regex regex = new Regex(@"(\d+)-(\d+) (\w): (\w+)");

		public Day2()
		{
			IEnumerable<Password> passwords = ParseInput();

			Day2A(passwords);
			Day2B(passwords);
		}

		private IEnumerable<Password> ParseInput()
		{
			IEnumerable<string> lines = File.ReadLines(@"S:\Users\Nils\source\repos\Advent of Code Cs\Advent of Code Cs\Inputs\Day2_Input.txt", Encoding.UTF8);
			return lines.Select(line =>
			{
				Match match = regex.Match(line);
				return new Password(match.Groups[4].Value, match.Groups[3].Value.ElementAt(0), int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
			});
		}

		private static void Day2A(IEnumerable<Password> passwords)
		{
			int valids = 0;

			foreach (Password pw in passwords)
			{
				int count = pw.Text.Count(c => c == pw.Checker);
				if (count >= pw.Min && count <= pw.Max)
					valids++;
			}

			Console.WriteLine($"\nThe solution to Day2A is {valids}.");
		}

		private static void Day2B(IEnumerable<Password> passwords)
		{
			int valids = 0;

			foreach (Password pw in passwords)
			{ 
				if (pw.Text.ElementAt(pw.Min - 1) == pw.Checker ^ pw.Text.ElementAt(pw.Max - 1) == pw.Checker)
				{
					valids++;
				}
			}

			Console.WriteLine($"\nThe solution to Day2B is {valids}.");
		}
	}
}
