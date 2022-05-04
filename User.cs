using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Database;
//It is used to manage all user details.
namespace EmployeeManagementSystem.User
{
    //It contains all predefined user types.
    public enum UserType
    {
        Employee, Manager, Admin, Undefined
    }
    public enum DesignationType
    {
        TRAINEE, SOFTWARE_DEVELOPER, SENIOR_SOFTWARE_DEVELOPER, LEAD, ARCHITECT, MANAGER, SENIOR_MANAGER, CEO
    }
    public interface IUserFunctions
    {

        void ShowDashboard();

    }
    //It contains common properties and functionalities among all users(Employee, Manager and Admin)
    public abstract class UserInformation
    {
#nullable enable
        private String? userName = "undefined";//It stores user name for all users(Employee, Manager and Admin)
        private String? password = "undefined";//It stores password for all users(Employee, Manager and Admin).
        protected static int id = 1;//It is treated as a counter to give unique Id to all employees.
        private String? employeeId = "undefined";//It stores employee Id for all users(Employee, Manager and Admin).
        private String? userRole = "undefined";//It stores which type of user whether employee,manager or admin.
        private String? firstName = "undefined";//It stores first name for all users(Employee, Manager and Admin).
        private String? lastName = "undefined";//It stores last name for all users(Employee, Manager and Admin).
        private String? designation = "undefined";//It stores designation for all users(Employee, Manager and Admin).
        private String? emailId = "undefined";//It stores email id for all users(Employee, Manager and Admin).
        private String? phoneNumber = "undefined";//It stores phone number for all users(Employee, Manager and Admin).
        private String? qualification = "undefined";//It stores qualification for all users(Employee, Manager and Admin).
        private byte yearsOfExperience = 0;//It stores years of experience for all users(Employee, Manager and Admin).
        private String? addressLine = "undefined";//It stores address for all users(Employee, Manager and Admin).
        private String? district = "undefined";//It stores district for all users(Employee, Manager and Admin).
        private String? state = "undefined";//It stores state for all users(Employee, Manager and Admin).
        private String? country = "undefined";//It stores country for all users(Employee, Manager and Admin).
        private String? pincode = "undefined";//It stores pincode for all users(Employee, Manager and Admin).
        protected byte attendanceCounter = 1;//It is used to mark the attendance only once
        private float salary = 0.0F;//It stores salary for all users(Employee, Manager and Admin).
        private String domainName="undefined";//It stores domain name.

        private bool employeeStatus;//true->active,false->inactive

        protected SortedDictionary<String, Attendance> attendanceRecords = new SortedDictionary<String, Attendance>();//It is used to store attendance records.

        //It is invoked whenever new user is created.(user means employee, manager and admin).
        public UserInformation()
        {
            this.EmployeeId = String.Format("ASPIRE{0}EMP{1}", DateTime.Now.Year, id++) ?? "undefined";
        }
        //It is used to get and set the user name.
        public String UserName
        {
            get
            {
                return this.userName ?? UserType.Undefined.ToString();
            }
            set
            {
                this.userName = value ?? UserType.Undefined.ToString();
            }
        }
        //It is used to get and set the password.
        public String Password
        {
            get
            {
                return this.password ?? UserType.Undefined.ToString();
            }
            set
            {
                this.password = value ?? UserType.Undefined.ToString();
            }
        }
        //It is used to get and set the employee Id.
        public String EmployeeId
        {
            get
            {
                return this.employeeId ?? UserType.Undefined.ToString();
            }
            set
            {
                this.employeeId = value ?? UserType.Undefined.ToString();
            }
        }
        //It is used to get and set the user type.
        public String UserRole
        {
            get
            {
                return this.userRole ?? UserType.Undefined.ToString();
            }
            set
            {
                this.userRole = value ?? UserType.Undefined.ToString();
            }
        }
        //It is used to get and set the first name.
        public String FirstName
        {
            get
            {
                return this.firstName ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.firstName = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set last name.
        public String LastName
        {
            get
            {
                return this.lastName ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.lastName = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the designation.
        public String Designation
        {
            get
            {
                return this.designation ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.designation = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the qualification.
        public String Qualification
        {
            get
            {
                return this.qualification ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.qualification = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set years of experience.
        public byte YearsOfExperience
        {
            get
            {
                return (byte)this.yearsOfExperience;
            }
            set
            {
                this.yearsOfExperience = value;
            }
        }
        //It is used to get and set the email Id.
        public String EmailId
        {
            get
            {
                return this.emailId ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.emailId = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the phone number.
        public String PhoneNumber
        {
            get
            {
                return this.phoneNumber ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.phoneNumber = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the address.
        public String AddressLine
        {
            get
            {
                return this.addressLine ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.addressLine = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the district.
        public String District
        {
            get
            {
                return this.district ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.district = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the state.
        public String State
        {
            get
            {
                return this.state ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.state = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the country.
        public String Country
        {
            get
            {
                return this.country ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.country = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the pincode.
        public String Pincode
        {
            get
            {
                return this.pincode ?? UserType.Undefined.ToString(); ;
            }
            set
            {
                this.pincode = value ?? UserType.Undefined.ToString(); ;
            }
        }
        //It is used to get and set the salary.
        public float Salary
        {
            get
            {
                return (float)this.salary;
            }
            set
            {
                this.salary = value;
            }
        }
        //It is used to get and set the employee status
        public bool EmployeeStatus
        {
            get
            {
                return this.employeeStatus;
            }
            set
            {
                this.employeeStatus = value;
            }
        }
        //It is used to get and set the domain name.
        public String DomainName {
            get {
                return this.domainName;
            } set {
                this.domainName=value;
            }
        }

        //It is used to show the user details.
        protected internal void ShowUserDetails()
        {
            Console.WriteLine("Employee Id: {0}", this.EmployeeId);
            Console.WriteLine("First name: {0}", this.FirstName);
            Console.WriteLine("Last name: {0}", this.LastName);
            Console.WriteLine("User Type: {0}", this.UserRole);
            Console.WriteLine("Designation: {0}", this.Designation);
            Console.WriteLine("Domain Name: {0}", this.DomainName);
            Console.WriteLine("Years of Experience: {0}", this.yearsOfExperience);
            Console.WriteLine("Salary: {0}", this.salary);
            Console.WriteLine("Qualification: {0}", this.qualification);
            Console.WriteLine("Email ID: {0}", this.EmailId);
            Console.WriteLine("Phone Number: {0}", this.PhoneNumber);
            Console.WriteLine("Address Line: {0}", this.AddressLine);
            Console.WriteLine("District: {0}", this.District);
            Console.WriteLine("State: {0}", this.State);
            Console.WriteLine("Country: {0}", this.Country);
            Console.WriteLine("Pincode: {0}", this.Pincode);
        }
        //It is used to edit the user details.
        protected void EditUserDetails()
        {
            do
            {
                Console.WriteLine("\n1.First Name\n2.Last Name\n3.Qualification\n4.Years of Experience"
                + "\n5.Email Id\n6.Phone Number\n7.Address Line\n8.District name\n9.State name\n10.Country name\n11.pincode\n12.Close\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your first name: ");
                        this.firstName = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 2:
                        Console.WriteLine("Enter your last name: ");
                        this.lastName = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 3:
                        Console.WriteLine("Enter your qualification: ");
                        this.qualification = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 4:
                        Console.WriteLine("Enter your years of experience: ");
                        this.YearsOfExperience = Convert.ToByte(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Enter your email Id: ");
                        this.emailId = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 6:
                        Console.WriteLine("Enter your phone number: ");
                        this.phoneNumber = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 7:
                        Console.WriteLine("Enter your address line: ");
                        this.addressLine = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 8:
                        Console.WriteLine("Enter your district name: ");
                        this.district = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 9:
                        Console.WriteLine("Enter your state name: ");
                        this.state = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 10:
                        Console.WriteLine("Enter your country name: ");
                        this.country = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 11:
                        Console.WriteLine("Enter your pincode: ");
                        this.pincode = Console.ReadLine() ?? UserType.Undefined.ToString();
                        break;
                    case 12:
                        return;
                }
                Console.WriteLine("Updated!");
            } while (true);

        }
        //It is used to check the attendance
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
                attendance.Signature = Console.ReadLine()??"undefined";
                Console.WriteLine("Check In successfully!");
                return;
            }
            else if (choice == 2)
            {
                if (!attendanceRecords.ContainsKey(Storage.TODAY_DATE))
                {
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
        //It is used to print the attendance.
        public void printAttendance()
        {
            foreach (KeyValuePair<String, Attendance> attendance in attendanceRecords)
            {
                Console.WriteLine(attendance.Value);
            }

        }


    }


}