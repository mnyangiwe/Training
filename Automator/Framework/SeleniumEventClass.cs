using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automator.Framework
{
    public class SeleniumEventClass
    {
        public static IWebDriver webDriver;
        private static DriverManager webDriverManager;
        private static BrowserType selectedBrowser;
        public SeleniumEventClass()
        {

        }

        public static void selectBrowser(BrowserType browserType)
        {
            if (webDriver == null)
            {
                selectedBrowser = browserType;
                instantiatedBrowser();
            }
        }

        public enum BrowserType { CHROME, FIREFOX, EDGE, IE, DEFAULT }

        protected static void instantiatedBrowser()
        {
            webDriverManager = new DriverManager();
            switch (selectedBrowser)
            {
                case BrowserType.CHROME:
                    webDriverManager.SetUpDriver(new ChromeConfig());
                    webDriver = new ChromeDriver();
                    break;
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().PageLoad.TotalMinutes.Equals(2);
            webDriver.Manage().Timeouts().ImplicitWait.TotalMinutes.Equals(1);
        }

        public void navigateTo(string siteUrl)
        {
            webDriver.Navigate().GoToUrl(siteUrl);
        }

        protected bool waitForElementToBeReady(By elementPath, bool isEanable = false)
        {

            bool elementFound = false;
            int counter = 0;
            try
            {
                while (!elementFound && counter < 5)
                {
                    try
                    {
                        IWebElement element = webDriver.FindElement(elementPath);
                        if (isEanable)
                        {
                            if (element.Displayed && element.Enabled)
                            {
                                elementFound = true;
                                break;
                            }
                        }
                        else
                        {
                            if (element.Displayed)
                            {
                                elementFound = true;
                                break;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        ex.Message.Trim();
                        elementFound = false;
                        counter++;
                    }
                    Thread.Sleep(250);
                }
            }
            catch (Exception ex)
            {
                ex.Message.TrimEnd();
                elementFound = false;
            }
            return elementFound;
        }

        protected bool clickElement(By elementPath)
        {
            try
            {
                waitForElementToBeReady(elementPath);
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
                if (waitForElementToBeReady(elementPath, true))
                {
                    webDriver.FindElement(elementPath).Click();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ex.Message.TrimEnd();
                return false;
            }
        }

        protected bool selectTextFromComboBox(By elementPath, String valueToBeSelected)
        {
            try
            {
                waitForElementToBeReady(elementPath, true);
                IWebElement element = webDriver.FindElement(elementPath);
                SelectElement comboBox = new SelectElement(element);
                comboBox.SelectByText(valueToBeSelected);
                return true;
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
                return false;
            }
        }

        protected bool enterText(By elementPath, String textToEnter)
        {
            try
            {
                waitForElementToBeReady(elementPath);
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(500));
                if (waitForElementToBeReady(elementPath, true))
                {
                    webDriver.FindElement(elementPath).SendKeys(textToEnter);
                }

                return true;
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
                return false;
            }
        }

        protected Boolean newTab(String url)
        {
            try
            {
                string currentWinHandle = webDriver.CurrentWindowHandle;
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)webDriver;
                jsExecutor.ExecuteScript("window.open('" + url + "')");
                int bn = webDriver.WindowHandles.Count;
                foreach (string winHandle in webDriver.WindowHandles)
                {
                    if (winHandle.Equals(currentWinHandle))
                    {
                        continue;
                    }
                    webDriver.SwitchTo().Window(winHandle);
                }

                if (currentWinHandle != webDriver.CurrentWindowHandle)
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public void dragAndDrop(By dragThis, By dropHere)
        {
            IWebElement elementToDrag = webDriver.FindElement(dragThis);
            IWebElement elementToDropAt = webDriver.FindElement(dropHere);
            SeleniumDragDrop.DragDropHelper helper = new SeleniumDragDrop.DragDropHelper(webDriver);
            helper.DragAndDrop(elementToDrag, elementToDropAt);
        }

        protected String getTextFromElement(By elementPath)
        {
            try
            {
                waitForElementToBeReady(elementPath);
                IWebElement element;
                string foundText="";
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(500));
                if (waitForElementToBeReady(elementPath, true))
                {
                    element=webDriver.FindElement(elementPath);
                    foundText=element.Text;
                }
                return foundText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    public static void closeTheDriver()
    {
        try{
            webDriver.Close();
            webDriver.Quit();

        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    }
}