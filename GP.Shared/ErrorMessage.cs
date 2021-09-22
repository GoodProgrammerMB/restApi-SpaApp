using System;

namespace GP.Shared
{
    public static class ErrorMessage
    {
        public const string UserNotFound = " User not found";
        public const string ServerError = "Server error";
        public const string UserLoginNotFound = "User login not found";
        public static string[] UserLoginNotFoundParams(string login) => new string[] { login };

        public const string WrongPasswordForUser = "Wrong password for user";
        public static string[] WrongPasswordForUserParams(string login) => new string[] { login };
        public const string UserAlreadyExisting = "User already existing";
        public static string[] UserAlreadyExistingParams(string login) => new string[] { login };
    }
}
