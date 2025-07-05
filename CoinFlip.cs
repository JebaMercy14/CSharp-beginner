using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoinFlip
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Random coin = new Random();
      Console.WriteLine((coin.Next(0, 2) == 0) ? "heads" : "tails");
		}
	}
}
