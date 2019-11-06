using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.Steps;
using ComponentLibrary.Tasks;

namespace UITestProject.Steps
{
    [Binding]
    public class GroupedSteps
    {
        private readonly IWebDriver driver;

        private readonly IdentityProviderSteps identityProviderSteps;
        private readonly OrdersPageSteps orderPageSteps;

        public GroupedSteps(IWebDriver driver, IdentityProviderSteps identityProviderSteps, OrdersPageSteps ordersPageSteps)
        {
            this.driver = driver;
            this.identityProviderSteps = identityProviderSteps;
            this.orderPageSteps = ordersPageSteps;
        }

        [Given(@"the user is logged into the DMI")]
        public void GivenTheUserIsLoggedIntoTheDMI()
        {
            identityProviderSteps.GivenTheUserIsOnTheLoginPage();
            identityProviderSteps.WhenTheUserAttemptsToLogIn();
            identityProviderSteps.ThenTheUserIsRedirectedToTheDMI();
        }

        [Given(@"the user is on the orders page")]
        public void GivenTheUserIsOnTheOrdersPage()
        {
            GivenTheUserIsLoggedIntoTheDMI();
            orderPageSteps.WhenTheUserNavigatesToTheOrdersPage();

        }
    }
}
