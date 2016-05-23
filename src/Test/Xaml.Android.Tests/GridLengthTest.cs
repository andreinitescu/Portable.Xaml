using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class GridLengthTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Font_should_be_empty_string()
        {
            var writer = new TestXamlWriter();
            var grid = new ContentPage
            {
                Content = new Grid()
            };

            var xaml = writer.Save(grid);
        }
    }
}