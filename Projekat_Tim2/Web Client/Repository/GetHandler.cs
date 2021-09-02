using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Database;

namespace Web_Client.Repository
{
	public class GetHandler
	{
        public Resurs GetResurs(string method, string id)
        {
            using (var db = new ResourceContext())
            {
                int pom = Int32.Parse(id);


                var query = (from g in db.resursi.Where(a => a.Id == pom).DefaultIfEmpty()
                             from u in db.tipovi.Where(a => a.Id == g.TipResursa.Id).DefaultIfEmpty()
                             select new
                             {
                                 Id = g.Id,
                                 Naziv = g.Naziv,
                                 Opis = g.Opis,
                                 Tip = u.Naziv
                             });

                Resurs r = new Resurs(0, "", "", new Tip(0, ""));
                try
                {
                    foreach (var item in query)
                    {
                        r.Id = item.Id;

                        r.Naziv = item.Naziv;
                        r.Opis = item.Opis;
                        Tip t = new Tip(0, item.Tip);
                        r.TipResursa = t;
                    }

                }
                catch
                {

                }


                return r;


            }
        }

        public Tip GetTip(string method, string id)
        {
            using (var db = new ResourceContext())
            {
                int pom = Int32.Parse(id);
                var query = (
                                     from u in db.tipovi.Where(a => a.Id == pom).DefaultIfEmpty()
                                     select new
                                     {
                                         Id = u.Id,
                                         Naziv = u.Naziv,

                                     });
                Tip t = new Tip(0, "");
                try
                {


                    foreach (var item in query)
                    {


                        t.Id = item.Id;
                        t.Naziv = item.Naziv;

                    }
                }
                catch
                {

                }
                return t;
            }

        }
        public Veza GetVeza(string id)
        {
            using (var db = new ResourceContext())
            {
                int pom = Int32.Parse(id);


                var query = (from g in db.veze.Where(a => a.Id == pom).DefaultIfEmpty()
                             from u in db.tipovi_veze.Where(a => a.Id == g.TipV.Id).DefaultIfEmpty()
                             select new
                             {
                                 id = g.Id,
                                 id_prvog = g.IdPrvog,
                                 id_drugog = g.IdDrugog,
                                 tip_veze = u.Naziv

                             });

                Veza v = new Veza(0, 0, 0, new TipVeze(0, ""));
                if (query == null)
                {

                }
                try
                {
                    foreach (var item in query)
                    {

                        v.Id = item.id;
                        v.IdPrvog = item.id_prvog;
                        v.IdDrugog = item.id_drugog;
                        TipVeze tip = new TipVeze(0, item.tip_veze);
                        v.TipV = tip;
                    }
                }
                catch
                {

                }
                return v;
            }
        }
        public TipVeze GetTipVeze(string id)
        {
            using (var db = new ResourceContext())
            {
                int pom = Int32.Parse(id);


                var query = (from g in db.tipovi_veze.Where(a => a.Id == pom).DefaultIfEmpty()

                             select new
                             {
                                 id = g.Id,
                                 Naziv = g.Naziv,

                             });

                TipVeze v = new TipVeze(0, "");
                try
                {
                    foreach (var item in query)
                    {

                        v.Id = item.id;
                        v.Naziv = item.Naziv;

                    }
                }
                catch
                {

                }


                return v;


            }
        }
    }
}
