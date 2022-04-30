using System;
using EmployeeManagementSystem.User;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.Security;
using EmployeeManagementSystem.ApplicationException;
namespace EmployeeManagementSystem.Home
{
    //It contains all registration related details.
    static class UserRegister
    {
        //It is used to perform the registration.
        public static void DoRegister(String user)
        {
            #nullable enable
            String? userName = "";//It is used to store the user name.
            String? password = "";//It is used to store password.
            String? reEnterUserName = "";//It is used to store re-enter username.
            String? reEnterPassword = "";//It is used to store re-enter password.
            //Getting user name from user and validating user name.
            do
            {
                Console.WriteLine("Enter the user name: ");
                userName = Console.ReadLine() ?? UserType.Undefined.ToString();
                if (Validation.IsValidUser(user, userName))
                {
                    Console.WriteLine("username was already exists!.Try again");
                    continue;
                }
                try
                {
                    Validation.IsValidUserNameFormat(userName);
                }
                catch (InValidUserNameFormatException exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }
                Console.WriteLine("Re-Enter the user name: ");
                reEnterUserName = Console.ReadLine();
                if (userName.Equals(reEnterUserName))
                {
                    Console.WriteLine("Your username was match");
                    break;
                }
                else
                {
                    Console.WriteLine("Both username does not match");
                }

            } while (true);
            //Getting password from user and Validating password
            do
            {
                Console.WriteLine("Enter the password: ");
                password = Console.ReadLine() ?? UserType.Undefined.ToString();
                try
                {
                    Validation.IsValidPasswordFormat(password);
                }
                catch (InValidPasswordFormatException exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }
                Console.WriteLine("Re-Enter the password: ");
                reEnterPassword = Console.ReadLine();
                if (password.Equals(reEnterPassword))
                {
                    Console.WriteLine("Your password was match");
                    break;
                }
                else
                {
                    Console.WriteLine("Your Password was not match");
                }
            } while (true);
            //Store user object to database.
            Storage.addUser(user, userName, password);
        }
    }
}
