using System;
using System.Threading.Tasks;
using System.Threading;
using TechTalk.SpecFlow;
using ComponentLibrary.HelperFunctions.SQL;
using ComponentLibrary.UserClasses;
using BoDi;
using ComponentLibrary.Actors;
using ComponentLibrary.Tasks;
using OpenQA.Selenium;

namespace UITestProject.Steps
{
    [Binding]
    public class UserGenerationSteps
    {
        //IObjectContainer objectContainer;


        DMIUser user;
        private readonly IWebDriver driver;
        private readonly Actor james;
        public UserGenerationSteps(DMIUser dmiuser, IWebDriver driver, Actor james) 
        {
            this.user = dmiuser;
            this.driver = driver;
            this.james = james;
        }

        [Given(@"I have a token")]
        public void GivenIHaveAToken()
        {
            //AuthenticateIdentityProviderUser request = new AuthenticateIdentityProviderUser();
            //var response = await request.AuthAsync();
            //Console.WriteLine(response.access_token.ToString());

            // DMIUser coolUser = await DMIUser.CreateDMIUser("2");

            //IdentityProviderUser user = new  IdentityProviderUser();
            //var response = await user.Create();
            //Console.WriteLine(response.username);


            //DMIUser dmiuser = new DMIUser("sfs");
            Console.WriteLine("This step can see the dmi user:  " + user.email);
            //Console.WriteLine("End of user creation");
            //Console.WriteLine("username of the new dmiuser is: " + dmiuser.username);

            //SQLConnection.Connect("QA-AZUKS-DMI2", "DMI_ApiReadModel");
            //SQLRead.FromDatabase();
            //SQLRead.FromDatabase();
        }

        [Then(@"a dmi user is created")]
        public void ThenADmiUserIsCreated()
        {

 
            james.IsAbleTo(Print.ToTheScreen("it works!"));
            james.IsAbleTo(Browse.TheWeb(driver));
            james.IsAbleTo(NavigateTo.Google());
            
            Console.WriteLine(user.firstname);
            Console.WriteLine(user.lastname);
            Console.WriteLine(user.username);
            Console.WriteLine(user.email);
            
            user.CanViewOrders();
            user.CanViewSettlements();
            user.DeleteUser();

        }

        [Then(@"go to dmi")]
        public void ThenGoToDmi()
        {
            james.IsAbleTo(NavigateTo.DMI(), 
                           Print.ToTheScreen("the text"),
                           Print.ToTheScreen("second line of text"));
        }
    }
}
