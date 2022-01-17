using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Academy {
	public partial class SearchForm : Form {
		string[] tables = { "Students", "Teachers", "Groups", "Subjects", "Faculties", "Departments" };
		AcademyEntities db = new AcademyEntities();
		public string[] ConnectionString;
		public SqlConnection conn;
		public SqlDataAdapter da;
		public SqlCommandBuilder cmd;
		public DataTable table;

		public string strValue;

		public SearchForm(string str) {
			InitializeComponent();
			try {
				ConnectionString = File.ReadAllLines("Connection.txt", Encoding.Default);
				conn = new SqlConnection($@"Data Source={ConnectionString[0]}; Initial Catalog=Academy; Integrated Security=SSPI;");
				strValue = str;
				OutputBase();
				GenerateRadioButton();
				dataGridView1.ContextMenuStrip = contextMenuStrip1;
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void GenerateRadioButton() {
			switch (strValue) {
				case "Students":
				case "Teachers":
					radioButton1.Text = "Прізвище"; radioButton2.Text = "Ім'я"; radioButton3.Text = "По батькові"; radioButton4.Text = "Дата народження";
					break;
				case "Groups":
					radioButton2.Location = new System.Drawing.Point(92, 51);
					radioButton1.Text = "Назва"; radioButton2.Text = "Курс"; radioButton3.Visible = false; radioButton4.Visible = false;
					break;
				case "Subjects":
				case "Faculties":
				case "Departments":
					radioButton1.Visible = false; radioButton2.Visible = false; radioButton3.Visible = false; radioButton4.Visible = false;
					dataGridView1.Location = new System.Drawing.Point(0, 51);
					dataGridView1.Size = new System.Drawing.Size(774, 525);
					break;
				default: break;
			}
		}

		private void OutputBase() {
			da = new SqlDataAdapter($"select * from {strValue}", conn);
			cmd = new SqlCommandBuilder(da);
			table = new DataTable();
			da.Fill(table);
			dataGridView1.DataSource = table;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			try {
				string str = "";
				switch (strValue) {
					case "Students":
					case "Teachers":
						if (radioButton1.Checked) str = "Surname";
						if (radioButton2.Checked) str = "Name";
						if (radioButton3.Checked) str = "Patronymic";
						if (radioButton4.Checked) str = "Date";
						break;
					case "Groups":
						if (radioButton1.Checked) str = "Name";
						if (radioButton2.Checked) str = "Year";
						break;
					case "Subjects": case "Faculties": case "Departments": str = "Name"; break;
					default: break;
				}
				da = new SqlDataAdapter($"select * from [{strValue}] where [{str}] like '%{textBox1.Text}%'", conn);
				cmd = new SqlCommandBuilder(da);
				table = new DataTable();
				da.Fill(table);
				dataGridView1.DataSource = table;
			}
			catch (Exception ex) {
				if (textBox1.Text != "") MessageBox.Show("Сначала выберите критерий поиска");
			}
		}

		private void додатиЗаписToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				switch (strValue) {
					case "Students":
						Students students = new Students {
							Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(),
							Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(),
							Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(),
							Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Students.AddOrUpdate(students); break;
					case "Teachers":
						Teachers teachers = new Teachers {
							Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(),
							Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(),
							Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(),
							Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Teachers.AddOrUpdate(teachers); break;
					case "Groups":
						Groups groups = new Groups {
							DepartmentId = int.Parse(dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString()),
							Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(),
							Year = int.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Groups.AddOrUpdate(groups); break;
					case "Subjects":
						Subjects subjects = new Subjects {
							Title = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(),
							TeacherId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Subjects.AddOrUpdate(subjects); break;
					case "Faculties":
						Faculties faculties = new Faculties {
							Name = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(),
							DeanId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Faculties.AddOrUpdate(faculties); break;
					case "Departments":
						Departments departments = new Departments {
							Name = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(),
							FacultyId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString()),
							SecretarId = int.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Departments.AddOrUpdate(departments); break;
					default: break;
				}
				db.SaveChanges();
				dataGridView1.Refresh();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void редагуватиЗаписToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				switch (strValue) {
					case "Students":
						Students students = db.Students.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						if (students == null) return;
						students.Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Students.AddOrUpdate(students); break;
					case "Teachers":
						Teachers teachers = db.Teachers.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						teachers.Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						teachers.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						teachers.Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
						teachers.Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Teachers.AddOrUpdate(teachers); break;
					case "Groups":
						Groups groups = db.Groups.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						groups.DepartmentId = int.Parse(dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString());
						groups.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						groups.Year = int.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Groups.AddOrUpdate(groups); break;
					case "Subjects":
						Subjects subjects = db.Subjects.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						subjects.Title = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						subjects.TeacherId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Subjects.AddOrUpdate(subjects); break;
					case "Faculties":
						Faculties faculties = db.Faculties.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						faculties.Name = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						faculties.DeanId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Faculties.AddOrUpdate(faculties); break;
					case "Departments":
						Departments departments = db.Departments.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						departments.Name = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						departments.FacultyId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
						departments.SecretarId = int.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Departments.AddOrUpdate(departments); break;
					default: break;
				}
				db.SaveChanges();
				dataGridView1.Refresh();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void видалитиЗаписToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				switch (strValue) {
					case "Students":
						Students students = db.Students.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						if (students == null) return;
						students.Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Students.Remove(students); break;
					case "Teachers":
						Teachers teachers = db.Teachers.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						teachers.Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						teachers.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						teachers.Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
						teachers.Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Teachers.Remove(teachers); break;
					case "Groups":
						Groups groups = db.Groups.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						groups.DepartmentId = int.Parse(dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString());
						groups.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						groups.Year = int.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Groups.Remove(groups); break;
					case "Subjects":
						Subjects subjects = db.Subjects.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						subjects.Title = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						subjects.TeacherId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Subjects.Remove(subjects); break;
					case "Faculties":
						Faculties faculties = db.Faculties.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						faculties.Name = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						faculties.DeanId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Faculties.Remove(faculties); break;
					case "Departments":
						Departments departments = db.Departments.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						departments.Name = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						departments.FacultyId = int.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
						departments.SecretarId = int.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Departments.Remove(departments); break;
					default: break;
				}
				db.SaveChanges();
				dataGridView1.Refresh();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
	}
}

