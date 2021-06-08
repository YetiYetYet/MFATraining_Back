using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFA_Training;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MFATraining_Back
{
    public class Program
    {
        public static void Main(string[] args)
        {/*UserContext db = new UserContext();
            UserDatabaseInteraction udInteraction = new UserDatabaseInteraction(db);
            //Test Create
            Console.WriteLine("Try to create user.");
            udInteraction.CreateUser("usernameTest", "passwordTest");
            udInteraction.CreateUser("usernameTest2", "passwordTest2");
            udInteraction.CreateUser("usernameTest", "passwordTest3");
            
            //Test Read
            List<User> usersList = new List<User>(udInteraction.GetUsersList());
            
            //Test Update
            udInteraction.updateUser(usersList.First().userID, "renameTest", "renameTest");
            udInteraction.quickPrintDatabase();
            
            //Test Remove
            foreach (var user in usersList)
            {
                udInteraction.removeUser(user.userID);
            }*/
            
            /*UserContext db = new UserContext();
            UserDatabaseInteraction udInteraction = new UserDatabaseInteraction(db);
            
            udInteraction.CreateUser("Jean", "passwordJean");*/
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}