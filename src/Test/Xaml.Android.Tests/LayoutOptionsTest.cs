using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class LayoutOptionsTest
    {
        [SetUp]
        public void BeforeTest()
        {
            EnhancedXamlConfiguration.Initialize();
        }

        [Test]
        public void Set_to_EndAndExpand()
        {
            var writer = new TestXamlWriter();

            var label = new Label
            {
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            var xaml = writer.Save(label);

            XamlAssert.AreEqual(xaml, "VerticalOptions", "EndAndExpand");
        }

        [Test]
        public void Default_set()
        {
            var writer = new TestXamlWriter();

            var label = new Label();
            var xaml = writer.Save(label);

            XamlAssert.AreEqual(xaml, "VerticalOptions", "Fill");
        }


        [Test]
        public void Set_to_Center()
        {
            var writer = new TestXamlWriter();

            var label = new Label
            {
                VerticalOptions = LayoutOptions.Center
            };

            var xaml = writer.Save(label);

            XamlAssert.AreEqual(xaml, "VerticalOptions", "Center");
        }
    }
}
