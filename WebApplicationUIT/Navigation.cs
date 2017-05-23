using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;


namespace WebApplicationUIT
{
   [TestFixture]
   public class Navigation
   {
      private IWebDriver driver;
      private StringBuilder verificationErrors;
      private string baseURL;
      private bool acceptNextAlert = true;

      [SetUp]
      public void SetupTest()
      {    
         baseURL = "http://localhost:11316/";
         verificationErrors = new StringBuilder();
      }

      [TearDown]
      public void TeardownTest()
      {
         try {
            driver.Quit();
         } catch (Exception) {
            // Ignore errors if unable to close the browser
         }
         Assert.AreEqual("", verificationErrors.ToString());
      }

      [Test]
      public void TheNavigationFirefoxTest()
      {
         driver = new FirefoxDriver();
         driver.Navigate().GoToUrl(baseURL + "/");
         driver.FindElement(By.LinkText("Home")).Click();
         Thread.Sleep(100);
         driver.FindElement(By.LinkText("About")).Click();
         Thread.Sleep(100);
         driver.FindElement(By.LinkText("Contact")).Click();
         Thread.Sleep(100);
         driver.FindElement(By.LinkText("UserAgent")).Click();
         Thread.Sleep(100);
         driver.FindElement(By.Id("loginLink")).Click();
         Thread.Sleep(100);
         driver.FindElement(By.Id("Email")).Clear();
         driver.FindElement(By.Id("Email")).SendKeys("test@test.com");
         driver.FindElement(By.Id("Password")).Clear();
         driver.FindElement(By.Id("Password")).SendKeys("abcde");
         driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();

         Thread.Sleep(1000);

         IWebElement element = driver.FindElement(By.ClassName("validation-summary-errors"));
         Assert.AreEqual("Invalid login attempt.", element.Text);
      }

      [Test]
      public void TheNavigationChromeTest()
      {
         driver = new ChromeDriver();
         driver.Navigate().GoToUrl(baseURL + "/");
         driver.FindElement(By.LinkText("Home")).Click();
         driver.FindElement(By.LinkText("About")).Click();
         driver.FindElement(By.LinkText("Contact")).Click();
         driver.FindElement(By.LinkText("UserAgent")).Click();
         driver.FindElement(By.Id("loginLink")).Click();
         driver.FindElement(By.Id("Email")).Clear();
         driver.FindElement(By.Id("Email")).SendKeys("test@test.com");
         driver.FindElement(By.Id("Password")).Clear();
         driver.FindElement(By.Id("Password")).SendKeys("abcde");
         driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();

         Thread.Sleep(1000);

         IWebElement element = driver.FindElement(By.ClassName("validation-summary-errors"));
         Assert.AreEqual("Invalid login attempt.", element.Text);
      }

      [Test]
      public void TheNavigationInternetExplorerTest()
      {
         driver = new InternetExplorerDriver();
         driver.Navigate().GoToUrl(baseURL + "/");
         driver.FindElement(By.LinkText("Home")).Click();
         driver.FindElement(By.LinkText("About")).Click();
         driver.FindElement(By.LinkText("Contact")).Click();
         driver.FindElement(By.LinkText("UserAgent")).Click();
         driver.FindElement(By.Id("loginLink")).Click();
         driver.FindElement(By.Id("Email")).Clear();
         driver.FindElement(By.Id("Email")).SendKeys("test@test.com");
         driver.FindElement(By.Id("Password")).Clear();
         driver.FindElement(By.Id("Password")).SendKeys("abcde");
         driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();

         Thread.Sleep(1000);

         IWebElement element = driver.FindElement(By.ClassName("validation-summary-errors"));
         Assert.AreEqual("Invalid login attempt.", element.Text);
      }

      [Test]
      public void TheNavigationHTMLUnitTest()
      {
         driver = new PhantomJSDriver();
         driver.Navigate().GoToUrl(baseURL + "/");
         driver.FindElement(By.LinkText("Home")).Click();
         driver.FindElement(By.LinkText("About")).Click();
         driver.FindElement(By.LinkText("Contact")).Click();
         driver.FindElement(By.LinkText("UserAgent")).Click();
         driver.FindElement(By.Id("loginLink")).Click();
         driver.FindElement(By.Id("Email")).Clear();
         driver.FindElement(By.Id("Email")).SendKeys("test@test.com");
         driver.FindElement(By.Id("Password")).Clear();
         driver.FindElement(By.Id("Password")).SendKeys("abcde");
         driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();

         Thread.Sleep(1000);

         IWebElement element = driver.FindElement(By.ClassName("validation-summary-errors"));
         Assert.AreEqual("Invalid login attempt.", element.Text);
      }

      private bool IsElementPresent(By by)
      {
         try {
            driver.FindElement(by);
            return true;
         } catch (NoSuchElementException) {
            return false;
         }
      }

      private bool IsAlertPresent()
      {
         try {
            driver.SwitchTo().Alert();
            return true;
         } catch (NoAlertPresentException) {
            return false;
         }
      }

      private string CloseAlertAndGetItsText()
      {
         try {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert) {
               alert.Accept();
            } else {
               alert.Dismiss();
            }
            return alertText;
         } finally {
            acceptNextAlert = true;
         }
      }
   }
}
