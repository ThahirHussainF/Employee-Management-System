using System;
using System.Text.RegularExpressions;
using EmployeeManagementSystem.User;
using EmployeeManagementSystem.Security;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.Home
{
    //It contains login related details.
    public static class UserLogin
    {
        //It is used to perform login operation,
        public static void DoLogin(String user)
        {
            #nullable enable
            String? userName = "";
            String? password = "";

            Console.WriteLine("Enter the user name: ");
            userName = Console.ReadLine() ?? UserType.Undefined.ToString();
            if (!Validation.IsValidUser(user,userName))
            {
                Console.WriteLine("Invalid User!");
                return;
            }
            Console.WriteLine("Enter the password: ");
            password = Console.ReadLine() ?? UserType.Undefined.ToString();
            if (!Validation.IsValidUserCredentials(user, userName, password))
            {
                Console.WriteLine("Your credentials was incorrect!");
                return;
            }
            Console.WriteLine("Logged successfully!");
            GoAccount(user,userName);//Navigate to corresponding account

        }

         //After the successful login, It is used to navigate to their coressponding account.
         public static void GoAccount(String user,String userName) {
             switch(user) {
                 case "Employee":
                 Employee employee=Storage.employeeRecords[userName];
                 employee.ShowDashboard();
                 break;
                 case "Manager":
                 Manager manager=Storage.managerRecords[userName];
                 manager.ShowDashboard();
                 //On progress
                 break;
                 case "Admin":
                 Admin admin=Storage.adminRecords[userName];
                 admin.ShowDashboard();
                 //on progress
                 break;
             }
         }

    }

}
