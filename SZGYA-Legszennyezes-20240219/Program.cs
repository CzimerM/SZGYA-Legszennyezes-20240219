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
            Console.WriteLine("\n3.feladat");
            foreach (var l in legadatok)
            {
                Console.WriteLine(l.Value.FirstOrDefault(n => n > 250));
            }

        }
    }
}