using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using OpenQA.Selenium;

namespace ComponentLibrary.Tasks
{
    public class Logout
    {
        public static void DMI(IWebDriver driver)
        {
            Click.Button(driver, DMIDashboardPage.AccountDropDownToggle);
            Click.LastButtonByCSS(driver);
            WaitFor.Element(driver, DMILoginPage.UsernameField);
        }
    }
}
