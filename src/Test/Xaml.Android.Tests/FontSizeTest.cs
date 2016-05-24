using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class FontSizeTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Should_serialize_fontsize()
        {
            var writer = new TestXamlWriter();

            var btn = new Button
            {
                FontSize = 25
            };

            var xaml = writer.Save(btn);

            XamlAssert.AreEqual(xaml, "FontSize", "25", "FontSize converter was not executed?");
        }
    }
}
