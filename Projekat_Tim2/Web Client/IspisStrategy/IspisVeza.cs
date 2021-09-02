using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.IspisStrategy
{
	public class IspisVeza : IIspisStrategy
	{
		public void Ispis(JObject odgovor)
		{
            if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "obrisan" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Veza uspesno obrisana iz baze.");
            }
            else if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "izmenjen" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Veza  uspesno patch-ovana u bazi.");
            }
            else if ((string)odgovor["response"]["PAYLOAD"]["Naziv"] == "upisan" && (string)odgovor["response"]["STATUS"] == "SUCCESS")
            {
                Console.WriteLine("Veza uspesno upisana u bazi.");
            }
            else if ((string)odgovor["response"]["STATUS"] == "REJECTED")
            {
                Console.WriteLine("Veza sa tim id-jem ne postoji.");
            }
            else if ((string)odgovor["response"]["STATUS"] == "SUCCESS")
            {

                Console.WriteLine("Id prvog resursa " + (string)odgovor["response"]["PAYLOAD"]["Id_prvog"]);
                Console.WriteLine("Id drugog resursa " + (string)odgovor["response"]["PAYLOAD"]["Id_drugog"]);
                Console.WriteLine("Tip veze " + (string)odgovor["response"]["PAYLOAD"]["Tip_veze"]);

            };
		}
	}
}
