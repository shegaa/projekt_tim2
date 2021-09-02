using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.IspisStrategy
{
	public class IspisStrategy
	{
		private IIspisStrategy _strategy;
		public IspisStrategy(IIspisStrategy strategija)
		{
			_strategy = strategija;
		}
		private string tipEntiteta;

		public string TipEntiteta
		{
			get { return tipEntiteta; }
			set { tipEntiteta = value; }
		}

		public void IspisRezultata(JObject json)
		{
			_strategy.Ispis(json);

		}
	}
}
