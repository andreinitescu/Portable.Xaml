using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class ButtonContentLayoutTest
    {
        [SetUp]
        public void BeforeTest()
        {
            EnhancedXamlConfiguration.Initialize();
        }

        [Test]
        public void Should_serialize_contentlayout_property()
        {
            var writer = new TestXamlWriter();
            var btn = new Button();
            var xaml = writer.Save(btn);

            TestHelpers.AreEqual(xaml, "ContentLayout", "Left, 10");
        }
    }
}
