using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Repository;

namespace Web_Client.DodatniFilteri
{
    public class DodatniFilteri
    {
        public void handler(string[] words)
		{
            if (words[1] == "resurs")
            {
                Console.WriteLine("Za 'Connected0' filter pritisnite enter.\n Bez dodatnih filtera bilo koje dugme osim entera.");
                bool dodatni_prvi;
                while (true)
                {
                    ConsoleKeyInfo k;
                    k = Console.ReadKey(true);
                    if (k.Key == ConsoleKey.Enter)
                    {
                        dodatni_prvi = true;
                        break;
                    }

                    else
                    {
                        dodatni_prvi = false;
                        break;
                    }


                }
                if (dodatni_prvi)
                {
                    int id;
                    Int32.TryParse(words[2], out id);
                    Entry e = new Entry();
                    e.entry_filters(id);
                }

                Console.WriteLine("Za 'ConnectedType' filter pritisnite enter.\n Bez dodatnih filtera bilo koje dugme osim entera.");
                bool dodatni_drugi;
                while (true)
                {
                    ConsoleKeyInfo k;
                    k = Console.ReadKey(true);
                    if (k.Key == ConsoleKey.Enter)
                    {
                        dodatni_drugi = true;
                        break;
                    }

                    else
                    {
                        dodatni_drugi = false;
                        break;
                    }


                }
                if (dodatni_drugi)
                {
                    int id;
                    Int32.TryParse(words[2], out id);
                    Entry e = new Entry();
                    e.entry_type(id);
                }

            }
        }
    }
}
