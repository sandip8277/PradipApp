using QuickReviewReports.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickReviewReports.Model;
using IronPdf;

namespace QuickReviewReports
{
    public partial class PlantPdfGenerationScreen : Form
    {
        //public string PlantId = string.Empty;
        private SqlConnection conn;



        public PlantPdfGenerationScreen()
        {
            InitializeComponent();
            getPlantId();
        }

        private void getPlantId()
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


            cmbPlantId.DataSource = dt;
            cmbPlantId.DisplayMember = "PlantId";
            cmbPlantId.ValueMember = "PlantId";

            cmbPlantId.SelectedItem = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashboardScreen ObjdashboardScreen = new DashboardScreen();
            ObjdashboardScreen.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ConnectionHelper connectionHelperObj = new ConnectionHelper();
            conn = connectionHelperObj.GetSqlConnection();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("spGetPlantPdf", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@PlantId", SqlDbType.Int).Value = int.Parse(cmbPlantId.Text);

            DataTable dt = new DataTable();

            da.Fill(dt);

            QuickReviewPdf qrp = new QuickReviewPdf();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    qrp.PlantId = Convert.ToInt32(row["PlantId"].ToString());
                    qrp.PlantName = row["PlantName"].ToString();
                    qrp.AreaName = row["AreaName"].ToString();
                    qrp.MachineName = row["MachineName"].ToString();
                    qrp.MachineLocation = row["MachineLocation"].ToString();
                    qrp.Image = row["Image"].ToString();
                }
                var pdfPath = "D:\\" + qrp.PlantName + ".pdf";
                var ImgDataURI = @"data:image/png;base64," + qrp.Image;
                var ImgHtml = String.Format("<img src='{0}'width='200' height='100'>", ImgDataURI);

                var HtmlLine = new ChromePdfRenderer();

                string pdfText = $"<table><tr><td><b>Plant Id :</b></td><td>{qrp.PlantId}</td></tr>" +
                    $"<tr><td><b>Plant Name :</b></td><td>{qrp.PlantName}</td></tr>" +
                    $"<tr><td><b>Area Name :</b></td><td>{qrp.AreaName}</td></tr>" +
                    $"<tr><td><b>Machine Name :</b></td><td>{qrp.MachineName}</td></tr>" +
                    $"<tr><td><b>Machine Location :</b></td><td>{qrp.MachineLocation}</td></tr>" +
                    $"<tr><td><b>Plant Photo :</b></td><td>{ImgHtml}</td></tr></table>";

                HtmlLine.RenderHtmlAsPdf(pdfText).SaveAs(pdfPath);
                MessageBox.Show("Image uploaded successfully.");
            }
            else
            {
                MessageBox.Show("Please Select Plant ID");
            }

        }
        
    }
}

