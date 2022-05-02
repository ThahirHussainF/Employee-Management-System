using System;
using EmployeeManagementSystem.User;
namespace EmployeeManagementSystem.Database
{
    public class Attendance
    {
        private String employeeId = UserType.Undefined.ToString();
        private String date = "undefined";
        private String timeIn = "undefined";
        private String timeOut = "undefined";
        private String totalHours="undefined";
        private String attendanceStatus = "NOT YET MARKED";//NOT YET MARKED,PRESENT,ABSENT
        private String signature = "undefined";

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
        public String TotalHours
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
                return this.signature;
            }
            set
            {
                this.signature = value;
            }
        }
        public void calculateTotalHours()
        {
            DateTime dtFrom = DateTime.Parse(this.timeIn);
            DateTime dtTo = DateTime.Parse(this.TimeOut);
            double hours = dtTo.Subtract(dtFrom).Hours;
            double minutes = dtTo.Subtract(dtFrom).Minutes;
            this.totalHours=hours+" hours and "+minutes+" minutes";

        }
        public void markAttendanceStatus() {
            if(this.attendanceStatus.Equals("NOT YET MARKED")) {
                 if(Convert.ToInt32(this.totalHours.Substring(0,1))==9) {
                     this.attendanceStatus="PRESENT";
                 } else{
                     this.attendanceStatus="ABSENT";
                 }
            }
            else{
                Console.WriteLine("Attendance status was already marked!");
            }
        }

        public override String ToString() {
              return "Attendance Details"+"\nEmployee Id: "+this.EmployeeId+"\nDate: "+this.Date+"\nCheck In: "+this.timeIn+"\nCheck out: "+this.timeOut+"\nTotal Working Hours: "+this.totalHours+"\nAttendance status: "+this.attendanceStatus+"\nSignature: "+this.signature;
        }

    }
}