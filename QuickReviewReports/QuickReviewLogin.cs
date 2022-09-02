
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickReviewReports.Helper;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuickReviewReports
{
    public partial class QuickReviewLogin : Form
    {
        string UserId = string.Empty;
        string FirstName = string.Empty;
        string LastName = string.Empty;
        bool IsAdminUser = false;

        public QuickReviewLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            bool flag= validateData();
            if (flag)
            {
                ConnectionHelper connectionHelperObj = new ConnectionHelper();
                SqlConnection conn = connectionHelperObj.GetSqlConnection();
                conn.Open();

                string userName = txtuserName.Text;
                string password = txtpassword.Text;


                string storedProcedureName = "spGetUserDetails";
                SqlDataAdapter da = new SqlDataAdapter(storedProcedureName, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar)).Value = userName;
                da.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = password;

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    UserId = dt.Rows[0]["UserId"].ToString();
                    FirstName = dt.Rows[0]["FirstName"].ToString();
                    LastName = dt.Rows[0]["LastName"].ToString();
                    IsAdminUser = Convert.ToBoolean(dt.Rows[0]["IsAdminUser"]);
                }

               else if (dt.Rows.Count == 0)
                {
                    //If no records found
                    lblWarning.Text = "You don't have access to this application.Please contact administrator.";
                }

                if (!IsAdminUser)
                {
                    lblWarning.Text = "You don't have access to this application.Please contact administrator.";
                }
                if(IsAdminUser && dt.Rows.Count>0)
                {
                    DashboardScreen objDashboardScreen = new DashboardScreen();
                    objDashboardScreen.Show();
                }

                //   this.Close();
                //   DashboardForm dashboardForm = new DashboardForm();
                //  dashboardForm.Show();
            }
            else
            {
                //if flag false;
                lblWarning.Text = "Please enter username or password.";
            }
        }

        public bool validateData()
        {
            bool flag = true;
            if(txtuserName.Text=="" || txtpassword.Text == "")
            {
                flag = false;
            }

            return flag;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
