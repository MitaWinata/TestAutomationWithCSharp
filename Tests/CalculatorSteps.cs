using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SupportLibraries;
using OpenQA.Selenium.Appium.Android;
using System.IO;
using NUnit.Framework;
using System.Configuration;

namespace Workflows
{
    [Binding]
    public class CalculatorSteps
    {
        public AndroidDriver<AndroidElement> androidDriver = Hooks1.driver.androidDriver;
        private static string appPackage = ConfigurationManager.AppSettings["AppPackage"];

        [Given(@"that the app is installed")]
        public void GivenThatTheAppIsInstalled()
        {
            Assert.IsTrue(androidDriver.IsAppInstalled(appPackage), 
                "Application is not installed");       
        }

        
        [Given(@"I have entered (.*) into the calculator as argument 1")]
        public void GivenIHaveEnteredIntoTheCalculatorAsArgument1(double arg1)
        {
            IWebElement arg1Elem = androidDriver.FindElement(By.Name("arg1"));
            arg1Elem.SendKeys(arg1.ToString());
            Assert.AreEqual( arg1.ToString(),arg1Elem.Text,
                "Wrong input for argument 1");
        }
        [Given(@"I have entered (.*) into the calculator as argument 2")]
        public void GivenIHaveEnteredIntoTheCalculatorAsArgument2(double arg2)
        {
            IWebElement arg2Elem = androidDriver.FindElement(By.Name("arg2"));
            arg2Elem.SendKeys(arg2.ToString());
            Assert.AreEqual(arg2.ToString(),arg2Elem.Text,
                "Wrong input for argument 2");
        }

        [When(@"I press minus")]
        public void WhenIPressMinus()
        {
            IWebElement minusSign = androidDriver.FindElement(By.Name("subtraction"));
            minusSign.Click();
        }

        [When(@"I press division")]
        public void WhenIPressDivision()
        {
            IWebElement divSign = androidDriver.FindElement(By.Name("division"));
            divSign.Click();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(double resultVerified)
        {
            IWebElement minusSign = androidDriver.FindElement(By.Name("result"));
            string resultObtained = minusSign.Text;
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual( resultVerified.ToString(),resultObtained,
                "Wrong output");
        }
    }
}
