namespace LouisWebCrawler
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.informationToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.downloadBtn = new System.Windows.Forms.Button();
			this.directoryBtn = new System.Windows.Forms.Button();
			this.directoryLabel = new System.Windows.Forms.Label();
			this.ftpServerNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ftpUsernameTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ftpPasswordTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ftpDestinationFolderTextBox = new System.Windows.Forms.TextBox();
			this.ftpGroupBox = new System.Windows.Forms.GroupBox();
			this.dbGroupBox = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dbDestinationDbTextBox = new System.Windows.Forms.TextBox();
			this.dbServerNameTextBox = new System.Windows.Forms.TextBox();
			this.dbUsernameTextBox = new System.Windows.Forms.TextBox();
			this.dbPasswordTextBox = new System.Windows.Forms.TextBox();
			this.statusStrip.SuspendLayout();
			this.ftpGroupBox.SuspendLayout();
			this.dbGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 305);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(490, 23);
			this.progressBar.TabIndex = 3;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 364);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(514, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip";
			// 
			// informationToolStripLabel
			// 
			this.informationToolStripLabel.Name = "informationToolStripLabel";
			this.informationToolStripLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// downloadBtn
			// 
			this.downloadBtn.Location = new System.Drawing.Point(427, 334);
			this.downloadBtn.Name = "downloadBtn";
			this.downloadBtn.Size = new System.Drawing.Size(75, 23);
			this.downloadBtn.TabIndex = 3;
			this.downloadBtn.Text = "Pobierz";
			this.downloadBtn.UseVisualStyleBackColor = true;
			this.downloadBtn.Click += new System.EventHandler(this.DownloadBtnClick);
			// 
			// directoryBtn
			// 
			this.directoryBtn.Location = new System.Drawing.Point(12, 12);
			this.directoryBtn.Name = "directoryBtn";
			this.directoryBtn.Size = new System.Drawing.Size(114, 23);
			this.directoryBtn.TabIndex = 0;
			this.directoryBtn.Text = "Katalog...";
			this.directoryBtn.UseVisualStyleBackColor = true;
			this.directoryBtn.Click += new System.EventHandler(this.DirectoryBtnClick);
			// 
			// directoryLabel
			// 
			this.directoryLabel.Location = new System.Drawing.Point(132, 14);
			this.directoryLabel.Name = "directoryLabel";
			this.directoryLabel.Size = new System.Drawing.Size(364, 18);
			this.directoryLabel.TabIndex = 4;
			this.directoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ftpServerNameTextBox
			// 
			this.ftpServerNameTextBox.Location = new System.Drawing.Point(119, 19);
			this.ftpServerNameTextBox.Name = "ftpServerNameTextBox";
			this.ftpServerNameTextBox.Size = new System.Drawing.Size(365, 20);
			this.ftpServerNameTextBox.TabIndex = 0;
			this.ftpServerNameTextBox.Text = "localhost";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Adres serwera:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nazwa użytkownika:";
			// 
			// ftpUsernameTextBox
			// 
			this.ftpUsernameTextBox.Location = new System.Drawing.Point(119, 45);
			this.ftpUsernameTextBox.Name = "ftpUsernameTextBox";
			this.ftpUsernameTextBox.Size = new System.Drawing.Size(365, 20);
			this.ftpUsernameTextBox.TabIndex = 1;
			this.ftpUsernameTextBox.Text = "tomasz";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Hasło:";
			// 
			// ftpPasswordTextBox
			// 
			this.ftpPasswordTextBox.Location = new System.Drawing.Point(119, 71);
			this.ftpPasswordTextBox.Name = "ftpPasswordTextBox";
			this.ftpPasswordTextBox.PasswordChar = '*';
			this.ftpPasswordTextBox.Size = new System.Drawing.Size(365, 20);
			this.ftpPasswordTextBox.TabIndex = 2;
			this.ftpPasswordTextBox.Text = "tomasz123";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Katalog docelowy:";
			// 
			// ftpDestinationFolderTextBox
			// 
			this.ftpDestinationFolderTextBox.Location = new System.Drawing.Point(119, 97);
			this.ftpDestinationFolderTextBox.Name = "ftpDestinationFolderTextBox";
			this.ftpDestinationFolderTextBox.Size = new System.Drawing.Size(365, 20);
			this.ftpDestinationFolderTextBox.TabIndex = 3;
			this.ftpDestinationFolderTextBox.Text = "probny";
			// 
			// ftpGroupBox
			// 
			this.ftpGroupBox.Controls.Add(this.label1);
			this.ftpGroupBox.Controls.Add(this.label4);
			this.ftpGroupBox.Controls.Add(this.label2);
			this.ftpGroupBox.Controls.Add(this.label3);
			this.ftpGroupBox.Controls.Add(this.ftpDestinationFolderTextBox);
			this.ftpGroupBox.Controls.Add(this.ftpServerNameTextBox);
			this.ftpGroupBox.Controls.Add(this.ftpUsernameTextBox);
			this.ftpGroupBox.Controls.Add(this.ftpPasswordTextBox);
			this.ftpGroupBox.Location = new System.Drawing.Point(12, 41);
			this.ftpGroupBox.Name = "ftpGroupBox";
			this.ftpGroupBox.Size = new System.Drawing.Size(490, 129);
			this.ftpGroupBox.TabIndex = 1;
			this.ftpGroupBox.TabStop = false;
			this.ftpGroupBox.Text = "FTP";
			// 
			// dbGroupBox
			// 
			this.dbGroupBox.Controls.Add(this.label5);
			this.dbGroupBox.Controls.Add(this.label6);
			this.dbGroupBox.Controls.Add(this.label7);
			this.dbGroupBox.Controls.Add(this.label8);
			this.dbGroupBox.Controls.Add(this.dbDestinationDbTextBox);
			this.dbGroupBox.Controls.Add(this.dbServerNameTextBox);
			this.dbGroupBox.Controls.Add(this.dbUsernameTextBox);
			this.dbGroupBox.Controls.Add(this.dbPasswordTextBox);
			this.dbGroupBox.Location = new System.Drawing.Point(12, 176);
			this.dbGroupBox.Name = "dbGroupBox";
			this.dbGroupBox.Size = new System.Drawing.Size(490, 123);
			this.dbGroupBox.TabIndex = 2;
			this.dbGroupBox.TabStop = false;
			this.dbGroupBox.Text = "Baza danych";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Adres serwera:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Baza docelowa:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(105, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Nazwa użytkownika:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 71);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Hasło:";
			// 
			// dbDestinationDbTextBox
			// 
			this.dbDestinationDbTextBox.Location = new System.Drawing.Point(120, 94);
			this.dbDestinationDbTextBox.Name = "dbDestinationDbTextBox";
			this.dbDestinationDbTextBox.Size = new System.Drawing.Size(365, 20);
			this.dbDestinationDbTextBox.TabIndex = 3;
			this.dbDestinationDbTextBox.Text = "tt_probny";
			// 
			// dbServerNameTextBox
			// 
			this.dbServerNameTextBox.Location = new System.Drawing.Point(120, 16);
			this.dbServerNameTextBox.Name = "dbServerNameTextBox";
			this.dbServerNameTextBox.Size = new System.Drawing.Size(365, 20);
			this.dbServerNameTextBox.TabIndex = 0;
			this.dbServerNameTextBox.Text = "localhost";
			// 
			// dbUsernameTextBox
			// 
			this.dbUsernameTextBox.Location = new System.Drawing.Point(120, 42);
			this.dbUsernameTextBox.Name = "dbUsernameTextBox";
			this.dbUsernameTextBox.Size = new System.Drawing.Size(365, 20);
			this.dbUsernameTextBox.TabIndex = 1;
			this.dbUsernameTextBox.Text = "root";
			// 
			// dbPasswordTextBox
			// 
			this.dbPasswordTextBox.Location = new System.Drawing.Point(120, 68);
			this.dbPasswordTextBox.Name = "dbPasswordTextBox";
			this.dbPasswordTextBox.PasswordChar = '*';
			this.dbPasswordTextBox.Size = new System.Drawing.Size(365, 20);
			this.dbPasswordTextBox.TabIndex = 2;
			this.dbPasswordTextBox.Text = "zaq12wsx";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 386);
			this.Controls.Add(this.dbGroupBox);
			this.Controls.Add(this.ftpGroupBox);
			this.Controls.Add(this.directoryLabel);
			this.Controls.Add(this.directoryBtn);
			this.Controls.Add(this.downloadBtn);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.progressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Louis Web Crawler";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ftpGroupBox.ResumeLayout(false);
			this.ftpGroupBox.PerformLayout();
			this.dbGroupBox.ResumeLayout(false);
			this.dbGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.Button downloadBtn;
		private System.Windows.Forms.ToolStripStatusLabel informationToolStripLabel;
		private System.Windows.Forms.Button directoryBtn;
		private System.Windows.Forms.Label directoryLabel;
		private System.Windows.Forms.TextBox ftpServerNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ftpUsernameTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ftpPasswordTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox ftpDestinationFolderTextBox;
		private System.Windows.Forms.GroupBox ftpGroupBox;
		private System.Windows.Forms.GroupBox dbGroupBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox dbDestinationDbTextBox;
		private System.Windows.Forms.TextBox dbServerNameTextBox;
		private System.Windows.Forms.TextBox dbUsernameTextBox;
		private System.Windows.Forms.TextBox dbPasswordTextBox;
	}
}

