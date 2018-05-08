using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "Employee Directory")]
    public class EmployeeHome : Activity
    {
        ListView jzEmployee;
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookList.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                var db = new SQLiteConnection(filePath);
                db.CreateTable<Employee>();
            }
            catch (IOException ex)
            {
                var reason = string.Format("Failed to create Table - reason {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }

            // Create your application here
            SetContentView(Resource.Layout.EmployeeHome);

            jzEmployee = FindViewById<ListView>(Resource.Id.jzEmployee);
        }

        private void PopulateListView()
        {
            var db = new SQLiteConnection(filePath);
            var employeeList = db.Table<Employee>();

            List<string> employeeName = new List<string>();

            foreach (var employee in employeeList)
            {
                employeeName.Add(employee.firstName);
            }
            jzEmployee.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, employeeName.ToArray());
        }
    }
}