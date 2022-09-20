using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuickReviewReports.Helper;
using System.Configuration;

namespace QuickReviewReports
{
    public partial class PlantDetailsScreen : Form
    {
        SqlConnection conn = new SqlConnection();
        public PlantDetailsScreen()
        {
            InitializeComponent();
          
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            lblWarning1.Text = "";
            bool flag = validateData();
            if (flag)
            {
                ConnectionHelper connectionHelperObj = new ConnectionHelper();
                conn = connectionHelperObj.GetSqlConnection();
                conn.Open();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("spSavePlantDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlantId", txtbPlantId.Text);
               cmd.Parameters.AddWithValue("@PlantName", txtbPlantName.Text);
                cmd.Parameters.AddWithValue("@AreaName", txtbAreaName.Text);
                cmd.Parameters.AddWithValue("@MachineName", txtbMachineName.Text);
                cmd.Parameters.AddWithValue("@MachineLocation", txtbMachineLocation.Text);

                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 255);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                string Message = Convert.ToString(cmd.Parameters["@Message"].Value);
                conn.Close();
                if(Message=="Done")
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "Records are Submitted Successfully";

                }
            }
            else
            {
                lblWarning1.Text = "All fields are Mandatory.";
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            
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
    public bool validateData()
    {
        bool flag = true;
        if (txtbPlantId.Text == "" || txtbPlantName.Text == "" || txtbAreaName.Text == "" || txtbMachineName.Text == "" || txtbMachineLocation.Text == "")
        {
            flag = false;
        }

        return flag;
    }
        private void btnShowPlantData_Click(object sender, EventArgs e)
        {

            DisplayPlantDetailsScreen ObjdisplayPlantDetailsScreen = new DisplayPlantDetailsScreen();
            ObjdisplayPlantDetailsScreen.Show();
            this.Close();

        }

        private void btnModifyPlants_Click(object sender, EventArgs e)
        {
            ModifyPlants ObjmodifyPlants = new ModifyPlants();
            ObjmodifyPlants.Show();
            this.Close();
        }

        private void btnPhotos_Click(object sender, EventArgs e)
        {
            SelectPlantPhotos ObjselectPlantPhotos = new SelectPlantPhotos();
            ObjselectPlantPhotos.Show();
            this.Close();
        }
    }
}
