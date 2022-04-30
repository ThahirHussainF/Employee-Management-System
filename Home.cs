using System;
using EmployeeManagementSystem.User;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.Home
{
    //It is used to show the home menu
    class HomeMenu
    {
        //It is used to show the home menu.
        public static void showHomeMenu()
        {
            Console.WriteLine("\n\n*****************************************************************************\n");
            Console.WriteLine("\t\t\tWELCOME TO ASPIRE SYSTEMS");
            Console.WriteLine("\n*****************************************************************************\n");
            bool exit = true;
            Storage.addAdmin();//Admin was added.
            do
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\tHOME");
                Console.WriteLine("-----------------------------------------------------------------------------");
                int choice;
                Console.WriteLine("\n1.Employee\n2.Manager\n3.Admin\n4.Exit\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    //Employee
                    case 1:
                        ShowLoginMenu(UserType.Employee.ToString());
                        break;
                    //Manager
                    case 2:
                        ShowLoginMenu(UserType.Manager.ToString());
                        break;
                    //Admin
                    case 3:
                        UserLogin.DoLogin(UserType.Admin.ToString());
                        break;
                    //Exit
                    case 4:
                        exit = false;
                        break;
                }
            } while (exit);

        }
        //It is used to show the login menu.
        public static void ShowLoginMenu(String user)
        {
            bool exit = true;

            do
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\tLOGIN");
                Console.WriteLine("-------------------------------------------------------------------------------");
                int choice;
                Console.WriteLine("\n1.Login\n2.Register\n3.Go to Home\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    //Login
                    case 1:
                        UserLogin.DoLogin(user);
                        break;
                    //Register
                    case 2:
                        UserRegister.DoRegister(user);
                        break;
                    //Exit
                    case 3:
                        exit = false;
                        break;
                }
            } while (exit);

        }

    }

}




