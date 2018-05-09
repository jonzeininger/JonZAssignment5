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
    [Activity(Label = "New Employee")]
    public class AddEmployee : Activity
    {
        EditText jzPhoto;
        EditText jzFirstName;
        EditText jzLastName;
        EditText jzTitle;
        EditText jzOfficePhone;
        EditText jzMobilePhone;
        EditText jzEmail;
        EditText jzManager;
        EditText jzManagerEmail;
        Button jzAdd;

        public string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EmployeeList.db3");

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
                var reason = string.Format("Failed to create table - reason {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }


            SetContentView(Resource.Layout.AddEmployee);

            jzPhoto = FindViewById<EditText>(Resource.Id.jzPhoto);
            jzFirstName = FindViewById<EditText>(Resource.Id.jzFirstName);
            jzLastName = FindViewById<EditText>(Resource.Id.jzLastName);
            jzTitle = FindViewById<EditText>(Resource.Id.jzTitle);
            jzOfficePhone = FindViewById<EditText>(Resource.Id.jzOfficePhone);
            jzMobilePhone = FindViewById<EditText>(Resource.Id.jzMobilePhone);
            jzEmail = FindViewById<EditText>(Resource.Id.jzEmail);
            jzManager = FindViewById<EditText>(Resource.Id.jzManager);
            jzManagerEmail = FindViewById<EditText>(Resource.Id.jzManagerEmail);
            jzAdd = FindViewById<Button>(Resource.Id.jzAdd);

            jzAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if(jzFirstName.Text.Length < 2)
            {
                Toast.MakeText(this, "First name must be at least 2 characters", ToastLength.Long).Show();
                return;
            }
            if (jzLastName.Text.Length < 2)
            {
                Toast.MakeText(this, "Last name must be at least 2 characters", ToastLength.Long).Show();
                return;
            }
            if (jzTitle.Text.Length < 2)
            {
                Toast.MakeText(this, "Title must be at least 2 characters", ToastLength.Long).Show();
                return;
            }
            string alertTitle, alertMessage;
            if (!string.IsNullOrEmpty(jzFirstName.Text))
            {
                var newEmployee = new Employee
                {
                    firstName = jzFirstName.Text,
                    lastName = jzLastName.Text,
                    jobTitle = jzTitle.Text,
                    officePhone = jzOfficePhone.Text,
                    mobilePhone = jzMobilePhone.Text,
                    emailAddress = jzEmail.Text,
                    manager = jzManager.Text,
                    managerEmail = jzManagerEmail.Text
                };

                var db = new SQLiteConnection(filePath);
                db.Insert(newEmployee);

                alertTitle = "Success";
                alertMessage = string.Format("Employee added!");

            }
            else
            {
                alertTitle = "Failed";
                alertMessage = "Enter valid employee info";
            }

            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(alertTitle);
            alert.SetMessage(alertMessage);
            alert.SetPositiveButton("OK", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Continue!", ToastLength.Short).Show();
            });
            alert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

    }
}