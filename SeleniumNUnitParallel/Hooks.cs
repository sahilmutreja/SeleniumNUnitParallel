using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Reflection;

namespace SeleniumNUnitParallel
{

    public class Hooks : Base
    {

        public Hooks(BrowserType browser)
        {
            SelectBrowser(browser);
        }

        private void SelectBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.firefox:
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    FirefoxOptions options = new FirefoxOptions();
                    Driver = new FirefoxDriver(service, options, TimeSpan.FromMinutes(1));
                    break;
                case BrowserType.chrome:
                    Driver = new ChromeDriver();
                    break;
                default:
                    break;
            }
        }
    }
    public enum BrowserType
    {
        firefox,
        chrome
    }
}