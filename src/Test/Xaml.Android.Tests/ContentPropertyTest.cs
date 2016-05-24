using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class ContentPropertyTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void ContentProperties_should_be_found_and_set()
        {
            var writer = new TestXamlWriter();

            var page = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label()
                    }
                }
            };

            var xaml = writer.Save(page);

            var doc = XDocument.Parse(xaml);
            var stackNode = doc.Root.Elements().First();
            var labelNode = stackNode.Elements().First();

            Assert.IsTrue(stackNode.Attributes().Any(a => a.Name.LocalName == "WidthRequest"));
            Assert.IsTrue(labelNode.Attributes().Any(a => a.Name.LocalName == "WidthRequest"));

            Assert.AreEqual("StackLayout", stackNode.Name.LocalName);
            Assert.AreEqual("Label", labelNode.Name.LocalName);
        }
    }
}
