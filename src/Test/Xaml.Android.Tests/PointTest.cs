using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class PointTest
    {
        [Test]
        public void Convert_to_point()
        {
            var tc = new XamlPointTypeConverter();
            var val = tc.ConvertTo(new Point(5.0, 10.0), typeof(string));

            Assert.AreEqual("5, 10", val);
        }
    }
}
