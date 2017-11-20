using ClassLibrary1;
using System;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ThaContext();
            var list = context.GlobalGoals.Include(gg => gg.Description.Languages.Select(l => l.Language));
            foreach (var item in list)
            {
                Console.WriteLine("item: " + item.Description.Languages.FirstOrDefault(l => l.Language.ISO == "DK").TranslatedText);
            }
            Console.WriteLine("Waiting!!!!");
            Console.ReadLine();
        }
    }
}
