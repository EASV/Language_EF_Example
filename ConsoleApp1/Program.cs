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
            var global = context.GlobalGoals
                .Include(gg => gg.Translation.Languages)
                .FirstOrDefault(gg => gg.Id == 1);
            var ggText = global.Translation.Languages
                             .FirstOrDefault(l => l.LanguageISO == "US");
            Console.WriteLine("descr: " + ggText.Description);
            Console.WriteLine("title: " + ggText.Title);

            Console.WriteLine("Waiting!!!!");
            Console.ReadLine();
        }
    }
}
