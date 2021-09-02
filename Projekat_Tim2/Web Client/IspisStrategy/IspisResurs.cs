using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.IspisStrategy
{
	public class IspisResurs : IIspisStrategy
	{
		public void Ispis(JObject odgovor)
		{
            if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "obrisan" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Resurs uspesno obrisan iz baze.");
            }
            else if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "izmenjen" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Resurs uspesno patch-ovan u bazi.");
            }
            else if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "upisan" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Resurs uspesno upisan u bazi.");
            }
            else if ((string)odgovor["response"]["STATUS"] == "REJECTED")
            {
                Console.WriteLine("Resurs sa tim id-jem ne postoji.");
            }
            else if ((string)odgovor["response"]["STATUS"] == "SUCCESS")
            {

                Console.WriteLine("Naziv resursa: " + (string)odgovor["response"]["PAYLOAD"]["Naziv"]);
                Console.WriteLine("Opis resursa: " + (string)odgovor["response"]["PAYLOAD"]["Opis"]);
                Console.WriteLine("Tip resursa: " + (string)odgovor["response"]["PAYLOAD"]["TipResursa"]);

            }
        }
	}
}
