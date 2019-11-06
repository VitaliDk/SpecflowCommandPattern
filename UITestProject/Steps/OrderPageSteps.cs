using System;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NLog;
using ComponentLibrary.Tasks;
using ComponentLibrary.Tasks.Orders;
using ComponentLibrary.HelperFunctions;


namespace UITestProject.Steps
{
    [Binding]
    public class OrdersPageSteps
    {
        private readonly IWebDriver driver;

        private static readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        public OrdersPageSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"the user navigates to the orders page")]
        public void WhenTheUserNavigatesToTheOrdersPage()
        {
            GoTo.OrdersPage(driver);
        }

        [When(@"the user can find at least 1 order")]
        public void WhenTheUserCanFindAtleast1Order()
        {
            FilterOrdersBySubmittedDate.FromDate(driver, 1, "Jun", "2011");
            FilterOrdersBySubmittedDate.ToDate(driver, 1, "Oct", "2019");
            VerifyOrderExists.DoesAnOrderExistOnThePage(driver);
        }

        [Then(@"the user can see an order")]
        public void ThenTheUserCanSeeAnOrder()
        {
            FilterOrdersBySubmittedDate.FromDate(driver, 1, "Jun", "2011");
            FilterOrdersBySubmittedDate.ToDate(driver, 1, "Oct", "2019");
            VerifyOrderExists.DoesAnOrderExistOnThePage(driver);
        }

        [When(@"the user clicks the link to the order details page for an order")]
        public void WhenOrderDetailsPage()
        {
            Thread.Sleep(10000);
            ForAnyOrderOnThePage.OpenOrderDetailsPage(driver);
        }
    }
}
