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
        public void ShowManagerMenu()
        {
            bool logOut = true;
            do
            {
                int choice;
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\tHi, {0}\n", this.EmployeeId);
                Console.WriteLine("\n1.Update my profile\n2.Check TimeSheet\n3.Show my profile\n4.Logout\nEnter your choice: ");
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
                        this.CheckTimesheet();
                        break;
                    //Show my profile
                    case 3:
                        this.ShowUserDetails();
                        break;
                    //Exit
                    case 4:
                        logOut = false;
                        break;
                }

            } while (logOut);
        }
        public void CheckTimesheet() {
            foreach(Employee employee in Storage.employeeRecords.Values) {
                employee.printAttendance();
            }

        }
        //It is used to show the manager details.
        public void ShowDashboard()
        {

        }
    }
}