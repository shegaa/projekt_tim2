using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Database;

namespace Web_Client.Repository
{
	public class DodatniFilteriHandler
	{
        public List<int> DodatniFilteri(int id)
        {
            using (var db = new ResourceContext())
            {
                int pom = id;
                List<int> response = new List<int>();
                var resurs = (from g in db.resursi.Where(a => a.Id == pom).DefaultIfEmpty()

                              select new
                              {
                                  Id = g.Id,
                                  Naziv = g.Naziv,
                                  Opis = g.Opis,
                                  Tip = g.TipResursa.Naziv,
                                  IdTipa = g.TipResursa.Id
                              });

                try
                {
                    foreach (var item in resurs)
                    {
                    }
                    var query = (from g in db.veze.Where(a => a.IdPrvog == pom).DefaultIfEmpty()

                                 select new
                                 {
                                     IdResursa = g.IdDrugog,
                                 });
                    try
                    {
                        int pomocna;
                        foreach (var item in query)
                        {
                            Int32.TryParse(item.ToString(), out pomocna);

                            if (!response.Contains(pomocna))
                            {
                                response.Add(item.IdResursa);
                            }
                        }
                    }
                    catch
                    {
                        var queryy = (from g in db.veze.Where(a => a.IdDrugog == pom).DefaultIfEmpty()

                                      select new
                                      {
                                          IdResursa = g.IdPrvog,

                                      });
                        try
                        {
                            int pomocna;
                            foreach (var item in queryy)
                            {
                                Int32.TryParse(item.ToString(), out pomocna);

                                if (!response.Contains(pomocna))
                                {
                                    response.Add(item.IdResursa);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }

                return response;
            }
        }
        public Resurs DodatniFilteriType(string ime_resursa, int id_veze)
        {
            using (var db = new ResourceContext())
            {
                Tip t = new Tip(0, "");
                Resurs r = new Resurs(0, "", "", t);


                var resursy = (from g in db.resursi.Where(a => a.Naziv == ime_resursa).DefaultIfEmpty()
                               select new
                               {
                                   Id = g.Id
                               });

                int[] iid_resurs = new int[10];
                int i = 0;

                try
                {
                    foreach (var ajtem in resursy)
                    {
                        iid_resurs[i++] = ajtem.Id;

                    }
                }
                catch
                {
                    r.Naziv = "ne_postoji_resurs";
                    return r;
                }

                int pu;
                for (int j = 0; j < i; j++)
                {
                    pu = iid_resurs[j];
                    if (db.veze.Any(a => a.TipV.Id == id_veze))
                    {

                        if (db.veze.Any(a => a.IdPrvog == pu))
                        {
                            var resursyy = (from g in db.resursi.Where(a => a.Id == iid_resurs[j]).DefaultIfEmpty()
                                            select new
                                            {
                                                Naziv = g.Naziv,
                                                Opis = g.Opis,
                                            });
                            try
                            {
                                foreach (var iitem in resursyy)
                                {
                                    r.Naziv = iitem.Naziv;
                                    r.Opis = iitem.Opis;
                                }
                                return r;
                            }
                            catch
                            {

                            }

                        }

                        if (db.veze.Any(a => a.IdDrugog == pu))
                        {

                            var resursyy = (from g in db.resursi.Where(a => a.Id == pu).DefaultIfEmpty()
                                            select new
                                            {
                                                Naziv = g.Naziv,
                                                Opis = g.Opis,
                                            });
                            try
                            {
                                foreach (var iitem in resursyy)
                                {
                                    r.Naziv = iitem.Naziv;
                                    r.Opis = iitem.Opis;
                                }
                                return r;
                            }
                            catch
                            {

                            }

                        }

                    }
                }
                return r;
            }
        }
    }
}
