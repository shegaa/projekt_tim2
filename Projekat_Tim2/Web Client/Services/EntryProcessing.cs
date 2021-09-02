using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.Services
{
	public class EntryProcessing
	{
		private string unos;

		public string Unos
		{
			get { return unos; }
			set { unos = value; }
		}

		public string Entry()
		{
			while (true)
			{
				bool state=false;
				string[] words = unos.Split('/');
               
				// Proveravamo da li je korisnik pravilno uneo metode.
				if (words[0] != "get" && words[0] != "post" && words[0] != "patch" && words[0] != "delete")
				{
                    Console.WriteLine("Pogresna forma zahteva. --- Unos zahteva: metoda/entitet/id(OPCIONALNO). Obratite paznju da je sve napisano malim slovima");
                    return "greska";
                }
                if(words[1] != "resurs" && words[1] != "tip" && words[1] != "veza" && words[1] != "tipveze")
                {
                    Console.WriteLine("Pogresna forma zahteva. --- Unos zahteva: metoda/entitet/id(OPCIONALNO). Obratite paznju da je sve napisano malim slovima");
                    return "greska";
                }
				int i;
				int j = 0;

                if(words[0] == "get")
                {
                    foreach (var word in words)
                    {
                        if (j == 2)
                        {
                            // Proveravamo da li je opcionalno polje id tipa int.
                            state = int.TryParse(word, out i); ;
                        }
                        //Proveravamo da li je korisnik uneo vise parametara u zahtevu(get/resurs/1/ersef).
                        if (j == 3)
                        {

                            state = false;
                        }
                        j++;

                    }
                    if (state)
                    {
                        break;
                    }
                    Console.WriteLine("Pogresna forma zahteva. --- Unos zahteva: metoda/entitet/id(OPCIONALNO). Obratite paznju da je sve napisano malim slovima");
                    return "greska";
                }           
                else if(words[0] == "post")
                {
                    int min_words = 0;
                    j = 0;
                    if(words[1] == "resurs")
                    {
                 
                        min_words = 5;
                    }
                    else if(words[1] == "tip")
                    {
                        min_words = 3;
                    }
                    else if(words[1] == "tipveze")
                    {
                        min_words = 3;
                    }
                    else if(words[1] == "veza")
                    {
                        min_words = 5;
                    }
                    foreach (var word in words)
                    {

                        j++;

                    }
                    if ( j == min_words)
                    {
                        break;
                    }
                    Console.WriteLine("Pogresna forma zahteva. --- Unos zahteva: metoda/entitet/id(OPCIONALNO). Obratite paznju da je sve napisano malim slovima");
                    return "greska";
                }
                else if (words[0] == "patch")
                {
                    int min_words = 0;
                    j = 0;
                    if (words[1] == "resurs")
                    {

                        min_words = 6;
                    }
                    else if (words[1] == "tip")
                    {
                        min_words = 4;
                    }
                    else if (words[1] == "tipveze")
                    {
                        min_words = 4;
                    }
                    else if (words[1] == "veza")
                    {
                        min_words = 6;
                    }
                    foreach (var word in words)
                    {

                        j++;

                    }
                    if (j == min_words)
                    {
                        break;
                    }
                    Console.WriteLine("Pogresna forma zahteva. --- Unos zahteva: metoda/entitet/id(OPCIONALNO). Obratite paznju da je sve napisano malim slovima");
                    return "greska";
                }
                else if (words[0] == "delete")
                {
                    j = 0;
                    foreach (var word in words)
                    {
                        if (j == 2)
                        {
                            // Proveravamo da li je opcionalno polje id tipa int.
                            state = int.TryParse(word, out i); ;
                        }
                        //Proveravamo da li je korisnik uneo vise parametara u zahtevu(get/resurs/1/ersef).
                        if (j == 3)
                        {

                            state = false;
                        }
                        j++;

                    }
                    if (state)
                    {
                        break;
                    }
                    Console.WriteLine("Pogresna forma zahteva. --- Unos zahteva: metoda/entitet/id(OPCIONALNO). Obratite paznju da je sve napisano malim slovima");
                    return "greska";
                }

                return unos;
            }
            return unos;

        }
    }
}
