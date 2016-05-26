using System.Linq;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;

namespace Xaml.Android.Tests
{
    public static class TestHelpers
    {
        public static void AreEqual(string xaml, string property, string value, string message = null)
        {
            var doc = XDocument.Parse(xaml);
            var a = doc.Root?.Attributes(property).FirstOrDefault();
            Assert.AreEqual(a?.Value, value, message);
        }

        public static XmlNodeList Get(string xaml, string xpath)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xaml);

            var nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("a", "clr-namespace:Xamarin.Forms;assembly=Xamarin.Forms.Core");
            return doc.SelectNodes(xpath, nsMgr);
        }
    }
}