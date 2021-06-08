using System;
using System.Collections.Generic;
using System.Linq;

namespace MFA_Training
{
    public class UserDatabaseInteraction
    {
        private UserContext _db;

        public UserDatabaseInteraction(UserContext db)
        {
            _db = db;
        }

        public void CreateUser(string username, string password)
        {
            Console.WriteLine("Create new user");
            if (username == String.Empty || password == String.Empty)
            {
                Console.WriteLine("Invalid create user argument");
                return;
            }
            _db.Add(new User() {create_date = DateTime.Now.ToString(), password = password, username = username});
            _db.SaveChanges();
        }

        public IEnumerable<User> GetUsersList()
        {
            List<User> userList = new List<User>();
            foreach (User user in _db.Users)
            {
                Console.WriteLine("ID : " + user.userID + " \t Username = " + user.username + " \t Password = " + user.password + " \t CreationDate = " + user.create_date);
                userList.Add(user);
            }
            return userList;
        }

        public User GetUserByUsername(string username)
        {
            List<User> userList = _db.Users.Where(x => x.username == username).ToList();
            if (userList.Count <= 0)
            {
                Console.WriteLine("No user with this name found : " + username);
                return null;
            }
            else
            {
                Console.WriteLine(userList.Count + " user(s) found with this usernames, return the first by default");
                return userList.First();
            }

        }

        public void updateUser(int userID, string newUsername, string newPassword)
        {
            Console.WriteLine("Update User");
            if (newUsername == String.Empty || newPassword == String.Empty)
            {
                Console.WriteLine("Invalid update user argument");
                return;
            }

            if (_db.Users.Find(userID) == null)
            {
                Console.WriteLine("user with this userId not found (userID = " + userID + ")");
            }
            else
            {
                Console.WriteLine("User Found");
                User user = _db.Users.Find(userID);
                user.username = newUsername;
                user.password = newPassword;
                _db.SaveChanges();
            }
        }

        public void removeUser(int userID)
        {
            Console.WriteLine("Remove User");
            if (_db.Users.Find(userID) == null)
            {
                Console.WriteLine("user with this userId not found (userID = " + userID + ")");
            }
            else
            {
                Console.WriteLine("User Found, and removed");
                _db.Remove(_db.Users.Find(userID) ?? throw new InvalidOperationException());
                _db.SaveChanges();
            }
        }

        public void quickPrintDatabase()
        {
            foreach (var user in _db.Users)
            {
                Console.WriteLine("ID : " + user.userID + " \t Username = " + user.username + " \t Password = " + user.password + " \t CreationDate = " + user.create_date);
            }
        }
    }
}