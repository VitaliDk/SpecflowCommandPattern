using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using OpenQA.Selenium;

namespace ComponentLibrary.Tasks
{
    public class LoginTo
    {
        public static void DMI(IWebDriver driver)
        {
            Enter.Into(driver, DMILoginPage.UsernameField, "qa1");
            Enter.Into(driver, DMILoginPage.PasswordField, "Password123.");
            Click.Button(driver, DMILoginPage.LoginButton);
            WaitFor.Element(driver, DMIDashboardPage.Dashboard);
        }

        public static void DMIWithInvalidUsername(IWebDriver driver)
        {
            Enter.Into(driver, DMILoginPage.UsernameField, "invalidusernameTest");
            Enter.Into(driver, DMILoginPage.PasswordField, "Password123.");
            Click.Button(driver, DMILoginPage.LoginButton);
            WaitFor.Element(driver, DMILoginPage.UsernameField);
        }

        public static void DMIWithInvalidPassword(IWebDriver driver)
        {
            Enter.Into(driver, DMILoginPage.UsernameField, "qa9");
            Enter.Into(driver, DMILoginPage.PasswordField, "Password123.");
            Click.Button(driver, DMILoginPage.LoginButton);
            WaitFor.Element(driver, DMILoginPage.UsernameField);
        }
    }
}
