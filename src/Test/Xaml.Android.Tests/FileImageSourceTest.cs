using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class FileImageSourceTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Should_serialize_filename()
        {
            var writer = new TestXamlWriter();

            var btn = new Button
            {
                Image = (FileImageSource) ImageSource.FromFile("test.png")
            };

            var xaml = writer.Save(btn);
            XamlAssert.AreEqual(xaml, "Image", "test.png");
        }
    }
}
