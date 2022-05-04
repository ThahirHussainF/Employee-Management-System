using System;
using EmployeeManagementSystem.User;
namespace EmployeeManagementSystem.Database
{
    //It is used to perform all attendance related operations.
    public class Attendance
    {
        private String employeeId = UserType.Undefined.ToString();//It stores employee Id.
        private String date = "undefined";//It stores date.
        private String timeIn = "undefined";//It stores timeIn.
        private String timeOut = "undefined";//It stores timeOut
        private String totalHours="undefined";//It stores total hours
        private String attendanceStatus = "NOT YET MARKED";//NOT YET MARKED,PRESENT,ABSENT
        private String signature = "undefined";//It stores signature.

        //It is used to get and set the employee Id.
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
        //It is used to get and set the date
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
        //It is used to get and set the timeIn.
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
        //It is used to get and set timeOut.
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
        //It is used to get and set the total hours
        public String TotalHours
        {
            get
            {
                return this.totalHours;
            }
        }
        //It is used to set and get the signature.
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
        //It is used to calculate total working hours.
        public void calculateTotalHours()
        {
            DateTime dtFrom = DateTime.Parse(this.timeIn);
            DateTime dtTo = DateTime.Parse(this.TimeOut);
            double hours = dtTo.Subtract(dtFrom).Hours;
            double minutes = dtTo.Subtract(dtFrom).Minutes;
            this.totalHours=hours+" hours and "+minutes+" minutes";

        }
        //It is used to mark the attendance.
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
        //It is used to print the attendance object.
        public override String ToString() {
              return "Attendance Details"+"\nEmployee Id: "+this.EmployeeId+"\nDate: "+this.Date+"\nCheck In: "+this.timeIn+"\nCheck out: "+this.timeOut+"\nTotal Working Hours: "+this.totalHours+"\nAttendance status: "+this.attendanceStatus+"\nSignature: "+this.signature;
        }

    }
}