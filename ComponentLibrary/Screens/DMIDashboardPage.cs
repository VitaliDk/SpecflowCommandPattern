using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMIDashboardPage
    {
        public static By OrdersLink = DMINavBar.OrdersWebLink;
        public static By SettlementsLink = DMINavBar.SettlementsWebLink;
        public static By BalancesLink = DMINavBar.BalancesWebLink;
        public static By RegisterLink = DMINavBar.RegisterWebLink;

        public static By Dashboard = By.Id("dashboard");

        public static By AccountDropDownToggle = By.Id("userDropdownContainer");
    }
}
