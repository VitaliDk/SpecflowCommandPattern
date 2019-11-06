using System;
using OpenQA.Selenium;
using ComponentLibrary.Screens;
using ComponentLibrary.HelperFunctions;
using ComponentLibrary.Actions;
using NLog;

namespace ComponentLibrary.Tasks.Orders
{
    public class ForAnyOrderOnThePage
    {
        protected static readonly Logger LogR = LogManager.GetCurrentClassLogger();

        public static void OpenOrderDetailsPage(IWebDriver driver)
        {
            int i = 0;
            // By OrderDetailsPageLink = By.XPath($"//div[text()='DMI Order ID']/following::a[contains(text(),'{i}')]");
            By OrderDetailsPageLink = OrdersPage.OrderDetailsLink(i);

            while (Find.ElementIfExists(driver, OrderDetailsPageLink) == false && i < 10)
            {
                LogR.Info($"Attempt to find an order on the page with a DMI Order ID containing the digit: {i}");
                OrderDetailsPageLink = By.XPath($"//div[text()='DMI Order ID']/following::a[contains(text(),'{i}')]");
                LogR.Info($"Attempting to look for: {OrderDetailsPageLink}");

                i += 1;
            }
            Click.Element(driver, OrderDetailsPageLink);
        }
    }
}
