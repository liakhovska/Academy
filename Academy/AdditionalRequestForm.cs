using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Academy {
	public partial class AdditionalRequestForm : Form {
		public string[] ConnectionString;
		public SqlConnection conn;
		public SqlDataAdapter da;
		public SqlCommandBuilder cmd;
		public DataTable table;
		public string strQuery = "";
		public AdditionalRequestForm() {
			InitializeComponent();
			try {
				listBox1.Text = "";
				listBox1.Items.AddRange(File.ReadAllLines("Query.txt", Encoding.Default));
				ConnectionString = File.ReadAllLines("Connection.txt", Encoding.Default);
				conn = new SqlConnection($@"Data Source={ConnectionString[0]}; Initial Catalog=Academy; Integrated Security=SSPI;");
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			try {
				int i = listBox1.SelectedIndex;
				OutputBase(i);
				da = new SqlDataAdapter(strQuery, conn);
				cmd = new SqlCommandBuilder(da);
				table = new DataTable();
				da.Fill(table);
				dataGridView1.DataSource = table;
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void OutputBase(int i) {
			switch (i) {
				case 0:
					strQuery = "select Groups.[Name] as 'Назва' from Groups where Groups.[Year] = 4"; break;
				case 1:
					strQuery = "select [Surname] + ' ' + [Name] + ' ' + [Patronymic] as 'Викладач' from Teachers where [Date]<'01.01.1970'"; break;
				case 2:
					strQuery = "select Departments.[Name] as 'Кафедра', Groups.[Name] as 'Група' from Departments join Groups on Departments.Id = Groups.DepartmentId"; break;
				case 3:
					strQuery = "select Title as 'Назва предмету' from Subjects join Teachers on Subjects.TeacherId = Teachers.Id where Teachers.[Name]='Инга' and Teachers.Surname='Шалаганова'"; break;
				case 4:
					strQuery = "select [Surname] + ' ' + [Name] + ' ' + [Patronymic] as 'Викладач', count(Subjects.Id) as 'Кількість предметів' from Teachers " +
						"join Subjects on Subjects.TeacherId = Teachers.Id group by[Surname] +' ' + [Name] + ' ' + [Patronymic]"; break;
				case 5:
					strQuery = "IF NOT EXISTS (SELECT * FROM [sysobjects] WHERE [name] = 'stud_rez' and [xtype]='U') " +
						"CREATE TABLE[dbo].[stud_rez] ([Id][int] IDENTITY(1,1) NOT NULL, [Surname] [nvarchar] (max) NOT NULL,	[Name] [nvarchar] (max) NOT NULL,	[Patronymic] [nvarchar] (max) NOT NULL,	[Date] [date]	NOT NULL," +
						"PRIMARY KEY CLUSTERED([Id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]" +
						"select* from[stud_rez]";
					MessageBox.Show("Таблица создана");
					break;
				case 6:
					break;
				case 7:
					break;
				default: break;
			}
		}
	}
}
