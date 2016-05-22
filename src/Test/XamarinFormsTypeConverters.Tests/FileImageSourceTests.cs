using System;
using Android.Provider;
using NUnit.Framework;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters.Tests
{
    [TestFixture]
    public class FileImageSourceTests
    {
        [SetUp]
        public void BeforeTest()
        {
            TypeConverterRegistrar.Initialize();
        }

        [Test]
        public void Should_set_red_to_hex_value()
        {
            var writer = new TestXamlWriter();

            var page = new ContentPage
            {
                Content = new Button
                {
                }
            };

            var xaml = writer.Save(page);
        }
    }
}