using Automator.Framework;
using Automator.Framework.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automator.POM.Globalsqa
{
    public class HomePage : SeleniumEventClass
    {
        private By pageHeader = By.XPath("//div[@class='page_heading']//h1");
        private By imageToDrag(string imageName) => By.XPath("//h5[text()='" + imageName + "']/..");
        private By trash = By.CssSelector("div#trash");
        private By imageInsideTrash(string imageName) => By.XPath("//div[@id='trash']//h5[text()='" + imageName + "']/..");
        private By selectCountry = By.XPath("//select");
        private By profilePic = By.XPath("//input[@name='file-553']");
        private By name = By.XPath("//input[contains(@id,'name')]");
        private By email = By.XPath("//input[contains(@id,'email')]");
        private By website = By.XPath("//input[contains(@id,'website')]");
        private By experience = By.XPath("//select[contains(@id,'experienceinyears')]");
        private By expertise(string skill) => By.XPath("//label[contains(text(),'" + skill + "')]");
        private By education(string qualification) => By.XPath("//label[contains(text(),'" + qualification + "')]");
        private By btnShowAlert = By.XPath("//button[text()='Alert Box : Click Here']");
        private By comment = By.XPath("//textarea[contains(@id,'comment')]");
        private By btnSubmit = By.XPath("//button[text()='Submit']");
        private By completedForm = By.XPath("//div[contains(@id,'contact-form')]");
        private By valueToValidate(string textOnScreen) => By.XPath("//p[contains(text(),'" + textOnScreen + "')]");
        By iframe = By.XPath("(//div[@class='newtabs horizontal']//iframe)[1]");

        public void navigateToTheSite(Essentials essentials)
        {
            navigateTo(essentials.SiteUrl);
            Assert.True(waitForElementToBeReady(pageHeader, true));
        }

        public void deletePicture(FormFillingTest formFillingTest)
        {
            int numberOfPictures = formFillingTest.Images.Length;
            //check if atleast there is an image
            Assert.True(numberOfPictures > 0);
            waitForElementToBeReady(iframe);
            //changing to iframe
            webDriver.SwitchTo().Frame(webDriver.FindElement(iframe));
            IWebElement element = webDriver.FindElement(trash);
            Actions actions = new Actions(webDriver);
            //dragging all the images
            foreach (string image in formFillingTest.Images)
            {
                IWebElement element2 = webDriver.FindElement(imageToDrag(image));
                actions.DragAndDrop(element2, element).Build().Perform();
                Assert.True(waitForElementToBeReady(imageInsideTrash(image),true));
            }
        }

        public void selectDropdown(FormFillingTest formFillingTest)
        {
            //openning new tab
            newTab(formFillingTest.SelectDropdownMenu);
            //selecting country
            selectTextFromComboBox(selectCountry, formFillingTest.CountryName);
        }

        public void fillForm(FormFillingTest formFillingTest)
        {
            string ggh=formFillingTest.Samplepagetest;
            newTab(formFillingTest.Samplepagetest);
            Assert.True(waitForElementToBeReady(pageHeader));
            enterText(profilePic, formFillingTest.ProfilePic);
            enterText(name, formFillingTest.Name);
            //moving cursor to next text box
            enterText(name, Keys.Tab);
            enterText(email, formFillingTest.Email);
            enterText(website, formFillingTest.WebSite);
            enterText(experience, formFillingTest.YearsOfExperience);
            //selecting all expertise
            foreach (string skill in formFillingTest.Skills)
            {
                clickElement(expertise(skill));
            }
            clickElement(education(formFillingTest.Qualification));

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            IWebElement element = webDriver.FindElement(education(formFillingTest.Qualification));
            //scrolling to an element
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(element).Build().Perform();
            //hovering and clicking buttong
            actions.MoveToElement(webDriver.FindElement(btnShowAlert)).Click().Build().Perform();

            //closing pop ups
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();
            alert.Accept();

            enterText(comment, formFillingTest.Comment);
            clickElement(btnSubmit);
        }

        public void validatedCompletedTest(FormFillingTest formFillingTest)
        {
            Assert.True(waitForElementToBeReady(completedForm));
            Assert.NotNull(getTextFromElement(valueToValidate(formFillingTest.Name)));
            Assert.NotNull(getTextFromElement(valueToValidate(formFillingTest.Email)));
            Assert.NotNull(getTextFromElement(valueToValidate(formFillingTest.WebSite)));
            Assert.NotNull(getTextFromElement(valueToValidate(formFillingTest.Qualification)));
            Assert.NotNull(getTextFromElement(valueToValidate(formFillingTest.Comment)));
        }
    }
}