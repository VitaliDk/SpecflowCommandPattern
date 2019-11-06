using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using OpenQA.Selenium;
using System;

namespace ComponentLibrary.Tasks
{
    public class GoTo
    {
        public void DMILoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://dmiqa3.calastonetest.com/dmi");
        }

        public static void OrdersPage(IWebDriver driver)
        {
            Click.Link(driver, DMIDashboardPage.OrdersLink);
        }

        public static void SettlementsPage(IWebDriver driver)
        {
            Click.Link(driver, DMIDashboardPage.SettlementsLink);
        }

        public static void BalancesPage(IWebDriver driver)
        {
            Click.Link(driver, DMIDashboardPage.BalancesLink);
        }

        public static void RegisterPage(IWebDriver driver)
        {
            Click.Link(driver, DMIDashboardPage.RegisterLink);
        }
    }
}
