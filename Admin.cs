namespace EmployeeManagementSystem.User
{
    //It is used to perform all admin related operations.
    class Admin : UserInformation,IUserFunctions
    {
        public Admin() {
            this.UserRole=UserType.Admin.ToString();
        }
        //It is used to show the admin details.
        public  void ShowDashboard()
        {

        }
    }
}