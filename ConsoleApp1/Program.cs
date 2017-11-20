using ClassLibrary1;
using ClassLibrary1.entities;
using System;
using System.Collections.Generic;
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

            var title = "Lækkert lækkert sted";
            var description = "Der var sovs";
            var ISO = "DK";

            var contextSave = new ThaContext();
            var lang = contextSave.Languages
                            .FirstOrDefault(l => l.ISO == ISO);
            var textLanguage = new TextLanguage() {
                Language = lang,
                Title = title,
                Description = description
            };
            var dkGlobalGoal = new GlobalGoal() {
                Translation = new Text() {
                    Languages = new List<TextLanguage>() { textLanguage }
                }
            };

            contextSave.GlobalGoals.Add(dkGlobalGoal);

            contextSave.SaveChanges();

            Console.WriteLine("Waiting!!!!");
            Console.ReadLine();
        }
    }
}
