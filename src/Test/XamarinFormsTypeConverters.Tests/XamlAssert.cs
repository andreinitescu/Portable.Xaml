using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace XamarinFormsTypeConverters.Tests
{
    public static class XamlAssert
    {
        public static void AreEqual(string xml, string property, string value, string message = null)
        {
            var doc = XDocument.Parse(xml);
            var match = doc.Document?.Descendants().FirstOrDefault(p => p.Name.LocalName == property);
            Assert.AreEqual(match?.Value, value, message);
        }
    }
}