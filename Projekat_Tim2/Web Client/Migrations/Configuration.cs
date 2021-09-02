namespace Web_Client.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Web_Client.Database;

    internal sealed class Configuration : DbMigrationsConfiguration<Web_Client.Database.ResourceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Web_Client.Database.ResourceContext";
        }

        protected override void Seed(Web_Client.Database.ResourceContext context)
        {
            string upit = $"SELECT * FROM resursi";
            var db = new ResourceContext();
            var query = db.resursi.SqlQuery(upit);
            Console.WriteLine("usao sam u seed metodu");
                Tip t = new Tip(3, "zivotinja");
                context.tipovi.Add(t);
                Resurs r = new Resurs(1, "Slon", "slon je zovitnja", t);

            foreach (var item in query)
            {

                Console.WriteLine("Naziv resursa: " + item.Naziv);
                Console.WriteLine("Opis resursa: " + item.Opis);
                Console.WriteLine("Tip resursa: " + item.TipResursa.Naziv);
               
            }


                context.resursi.Add(r);
                //Database.db

                context.SaveChanges();
            

                

            //db.tipovi.Add(t);
            //db.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
