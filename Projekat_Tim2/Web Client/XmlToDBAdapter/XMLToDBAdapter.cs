using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Web_Client.Repository;
using Model;

namespace Web_Client.XmlToDBAdapter
{
    public class XMLToDBAdapter
    {
        public XNode XMLToDB(XNode xml)
        {
            GetHandler getovi = new GetHandler();
            PostHandler postovi = new PostHandler();
            PatchHandler patchevi = new PatchHandler();
            DeleteHandler del = new DeleteHandler();
            string s = xml.ToString();

            XElement x = XElement.Parse(s);
            string method = x.Descendants("verb").First().Value;
            string path = x.Descendants("noun").First().Value;

            bool ret = false;

            string[] ar = path.Split('/');
            string methoda = ar[0];
            string table = ar[1];

            XElement xxml = null;
            xxml =
          new XElement("response",
          new XElement("Entitet", ""),
          new XElement("STATUS", "BAD_FORMAT"),
          new XElement("STATUS_CODE", "5000"),
          new XElement("PAYLOAD",
          new XElement("Naziv", "")));

            if (method == "post")
            {
               if (table == "resurs")
                {
                    string naziv = ar[2];
                    string opis = ar[3];
                    int TipResursa_Id = Int32.Parse(ar[4]);
                    postovi.PostResurs(naziv, opis, TipResursa_Id);
                    xxml =
      new XElement("response",
      new XElement("Entitet", "Resurs"),
      new XElement("STATUS", "SUCCESS"),
      new XElement("STATUS_CODE", "2000"),
      new XElement("PAYLOAD",
      new XElement("Naziv", "upisan")));
                }
                else if (table == "tip")
                {
                    string naziv = ar[2];
                    postovi.PostTip(naziv);
                    xxml =
       new XElement("response",
       new XElement("Entitet", "Tip"),
       new XElement("STATUS", "SUCCESS"),
       new XElement("STATUS_CODE", "2000"),
       new XElement("PAYLOAD",
       new XElement("Naziv", "upisan")));

                }
                else if (table == "veza")
                {
                    int id_prvog = Int32.Parse(ar[2]);
                    int id_drugog = Int32.Parse(ar[3]);
                    int id_tipa_veze = Int32.Parse(ar[4]);

                    if (id_prvog == id_drugog)
                    {
                        Console.WriteLine("Resurs ne sme biti u vezi sa samim sobom.");

                    }
                    else
                    {
                        postovi.PostVeza(id_prvog, id_drugog, id_tipa_veze);
                        xxml =
          new XElement("response",
          new XElement("Entitet", "Veza"),
          new XElement("STATUS", "SUCCESS"),
          new XElement("STATUS_CODE", "2000"),
          new XElement("PAYLOAD",
          new XElement("Naziv", "upisan")));
                    }

                }
                else if (table == "tipveze")
                {
                    string naziv = ar[2];
                    postovi.PostTipVeze(naziv);
                    xxml =
      new XElement("response",
      new XElement("Entitet", "TipVeze"),
      new XElement("STATUS", "SUCCESS"),
      new XElement("STATUS_CODE", "5000"),
      new XElement("PAYLOAD",
      new XElement("Naziv", "upisan")));
                }
            }
            else if (method == "get")
            {
                string id = ar[2];
                if (table == "resurs")
                {
                    Resurs odgovor = getovi.GetResurs(method, id);                    
                    if(odgovor.Id == 0)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Resurs"),
                    new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", ""),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                       
                    }                    
                    else
                    {
                        
                        xxml =
                   new XElement("response",
                   new XElement("Entitet", "Resurs"),
                   new XElement("STATUS", "SUCCESS"),
                   new XElement("STATUS_CODE", "2000"),
                   new XElement("PAYLOAD",
                   new XElement("Naziv", odgovor.Naziv),
                   new XElement("Opis", odgovor.Opis),
                   new XElement("TipResursa", odgovor.TipResursa.Naziv)));

                    }                    
                }
                else if (table == "tip")
                {
                    Tip odgovor = getovi.GetTip(method, id);
                    if(odgovor.Id == 0)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Tip"),
                    new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                     new XElement("Id", 0),
                    new XElement("Naziv", "")));
                    }
                    else
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Tip"),
                    new XElement("STATUS", "SUCCESS"),
                    new XElement("STATUS_CODE", "2000"),
                    new XElement("PAYLOAD",
                     new XElement("Id", odgovor.Id),
                        new XElement("Naziv", odgovor.Naziv)));
                    }
                   
                }
                else if (table == "veza")
                {                    
                    Veza odgovor = getovi.GetVeza(id);
                    if(odgovor.Id == 0)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Veza"),
                     new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                    new XElement("Id_prvog", ""),
                    new XElement("Id_drugog", ""),
                    new XElement("Tip_veze", "")));
                    }
                    else
                    {
                        xxml =
                   new XElement("response",
                   new XElement("Entitet", "Veza"),
                    new XElement("STATUS", "SUCCESS"),
                   new XElement("STATUS_CODE", "2000"),
                   new XElement("PAYLOAD",
                   new XElement("Id_prvog", odgovor.IdPrvog),
                   new XElement("Id_drugog", odgovor.IdDrugog),
                   new XElement("Tip_veze", odgovor.TipV.Naziv)));
                    }
                       
                }
                else
                {
                    TipVeze odgovor = getovi.GetTipVeze(id);
                    if(odgovor.Id == 0)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "TipVeze"),
                    new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                     new XElement("Id", 0),
                    new XElement("Naziv", "")));
                    }
                    else
                    {
                        xxml =
                   new XElement("response",
                   new XElement("Entitet", "TipVeze"),
                   new XElement("STATUS", "SUCCESS"),
                   new XElement("STATUS_CODE", "3000"),
                   new XElement("PAYLOAD",
                    new XElement("Id", odgovor.Id),
                   new XElement("Naziv", odgovor.Naziv)));
                    }
                       
                }
            }
            else if (method == "patch")
            {
                if (table == "resurs")
                {
                    int id = Int32.Parse(ar[2]);
                    string naziv = ar[3];
                    string opis = ar[4];
                    int tip_resursa_id = Int32.Parse(ar[5]);
                    ret = patchevi.PatchResurs(id, naziv, opis, tip_resursa_id);
                    if (ret)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Resurs"),
                    new XElement("STATUS", "SUCCESS"),
                    new XElement("STATUS_CODE", "2000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", "izmenjen"),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Resurs"),
                    new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", ""),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }                   
                }
                else if (table == "tip")
                {
                    int id = Int32.Parse(ar[2]);
                    string naziv = ar[3];                   
                    ret = patchevi.PatchTip(id, naziv);
                    if (ret)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Tip"),
                    new XElement("STATUS", "SUCCESS"),
                    new XElement("STATUS_CODE", "2000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", "izmenjen"),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Tip"),
                    new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", "izmenjen"),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }                                    
                }
                else if (table == "veza")
                {
                    int id = Int32.Parse(ar[2]);
                    int id_prvog = Int32.Parse(ar[3]);
                    int id_drugog = Int32.Parse(ar[4]);
                    int id_tipa_veze = Int32.Parse(ar[5]);
                    ret = patchevi.PatchVeza(id, id_prvog, id_drugog, id_tipa_veze);
                    if (ret)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Veza"),
                    new XElement("STATUS", "SUCCESS"),
                    new XElement("STATUS_CODE", "2000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", "izmenjen"),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Veza"),
                    new XElement("STATUS", "REJECTED"),
                    new XElement("STATUS_CODE", "3000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", ""),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }                   
                }
                else if (table == "tipveze")
                {
                    int id = Int32.Parse(ar[2]);
                    string naziv = ar[3];                    
                    ret = patchevi.PatchTipVeze(id, naziv);
                    if (ret)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "TipVeze"),
                    new XElement("STATUS", "SUCCESS"),
                    new XElement("STATUS_CODE", "2000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", "izmenjen"),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "TipVeze"),
                     new XElement("STATUS", "REJECTED"),
                     new XElement("STATUS_CODE", "3000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "izmenjen"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }                    
                }
            }
            else if (method == "delete")
            {
                int id = Int32.Parse(ar[2]);
                if (table == "resurs")
                {
                    ret = del.DeleteResurs(id);
                    if (ret)
                    {
                        xxml =
                    new XElement("response",
                    new XElement("Entitet", "Resurs"),
                    new XElement("STATUS", "SUCCESS"),
                    new XElement("STATUS_CODE", "2000"),
                    new XElement("PAYLOAD",
                    new XElement("Naziv", "obrisan"),
                    new XElement("Opis", ""),
                    new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                   new XElement("response",
                   new XElement("Entitet", "Resurs"),
                   new XElement("STATUS", "REJECTED"),
                   new XElement("STATUS_CODE", "3000"),
                   new XElement("PAYLOAD",
                   new XElement("Naziv", "obrisan"),
                   new XElement("Opis", ""),
                   new XElement("TipResursa", "")));
                    }
                }
                else if(table == "tip")
                {
                    ret = del.DeleteTip(id);
                    if(ret)
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "Tip"),
                     new XElement("STATUS", "SUCCESS"),
                     new XElement("STATUS_CODE", "2000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "obrisan"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "Tip"),
                     new XElement("STATUS", "REJECTED"),
                     new XElement("STATUS_CODE", "3000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "obrisan"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }
                }
                else if (table == "veza")
                {                    
                    ret = del.DeleteVeza(id);
                    if (ret)
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "Veza"),
                     new XElement("STATUS", "SUCCESS"),
                     new XElement("STATUS_CODE", "2000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "obrisan"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "Veza"),
                     new XElement("STATUS", "REJECTED"),
                     new XElement("STATUS_CODE", "3000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "obrisan"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }
                }
                else if (table == "tipveze")
                {
                    ret = del.DeleteTipVeze(id);
                    if (ret)
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "TipVeze"),
                     new XElement("STATUS", "SUCCESS"),
                     new XElement("STATUS_CODE", "2000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "obrisan"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }
                    else
                    {
                        xxml =
                     new XElement("response",
                     new XElement("Entitet", "Tip"),
                     new XElement("STATUS", "REJECTED"),
                     new XElement("STATUS_CODE", "3000"),
                     new XElement("PAYLOAD",
                     new XElement("Naziv", "obrisan"),
                     new XElement("Opis", ""),
                     new XElement("TipResursa", "")));
                    }
                    

                }
            }
                return xxml;
        }
    }
}
