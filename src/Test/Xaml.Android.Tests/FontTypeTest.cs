using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class FontTypeTest
    {
        [SetUp]
        public void BeforeTest()
        {
            EnhancedXamlConfiguration.Initialize();
        }
        
        [Test]
        public void Font_should_be_empty_string()
        {
            var writer = new TestXamlWriter();
            var label = new Label();
            var xaml = writer.Save(label);

            TestHelpers.AreEqual(xaml, "Font", "", "&quot;&quot?");
        }

        [Test]
        public void Family_and_size_set()
        {
            var writer = new TestXamlWriter();
            var label = new Label
            {
                FontAttributes = FontAttributes.Bold,
                Font = Font.OfSize("Droid Sans Mono", 24)
            };

            var xaml = writer.Save(label);
            TestHelpers.AreEqual(xaml, "Font", "Droid Sans Mono, None, 24");
        }


        [Test]
        public void Size_and_attributes_set()
        {
            var writer = new TestXamlWriter();
            var label = new Label
            {
                FontAttributes = FontAttributes.Bold,
                Font = Font.SystemFontOfSize(18, FontAttributes.Bold)
            };

            var xaml = writer.Save(label);

            TestHelpers.AreEqual(xaml, "FontSize", "18", "Font Size");
            TestHelpers.AreEqual(xaml, "FontAttributes", "Bold", "Attributes");
        }
    }
}
