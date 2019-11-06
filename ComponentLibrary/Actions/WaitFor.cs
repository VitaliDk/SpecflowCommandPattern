using ComponentLibrary.HelperFunctions;
using OpenQA.Selenium;
using System;

namespace ComponentLibrary.Actions
{
    public class WaitFor
    {
        public static void Element(IWebDriver driver, By id)
        {
            Find.Element(driver, id);
            TakeScreenshot.SaveAs(driver, "C:\\CSharpUITestProject\\UITestProject\\UITests", "testScreenshotMethod");
        }
    }
}
