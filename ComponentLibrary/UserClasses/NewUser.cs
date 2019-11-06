using System;
using System.Collections.Generic;
using System.Text;
using ComponentLibrary.HelperFunctions;

namespace ComponentLibrary.UserClasses
{
    public class NewUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }



        public NewUser()
        {

        }

        public static NewUser GenerateRandomUser()
        {
            NewUser newuser = new NewUser();
            newuser.email = "danial.khan@calastone.com";
            newuser.username = "TestUser" + GenerateRandom.StringOfLength(8);
            newuser.firstName = GenerateRandom.StringOfLength(5);
            newuser.lastName = GenerateRandom.StringOfLength(5);
            newuser.password = "Password123.";

            return newuser;
        }



    }
}
