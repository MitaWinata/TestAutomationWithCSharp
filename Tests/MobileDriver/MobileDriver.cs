using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflows
{
  
    public class MobileDriver 
    {
        public AndroidDriver<AndroidElement> androidDriver;
        private string serverAddress = ConfigurationManager.AppSettings["ServerAddress"];
        private string serverPort = ConfigurationManager.AppSettings["ServerPort"];
        private string appPackage = ConfigurationManager.AppSettings["AppPackage"];
        private string appActivity = ConfigurationManager.AppSettings["AppActivity"];
        private string phoneName = ConfigurationManager.AppSettings["PhoneName"];

        public MobileDriver(string plaformName)
        {
            try
            {
                createDriver(plaformName);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
        }

        private void createDriver(string platformName)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", platformName);
            capabilities.SetCapability("appPackage", appPackage);
            capabilities.SetCapability("appActivity", appActivity);
            capabilities.SetCapability("deviceName", phoneName);
            androidDriver = new AndroidDriver<AndroidElement>(
                                new Uri("http://"+ serverAddress
                                + ":"
                                + serverPort
                                + "/wd/hub"),
                                capabilities,
                                new TimeSpan(0, 0, 60));
        }
        public void Dispose()
        {
            if (androidDriver != null)
            {
                androidDriver.CloseApp();
                androidDriver.Quit();
            }
        }

    }
}
