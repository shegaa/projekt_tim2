using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web_Client.DodatniFilteri;
using Web_Client.Services;

namespace Web_ClientTest.Services
{
	[TestClass]
	public class EntryProcessingTest
	{
		[TestMethod]
		public void EntryTest_EverythingValid()
		{
			string test = "get/resurs/1";
			EntryProcessing t = new EntryProcessing();
			t.Unos = test;
			t.Entry();
			Assert.AreEqual(test, t.Unos);

		}

		[TestMethod]
		public void EntryTest_InvalidCommandName()
		{
			string test = "qwer/resurs/1";
			string s = "";
			EntryProcessing t = new EntryProcessing();
			t.Unos = test;
			s=t.Entry();
			Assert.AreEqual("greska", s);
		}

		[TestMethod]
		public void EntryTest_InvalidEntityName()
		{
			string s = "";
			string test = "qwer/resurs/1";
			EntryProcessing t = new EntryProcessing();
			t.Unos = test;
			s=t.Entry();
			Assert.AreEqual("greska", s);

		}

	}
}
