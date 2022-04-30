using System;
using EmployeeManagementSystem.User;
namespace EmployeeManagementSystem.Database
{
    class Attendance
    {
        private String employeeId=UserType.Undefined.ToString();
        private String date = "";
        private String timeIn = "";
        private String timeOut = "";
        private byte totalHours;
        private byte attendanceStatus=0;//0->NOT YET MARKED,1-PRESENT,2-ABSENT
        private String signature = "";

        public String EmployeeId
        {
            get
            {
                return this.employeeId;
            }
            set
            {
                this.employeeId = value;
            }
        }
        public String Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public String TimeIn
        {
            get
            {
                return this.timeIn;
            }
            set
            {
                this.timeIn = value;
            }
        }
        public String TimeOut
        {
            get
            {
                return this.timeOut;
            }
            set
            {
                this.timeOut = value;
            }
        }
        public byte TotalHours
        {
            get
            {
                return this.totalHours;
            }
        }
        public String Signature
        {
            get
            {
                return this.Signature;
            }
            set
            {
                this.signature = value;
            }
        }

    }
}