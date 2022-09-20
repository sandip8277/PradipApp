using QuickReviewReports.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickReviewReports
{
    public partial class ModifyPlants : Form
    {
        public string PlantId = string.Empty;
        private SqlConnection conn;

        public ModifyPlants()
        {
            InitializeComponent();
            getPlantId();
        }

        public void getPlantId()
        {
            ConnectionHelper connectionHelperObj = new ConnectionHelper();
            conn = connectionHelperObj.GetSqlConnection();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("spGetPlantDetails", conn);

            DataTable dt = new DataTable();

            da.Fill(dt);


            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { "0", "0" };
            dt.Rows.InsertAt(dr, 0);


            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PlantId";
            comboBox1.ValueMember = "PlantId";

            comboBox1.SelectedItem = "0";

        }

        private void btnModify_Click(object sender, EventArgs e)
        {


        }

        private void OnPlantIdChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                ConnectionHelper connectionHelperObj = new ConnectionHelper();
                conn = connectionHelperObj.GetSqlConnection();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetPlantDetailsFromId", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter("@PlantId", SqlDbType.Int)).Value = int.Parse(comboBox1.Text);

                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (DataRow records in dt.Rows)
                {
                    txtbPlantName.Text = records["PlantName"].ToString();
                    txtbAreaName.Text = records["AreaName"].ToString();
                    txtbMachineName.Text = records["MachineName"].ToString();
                    txtbMachineLocation.Text = records["MachineLocation"].ToString();
                }
            }
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            lblwarning1.Text = "";
            bool flag = validateData();
            if (flag)
            {
                ConnectionHelper connectionHelperObj = new ConnectionHelper();
                conn = connectionHelperObj.GetSqlConnection();
                conn.Open();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("[spModifyDetailsById]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlantId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@PlantName", txtbPlantName.Text);
                cmd.Parameters.AddWithValue("@AreaName", txtbAreaName.Text);
                cmd.Parameters.AddWithValue("@MachineName", txtbMachineName.Text);
                cmd.Parameters.AddWithValue("@MachineLocation", txtbMachineLocation.Text);



                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                int i = 0;
                cmd.Connection = conn;
                try
                {
                    i = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    var data = ex.Message;
                }
                if (i != 0)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "Records are updated Successfully";
                    ClearAllText(this);

                    void ClearAllText(Control con)
                    {
                        foreach (Control c in con.Controls)
                        {
                            if (c is TextBox)
                                ((TextBox)c).Clear();
                            else
                                ClearAllText(c);
                        }


                    }
                }
            }
            else
            {
                lblwarning1.Text = "All fields are Mandatory.";
            }

        }

        private bool validateData()
        {
            bool flag = true;
            if (comboBox1.Text == "" || txtbPlantName.Text == "" || txtbAreaName.Text == "" || txtbMachineName.Text == "" || txtbMachineLocation.Text == "")
            {
                flag = false;
            }

            return flag;
        }

        private void ModifyPlants_Load(object sender, EventArgs e)
        {

        }
    }
}
