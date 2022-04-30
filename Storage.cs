using System;
using System.Collections.Generic;
using EmployeeManagementSystem.User;
//It contains all database related classes.
namespace EmployeeManagementSystem.Database
{
    //It is treated as Storage medium to store all details among all users(Employee, Manager, Admin).
    public static class Storage
    {
        internal  static readonly String TODAY_DATE=DateTime.Now.ToShortDateString();
        internal static SortedDictionary<String, Employee> employeeRecords = new SortedDictionary<string, Employee>();//It is used to store user name with their employee object into coresponding dictionary.
        internal static SortedDictionary<String, Manager> managerRecords = new SortedDictionary<string, Manager>();//It is used to store user name with their manager object into coresponding dictionary.
        internal static SortedDictionary<String, Admin> adminRecords = new SortedDictionary<string, Admin>();//It is used to store user name with their admin object into coresponding dictionary.
        public static void addUser(String user, String userName, String password)
        {
            //user means Employee, Manager, Admin
            if (user.Equals(UserType.Employee.ToString()))
            {
                Employee employee = new Employee();
                employee.UserName = userName;
                employee.Password = password;
                employeeRecords.Add(employee.UserName, employee);
                Console.WriteLine("Account was  created successfully!\n\nYour {0} Id was {1}.", user, employee.EmployeeId);
            } else if(user.Equals(UserType.Manager.ToString())) {
                Manager manager =new Manager();
                manager.UserName=userName;
                manager.Password=password;
                managerRecords.Add(manager.EmployeeId,manager);
                Console.WriteLine("Account was  created successfully!\n\nYour {0} Id was {1}.", user,manager.EmployeeId);
            }
        }
        public static void addAdmin() {
            Admin admin=new Admin();
            admin.UserName="Thahir14";
            admin.Password="Thahir@14";
            adminRecords.Add(admin.UserName,admin);
            Employee employee=new Employee();
            employee.UserName="Thahir14";
            employee.Password="Thahir14@";
            employeeRecords.Add(employee.UserName,employee);
            Manager manager=new Manager();
            manager.UserName="Thahir14";
            manager.Password="Thahir14@";
            managerRecords.Add(manager.UserName,manager);
        }
    }
}
