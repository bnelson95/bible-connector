using System;
using BibleConnector.ESV;

namespace BibleConnector.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please enter a book and chapter");
                Console.WriteLine("Usage: BibleConnector.ConsoleSample John 1");
                return;
            }

            var book = args[0];
            if (!int.TryParse(args[1], out var chapter))
            {
                Console.WriteLine("Not a valid chapter number");
                Console.WriteLine("Usage: BibleConnector.ConsoleSample John 1");
                return;
            }

            var esvBible = new ESVBibleService("9b8f8fb143a13ea5060250f223c640d1121828bc");
            var passage = esvBible.GetPassage(book, chapter).Result;

            Console.WriteLine(passage.Reference);
            Console.WriteLine(passage.Text);
        }
    }
}
