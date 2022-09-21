
namespace QuickReviewReports
{
    partial class DashboardScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblUploadCSV = new System.Windows.Forms.Label();
            this.BrowseCSV = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblReportPath = new System.Windows.Forms.Label();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.btnGeneratePDFreport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTargetPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMsg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Location = new System.Drawing.Point(185, 149);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(0, 17);
            this.lblDashboard.TabIndex = 0;
            // 
            // lblUploadCSV
            // 
            this.lblUploadCSV.AutoSize = true;
            this.lblUploadCSV.Location = new System.Drawing.Point(245, 183);
            this.lblUploadCSV.Name = "lblUploadCSV";
            this.lblUploadCSV.Size = new System.Drawing.Size(92, 17);
            this.lblUploadCSV.TabIndex = 1;
            this.lblUploadCSV.Text = "Upload CSV :";
            // 
            // BrowseCSV
            // 
            this.BrowseCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseCSV.Location = new System.Drawing.Point(751, 176);
            this.BrowseCSV.Name = "BrowseCSV";
            this.BrowseCSV.Size = new System.Drawing.Size(125, 34);
            this.BrowseCSV.TabIndex = 2;
            this.BrowseCSV.Text = "Browse CSV";
            this.BrowseCSV.UseVisualStyleBackColor = true;
            this.BrowseCSV.Click += new System.EventHandler(this.BrowseCSV_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(377, 180);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(343, 26);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // lblReportPath
            // 
            this.lblReportPath.AutoSize = true;
            this.lblReportPath.Location = new System.Drawing.Point(248, 248);
            this.lblReportPath.Name = "lblReportPath";
            this.lblReportPath.Size = new System.Drawing.Size(92, 17);
            this.lblReportPath.TabIndex = 4;
            this.lblReportPath.Text = "Report Path :";
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargetPath.Location = new System.Drawing.Point(377, 247);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(343, 26);
            this.txtTargetPath.TabIndex = 5;
            // 
            // btnGeneratePDFreport
            // 
            this.btnGeneratePDFreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePDFreport.Location = new System.Drawing.Point(438, 301);
            this.btnGeneratePDFreport.Name = "btnGeneratePDFreport";
            this.btnGeneratePDFreport.Size = new System.Drawing.Size(246, 36);
            this.btnGeneratePDFreport.TabIndex = 6;
            this.btnGeneratePDFreport.Text = "Generate PDF Report";
            this.btnGeneratePDFreport.UseVisualStyleBackColor = true;
            this.btnGeneratePDFreport.Click += new System.EventHandler(this.btnGeneratePDFreport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(624, 359);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 37);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnTargetPath
            // 
            this.btnTargetPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTargetPath.Location = new System.Drawing.Point(760, 242);
            this.btnTargetPath.Name = "btnTargetPath";
            this.btnTargetPath.Size = new System.Drawing.Size(225, 31);
            this.btnTargetPath.TabIndex = 8;
            this.btnTargetPath.Text = "Browse Target Path";
            this.btnTargetPath.UseVisualStyleBackColor = true;
            this.btnTargetPath.Click += new System.EventHandler(this.btnTargetPath_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(207, 426);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            this.lblMsg.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(346, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Generate Plant PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(1064, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(106, 36);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // DashboardScreen
            // 
            this.ClientSize = new System.Drawing.Size(1182, 471);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnTargetPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGeneratePDFreport);
            this.Controls.Add(this.txtTargetPath);
            this.Controls.Add(this.lblReportPath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.BrowseCSV);
            this.Controls.Add(this.lblUploadCSV);
            this.Controls.Add(this.lblDashboard);
            this.Name = "DashboardScreen";
            this.Text = "DashBoard Screen";
            this.Load += new System.EventHandler(this.DashboardScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblUploadCSV;
        private System.Windows.Forms.Button BrowseCSV;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblReportPath;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Button btnGeneratePDFreport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTargetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLogOut;
    }
}