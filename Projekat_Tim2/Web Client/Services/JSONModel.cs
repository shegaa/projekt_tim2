using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.Services
{
	public class JSONModel
	{
		private string verb;

		public string Verb
		{
			get { return verb; }
			set { verb = value; }
		}

		private string noun;

		public string Noun
		{
			get { return noun; }
			set { noun = value; }
		}

		private string querry;

		public string Querry
		{
			get { return querry; }
			set { querry = value; }
		}

		private string fields;

		public string Fields
		{
			get { return fields; }
			set { fields = value; }
		}

		public JSONModel(string verb, string noun, string querry)
		{
			Verb = verb;
			Noun = noun;
			Querry = querry;
		}
	}
}
