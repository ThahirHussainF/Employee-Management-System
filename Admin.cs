using System;
using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.User;
namespace EmployeeManagementSystem.User
{

    //It contains all domains.
    enum Domain
    {
        JAVA, DOTNET, PYTHON, IAS, BFS, ORACLE
    }
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
                    //Print employees
                    case 1:
                        this.PrintEmployees();
                        break;
                    //Print managers    
                    case 2:
                        this.PrintManagers();
                        break;
                    //Approve or deny manager    
                    case 3:
                        this.approveManager();
                        break;
                    //Assign role to manager    
                    case 4:
                        this.AssignRole();
                        break;
                    //Update the salary details    
                    case 5:
                        this.UpdateSalaryDetails();
                        break;
                    //Exit    
                    case 6:
                        logOut = false;
                        break;
                }
            } while (logOut);

        }
        //It is used to print employees
        void PrintEmployees()
        {
            Console.WriteLine("Employee Details");
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                employee.ShowUserDetails();
            }
        }
        //It is used to print managers
        void PrintManagers()
        {
            Console.WriteLine("Manager Details");
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
            }
        }
        //It is used to approve managers
        public void approveManager()
        {
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
                Console.WriteLine("\n*****************************************************************************\n");
                Console.WriteLine("\n1.Approve\n2.Deny\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    manager.EmployeeStatus = true;
                    Console.WriteLine("Approved successfully!");
                    this.allocateDomain();
                    return;
                }
                Console.WriteLine("Denied successfully!");

            }

        }
        //It is used to assign role.
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
                Console.WriteLine("Designation was updated successfully!");
            }
        }
        //It is used to update salary details.
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
        //It is used to allocate domain.
        void allocateDomain()
        {
            Console.WriteLine("Domain Allocation");
            foreach (Manager manager in Storage.managerRecords.Values)
            {
                manager.ShowUserDetails();
                Console.WriteLine("\n1.JAVA\n2.DOTNET\n3.PYTHON\n4.IAS\n5.BFS\n6.ORACLE\nEnter the choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        manager.DomainName = Domain.JAVA.ToString();
                        break;
                    case 2:
                        manager.DomainName = Domain.DOTNET.ToString();
                        break;
                    case 3:
                        manager.DomainName = Domain.PYTHON.ToString();
                        break;
                    case 4:
                        manager.DomainName = Domain.IAS.ToString();
                        break;
                    case 5:
                        manager.DomainName = Domain.BFS.ToString();
                        break;
                    case 6:
                        manager.DomainName = Domain.ORACLE.ToString();
                        break;

                }

                Console.WriteLine("Domain was allocated successfully!");
            }
        }

    }
}