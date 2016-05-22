using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace Xaml.Android.Tests
{
    public static class XamlAssert
    {
        public static void AreEqual(string xml, string property, string value, string message = null)
        {
            var doc = XDocument.Parse(xml);
            var attrib = doc.Root?.Attributes(property).FirstOrDefault();
            Assert.AreEqual(attrib?.Value, value, message);
        }
    }
}