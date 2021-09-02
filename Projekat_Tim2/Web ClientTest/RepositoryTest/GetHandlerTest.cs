using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Text;
using Web_Client.Repository;
using Web_Client.Database;

namespace Web_ClientTest.RepositoryTest
{
	[TestClass]
	public class GetHandlerTest
	{
		[TestMethod]
		public void GetResursTest()
		{
			GetHandler get = new GetHandler();
			Tip t = new Tip(3, "ogledalo");
			Tip q = get.GetTip("get", "3");
			Resurs r = new Resurs(3, "test", "test", q);
			Resurs test = get.GetResurs("", q.Id.ToString()) ;
			Assert.AreEqual(r, test);
		}
	}
}
