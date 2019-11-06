using System;
using TechTalk.SpecFlow;
using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using NLog;
using OpenQA.Selenium;
using ComponentLibrary.Tasks;
using System.IO;
using ComponentLibrary.Tasks.Orders;
using ComponentLibrary.UserClasses;

namespace UITests.Steps
{
    [Binding]
    public class IdentityProviderSteps
    {

        private readonly IWebDriver driver;

        private static readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        public IdentityProviderSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            // GoTo.DMILoginPage(driver);
            //AuthenticateUser request = new AuthenticateUser();

        }

        [When(@"the user attempts to log in")]
        public void WhenTheUserAttemptsToLogIn()
        {
            LoginTo.DMI(driver);
        }

        [When(@"the user attempts to log in with an invalid username")]
        public void WhenTheUserAttemptsToLogInWithAnInvalidUsername()
        {
            LoginTo.DMIWithInvalidUsername(driver);
        }

        [When(@"the user attempts to log in with an invalid password")]
        public void WhenTheUserAttemptsToLogInWithAnInvalidPassword()
        {
            LoginTo.DMIWithInvalidPassword(driver);
        }

        [When(@"the user attempts to log out")]
        public void WhenTheUserAttemptsToLogOut()
        {
            Logout.DMI(driver);
        }

        [Then(@"the user is redirected to the DMI")]
        public void ThenTheUserIsRedirectedToTheDMI()
        {
            WaitFor.Element(driver, DMIDashboardPage.Dashboard);
        }

        [Then(@"the user is redirected to the DMI login page")]
        public void ThenTheUserIsRedirectedToTheDMILoginPage()
        {
            WaitFor.Element(driver, DMILoginPage.LoginButton);
        }

        [Then(@"the user is shown a validation message explaining that their login attempt was unsuccessful")]
        public void ThenTheUserIsUnsuccessfulInLoggingIntoTheDMI()
        {
            WaitFor.Element(driver, DMILoginPage.InvalidLoginAttemptMessage);
        }

        [When(@"the user searches for all orders submitted after 1st June 2009")]
        public void WhenTheUserSearchesForAllOrdersSubmittedAfter1stJun2009()
        {
            // PlayStep for now
            GoTo.OrdersPage(driver);
            FilterOrdersBySubmittedDate.FromDate(driver, 1, "Jun", "2011");
            FilterOrdersBySubmittedDate.ToDate(driver, 1, "Oct", "2019");
            Console.WriteLine(VerifyOrderExists.FindOrder(driver, "2"));
            //VerifyOrderExists.DoesAnOrderExistOnThePage(driver);
            //VerifyOrderExists.DmiOrderIdEquals(driver, "1");
        }
    }
}
