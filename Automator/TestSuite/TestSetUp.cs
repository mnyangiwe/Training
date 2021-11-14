using Automator.Framework;
using NUnit.Framework;

namespace Automator.TestSuite
{
    public abstract class TestSetUp
    {
        public Globalsqa globalsqa;

        public TestSetUp()
        {
            globalsqa=new Globalsqa();
        }

        [SetUp]
        public void startBrowser()
        {
            Framework.Data.Essentials essentials =new Framework.Data.Essentials();
            SeleniumEventClass.selectBrowser(SeleniumEventClass.BrowserType.CHROME);
        }

        [TearDown]
        public void closeBrowser()
        {
            SeleniumEventClass.closeTheDriver();
        }
        public abstract string siteUrl();
    }
}