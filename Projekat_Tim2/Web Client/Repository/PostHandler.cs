using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Database;

namespace Web_Client.Repository
{
	public class PostHandler
	{
        public void PostResurs(string naziv, string opis, int TipResursa_id)
        {
            using (var db = new ResourceContext())
            {


                var query = (from g in db.tipovi.Where(a => a.Id == TipResursa_id).DefaultIfEmpty()
                             select new
                             {
                                 Id = g.Id,
                                 Naziv = g.Naziv
                             });

                Tip t = new Tip(0, "naziv");
                foreach (var item in query)
                {
                    t.Id = item.Id;
                    t.Naziv = item.Naziv;

                }


                Resurs r = new Resurs(15, naziv, opis, t);

                db.resursi.Add(r);
                db.SaveChanges();


            }
        }

        public void PostTip(string naziv)
        {
            using (var db = new ResourceContext())
            {

                Tip t = new Tip(0, naziv);

                db.tipovi.Add(t);
                db.SaveChanges();


            }
        }
        public void PostTipVeze(string naziv)
        {
            using (var db = new ResourceContext())
            {

                TipVeze t = new TipVeze(0, naziv);

                db.tipovi_veze.Add(t);
                db.SaveChanges();


            }
        }


        public void PostVeza(int prvi, int drugi, int tip_veze)
        {

            using (var db = new ResourceContext())
            {

                TipVeze r = new TipVeze(0, "");
                Veza v = new Veza(0, 0, 0, r);

                var queryy = (from g in db.tipovi_veze.Where(a => a.Id == tip_veze).DefaultIfEmpty()
                              select new
                              {
                                  Id = g.Id,
                                  Naziv = g.Naziv,

                              });
                foreach (var item in queryy)
                {
                    v.IdPrvog = prvi;
                    v.IdDrugog = drugi;
                    r.Id = item.Id;
                    r.Naziv = item.Naziv;
                    v.TipV = r;
                }



                db.veze.Add(v);
                db.SaveChanges();


            }
        }
    }
}
