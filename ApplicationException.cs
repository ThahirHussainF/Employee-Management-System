using System;
//It is used to handle Invalid username whenever user types.
namespace EmployeeManagementSystem.ApplicationException
{
    class InValidUserNameFormatException : Exception
    {
        public InValidUserNameFormatException() : base("Your user name was not correct format.Try Again!")
        {

        }
    }
    //It is used to handle Invalid passoword whenever user types.

    class InValidPasswordFormatException : Exception
    {
        public InValidPasswordFormatException() : base("Your password was not correct format.Try Again!")
        {

        }
    }
}