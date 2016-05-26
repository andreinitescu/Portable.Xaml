using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class AttachablePropertyTest
    {
        [SetUp]
        public void BeforeTest()
        {
            EnhancedXamlConfiguration.Initialize();
        }

        [Test]
        public void Should_write_attached_value_properties()
        {
            var writer = new TestXamlWriter();

            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = GridLength.Auto},
                    new ColumnDefinition {Width = GridLength.Auto},
                }
            };

            var frame1 = new Frame();
            Grid.SetRow(frame1, 1);
            Grid.SetColumn(frame1, 2);

            var frame2 = new Frame {Content = new Label()};
            Grid.SetRow(frame2, 3);
            Grid.SetColumn(frame2, 4);

            grid.Children.Add(frame1);
            grid.Children.Add(frame2);

            var page = new ContentPage
            {
                Content = grid
            };

            var xaml = writer.Save(page);
            var fs = TestHelpers.Get(xaml, "//a:ContentPage/a:Grid/a:Frame");

            Assert.AreEqual("1", fs[0].Attributes["Grid.Row"].Value);
            Assert.AreEqual("2", fs[0].Attributes["Grid.Column"].Value);

            Assert.AreEqual("3", fs[1].Attributes["Grid.Row"].Value);
            Assert.AreEqual("4", fs[1].Attributes["Grid.Column"].Value);

            var ls = TestHelpers.Get(xaml, "//a:ContentPage/a:Grid/a:Frame/a:Frame.Content/a:Label");
            Assert.IsNull(ls[0].Attributes["Grid.Row"]);
        }
    }
}