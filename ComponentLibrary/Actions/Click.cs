using ComponentLibrary.BaseClasses;
using ComponentLibrary.HelperFunctions;
using OpenQA.Selenium;
using NLog;

namespace ComponentLibrary.Actions
{
    public class Click : BaseAction
    {
        protected static readonly Logger LogR = LogManager.GetCurrentClassLogger();


        public static void Button(IWebDriver driver, By id)
        {
            // _Logger.Info("Attempting to click on button with id: " + id);
            LogR.Info($"Attempt to click button with id: {id}");
            Find.Element(driver, id).Click();
        }

        public static void Link(IWebDriver driver, By id)
        {
            Find.Element(driver, id).Click();
        }

        public static void LastButtonByCSS(IWebDriver driver)
        {
            LogR.Info("Attempting to click the last button using a CSS Selector");
            Find.Element(driver, By.CssSelector("button:last-child")).Click();
        }

        public static void LinkByStringValue(IWebDriver driver, string text)
        {
            LogR.Info($"Attempt to click link by text: {text}");
            Find.Element(driver, By.LinkText(text)).Click();
        }

        public static void Element(IWebDriver driver, By screenElement)
        {
            LogR.Info($"Attempt to click element with Id:  {screenElement}");
            Find.Element(driver, screenElement).Click();
        }
    }
}
