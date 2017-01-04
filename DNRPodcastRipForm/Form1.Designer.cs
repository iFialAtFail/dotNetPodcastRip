namespace DNRPodcastRipForm
{
    partial class Form1
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.listBoxFileList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAllFilesAvailable = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblFilesAvailableCount = new System.Windows.Forms.Label();
            this.lblPathLocation = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(467, 509);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download Podcast";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // listBoxFileList
            // 
            this.listBoxFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFileList.FormattingEnabled = true;
            this.listBoxFileList.HorizontalScrollbar = true;
            this.listBoxFileList.Location = new System.Drawing.Point(34, 122);
            this.listBoxFileList.Name = "listBoxFileList";
            this.listBoxFileList.Size = new System.Drawing.Size(195, 290);
            this.listBoxFileList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Files you have";
            // 
            // listBoxAllFilesAvailable
            // 
            this.listBoxAllFilesAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAllFilesAvailable.FormattingEnabled = true;
            this.listBoxAllFilesAvailable.HorizontalScrollbar = true;
            this.listBoxAllFilesAvailable.Location = new System.Drawing.Point(280, 122);
            this.listBoxAllFilesAvailable.Name = "listBoxAllFilesAvailable";
            this.listBoxAllFilesAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxAllFilesAvailable.Size = new System.Drawing.Size(213, 290);
            this.listBoxAllFilesAvailable.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "All files available for download";
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(13, 509);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(303, 23);
            this.progressBarDownload.TabIndex = 5;
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(34, 419);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(35, 13);
            this.lblFileCount.TabIndex = 6;
            this.lblFileCount.Text = "label3";
            // 
            // lblFilesAvailableCount
            // 
            this.lblFilesAvailableCount.AutoSize = true;
            this.lblFilesAvailableCount.Location = new System.Drawing.Point(280, 419);
            this.lblFilesAvailableCount.Name = "lblFilesAvailableCount";
            this.lblFilesAvailableCount.Size = new System.Drawing.Size(35, 13);
            this.lblFilesAvailableCount.TabIndex = 7;
            this.lblFilesAvailableCount.Text = "label3";
            // 
            // lblPathLocation
            // 
            this.lblPathLocation.AutoSize = true;
            this.lblPathLocation.BackColor = System.Drawing.SystemColors.Info;
            this.lblPathLocation.Location = new System.Drawing.Point(174, 35);
            this.lblPathLocation.Name = "lblPathLocation";
            this.lblPathLocation.Size = new System.Drawing.Size(91, 13);
            this.lblPathLocation.TabIndex = 8;
            this.lblPathLocation.Text = "No Path Selected";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(34, 30);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(112, 23);
            this.btnSelectFolder.TabIndex = 9;
            this.btnSelectFolder.Text = "Select Location";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 544);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lblPathLocation);
            this.Controls.Add(this.lblFilesAvailableCount);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.progressBarDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAllFilesAvailable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxFileList);
            this.Controls.Add(this.btnDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListBox listBoxFileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAllFilesAvailable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblFilesAvailableCount;
        private System.Windows.Forms.Label lblPathLocation;
        private System.Windows.Forms.Button btnSelectFolder;
    }
}

