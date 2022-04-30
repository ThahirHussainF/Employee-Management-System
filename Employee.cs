using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Database;
namespace EmployeeManagementSystem.User
{
    //It contains all employee related details.
    class Employee : UserInformation, IUserFunctions
    {
        SortedDictionary<String, Attendance> records = new SortedDictionary<string, Attendance>();
        //IT is being invoked whenever new employee was added to database.
        public Employee()
        {
            this.UserRole = UserType.Employee.ToString();
        }
        public void ShowEmployeeMenu()
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
        public void UnderProgress()
        {
            if (records.ContainsKey(Storage.TODAY_DATE))
            {
                Console.WriteLine("You were already marked attendance at {0}!", Storage.TODAY_DATE);
                return;
            }
            Console.WriteLine("You were not yet mark attendance!");
            Attendance attendance=new Attendance();
            records[Storage.TODAY_DATE]=attendance;
            Console.WriteLine("Did you mark attendance(press 1 for yes,2 for no): ");
            byte choice = Convert.ToByte(Console.ReadLine());
            if (choice == 1)
            {
                attendance.TimeIn=DateTime.Now.ToShortTimeString();
                attendance.EmployeeId=this.EmployeeId;
                Console.WriteLine("You were marked attendance on {0}", Storage.TODAY_DATE);
                return;
            }
            else
            {
                Console.WriteLine("You were not mark attendance!");
            }

        }
        public void CheckAttendance()
        {
            if (this.attendanceRecords.ContainsKey(Storage.TODAY_DATE))
            {
                Console.WriteLine("You were already marked attendance at {0}!", Storage.TODAY_DATE);
                return;
            }
            else
            {
                Console.WriteLine("You were not yet mark attendance!");
                Console.WriteLine("Did you mark attendance(press 1 for yes,2 for no): ");
                byte choice = Convert.ToByte(Console.ReadLine());
                if (choice == 1)
                {
                    this.attendanceRecords[Storage.TODAY_DATE] = true;
                    Console.WriteLine("You were marked attendance on {0}", Storage.TODAY_DATE
                    );
                    return;
                }
                else
                {
                    Console.WriteLine("You were not mark attendance!");
                }

            }

        }
        public void printAttendance()
        {
            string option;//It may be PRESENT/ABSENT/NOT YET MARKED
            Console.WriteLine("\n\n*****************************************************************************\n");
            Console.WriteLine("Name: {0} \nEmployee Id: {1} \nEmployee Designation: {2}", this.FirstName + " " + this.LastName, this.EmployeeId, this.Designation);
            Console.WriteLine("\n*****************************************************************************\n");
            Console.WriteLine("\t\t Date\t\t\tAttendance status\n");
            if (!this.attendanceRecords.ContainsKey(DateTime.Now.Date.ToShortDateString()))
            {
                Console.WriteLine("\t\t{0}\t\t\tNot YET MARKED", DateTime.Now.Date.ToShortDateString());
                return;

            }
            foreach (KeyValuePair<String, bool> attendance in this.AttendenceRecords)
            {
                option = (attendance.Value == true) ? "PRESENT" : "ABSENT";
                Console.WriteLine("\t\t{0}\t\t{1}", attendance.Key, option);

            }
        }
        //It this used to show the employee details.
        public void ShowDashboard()
        {

        }
    }
}