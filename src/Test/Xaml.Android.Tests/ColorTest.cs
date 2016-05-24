using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class ColorTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Should_set_red_to_hex_value()
        {
            var writer = new TestXamlWriter();

            var page = new ContentPage { BackgroundColor = Color.Red };
            var xaml = writer.Save(page);

            XamlAssert.AreEqual(xaml, "BackgroundColor", "#FF0000");
        }

        [Test]
        public void Should_set_blue_to_hex_value()
        {
            var writer = new TestXamlWriter();

            var page = new ContentPage { BackgroundColor = Color.Blue };
            var xaml = writer.Save(page);

            XamlAssert.AreEqual(xaml, "BackgroundColor", "#0000FF");
        }

        [Test]
        public void Should_set_and_retrieve_hex_value()
        {
            var writer = new TestXamlWriter();
            const string hex = "#FFB254";
            var color = Color.FromHex(hex);

            var page = new ContentPage {BackgroundColor = color};
            var xaml = writer.Save(page);

            XamlAssert.AreEqual(xaml, "BackgroundColor", hex);
        }
    }
}
