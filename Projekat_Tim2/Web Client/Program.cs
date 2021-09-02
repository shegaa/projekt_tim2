using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Services;
using Model;
using Web_Client.Database;
using Web_Client.DodatniFilteri;
using Newtonsoft.Json;
using System.Threading;
using Web_Client.IspisStrategy;

namespace Web_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string s = "";
                EntryProcessing unos = new EntryProcessing();
                do
                {
                    Console.WriteLine("Unesite zahtev:");
                    unos.Unos = Console.ReadLine();
                    s = unos.Entry();
                } while (s == "greska");
                string[] words = unos.Unos.Split('/');
                
                if(words[0] == "get")
                {
                    DodatniFilteri.DodatniFilteri filteri = new DodatniFilteri.DodatniFilteri();
                    filteri.handler(words);
                }

                JSONParser parser = new JSONParser();
                JObject json = JObject.Parse(parser.JSONParse(words));

                JSONToXMLAdapter.JSONToXMLAdapter adapter = new JSONToXMLAdapter.JSONToXMLAdapter();
                JObject odgovor = adapter.JSONToXML(json);

                string strategija = (string)odgovor["response"]["Entitet"];
                switch (strategija)
                {
                    case "Resurs":
                        new IspisStrategy.IspisStrategy(new IspisResurs()).IspisRezultata(odgovor);
                        break;
                    case "Tip":
                        new IspisStrategy.IspisStrategy(new IspisTip()).IspisRezultata(odgovor);
                        break;
                    case "Veza":
                        new IspisStrategy.IspisStrategy(new IspisVeza()).IspisRezultata(odgovor);
                        break;
                    case "TipVeze":
                        new IspisStrategy.IspisStrategy(new IspisTipVeze()).IspisRezultata(odgovor);
                        break;
                    default:
                        break;
                }

            }
            
        }
       
        }
    }
