using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    public class RectangleView : ContentView
    {
        public Rectangle TestProp { get; set; }    
    }

    [TestFixture]
    public class RectangleTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Set_rectangle_property_value()
        {
            var writer = new TestXamlWriter();
            var view = new RectangleView
            {
                TestProp = new Rectangle(5.5, 10.1, 15, 20)
            };

            var xaml = writer.Save(view);
            XamlAssert.AreEqual(xaml, "TestProp", "5.5, 10.1, 15, 20");
        }
    }
}
