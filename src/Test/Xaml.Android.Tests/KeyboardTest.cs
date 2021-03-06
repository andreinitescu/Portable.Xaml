using NUnit.Framework;
using Xamarin.Forms;
using XamarinFormsTypeConverters;

namespace Xaml.Android.Tests
{
    [TestFixture]
    public class KeyboardTest
    {
        [SetUp]
        public void BeforeTest()
        {
            EnhancedXamlConfiguration.Initialize();
        }

        [Test]
        public void Keyboard_default()
        {
            var writer = new TestXamlWriter();
            var entry = new Entry();
            
            var xaml = writer.Save(entry);
            TestHelpers.AreEqual(xaml, "Keyboard", "Default");
        }

        [Test]
        public void Keyboard_chat()
        {
            var writer = new TestXamlWriter();
            var entry = new Entry
            {
                Keyboard = Keyboard.Chat
            };

            var xaml = writer.Save(entry);
            TestHelpers.AreEqual(xaml, "Keyboard", "Chat");
        }
    }
}
