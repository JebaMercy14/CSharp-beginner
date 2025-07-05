using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace mailGenerate
{
    public class Program
    {
        void DisplayEmail(string first, string last, string domain = "contoso.com")
        {
            string email = first.Substring(0, 2) + last;
            email = email.ToLower();
            Console.WriteLine($"{email}@{domain}");
        }

        public static void Main(string[] args)
        {
            string[,] corporate =
            {
                {"Robert", "Bavin"}, {"Simon", "Bright"},
                {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
                {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
            };

            string[,] external =
            {
                {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
                {"Shay", "Lawrence"}, {"Daren", "Valdes"}
            };

            string externalDomain = "hayworth.com";

            Program program = new Program();

            for (int i = 0; i < corporate.GetLength(0); i++)
            {
                program.DisplayEmail(first: corporate[i, 0], last: corporate[i, 1]);
            }

            for (int i = 0; i < external.GetLength(0); i++)
            {
                program.DisplayEmail(first: external[i, 0], last: external[i, 1], domain: externalDomain);
            }
        }
    }
}
