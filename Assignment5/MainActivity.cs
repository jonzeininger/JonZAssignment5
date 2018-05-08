using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace Assignment5
{
    [Activity(Label = "Gold Star Brands", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        Button btnLogin;
        Button btnEmployee;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnEmployee = FindViewById<Button>(Resource.Id.btnEmployee);

            btnLogin.Click += BtnLogin_Click;
            btnEmployee.Click += BtnEmployee_Click;
        }

        private void BtnEmployee_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(EmployeeHome));
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            if (txtUsername.Text.ToLower() == "employeeadmin" && txtPassword.Text == "318@ppUser")
            {
                StartActivity(typeof(HomeActivity));
                Toast.MakeText(this, "Success", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Enter Valid Login Cridentials", ToastLength.Long).Show();
            }
        }
    }
}

