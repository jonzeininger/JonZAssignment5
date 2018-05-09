using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Assignment5
{
    class Employee
    {
        [PrimaryKey]
        // [PrimaryKey, AutoIncrement]
        // public int EmployeeId { get; set; }
        // Added EmployeeId after the first time I created the "Employee" table, get a SQLite exception if the code is added 
        // Would have to delete the table and recreate to add it as the primary key with auto increments.
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
        public string officePhone { get; set; }
        public string mobilePhone { get; set; }
        public string emailAddress { get; set; }
        public string manager { get; set; }
        public string managerEmail { get; set; }
    }
}