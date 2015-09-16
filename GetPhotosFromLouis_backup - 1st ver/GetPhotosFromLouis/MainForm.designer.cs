namespace GetPhotosFromLouis
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
			this.destinationCatalogButton = new System.Windows.Forms.Button();
			this.destinationCatalogTextBox = new System.Windows.Forms.TextBox();
			this.informationBox = new System.Windows.Forms.ListBox();
			this.downloadButton = new System.Windows.Forms.Button();
			this.ftpServerName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ftpDirectory = new System.Windows.Forms.TextBox();
			this.ftpUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ftpPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// destinationCatalogButton
			// 
			this.destinationCatalogButton.Location = new System.Drawing.Point(12, 12);
			this.destinationCatalogButton.Name = "destinationCatalogButton";
			this.destinationCatalogButton.Size = new System.Drawing.Size(125, 23);
			this.destinationCatalogButton.TabIndex = 0;
			this.destinationCatalogButton.Text = "Katalog docelowy";
			this.destinationCatalogButton.UseVisualStyleBackColor = true;
			this.destinationCatalogButton.Click += new System.EventHandler(this.DestinationCatalogButtonClick);
			// 
			// destinationCatalogTextBox
			// 
			this.destinationCatalogTextBox.Location = new System.Drawing.Point(143, 14);
			this.destinationCatalogTextBox.Name = "destinationCatalogTextBox";
			this.destinationCatalogTextBox.Size = new System.Drawing.Size(456, 20);
			this.destinationCatalogTextBox.TabIndex = 1;
			this.destinationCatalogTextBox.Text = "Katalog";
			this.destinationCatalogTextBox.Enter += new System.EventHandler(this.DestinationCatalogTextBoxEnter);
			this.destinationCatalogTextBox.Leave += new System.EventHandler(this.DestinationCatalogTextBoxLeave);
			// 
			// informationBox
			// 
			this.informationBox.FormattingEnabled = true;
			this.informationBox.Location = new System.Drawing.Point(12, 241);
			this.informationBox.Name = "informationBox";
			this.informationBox.Size = new System.Drawing.Size(587, 186);
			this.informationBox.TabIndex = 3;
			// 
			// downloadButton
			// 
			this.downloadButton.Location = new System.Drawing.Point(12, 436);
			this.downloadButton.Name = "downloadButton";
			this.downloadButton.Size = new System.Drawing.Size(138, 23);
			this.downloadButton.TabIndex = 4;
			this.downloadButton.Text = "Pobierz";
			this.downloadButton.UseVisualStyleBackColor = true;
			this.downloadButton.Click += new System.EventHandler(this.DownloadButtonClick);
			// 
			// ftpServerName
			// 
			this.ftpServerName.Location = new System.Drawing.Point(143, 40);
			this.ftpServerName.Name = "ftpServerName";
			this.ftpServerName.Size = new System.Drawing.Size(456, 20);
			this.ftpServerName.TabIndex = 5;
			this.ftpServerName.Text = "localhost";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Adres serwera FTP:";
			// 
			// ftpDirectory
			// 
			this.ftpDirectory.Location = new System.Drawing.Point(143, 67);
			this.ftpDirectory.Name = "ftpDirectory";
			this.ftpDirectory.Size = new System.Drawing.Size(456, 20);
			this.ftpDirectory.TabIndex = 7;
			this.ftpDirectory.Text = "probny";
			// 
			// ftpUsername
			// 
			this.ftpUsername.Location = new System.Drawing.Point(143, 94);
			this.ftpUsername.Name = "ftpUsername";
			this.ftpUsername.Size = new System.Drawing.Size(456, 20);
			this.ftpUsername.TabIndex = 8;
			this.ftpUsername.Text = "tomasz";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Katalog główny FTP:";
			// 
			// ftpPassword
			// 
			this.ftpPassword.Location = new System.Drawing.Point(143, 121);
			this.ftpPassword.Name = "ftpPassword";
			this.ftpPassword.PasswordChar = '*';
			this.ftpPassword.Size = new System.Drawing.Size(456, 20);
			this.ftpPassword.TabIndex = 10;
			this.ftpPassword.Text = "tomasz123";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Nazwa użytkownika:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 124);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Hasło:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 467);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ftpPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ftpUsername);
			this.Controls.Add(this.ftpDirectory);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ftpServerName);
			this.Controls.Add(this.downloadButton);
			this.Controls.Add(this.informationBox);
			this.Controls.Add(this.destinationCatalogTextBox);
			this.Controls.Add(this.destinationCatalogButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Get photos from Louis.de";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button destinationCatalogButton;
		private System.Windows.Forms.TextBox destinationCatalogTextBox;
		private System.Windows.Forms.ListBox informationBox;
		private System.Windows.Forms.Button downloadButton;
		private System.Windows.Forms.TextBox ftpServerName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ftpDirectory;
		private System.Windows.Forms.TextBox ftpUsername;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ftpPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

