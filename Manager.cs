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
        public void ShowDashboard()
        {
            bool logOut = true;
            do
            {
                int choice;
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\tHi, {0}\n", this.EmployeeId);
                Console.WriteLine("\n1.Update my profile\n2.Check TimeSheet\n3.Check Attendance\n4.print Attendance\n5.Show my profile\n6.Approve Emploee\n7.Logout\nEnter your choice: ");
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
                    //Exit
                    case 7:
                        logOut = false;
                        break;
                }

            } while (logOut);
        }
        public void CheckTimesheet()
        {
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                employee.printAttendance();
                Console.WriteLine("\n*****************************************************************************\n");
            }

        }
        public void approveEmployee()
        {
            foreach (Employee employee in Storage.employeeRecords.Values)
            {
                employee.ShowUserDetails();
                Console.WriteLine("\n*****************************************************************************\n");
                Console.WriteLine("\n1.Approv\n2.Deny\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    employee.EmployeeStatus = true;
                    Console.WriteLine("You was approved employee!");
                    employee.ManagerId=this.EmployeeId;
                    return;
                }
                Console.WriteLine("You was denied employee!");

            }

        }
        public void AssignRole()
        {
            foreach (Employee employee in Storage.employeeRecords.Values)
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
                Console.WriteLine("Designation was updated sucessfully!");


            }

        }

    }
}