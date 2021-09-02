using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web_Client.XmlToDBAdapter;

namespace Web_Client.CommunicationBus
{
	public class CommunicationBus
	{
		public XNode ComBus(XNode xml)
		{
			XMLToDBAdapter adapter = new XMLToDBAdapter();
			XNode odgovor = adapter.XMLToDB(xml);
			return odgovor;
		}
	}
}
