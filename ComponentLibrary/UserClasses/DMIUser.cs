using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ComponentLibrary.HelperFunctions.SQL;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ComponentLibrary.UserClasses
{
    public class DMIUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string userId { get; set; }
        public string clientId { get; set; }


        public DMIUser(string clientId)
        {
            this.clientId = clientId;
        }

        public static async Task<DMIUser> Create(NewUser newuser, string clientId)
        {
            DMIUser user = new DMIUser(clientId);
            IdentityProviderUser identityProvideruser = new IdentityProviderUser();
            
            var userCreated = await identityProvideruser.Create(newuser);
            user.username = userCreated.username;
            user.firstname = userCreated.firstName;
            user.lastname = userCreated.lastName;
            user.email = userCreated.email;
            user.userId = userCreated.id;

            InsertUserIntoCTNReportDatabase(user);

            return user;
        }

        public static async Task<DMIUser> Create(string clientId)
        {
            DMIUser user = new DMIUser(clientId);
            IdentityProviderUser identityProvideruser = new IdentityProviderUser();
            NewUser newuser = NewUser.GenerateRandomUser();

            var userCreated = await identityProvideruser.Create(newuser);
            user.username = userCreated.username;
            user.firstname = userCreated.firstName;
            user.lastname = userCreated.lastName;
            user.email = userCreated.email;
            user.userId = userCreated.id;

            InsertUserIntoCTNReportDatabase(user);

            return user;
        }

        public DMIUser CanViewOrders()
        {
            UserRights.InsertRightsFor(ProductType.DmiOrders, UserClaimAbility.CanSee, this);
            return this;
        }
        public DMIUser CanViewSettlements()
        {
            UserRights.InsertRightsFor(ProductType.DmiSettlements, UserClaimAbility.CanSee, this);
            return this;
        }
        public DMIUser CanSettleNetPositions()
        {
            UserRights.InsertRightsFor(ProductType.DmiSettlements, UserClaimAbility.canCloseNetPositions, this);
            return this;
        }
        public DMIUser CanViewBalances()
        {
            UserRights.InsertRightsFor(ProductType.DmiSettlements, UserClaimAbility.canViewBalances, this);
            return this;
        }

        public void DisableUser()
        {

            HttpClient Client = new HttpClient();
            var authenticateUser = new AuthenticateIdentityProviderUser();
            var token = authenticateUser.AuthAsync().GetAwaiter().GetResult();
            string patchJson = "[{'op': 'replace','path': '/disabled','value': true}]";

            //string aUser = JsonConvert.SerializeObject(newuser);
            var buffer = System.Text.Encoding.UTF8.GetBytes(patchJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            string Uri = "https://dmiqa2.calastonetest.com/login/oauth/users/" + this.userId;
            var response =  Client.PatchAsync(Uri, byteContent);

        }

        public void DeleteUser()
        {
            HttpClient Client = new HttpClient();
            var authenticateUser = new AuthenticateIdentityProviderUser();
            var token = authenticateUser.AuthAsync().GetAwaiter().GetResult();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            string Uri = "https://dmiqa2.calastonetest.com/login/oauth/users/" + this.userId;
            var response = Client.DeleteAsync(Uri);

        }

        private static void InsertUserIntoCTNReportDatabase(DMIUser user)
        {
            SqlConnection myConnection = SQLDatabaseConnection.ConnectTo("QA-AZUKS-DMI2", "CTN_Report");
            myConnection.Open();

            //generate SQL insert statement parts
            string insertInto = "INSERT INTO [User]";
            string columnNames = "(UserId,FirstName,Surname,ClientId,Username,Email,GlobalAdminType,UserMustChangePasswordOnLogin,Deleted,Disabled)";
            string columnValues = $"VALUES ('{user.userId}','{user.firstname}', '{user.lastname}', '2349','{user.username}','{user.email}',0,0,0,0)";

            //construct sql statement
            string command = insertInto + columnNames + columnValues;

            SqlCommand myCommand = new SqlCommand(command, myConnection);

            myCommand.ExecuteNonQuery();

        }
    }
}
