using System;
namespace EmployeeManagementSystem.ApplicationException
{
    class InValidUserNameFormatException : Exception
    {
        public InValidUserNameFormatException() : base("Your user name was not correct format.Try Again!")
        {

        }
    }
    class InValidPasswordFormatException : Exception
    {
        public InValidPasswordFormatException() : base("Your password was not correct format.Try Again!")
        {

        }
    }
}