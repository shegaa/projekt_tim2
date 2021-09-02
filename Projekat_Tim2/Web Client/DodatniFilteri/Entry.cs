using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Repository;

namespace Web_Client.DodatniFilteri
{
    public class Entry
    {
        public Entry()
        {

        }
        public void entry_filters(int id1)
        {
            DodatniFilteriHandler filteri = new DodatniFilteriHandler();
            Console.WriteLine("------Connected to------");
            
            int id = -1;


            id = id1;

            List<int> lista = filteri.DodatniFilteri(id);

            try
            {
                foreach (var item in lista)
                {
                    Console.WriteLine("Id povezanog resursa:" + item);
                  
                }
            }
            catch
            {
                Console.WriteLine("Resurs nema relacije.");
            }     
                
           

        }

        public void entry_type(int id_resurs)
        {
            DodatniFilteriHandler filteri = new DodatniFilteriHandler();
            Console.WriteLine("------Connected type------");        

            Console.WriteLine("Unesite naziv resursa:");
            string ime_resurs = Console.ReadLine();


            Console.WriteLine("Unesite id tipa veze:");
            string idtipa = Console.ReadLine();
            int id_veze;
            Int32.TryParse(idtipa, out id_veze);

            Resurs r = filteri.DodatniFilteriType(ime_resurs, id_veze);

            try
            {
               
                    Console.WriteLine("Naziv resursa:" + r.Naziv);
                    Console.WriteLine("Opis resursa:" + r.Opis);
                    Console.WriteLine("Naziv tipa:" + r.TipResursa.Naziv);

                
            }
            catch
            {
                Console.WriteLine("Resurs nema relacije.");
            }



        }


    }
}
