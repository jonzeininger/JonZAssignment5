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

namespace Assignment5
{
    class ListViewAdapter : BaseAdapter<Employee>
    {
        private List<Employee> employees;
        private Context mContext;

        public ListViewAdapter(Context context, List<Employee> items)
        {
            employees = items;
            mContext = context;
        }

        public override int Count
        {
            get { return employees.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Employee this[int position]
        {
            get { return employees[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.jzTitle);
            txtName.Text = employees[position].jobTitle;

            TextView txtDate = row.FindViewById<TextView>(Resource.Id.jzFirstName);
            txtDate.Text = employees[position].firstName;

            TextView txtAmount = row.FindViewById<TextView>(Resource.Id.jzLastName);
            txtAmount.Text = employees[position].lastName;

            return row;
        }
    }
}