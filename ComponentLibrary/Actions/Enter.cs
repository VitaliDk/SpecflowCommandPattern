
using ComponentLibrary.BaseClasses;
using ComponentLibrary.HelperFunctions;
using OpenQA.Selenium;

namespace ComponentLibrary.Actions
{
    public class Enter : BaseAction
    {
        public static void Into(IWebDriver driver, By id, string text)
        {
            Find.Element(driver, id).SendKeys(text);
        }
    }
}
