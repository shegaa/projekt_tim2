using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.IspisStrategy
{
	public interface IIspisStrategy
	{
		void Ispis(JObject odgovor);
	}
}
