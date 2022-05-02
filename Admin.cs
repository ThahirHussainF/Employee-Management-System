using System;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.User;
namespace EmployeeManagementSystem.User
{
    //It is used to perform all admin related operations.
    class Admin : UserInformation, IUserFunctions
    {
        public Admin()
        {
            this.UserRole = UserType.Admin.ToString();
        }
        //It is used to show the admin details.
        public void ShowDashboard()
        {
            bool logOut = true;
            do
            {
                int choice;
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\tHi, Admin\n");
                Console.WriteLine("\n1.Print Employees\n2.Print Managers\n3.Approve Managers\n4.Assign Role\n5.Update salary details\n6.Logout");
                Console.WriteLine("\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        this.PrintEmployees();
                        break;
                    case 2:
                        this.PrintManagers();
                        break;
                    case 3:
                        this.approveManager();
                        break;
                    case 4:
                        this.AssignRole();
                        break;
                    case 5:
                        break;
                    case 6:
                        logOut = false;
                        break;
                }
            } while (logOut);

        }
        void PrintEmployees()
        {
            Console.WriteLine("Employee Details");
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                employee.ShowUserDetails();
            }
        }
        void PrintManagers()
        {
            Console.WriteLine("Manager Details");
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
            }
        }

        public void approveManager()
        {
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
                Console.WriteLine("\n*****************************************************************************\n");
                Console.WriteLine("\n1.Approv\n2.Deny\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    manager.EmployeeStatus = true;
                    Console.WriteLine("You was approved  by admin!");
                    return;
                }
                Console.WriteLine("You was denied by admin!");

            }

        }
        public void AssignRole()
        {
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
                Console.WriteLine("\n*****************************************************************************\n");
                Console.WriteLine("****Roles Available****\n1.MANAGER\n2.SENIOR_MANAGER\n3.CEO");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        manager.Designation = DesignationType.MANAGER.ToString();
                        break;
                    case 2:
                        manager.Designation = DesignationType.SENIOR_MANAGER.ToString();
                        break;
                    case 3:
                        manager.Designation = DesignationType.CEO.ToString();
                        break;

                }
                Console.WriteLine("Designation was updated sucessfully!");
            }
        }

        void UpdateSalaryDetails()
        {
            Console.WriteLine("Salary Details");
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
                Console.WriteLine("Enter the salary to update: ");
                manager.Salary = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Salary was updated successfully!");
            }
        }

    }
}