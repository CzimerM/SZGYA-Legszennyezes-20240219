using System.Text;

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

            //--------------------
            //-------SZORGALMI----
            //--------------------

            //8
            Console.WriteLine($"\n8.feladat: {legadatok.First().Value.IndexOf(legadatok.First().Value.Max()) + 1}");

            //9 
            Console.WriteLine($"\n9.feladat: {legadatok.Average(l => l.Value[11])}");

            //10
            var felek = legadatok.Chunk(15);
            Console.WriteLine($"\n10.feladat: {(felek.First().Sum(l => l.Value.Sum()) > felek.Last().Sum(l => l.Value.Sum()) ? "az első" : "a második")} volt nagyobb");

            //11 
            var gyujto = legadatok.Where(l => legadatok.Average(l => l.Value.Sum()) - l.Value.Sum() > 100);
            Console.WriteLine("\n11.feladat");
            foreach (var nap in gyujto)
            {
                Console.WriteLine($"\t{nap.Key}");
            }
        }
    }
}