using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Database;

namespace Web_Client.Repository
{
	public class DeleteHandler
	{
        public bool DeleteResurs(int id)
        {
            using (var db = new ResourceContext())
            {
                var resurs = new Resurs { Id = id };
                if (db.resursi.Any(a => a.Id == id))
                {
                    db.resursi.Attach(resurs);
                    db.Entry(resurs).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;

                }
                Console.WriteLine("Resurs sa ovim id-jem ne postoji.");
                return false;


            }
        }
        public bool DeleteTip(int id)
        {
            using (var db = new ResourceContext())
            {
                var tip = new Tip { Id = id };
                if (db.tipovi.Any(a => a.Id == id))
                {
                    db.tipovi.Attach(tip);
                    db.Entry(tip).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;

                }
                return false;



            }
        }
        public bool DeleteVeza(int id)
        {
            using (var db = new ResourceContext())
            {
                var veza = new Veza { Id = id };
                if (db.veze.Any(a => a.Id == id))
                {
                    db.veze.Attach(veza);
                    db.Entry(veza).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();

                    return true;

                }
                return false;



            }
        }
        public bool DeleteTipVeze(int id)
        {
            using (var db = new ResourceContext())
            {
                var tip_veze = new TipVeze { Id = id };
                if (db.tipovi_veze.Any(a => a.Id == id))
                {
                    db.tipovi_veze.Attach(tip_veze);
                    db.Entry(tip_veze).State = System.Data.Entity.EntityState.Deleted;
                    try
                    {
                        db.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        Console.WriteLine("Prvo obrisite vezu koja sadrzi ovaj tip veze.");
                        return false;
                    }




                }
                return false;



            }
        }
    }
}
