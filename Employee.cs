using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.User
{
    //It contains all employee related details.
    class Employee : UserInformation, IUserFunctions
    {
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
        //test purpose
        public void CheckAttendance()
        {
            Console.WriteLine("\n1.Check In\n2.Check out\n3.Cancel");
            byte choice = Convert.ToByte(Console.ReadLine());
            if (choice == 1)
            {
                if (attendanceRecords.ContainsKey(Storage.TODAY_DATE))
                {
                    Console.WriteLine("You were already marked attendance at {0}!", Storage.TODAY_DATE);
                    return;
                }

                Attendance attendance = new Attendance();
                attendanceRecords[Storage.TODAY_DATE] = attendance;
                attendance.TimeIn = DateTime.Now.ToShortTimeString();
                attendance.EmployeeId = this.EmployeeId;
                attendance.Date = Storage.TODAY_DATE;
                Console.WriteLine("Enter your Signature: ");
                attendance.Signature = Console.ReadLine();
                Console.WriteLine("Check In successfully!");
                return;
            }
            else if (choice == 2)
            {
                if(!attendanceRecords.ContainsKey(Storage.TODAY_DATE)){
                    Console.WriteLine("You were not checked In!");
                    return;
                }
                Attendance attendance = attendanceRecords[Storage.TODAY_DATE];
                attendance.TimeOut = DateTime.Now.ToShortTimeString();
                attendance.calculateTotalHours();
                attendance.markAttendanceStatus();
                Console.WriteLine("Checked out successfully!");

            }

        }
        public void printAttendance()
        {
            foreach (KeyValuePair<String, Attendance> attendance in attendanceRecords)
            {
                Console.WriteLine(attendance.Value);
            }

        }

    }
}