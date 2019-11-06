using System;
using OpenQA.Selenium;
using ComponentLibrary.HelperFunctions;
using ComponentLibrary.Screens;

namespace ComponentLibrary.Tasks.Orders
{
    public class VerifyUserIsOnThePage
    {
        public static void OrderDetailsPage(IWebDriver driver)
        {
            Find.Element(driver, Screens.OrderDetailsPage.OrderDetailsTitle);
        }
    }
}
