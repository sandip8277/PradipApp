using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChoETL;
using QuickReviewReports.Model;
using IronPdf;

namespace QuickReviewReports
{
    public partial class DashboardScreen : Form
    {
        List<PlantDetails> lstPlantDetails = new List<PlantDetails>();
        public DashboardScreen()
        {
            InitializeComponent();
        }

        private void DashboardScreen_Load(object sender, EventArgs e)
        {
            lblDashboard.Text = "Welcome to dashboard Screen";
        }

        private void BrowseCSV_Click(object sender, EventArgs e)
        {

            OpenFileDialog ObjopenFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CSV Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (ObjopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ObjopenFileDialog.FileName;
            }
        }

        private void btnTargetPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTargetPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGeneratePDFreport_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            lblMsg.ForeColor = Color.Red;
            lblMsg.BackColor = Color.Yellow;
            try
            {
                lstPlantDetails = new List<PlantDetails>(); //To clear the list everytime before generating
                foreach (var record in new ChoCSVReader<PlantDetails>(txtFilePath.Text).WithFirstLineHeader())
                {
                    PlantDetails objPlantDetails = new PlantDetails();
                    objPlantDetails.Plant_Id = record.Plant_Id;
                    objPlantDetails.Plant_Name = record.Plant_Name;
                    objPlantDetails.Area_Name = record.Area_Name;
                    objPlantDetails.Machine_Data = record.Machine_Data;

                    lstPlantDetails.Add(objPlantDetails);
                }
                GeneratePDFForEachRow(lstPlantDetails);
            }
            catch (Exception ex)  //Need to understand Exception handling=== Pre-defined Exception Class
            {
                var error_data = ex.Message;

                lblMsg.Text = error_data;
            }

        }

        private void GeneratePDFForEachRow(List<PlantDetails> lstPlantDetails)
        {
            DirectoryInfo di = new DirectoryInfo(txtTargetPath.Text);

            //First it deletes all files at given path
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (var item in lstPlantDetails)
            {
                try
                {

                    var pdfPath = txtTargetPath.Text + "\\" + item.Plant_Name + ".pdf";
                    string imagePath = $"..\\..\\Images\\plant_image.png";


                    var pngBinaryData = File.ReadAllBytes(imagePath);
                    var ImgDataURI = @"data:image/png;base64," + Convert.ToBase64String(pngBinaryData);
                    var ImgHtml = String.Format("<img src='{0}'>", ImgDataURI);

                    var HtmlLine = new ChromePdfRenderer();
                    
                    string pdftext = $"{ImgHtml} <br/> <table><tr><td> Plant_Id </td><td> Plant_Name </td><td> Area_Name </td><td>Machine_Data </td></tr><tr><td> {item.Plant_Id}</td><td> {item.Plant_Name} </td><td> {item.Area_Name} </td><td> {item.Machine_Data}</td></tr><table>";
                    //Here we are rendering or converting htmlaspdf.
                    HtmlLine.RenderHtmlAsPdf(pdftext).SaveAs(pdfPath);
                }
                catch(Exception ex)
                {
                    var error_data = ex.Message;

                    lblMsg.Text = error_data;
                }
                
            }

            if (string.IsNullOrEmpty(lblMsg.Text))
            {
                lblMsg.Text = "All pdf are genereted successfully at provided folder path.";
            }
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlantPdfGenerationScreen ObjplantPdfGenerationScreen = new PlantPdfGenerationScreen();
            ObjplantPdfGenerationScreen.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            QuickReviewLogin ObjquickReviewLogin = new QuickReviewLogin();
            ObjquickReviewLogin.Show();
            this.Close();

        }
    }
  
}
