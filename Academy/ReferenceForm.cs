using System.IO;
using System.Windows.Forms;

namespace Academy {
	public partial class ReferenceForm : Form {
		public ReferenceForm() {
			InitializeComponent();
			textBox1.Text = File.ReadAllText("text.txt");
		}
	}
}
