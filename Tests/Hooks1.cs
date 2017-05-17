using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SupportLibraries;
using System.Configuration;
using System.IO;

namespace Workflows
{
    [Binding]
    public class Hooks1
    {
        public static MobileDriver driver;
        private static string appPackage = ConfigurationManager.AppSettings["AppPackage"];
        private static string phoneUUID = ConfigurationManager.AppSettings["UUID"];
        private static string serverAddress = ConfigurationManager.AppSettings["ServerAddress"];
        private static string serverPort = ConfigurationManager.AppSettings["ServerPort"];
        private static string bootstrapPort = ConfigurationManager.AppSettings["BootStrapPort"];

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Helpers.StartAppiumServer(serverAddress, 
                                      serverPort,
                                      bootstrapPort, 
                                      phoneUUID);
            driver = new MobileDriver("Android");
        }
        [BeforeScenario]
        public void BeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            string imagePath = Path.Combine(
               Helpers.GetTestResultFolder(),
               "result_"
               + ScenarioContext.Current.ScenarioInfo.Title.Trim()
               + ".jpeg"
           );
            Helpers.GetScreenShoot(driver.androidDriver, imagePath);
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.androidDriver.Dispose();
            Helpers.KillProcess("node");
            Helpers.CollectAppLog(appPackage);
        }
    }
}
