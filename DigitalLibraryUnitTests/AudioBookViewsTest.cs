using Xunit;
using Moq;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DigitalLibraryUnitTests
{
    public class AudioBookViewsTest : IDisposable
    {
        private ChromeDriver _driver;
        
        public AudioBookViewsTest()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void test()
        {
            _driver.Navigate().GoToUrl(@"http://localhost:53833/");
            var link = _driver.FindElement(By.PartialLinkText("Create New"));
            var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
            ((IJavaScriptExecutor)_driver).ExecuteScript(jsToBeExecuted);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Create New")));
            clickableElement.Click();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}

