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
        public void Should_serialize_gridlength()
        {
            var writer = new TestXamlWriter();

            var grid = new Grid();
            grid.Children.Add(new Label());

            var page = new ContentPage
            {
                Content = grid
            };

            var xaml = writer.Save(page);
            Assert.Fail();
        }
    }
}