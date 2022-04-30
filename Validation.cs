using System;
using System.Text.RegularExpressions;
using EmployeeManagementSystem.User;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.ApplicationException;
//It is used to perform all security related operations.
namespace EmployeeManagementSystem.Security
{
    //It is used to perform the validation.
    static class Validation
    {
        //It is used to validating username
        public static void IsValidUserNameFormat(String userName)
        {
            string userNameForamt = "^(?=.*[0-9])" + "(?=.*[a-z])" + "(?=.*[A-Z]).{5,8}$";
            Regex regex = new Regex(userNameForamt);
            if (regex.IsMatch(userName))
            {
                return;
            }
            throw new InValidUserNameFormatException();
        }
        //It is used to validating password
        public static void IsValidPasswordFormat(String password)
        {
            string passwordForamt = "^(?=.*[0-9])" + "(?=.*[a-z])(?=.*[A-Z])" + "(?=.*[@#$%^&+=])" + "(?=\\S+$).{8,20}$";
            Regex regex = new Regex(passwordForamt);
            if (regex.IsMatch(password))
            {
                return;
            }
            throw new InValidPasswordFormatException();
        }
        //It is used to validate the user such as Employee, Manager and Admin.
        public static bool IsValidUser(String user, String userName)
        {
            if (user.Equals(UserType.Employee.ToString()) && Storage.employeeRecords.ContainsKey(userName))
            {
                return true;
            }
            else if (user.Equals(UserType.Manager.ToString()) && Storage.managerRecords.ContainsKey(userName))
            {
                return true;
            }
            else if (user.Equals(UserType.Admin.ToString()) && Storage.adminRecords.ContainsKey(userName))
            {
                return true;
            }
            return false;
        }
        //It is used to check the user credentials.
        public static bool IsValidUserCredentials(String user, String userName, String password)
        {

            if (user.Equals(UserType.Employee.ToString()) && Storage.employeeRecords[userName].Password.Equals(password))
            {
                return true;
            }
            else if (user.Equals(UserType.Manager.ToString()) && Storage.managerRecords[userName].Password.Equals(password))
            {
                return true;
            }
            else if (user.Equals(UserType.Admin.ToString()) && Storage.adminRecords[userName].Password.Equals(password))
            {
                return true;
            }
            return false;
        }
    }
}
