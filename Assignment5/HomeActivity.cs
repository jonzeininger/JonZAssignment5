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
    public class HomeActivity : Activity
    {
        Button jzAdd;
        ListView jzEmployee;

        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EmployeeList.db3");
        // Code used for SQLite is from Lab 17. Can't find a way to get the code to display in the listview. 
        // Know data is being added to the DB, getting constraint error for entering duplicate info. 

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
            SetContentView(Resource.Layout.Home);

            jzAdd = FindViewById<Button>(Resource.Id.jzAdd);
            jzEmployee = FindViewById<ListView>(Resource.Id.jzEmployee);

            jzAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddEmployee));
        }

        private void PopulateListView()
        {
            var db = new SQLiteConnection(filePath);
            var employeeList = db.Table<Employee>();

            List<string> employeeInfo = new List<string>();

            foreach (var employee in employeeList)
            {
                employeeInfo.Add(employee.firstName);
            }

            jzEmployee.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, employeeInfo.ToArray());
        }
    }


}