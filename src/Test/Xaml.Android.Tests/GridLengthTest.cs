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
            EnhancedXamlConfiguration.Initialize();
        }

        [Test]
        public void Should_serialize_gridlength()
        {
            var writer = new TestXamlWriter();

            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(100, GridUnitType.Absolute)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = GridLength.Auto},
                    new ColumnDefinition {Width = new GridLength(15)},
                    new ColumnDefinition {Width = new GridLength(20, GridUnitType.Absolute)},
                }
            };

            var page = new ContentPage
            {
                Content = grid
            };

            var xaml = writer.Save(page);

            var cols = TestHelpers.Get(xaml, "//a:ContentPage/a:Grid/a:Grid.ColumnDefinitions/a:ColumnDefinitionCollection/a:ColumnDefinition");
            var rows = TestHelpers.Get(xaml, "//a:ContentPage/a:Grid/a:Grid.RowDefinitions/a:RowDefinitionCollection/a:RowDefinition");

            Assert.AreEqual("Auto", cols[0].Attributes["Width"].Value);
            Assert.AreEqual("15", cols[1].Attributes["Width"].Value);
            Assert.AreEqual("20", cols[2].Attributes["Width"].Value);

            Assert.AreEqual("Auto", rows[0].Attributes["Height"].Value);
            Assert.AreEqual("*", rows[1].Attributes["Height"].Value);
            Assert.AreEqual("100", rows[2].Attributes["Height"].Value);
        }
    }
}