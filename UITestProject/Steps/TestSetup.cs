using System;
using BoDi;
using TechTalk.SpecFlow;
using ComponentLibrary.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using ComponentLibrary.Tasks;
using System.IO;
using System.Threading.Tasks;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Actors;

namespace UITestProject.Steps
{
    [Binding]
    public class TestSetup
    {

        private readonly IObjectContainer _objectContainer;

        public TestSetup(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 1)]
        public void InitialiseTest()
        {
            WebDriverFactory factory = new WebDriverFactory();
            IWebDriver driver = factory.Create(BrowserType.Chrome);
            driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [BeforeScenario(Order = 2)]
        public async Task<DMIUser> intializeDmiUser()
        {
            //DMIUser user = new DMIUser("dgfdg");
            //NewUser newuser = NewUser.GenerateRandomUser();
            //newuser.username = "TestDMIUser";
            //DMIUser user = await DMIUser.Create(newuser, "someclient");
            DMIUser user = await DMIUser.Create("someclient");
            _objectContainer.RegisterInstanceAs<DMIUser>(user);
            Actor james = new Actor();
            _objectContainer.RegisterInstanceAs<Actor>(james);

            return user;
        }

        [AfterScenario]
        public void TearDown(IWebDriver driver)
        {
            var result = TestContext.CurrentContext.Result.Outcome.ToString();
            var testName = TestContext.CurrentContext.Test.Name;

            //ReportPublisher.Excel(new FileInfo("C:\\TestOutput\\newexcel.xlsx"), testName.ToString(), result.ToString());
            if (result == "Passed")
            {
                Console.WriteLine("Test " + testName + "passed");
            }
            else if (result == "Failed")
            {
                Console.WriteLine("it failed");
            }
            driver.Close();
            driver.Quit();
        }

    }
}
