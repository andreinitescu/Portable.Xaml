using NUnit.Framework;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters.Tests
{
    [TestFixture]
    public class ThicknessTests
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Padding_value_should_be_converted_to_string()
        {
            var page = new ContentPage
            {
                Padding = new Thickness(5, 10, 15, 20)
            };

            var xaml = TestXamlWriter.Save(page);
            XamlAssert.AreEqual(xaml, "ContentPage.Padding", "5,10,15,20");
        }
    }
}