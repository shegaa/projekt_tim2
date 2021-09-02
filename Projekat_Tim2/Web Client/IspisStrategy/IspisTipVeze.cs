using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.IspisStrategy
{
	public class IspisTipVeze : IIspisStrategy
	{
		public void Ispis(JObject odgovor)
		{
            if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "obrisan" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Tipveze uspesno obrisan iz baze.");
            }
            else if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "izmenjen" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Tipveze  uspesno patch-ovan u bazi.");
            }
            else if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "upisan" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Tipveze uspesno upisan u bazi.");
            }
            else if ((string)odgovor["response"]["STATUS"] == "REJECTED")
            {
                Console.WriteLine("Tipveze sa tim id-jem ne postoji.");
            }
            else if ((string)odgovor["response"]["STATUS"] == "SUCCESS")
            {

                //Console.WriteLine("Id veze: " + (string)odgovor["response"]["Id"]);
                Console.WriteLine("Naziv: " + (string)odgovor["response"]["PAYLOAD"]["Naziv"]);

            };
		}
	}
}
