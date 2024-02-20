﻿using System.Text;

namespace SZGYA_Legszennyezes_20240219
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> legadatok = new();

            var sr = new StreamReader("../../../src/SO2.txt", Encoding.UTF8);

            for (int i = 1; !sr.EndOfStream; i++)
            {
                legadatok.Add(i, sr.ReadLine().Split(';').Select(l => int.Parse(l)).ToList());
            }

            //2
            Console.WriteLine("\n2.feladat");
            foreach (var l in legadatok)
            {
                Console.WriteLine(string.Join(' ', l.Value));
            }

            //3
            var sw = new StreamWriter("../../../src/datum.txt", false, Encoding.UTF8);
            Console.WriteLine("\n3.feladat");
            foreach (var l in legadatok)
            {
                if (l.Value.Any(n => n > 250)) sw.WriteLine(DateTime.Parse($"3.{l.Key}.").ToString("MMMM d."));
            }
            sw.Close();

            //4
            var max = legadatok.MaxBy(l => l.Value.Max());
            Console.WriteLine($"\n4.feladat: {max.Key}. nap {max.Value.IndexOf(max.Value.Max()) + 1} óra");

            //5
            Console.WriteLine($"\n5.feladat: {legadatok.Sum(l => l.Value.Count(n => n < 100))}");

            //6
            Console.WriteLine($"\n6.feladat: {legadatok.Average(l => l.Value.Average())}");

            //7
            var hatvanalatt = legadatok.FirstOrDefault(l => l.Value.All(n => n < 60));
            Console.WriteLine($"\n7.feladat \n\t{(hatvanalatt.Key != 0 ? $"{hatvanalatt.Key}" : "[HIBA] Nincs ilyen nap")}");

        }
    }
}