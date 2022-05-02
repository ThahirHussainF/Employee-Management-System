using System;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.User
{
    //It contains manager related details.
    class Manager : UserInformation, IUserFunctions

    {
        public Manager() {
            this.UserRole=UserType.Manager.ToString();
        }
        public void ShowDashboard()
        {
            bool logOut = true;
            do
            {
                int choice;
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\tHi, {0}\n", this.EmployeeId);
                Console.WriteLine("\n1.Update my profile\n2.Check TimeSheet\n3.Check Attendance\n4.print Attendance\n5.Show my profile\n6.Logout\nEnter your choice: ");
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
                    //Exit
                    case 6:
                        logOut = false;
                        break;
                }

            } while (logOut);
        }
        public void CheckTimesheet() {
            foreach(Employee employee in Storage.employeeRecords.Values) {
            employee.printAttendance();
            Console.WriteLine("\n*****************************************************************************\n");
            }

        }

    }
}