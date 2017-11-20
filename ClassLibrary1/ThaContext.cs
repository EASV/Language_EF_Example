using ClassLibrary1.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace ClassLibrary1
{
    public class ThaContext : DbContext
    {
        public ThaContext() : base("theDBConnectionString")
        {
            Database.SetInitializer(new CustomInitializer<ThaContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Language>().HasKey(l => l.ISO);

            modelBuilder.Entity<Text>()
                            .HasMany(t => t.Languages)
                            .WithRequired(tl => tl.Text);

            modelBuilder.Entity<Language>()
                            .HasMany(l => l.Texts)
                            .WithRequired(tl => tl.Language);

            modelBuilder.Entity<TextLanguage>()
                .HasKey(tl => new { tl.LanguageISO, tl.TextId });
            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<GlobalGoal> GlobalGoals { get; set; }

    }

    public class CustomInitializer<T> : DropCreateDatabaseAlways<ThaContext>
    {
        public override void InitializeDatabase(ThaContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(ThaContext context)
        {
            // Seed code goes here...
            var dkLan = new Language { Country = "Denmark", ISO = "DK" };
            var usLan = new Language { Country = "USA", ISO = "US" };
            var enLan = new Language { Country = "Britain", ISO = "EN" };
            context.Languages.Add(dkLan);
            context.Languages.Add(usLan);
            context.Languages.Add(enLan);

            var firstTextDK = new TextLanguage { Language = dkLan,
                                                 Description = "Smølfer er blå",
                                                 Title = "Smølferne"};
            var firstTextUS = new TextLanguage { Language = usLan,
                                                 Description = "Smurfs are Blue",
                                                 Title = "Smurfs" };
            var firstTextEN = new TextLanguage { Language = enLan,
                                                 Description = "Smurfs are Blue, and a Cup of TEA",
                                                 Title = "Smurfs, and a Cup of TEA"};

            var smurfText = new Text()
            {
                Languages = new List<TextLanguage> { firstTextDK, firstTextUS, firstTextEN }
            };
            context.Texts.Add(smurfText);
            
            context.GlobalGoals.Add(new GlobalGoal()
            {
                Translation = smurfText
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
