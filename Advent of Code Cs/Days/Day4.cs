using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace Advent_of_Code_Cs.Days
{
	public struct Passport
	{
		public Passport(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
		{
			_byr = byr;
			_iyr = iyr;
			_eyr = eyr;
			_hgt = hgt;
			_hcl = hcl;
			_ecl = ecl;
			_pid = pid;
			_cid = cid;
		}

		private string _byr;
		private string _iyr;
		private string _eyr;
		private string _hgt;
		private string _hcl;
		private string _ecl;
		private string _pid;
		private string _cid;

		public string byr { get => _byr; set => _byr = value; }
		public string iyr { get => _iyr; set => _iyr = value; }
		public string eyr { get => _eyr; set => _eyr = value; }
		public string hgt { get => _hgt; set => _hgt = value; }
		public string hcl { get => _hcl; set => _hcl = value; }
		public string ecl { get => _ecl; set => _ecl = value; }
		public string pid { get => _pid; set => _pid = value; }
		public string cid { get => _cid; set => _cid = value; }
	}

	public class Day4
	{

		public Day4()
		{
			List<Passport> passports = ParseInput();

			Day4A(passports);
			Day4B(passports);
		}

		private List<Passport> ParseInput()
		{
			string[] passportStrings = File.ReadAllText(@"S:\Users\Nils\source\repos\Advent of Code Cs\Advent of Code Cs\Inputs\Day4_Input.txt", Encoding.UTF8).Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

			List<Passport> passports = new List<Passport>();

			foreach (string passportString in passportStrings)
			{
				Passport passport = new Passport();

				string[] fields = passportString.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

				foreach (string field in fields)
				{
					string[] fieldParts = field.Split(':');

					//typeof(Passport).GetProperty(fieldParts[0]).SetValue(passport, fieldParts[1]);

					switch (fieldParts[0])
					{
						case "byr":
							passport.byr = fieldParts[1];
							break;
						case "iyr":
							passport.iyr = fieldParts[1];
							break;
						case "eyr":
							passport.eyr = fieldParts[1];
							break;
						case "hgt":
							passport.hgt = fieldParts[1];
							break;
						case "hcl":
							passport.hcl = fieldParts[1];
							break;
						case "ecl":
							passport.ecl = fieldParts[1];
							break;
						case "pid":
							passport.pid = fieldParts[1];
							break;
						case "cid":
							passport.cid = fieldParts[1];
							break;
					}
				}

				passports.Add(passport);
			}

			return passports;

		}

		private void Day4A(List<Passport> passports)
		{
			int valids = passports.Count;

			foreach (Passport passport in passports)
			{
				foreach (PropertyInfo property in typeof(Passport).GetProperties())
				{
					if (property.Name != "cid" && String.IsNullOrEmpty((string)property.GetValue(passport)))
					{
						valids--;
						break;
					}
				}
			}

			Console.WriteLine($"\nThe solution to Day4A is {valids}.");
		}

		private void Day4B(List<Passport> passports)
		{
			string[] colours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

			int valids = 0;

			foreach (Passport passport in passports)
			{
				try
				{
					int byr = int.Parse(passport.byr);
					int iyr = int.Parse(passport.iyr);
					int eyr = int.Parse(passport.eyr);
					if ((byr >= 1920 && byr <= 2020)
					&& (iyr >= 2010 && iyr <= 2020)
					&& (eyr >= 2020 && eyr <= 2030)
					&& ((passport.hgt.EndsWith("cm") && int.Parse(passport.hgt.Substring(0, 3)) >= 150 && int.Parse(passport.hgt.Substring(0, 3)) <= 193)
						|| (passport.hgt.EndsWith("in") && int.Parse(passport.hgt.Substring(0, 2)) >= 59 && int.Parse(passport.hgt.Substring(0, 2)) <= 76))
					&& (passport.hcl.StartsWith("#") && passport.hcl.Length == 7 && !passport.hcl.Substring(1).Any(c => !(char.IsDigit(c) || (char.IsLower(c)))))
					&& (colours.Any(col => col == passport.ecl))
					&& (passport.pid.Length == 9))
					{
						valids++;
					}
				}
				catch (NullReferenceException)
				{

				}
			}

			Console.WriteLine($"\nThe solution to Day4A is {valids}.");
		}
	}
}
