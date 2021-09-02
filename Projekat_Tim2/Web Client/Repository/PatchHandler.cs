using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Database;

namespace Web_Client.Repository
{
	public class PatchHandler
	{
        public bool PatchResurs(int id, string naziv, string opis, int TipResursa_id)
        {
            using (var db = new ResourceContext())
            {

                var result = db.resursi.SingleOrDefault(b => b.Id == id);

                var q = (from g in db.tipovi.Where(a => a.Id == TipResursa_id).DefaultIfEmpty()
                         select new
                         {
                             Id = g.Id,
                             Naziv = g.Naziv
                         });


                if (result != null)
                {
                    result.Naziv = naziv;
                    result.Opis = opis;
                    Tip tip = new Tip(0, "");

                    foreach (var item in q)
                    {
                        tip.Id = item.Id;
                        tip.Naziv = item.Naziv;
                    }




                    result.TipResursa = tip;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool PatchTip(int id, string naziv)
        {
            using (var db = new ResourceContext())
            {
                var result = db.tipovi.SingleOrDefault(a => a.Id == id);

                if (result != null)
                {
                    result.Naziv = naziv;

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool PatchVeza(int id, int id_prvog, int id_drugog, int id_tipa_veze)
        {
            using (var db = new ResourceContext())
            {
                var result = db.veze.SingleOrDefault(b => b.Id == id);

                var q = (from g in db.tipovi_veze.Where(a => a.Id == id_tipa_veze).DefaultIfEmpty()
                         select new
                         {
                             Id = g.Id,
                             Naziv = g.Naziv
                         });
                if (result != null)
                {
                    result.IdPrvog = id_prvog;
                    result.IdDrugog = id_drugog;
                    TipVeze tip_veze = new TipVeze(0, "");

                    foreach (var item in q)
                    {
                        tip_veze.Id = item.Id;
                        tip_veze.Naziv = item.Naziv;
                    }

                    result.TipV = tip_veze;
                    db.SaveChanges();
                    return true;



                }
                else
                {
                    return false;
                }

            }
        }

        public bool PatchTipVeze(int id, string naziv)
        {
            using (var db = new ResourceContext())
            {
                var result = db.tipovi_veze.SingleOrDefault(a => a.Id == id);

                try
                {
                    if (result != null)
                    {
                        result.Naziv = naziv;

                        db.SaveChanges();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
    }
}
