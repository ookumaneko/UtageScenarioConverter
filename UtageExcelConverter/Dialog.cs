using System;
using System.Windows.Forms;

namespace UtageExcelConverter
{
	public partial class Dialog : Form
	{
		public Dialog ()
		{
			InitializeComponent ();
		}

		public string Message
		{
			get => this.labelMessage.Text;
			set => this.labelMessage.Text = value;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Close ();
		}
	}
}
