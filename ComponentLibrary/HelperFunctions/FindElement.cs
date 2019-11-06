using System;
using ComponentLibrary.BaseClasses;
using OpenQA.Selenium;
using NLog;
using System.Reflection;
using System.IO;

namespace ComponentLibrary.HelperFunctions
{
    public class Find : BaseAction
    {
        protected static readonly Logger LogR = LogManager.GetCurrentClassLogger();

        public static IWebElement Element(IWebDriver driver, By selector)
        {
            // Return null by default
            IWebElement elementToReturn = null;
            string dirPath = System.IO.Directory.GetCurrentDirectory();
            String format = "dd.hh.mm.ss.ffffff";//"dd-mm-yyyy.hh.mm.tt";

            try
            {
                TakeScreenshot.SaveAs(driver, $"{dirPath}\\Screenshots", DateTime.Now.ToString(format));
                LogR.Info($"Attempt to find element with Id:  {selector}");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                elementToReturn = driver.FindElement(selector);
            }
            catch (NoSuchElementException e)
            {
                LogR.Info($"NoSuchElementException thrown");
                TakeScreenshot.SaveAs(driver, $"{dirPath}\\Screenshots", DateTime.Now.ToString(format));
                throw new NoSuchElementException("exception thrown", e);
            }
            catch (Exception e)
            {
                LogR.Info($"Exception {e} thrown for: {selector}");
                TakeScreenshot.SaveAs(driver, $"{dirPath}\\Screenshots", DateTime.Now.ToString(format));
                throw e;
            }
            // return either the element or null
            return elementToReturn;
        }

        public static Boolean ElementIfExists(IWebDriver driver, By selector)
        {
            try
            {
                driver.FindElement(selector);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
