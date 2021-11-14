using Automator.Framework.Data;
using NUnit.Framework;

namespace Automator.TestSuite
{
    public class TestRunner : TestSetUp
    {
        [Test]
        public void run_Test()
        {
            Essentials essentials=new Essentials();
            FormFillingTest formFillingTest=new FormFillingTest();
            
            globalsqa.homePage.navigateToTheSite(essentials.basicData());
            globalsqa.homePage.deletePicture(formFillingTest.getTestData());
            globalsqa.homePage.selectDropdown(formFillingTest.getTestData());
            globalsqa.homePage.fillForm(formFillingTest.getTestData());
            globalsqa.homePage.validatedCompletedTest(formFillingTest.getTestData());
        }
        public override string siteUrl()
        {
            return new Essentials().SiteUrl;
        }
    }
}