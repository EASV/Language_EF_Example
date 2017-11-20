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
                .Include(gg => gg.Title.Languages)
                .Include(gg => gg.Description.Languages)
                .FirstOrDefault(gg => gg.Id == 1);

            Console.WriteLine("descr: " + global.Description.Languages
                                                .FirstOrDefault(l => l.LanguageISO == "US")
                                                .TranslatedText);
            Console.WriteLine("title: " + global.Title.Languages
                                            .FirstOrDefault(l => l.LanguageISO == "US")
                                            .TranslatedText);

            Console.WriteLine("Waiting!!!!");
            Console.ReadLine();
        }
    }
}
