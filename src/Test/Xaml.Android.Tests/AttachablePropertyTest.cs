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
        public void Font_should_be_empty_string()
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
            Grid.SetRow(frame1, 0);
            Grid.SetColumn(frame1, 0);

            var frame2 = new Frame();
            Grid.SetRow(frame2, 1);
            Grid.SetColumn(frame2, 1);

            grid.Children.Add(frame1);
            grid.Children.Add(frame2);

            var page = new ContentPage
            {
                Content = grid
            };

            var xaml = writer.Save(page);
        }
    }
}