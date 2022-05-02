using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.User
{
    //It contains all employee related details.
    class Employee : UserInformation, IUserFunctions
    {
        private String managerId;
        //IT is being invoked whenever new employee was added to database.
        public Employee()
        {
            this.UserRole = UserType.Employee.ToString();
        }
        public void ShowDashboard()
        {
            bool logOut = true;
            do
            {
                int choice;
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\tHi, {0}\n", this.EmployeeId);
                if(this.EmployeeStatus==false) {
                    Console.WriteLine("You were not approved by manager!");
                    return;
                }
                Console.WriteLine("\n1.Update my profile\n2.Check attendance\n3.Show my profile\n4.print Attendance\n5.Logout\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------------------------------");
                switch (choice)
                {
                    //Update my profile
                    case 1:
                        this.EditUserDetails();
                        break;
                    //Check attendance
                    case 2:
                        this.CheckAttendance();
                        break;
                    //Show my profile
                    case 3:
                        this.ShowUserDetails();
                        break;
                    //Print Attendance
                    case 4:
                        this.printAttendance();
                        break;
                    //Exit
                    case 5:
                        logOut = false;
                        break;
                }

            } while (logOut);
        }
         public String ManagerId {
            get{
                return this.managerId;
            } set {
                this.managerId=value;
            }
        }

    }
}