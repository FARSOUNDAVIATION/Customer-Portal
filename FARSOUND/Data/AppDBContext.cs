﻿namespace FARSOUND.Data
{
    public class AppDBContext
    {
        private static List<User> _users = new List<User>();
        public static bool SaveUser(User user)
        {
            bool isExist = _users.Any(x => x.Username == user.Username);
            if (!isExist)
            {
                _users.Add(user);
                return true;
            }
            return false;
        }
        public static User? Verify(string username, string password)
        {
            return _users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
        }
    }
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string Role { get; set; }
    }
}