namespace UtageExcelConverter
{
	partial class Dialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOk = new System.Windows.Forms.Button();
			this.labelMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(159, 84);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(82, 25);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// labelMessage
			// 
			this.labelMessage.Location = new System.Drawing.Point(15, 13);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(382, 56);
			this.labelMessage.TabIndex = 1;
			this.labelMessage.Text = "label1a";
			// 
			// Dialog
			// 
			this.ClientSize = new System.Drawing.Size(405, 130);
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.btnOk);
			this.Name = "Dialog";
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label labelMessage;

		#endregion
	}
}