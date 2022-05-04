using System;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.User
{
    //It contains manager related details.
    class Manager : UserInformation, IUserFunctions
    {
        public Manager()
        {
            this.UserRole = UserType.Manager.ToString();
        }
        //It is used to show dashboard.
        public void ShowDashboard()
        {
            bool logOut = true;
            do
            {
                int choice;
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\tHi, {0}\n", this.EmployeeId);
                if (this.EmployeeStatus == false)
                {
                    Console.WriteLine("You were not approved by admin!");
                    return;
                }
                Console.WriteLine("\n1.Update my profile\n2.Check TimeSheet\n3.Check Attendance\n4.print Attendance\n5.Show my profile\n6.Approve Emploee\n7.Update salary details\n8.Logout\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------------------------------");
                switch (choice)
                {
                    //Update my profile
                    case 1:
                        this.EditUserDetails();
                        break;
                    //Check timesheet
                    case 2:
                        this.CheckTimesheet();
                        break;
                    //check attendance
                    case 3:
                        this.CheckAttendance();
                        break;
                    //print attendance
                    case 4:
                        this.printAttendance();
                        break;
                    //Show my profile
                    case 5:
                        this.ShowUserDetails();
                        break;
                    //Approve or Deny Employee
                    case 6:
                        this.approveEmployee();
                        break;
                    //Update salary details    
                    case 7:
                        this.UpdateSalaryDetails();
                        break;
                    //Exit
                    case 8:
                        logOut = false;
                        break;
                }

            } while (logOut);
        }
        //It is used to Check the timesheet.
        public void CheckTimesheet()
        {
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                if (employee.ManagerId.Equals(this.EmployeeId))
                {
                    employee.printAttendance();
                    Console.WriteLine("\n*****************************************************************************\n");
                }

            }

        }
        //It is used to approve employee.
        public void approveEmployee()
        {
            foreach (Employee employee in Storage.employeeRecords.Values)
            {

                if (employee.ManagerId.Equals(this.EmployeeId))
                {
                    employee.ShowUserDetails();
                    Console.WriteLine("\n*****************************************************************************\n");
                    Console.WriteLine("\n1.Approve\n2.Deny\nEnter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        employee.EmployeeStatus = true;
                        Console.WriteLine("Approved successfully!");
                        employee.ManagerId = this.EmployeeId;
                        allocateDomain();
                        return;
                    }
                    Console.WriteLine("Denied successfully!");
                }



            }

        }
        //It is used to assign role.
        public void AssignRole()
        {
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                if (employee.ManagerId.Equals(this.EmployeeId))
                {
                    employee.ShowUserDetails();
                    Console.WriteLine("\n*****************************************************************************\n");
                    Console.WriteLine("****Roles Available****\n1.TRAINEE\n2.SOFTWARE_DEVELOPER\n3.SENIOR_SOFTWARE_DEVELOPER\n4.LEAD\n5.ARCHITECT");
                    Console.WriteLine("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            employee.Designation = DesignationType.TRAINEE.ToString();
                            break;
                        case 2:
                            employee.Designation = DesignationType.SOFTWARE_DEVELOPER.ToString();

                            break;
                        case 3:
                            employee.Designation = DesignationType.SENIOR_SOFTWARE_DEVELOPER.ToString();

                            break;
                        case 4:
                            employee.Designation = DesignationType.LEAD.ToString();

                            break;
                        case 5:
                            employee.Designation = DesignationType.ARCHITECT.ToString();

                            break;

                    }
                    Console.WriteLine("Designation was updated successfully!");

                }


            }

        }
        //It is used to update the salary details.
        void UpdateSalaryDetails()
        {
            Console.WriteLine("Salary Details");
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                if (employee.ManagerId.Equals(this.EmployeeId))
                {
                    employee.ShowUserDetails();
                    Console.WriteLine("Enter the salary to update: ");
                    employee.Salary = (float)Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Salary was updated successfully!");
                }

            }
        }
        //It is used to allocate the domain.
        void allocateDomain()
        {
            Console.WriteLine("Domain Allocation");
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                employee.ShowUserDetails();
                Console.WriteLine("\n1.JAVA\n2.DOTNET\n3.PYTHON\n4.IAS\n5.BFS\n6.ORACLE\nEnter the choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    //JAVA
                    case 1:
                        employee.DomainName = Domain.JAVA.ToString();
                        break;
                    //DOTNET    
                    case 2:
                        employee.DomainName = Domain.DOTNET.ToString();
                        break;
                    //PYTHON    
                    case 3:
                        employee.DomainName = Domain.PYTHON.ToString();
                        break;
                    //IAS    
                    case 4:
                        employee.DomainName = Domain.IAS.ToString();
                        break;
                    //BFS    
                    case 5:
                        employee.DomainName = Domain.BFS.ToString();
                        break;
                    //ORACLE    
                    case 6:
                        employee.DomainName = Domain.ORACLE.ToString();
                        break;

                }

                Console.WriteLine("Domain was allocated successfully!");
            }
        }

    }
}