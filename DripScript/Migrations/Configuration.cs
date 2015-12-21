namespace DripScript.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DripScript.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DripScript.Models.DSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DripScript.Models.DSContext context)
        {
            //context.DSUsers.AddOrUpdate(u => u.UserId,
            //    new DSUser() { UserId = 1, FirstName = "Jeremy", LastName = "Grondahl", Description = "I enjoy long walks on the beach" },
            //    new DSUser() { UserId = 2, FirstName = "Jess", LastName = "Grondahl", Description = "I love to watch cheesy christmas movies" },
            //    new DSUser() { UserId = 3, FirstName = "Mike", LastName = "Johnson", Description = "I like football" }
            //    );

            //context.Entries.AddOrUpdate(e => e.EntryId,
            //    new JournalEntry() { EntryId = 1, Title = "My Favorite Book", Body = "My favorite book is Jungle Book, because it has 'book' in the title.", Date = DateTime.Now, UserId = 1},
            //    new JournalEntry() { EntryId = 2, Title = "Buttermilk Tickles My Stomach", Body = "I was talking to my wife about this funny looking bisquit...", Date = DateTime.Now, UserId = 1},
            //    new JournalEntry() { EntryId = 3, Title = "No Sleeping Dogs", Body = "I could sleep, and neither could the dog", Date = DateTime.Now, UserId = 3},
            //    new JournalEntry() { EntryId = 4, Title ="Puppies!!!", Body ="I love all differen't kinds of puppies, except for the ugly ones.", Date = DateTime.Now, UserId = 2}
            //    );
          
        }
    }
}
