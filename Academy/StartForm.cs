using System;
using System.Windows.Forms;

namespace Academy {
	public partial class StartForm : Form {
		public StartForm() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			try {
				MainForm form = new MainForm();
				form.ShowDialog();
			}
			catch (Exception) { }
			Close();
		}
	}
}
