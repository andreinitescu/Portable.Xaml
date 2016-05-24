using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class ThicknessTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Padding_value_should_be_converted_to_string()
        {
            var writer = new TestXamlWriter();
            var page = new ContentPage
            {
                Padding = new Thickness(5, 10, 15, 20)
            };

            var xaml = writer.Save(page);
            XamlAssert.AreEqual(xaml, "Padding", "5,10,15,20");
        }
    }
}
