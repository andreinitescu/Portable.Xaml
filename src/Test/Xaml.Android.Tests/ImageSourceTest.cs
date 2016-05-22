using System;
using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class ImageSourceTest
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Source_property_xnull()
        {
            var writer = new TestXamlWriter();
            var img = new Image();
            var xaml = writer.Save(img);

            XamlAssert.AreEqual(xaml, "Source", "{x:Null}");
        }

        [Test]
        public void Source_property_set_to_filename()
        {
            const string file = "filename.png";
            var writer = new TestXamlWriter();
            var img = new Image {Source = ImageSource.FromFile(file) };
            var xaml = writer.Save(img);

            XamlAssert.AreEqual(xaml, "Source", file);
        }

        [Test]
        public void Source_property_set_to_uri()
        {
            const string url = "http://www.doesntexist.com/pic.png";
            var writer = new TestXamlWriter();
            var img = new Image { Source = ImageSource.FromUri(new Uri(url)) };
            var xaml = writer.Save(img);

            XamlAssert.AreEqual(xaml, "Source", url);
        }
    }
}