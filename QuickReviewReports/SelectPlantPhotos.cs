using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuickReviewReports.Helper;
using System.Data.SqlClient;

namespace QuickReviewReports
{
    
    public partial class SelectPlantPhotos : Form
    {
        public string PlantId = string.Empty;
        private SqlConnection conn;

        public SelectPlantPhotos()
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
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = @"This PC:\",
                Title = "Browse png Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true

            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtbUploadPhotos.Text = openFileDialog.FileName;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> errorMsg = new List<string>();
            bool isValidateForm = true;
            if(comboBox1.SelectedIndex <= 0)
            {
                errorMsg.Add("Please Select Plant ID");
                isValidateForm = false;
            }
            if(txtbUploadPhotos.Text == null || txtbUploadPhotos.Text == "")
            {
                errorMsg.Add("Please Select Image");
                isValidateForm = false;
            }
            if (isValidateForm)
            {
                ConnectionHelper connectionHelperObj = new ConnectionHelper();
                conn = connectionHelperObj.GetSqlConnection();
                conn.Open();

                string image = txtbUploadPhotos.Text;
                Bitmap bmp = new Bitmap(image);
                FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
                byte[] bimage = new byte[fs.Length];
                fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("spGetPlantPhoto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlantId", SqlDbType.Int).Value = int.Parse(comboBox1.Text);
                cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = bimage;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Image uploaded successfully.");
            }
            else
            {
                if (errorMsg.Count > 0)
                {
                    lblwarning.Text = "";
                    foreach(string text in errorMsg)
                    {
                        string warning = text + '\n';
                        lblwarning.Text += warning;
                    }
                }
            }
           
        }
    }
}
       
