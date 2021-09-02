using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace Web_Client.JSONToXMLAdapter
{
	public class JSONToXMLAdapter
	{
		public JObject JSONToXML(JObject json)
		{
			XNode node = JsonConvert.DeserializeXNode(json.ToString(), "Root");
			CommunicationBus.CommunicationBus bus = new CommunicationBus.CommunicationBus();
			XNode xml = bus.ComBus(node);
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml.ToString());
			string jstring = JsonConvert.SerializeXmlNode(doc);
			JObject odgovor = JObject.Parse(jstring);
			return odgovor;
		}
	}
}
