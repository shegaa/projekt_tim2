using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web_Client.Services;

namespace Web_ClientTest.Services
{
	[TestClass]
	public class JSONParserTest
	{
		[TestMethod]
		public void JSONParseTest_GetResurs()
		{
			JSONParser j = new JSONParser();
			string unos = "get/resurs/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_GetTipVeze()
		{
			JSONParser j = new JSONParser();
			string unos = "get/tipveze/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_GetVeza()
		{
			JSONParser j = new JSONParser();
			string unos = "get/veza/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_GetTip()
		{
			JSONParser j = new JSONParser();
			string unos = "get/tip/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}

		[TestMethod]
		public void JSONParseTest_DeleteResurs()
		{
			JSONParser j = new JSONParser();
			string unos = "delete/resurs/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}

		[TestMethod]
		public void JSONParseTest_DeleteTip()
		{
			JSONParser j = new JSONParser();
			string unos = "delete/tip/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_DeleteVeza()
		{
			JSONParser j = new JSONParser();
			string unos = "delete/veza/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_DeleteTipVeze()
		{
			JSONParser j = new JSONParser();
			string unos = "delete/tipveze/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}

		[TestMethod]
		public void JSONParseTest_PostVeza()
		{
			JSONParser j = new JSONParser();
			string unos = "post/veza/asdf/qwer/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" +s[3] + "/" + s[4] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}

		[TestMethod]
		public void JSONParseTest_PostResurs()
		{
			JSONParser j = new JSONParser();
			string unos = "post/resurs/asdf/qwer/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3] + "/" + s[4] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_PostTip()
		{
			JSONParser j = new JSONParser();
			string unos = "post/resurs/asdf/qwer/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3] + "/" + s[4] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_PostTipVeze()
		{
			JSONParser j = new JSONParser();
			string unos = "post/resurs/asdf/qwer/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3] + "/" + s[4] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}

		[TestMethod]
		public void JSONParseTest_PatchVeza()
		{
			JSONParser j = new JSONParser();
			string unos = "patch/veza/aqqqf/qwer/asdf/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3] + "/" + s[4] + "/" + s[5] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_PatchResurs()
		{
			JSONParser j = new JSONParser();
			string unos = "patch/resurs/aqqqf/qwer/asdf/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3] + "/" + s[4] + "/" + s[5] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_PatchTip()
		{
			JSONParser j = new JSONParser();
			string unos = "patch/tip/aqqqf/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3]+ "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
		[TestMethod]
		public void JSONParseTest_PatchTipVeze()
		{
			JSONParser j = new JSONParser();
			string unos = "patch/tipveze/aqqqf/1";
			string[] s = unos.Split('/');
			string test = j.JSONParse(s);

			Assert.AreEqual("{" + "\"verb\":" + "\"" + s[0] + "\"," + "\"noun\":" + "\"" + "/" + s[1] + "/" + s[2] + "/" + s[3] + "\"," + "\"query\":" + "\"" + s[2] + "\"" + "}", test);
		}
	}
}
