using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.Services
{
	public class JSONParser
	{
		public string JSONParse(string[] words)
		{
            string js = "";
            if (words[0] == "get" || words[0] == "delete")
            {
                JSONModel mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2], words[2]);//treca argument u naredbi je opcionalan pa moramo implementirati provjeru
                js = "{" + "\"verb\":" + "\"" + mod.Verb + "\"," + "\"noun\":" + "\"" + mod.Noun + "\"," + "\"query\":" + "\"" + mod.Querry + "\"" + "}";
            }
            else if (words[0] == "post")
            {
                JSONModel mod = null;
                if (words[1] == "resurs")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2] + "/" + words[3] + "/" + words[4], words[2]);//treca argument u naredbi je opcionalan pa moramo implementirati provjeru
                }
                else if (words[1] == "tip")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2], words[2]);//treca argument u naredbi je opcionalan pa moramo implementirati provjeru
                }
                else if (words[1] == "veza")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2] + "/" + words[3] + "/" + words[4], words[2]);
                }
                else if (words[1] == "tipveze")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2], words[2]);
                }

                js = "{" + "\"verb\":" + "\"" + mod.Verb + "\"," + "\"noun\":" + "\"" + mod.Noun + "\"," + "\"query\":" + "\"" + mod.Querry + "\"" + "}";
            }
            else if (words[0] == "patch")
            {
                JSONModel mod = null;
                if (words[1] == "resurs")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2] + "/" + words[3] + "/" + words[4] + "/" + words[5], words[2]);//treca argument u naredbi je opcionalan pa moramo implementirati provjeru
                }
                else if (words[1] == "tip")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2] + "/" + words[3], words[2]);//treca argument u naredbi je opcionalan pa moramo implementirati provjeru
                }
                else if (words[1] == "veza")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2] + "/" + words[3] + "/" + words[4] + "/" + words[5], words[2]);
                }
                else if (words[1] == "tipveze")
                {
                    mod = new JSONModel(words[0], "/" + words[1] + "/" + words[2] + "/" + words[3], words[2]);
                }

                js = "{" + "\"verb\":" + "\"" + mod.Verb + "\"," + "\"noun\":" + "\"" + mod.Noun + "\"," + "\"query\":" + "\"" + mod.Querry + "\"" + "}";
            }
            return js;
        }
	}
}
