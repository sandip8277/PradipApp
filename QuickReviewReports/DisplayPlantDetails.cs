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
using IronPdf;
using QuickReviewReports.Model;

using System.IO;
using ChoETL;

namespace QuickReviewReports
{
    public partial class DisplayPlantDetailsScreen : Form
    {
        List<PlantDetailsData> lstPlantDetailsData = new List<PlantDetailsData>();
        SqlConnection conn = new SqlConnection();
        public DisplayPlantDetailsScreen()
        {
            InitializeComponent();

            ConnectionHelper connectionHelperObj = new ConnectionHelper();
            conn = connectionHelperObj.GetSqlConnection();
            SqlCommand cmd = new SqlCommand("spGetDisplayPlantDetails", conn);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PlantDetailsScreen ObjplantDetailsScreen = new PlantDetailsScreen();
            ObjplantDetailsScreen.Show();
            this.Close();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            ConnectionHelper connectionHelperObj = new ConnectionHelper();
            conn = connectionHelperObj.GetSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetDisplayPlantDetails", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
          
            foreach (DataRow record in dt.Rows)
            {
                PlantDetailsData plantDetailsDataObj = new PlantDetailsData();
                plantDetailsDataObj.PlantId = Convert.ToInt32(record["PlantId"].ToString());
                plantDetailsDataObj.PlantName = record["PlantName"].ToString();
                plantDetailsDataObj.AreaName = record["AreaName"].ToString();
                plantDetailsDataObj.MachineName = record["MachineName"].ToString();
                plantDetailsDataObj.MachineLocation = record["MachineLocation"].ToString();

                lstPlantDetailsData.Add(plantDetailsDataObj);
            }
            
            GeneratePDFF(lstPlantDetailsData);

        }
        private void GeneratePDFF(List<PlantDetailsData> lstPlantDetailsData)
        {
            var pdfPath = @"D:\PlantPdf\mypdf.pdf"+".pdf";
            var HtmlLine = new ChromePdfRenderer();
            string pdftext = string.Empty;
            pdftext += "<br/><table border><tr><td> Plant Id </td><td> Plant Name </td><td> Area Name </td><td>Machine Name </td><td>MAchine Location </td></tr><tr>";
            foreach (var item in lstPlantDetailsData)
            {
                try
                {
                     pdftext += $"<tr><td> {item.PlantId}</td><td> {item.PlantName} </td><td> {item.AreaName} </td><td> {item.MachineName}</td><td> {item.MachineLocation} </td></tr>";
                }
                
                catch (Exception ex)
                {
                    var error_data = ex.Message;
                }
                
            }
            pdftext += "</tr></table>";
            HtmlLine.RenderHtmlAsPdf(pdftext).SaveAs(pdfPath);

            if (string.IsNullOrEmpty(lblmsg.Text))
            {
                lblmsg.Text = "Pdf are genereted successfully";
            }
        }

        
    }
}
   

