using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class WebViewSourceTest
    {
        [SetUp]
        public void BeforeTest()
        {
            EnhancedXamlConfiguration.Initialize();
        }

        [Test]
        public void Should_set_red_to_hex_value()
        {
            const string url = "http://www.test.com/test.html";
            var writer = new TestXamlWriter();

            var page = new WebView
            {
                Source = new UrlWebViewSource {Url = url}
            };

            var xaml = writer.Save(page);

            XamlAssert.AreEqual(xaml, "Source", url);
        }
    }
}
