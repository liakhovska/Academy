using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Academy {
	public partial class MainForm : Form {
		string[] tables = { "Students", "Teachers", "Groups", "Subjects", "Faculties", "Departments", "GroupsSecretaries", "GroupsStudents", "Secretaries", "Deans" };
		AcademyEntities db = new AcademyEntities();

		string[] ConnectionString = null;
		SqlConnection conn = null;
		DataSet ds = null;
		SqlDataAdapter da = null;
		DataTable table = null;

		public MainForm() {
			InitializeComponent();
			try {
				ConnectionString = File.ReadAllLines("Connection.txt", Encoding.Default);
				conn = new SqlConnection($@"Data Source={ConnectionString[0]}; Initial Catalog=Academy; Integrated Security=SSPI;");
				OutputBase();
				for (int i = 0; i < tabControl1.TabCount; i++) {
					switch (i) {
						case 0: dataGridView1.ContextMenuStrip = contextMenuStrip1; break;
						case 1: dataGridView2.ContextMenuStrip = contextMenuStrip1; break;
						case 2: dataGridView3.ContextMenuStrip = contextMenuStrip1; break;
						case 3: dataGridView4.ContextMenuStrip = contextMenuStrip1; break;
						case 4: dataGridView5.ContextMenuStrip = contextMenuStrip1; break;
						case 5: dataGridView6.ContextMenuStrip = contextMenuStrip1; break;
						case 6: dataGridView7.ContextMenuStrip = contextMenuStrip1; break;
						case 7: dataGridView8.ContextMenuStrip = contextMenuStrip1; break;
						case 8: dataGridView9.ContextMenuStrip = contextMenuStrip1; break;
						case 9: dataGridView10.ContextMenuStrip = contextMenuStrip1; break;
						default: break;
					}
				}
			}
			catch (Exception ex) {
				ReferenceForm form = new ReferenceForm();
				form.ShowDialog();
				Close();
			}
		}

		private void OutputBase() {
			try {
				ds = new DataSet();
				for (int i = 0; i < tabControl1.TabCount; i++) {
					da = new SqlDataAdapter($"select * from {tables[i]}", conn);
					table = new DataTable();
					da.Fill(table);
					switch (i) {
						case 0: dataGridView1.DataSource = table; dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 1: dataGridView2.DataSource = table; dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 2: dataGridView3.DataSource = table; dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 3: dataGridView4.DataSource = table; dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 4: dataGridView5.DataSource = table; dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 5: dataGridView6.DataSource = table; dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 6: dataGridView7.DataSource = table; dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 7: dataGridView8.DataSource = table; dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 8: dataGridView9.DataSource = table; dataGridView9.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						case 9: dataGridView10.DataSource = table; dataGridView10.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; break;
						default: break;
					}
					da.Fill(ds, tables[i]);
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void студентамToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				SearchForm form = new SearchForm("Students");
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void викладачамToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				SearchForm form = new SearchForm("Teachers");
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void групамToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				SearchForm form = new SearchForm("Groups");
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void предметамToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				SearchForm form = new SearchForm("Subjects");
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void факультетамToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				SearchForm form = new SearchForm("Faculties");
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void кафедрамToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				SearchForm form = new SearchForm("Departments");
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void Refreshed(int ad) {
			switch (ad) {
				case 0: dataGridView1.Refresh(); break;
				case 1: dataGridView2.Refresh(); break;
				case 2: dataGridView3.Refresh(); break;
				case 3: dataGridView4.Refresh(); break;
				case 4: dataGridView5.Refresh(); break;
				case 5: dataGridView6.Refresh(); break;
				case 6: dataGridView7.Refresh(); break;
				case 7: dataGridView8.Refresh(); break;
				case 8: dataGridView9.Refresh(); break;
				case 9: dataGridView10.Refresh(); break;
				default: break;
			}
		}

		private void додатиЗаписToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				int ad = tabControl1.SelectedIndex;
				switch (ad) {
					case 0:
						Students students = new Students {
							Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(),
							Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(),
							Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(),
							Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString())
						};
						db.Students.AddOrUpdate(students); break;
					case 1:
						Teachers teachers = new Teachers {
							Surname = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString(),
							Name = dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString(),
							Patronymic = dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString(),
							Date = DateTime.Parse(dataGridView2[4, dataGridView2.CurrentRow.Index].Value.ToString())
						};
						db.Teachers.AddOrUpdate(teachers); break;
					case 2:
						Groups groups = new Groups {
							DepartmentId = int.Parse(dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString()),
							Name = dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString(),
							Year = int.Parse(dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString())
						};
						db.Groups.AddOrUpdate(groups); break;
					case 3:
						Subjects subjects = new Subjects {
							Title = dataGridView4[1, dataGridView4.CurrentRow.Index].Value.ToString(),
							TeacherId = int.Parse(dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString())
						};
						db.Subjects.AddOrUpdate(subjects); break;
					case 4:
						Faculties faculties = new Faculties {
							Name = dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString(),
							DeanId = int.Parse(dataGridView5[2, dataGridView5.CurrentRow.Index].Value.ToString())
						};
						db.Faculties.AddOrUpdate(faculties); break;
					case 5:
						Departments departments = new Departments {
							Name = dataGridView6[1, dataGridView6.CurrentRow.Index].Value.ToString(),
							FacultyId = int.Parse(dataGridView6[2, dataGridView6.CurrentRow.Index].Value.ToString()),
							SecretarId = int.Parse(dataGridView6[3, dataGridView6.CurrentRow.Index].Value.ToString())
						};
						db.Departments.AddOrUpdate(departments); break;
					case 6:
						GroupsSecretaries groupsSecretaries = new GroupsSecretaries {
							Session_Begin = DateTime.Parse(dataGridView7[1, dataGridView7.CurrentRow.Index].Value.ToString()),
							Session_End = DateTime.Parse(dataGridView7[2, dataGridView7.CurrentRow.Index].Value.ToString()),
							SecretarId = int.Parse(dataGridView7[3, dataGridView7.CurrentRow.Index].Value.ToString()),
							GroupId = int.Parse(dataGridView7[4, dataGridView7.CurrentRow.Index].Value.ToString())
						};
						db.GroupsSecretaries.AddOrUpdate(groupsSecretaries); break;
					case 7:
						GroupsStudents groupsStudents = new GroupsStudents {
							StudentId = int.Parse(dataGridView8[1, dataGridView8.CurrentRow.Index].Value.ToString()),
							GroupId = int.Parse(dataGridView8[2, dataGridView8.CurrentRow.Index].Value.ToString())
						};
						db.GroupsStudents.AddOrUpdate(groupsStudents); break;
					case 8:
						Secretaries secretaries = new Secretaries {
							TeacherId = int.Parse(dataGridView9[1, dataGridView9.CurrentRow.Index].Value.ToString())
						};
						db.Secretaries.AddOrUpdate(secretaries); break;
					case 9:
						Deans deans = new Deans {
							TeacherId = int.Parse(dataGridView10[1, dataGridView10.CurrentRow.Index].Value.ToString())
						};
						db.Deans.AddOrUpdate(deans); break;
					default: break;
				}
				db.SaveChanges();
				Refreshed(ad);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void редагуватиЗаписToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				int ad = tabControl1.SelectedIndex;
				switch (ad) {
					case 0:
						Students students = db.Students.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						if (students == null) return;
						students.Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Students.AddOrUpdate(students); break;
					case 1:
						Teachers teachers = db.Teachers.Find(int.Parse(dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString()));
						teachers.Surname = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
						teachers.Name = dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString();
						teachers.Patronymic = dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString();
						teachers.Date = DateTime.Parse(dataGridView2[4, dataGridView2.CurrentRow.Index].Value.ToString());
						db.Teachers.AddOrUpdate(teachers); break;
					case 2:
						Groups groups = db.Groups.Find(int.Parse(dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString()));
						groups.DepartmentId = int.Parse(dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString());
						groups.Name = dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString();
						groups.Year = int.Parse(dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString());
						db.Groups.AddOrUpdate(groups); break;
					case 3:
						Subjects subjects = db.Subjects.Find(int.Parse(dataGridView4[0, dataGridView4.CurrentRow.Index].Value.ToString()));
						subjects.Title = dataGridView4[1, dataGridView4.CurrentRow.Index].Value.ToString();
						subjects.TeacherId = int.Parse(dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString());
						db.Subjects.AddOrUpdate(subjects); break;
					case 4:
						Faculties faculties = db.Faculties.Find(int.Parse(dataGridView5[0, dataGridView5.CurrentRow.Index].Value.ToString()));
						faculties.Name = dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString();
						faculties.DeanId = int.Parse(dataGridView5[2, dataGridView5.CurrentRow.Index].Value.ToString());
						db.Faculties.AddOrUpdate(faculties); break;
					case 5:
						Departments departments = db.Departments.Find(int.Parse(dataGridView6[0, dataGridView6.CurrentRow.Index].Value.ToString()));
						departments.Name = dataGridView6[1, dataGridView6.CurrentRow.Index].Value.ToString();
						departments.FacultyId = int.Parse(dataGridView6[2, dataGridView6.CurrentRow.Index].Value.ToString());
						departments.SecretarId = int.Parse(dataGridView6[3, dataGridView6.CurrentRow.Index].Value.ToString());
						db.Departments.AddOrUpdate(departments); break;
					case 6:
						GroupsSecretaries groupsSecretaries = db.GroupsSecretaries.Find(int.Parse(dataGridView7[0, dataGridView7.CurrentRow.Index].Value.ToString()));
						groupsSecretaries.Session_Begin = DateTime.Parse(dataGridView7[1, dataGridView7.CurrentRow.Index].Value.ToString());
						groupsSecretaries.Session_End = DateTime.Parse(dataGridView7[2, dataGridView7.CurrentRow.Index].Value.ToString());
						groupsSecretaries.SecretarId = int.Parse(dataGridView7[3, dataGridView7.CurrentRow.Index].Value.ToString());
						groupsSecretaries.GroupId = int.Parse(dataGridView7[4, dataGridView7.CurrentRow.Index].Value.ToString());
						db.GroupsSecretaries.AddOrUpdate(groupsSecretaries); break;
					case 7:
						GroupsStudents groupsStudents = db.GroupsStudents.Find(int.Parse(dataGridView8[0, dataGridView8.CurrentRow.Index].Value.ToString()));
						groupsStudents.StudentId = int.Parse(dataGridView8[1, dataGridView8.CurrentRow.Index].Value.ToString());
						groupsStudents.GroupId = int.Parse(dataGridView8[2, dataGridView8.CurrentRow.Index].Value.ToString());
						db.GroupsStudents.AddOrUpdate(groupsStudents); break;
					case 8:
						Secretaries secretaries = db.Secretaries.Find(int.Parse(dataGridView9[0, dataGridView9.CurrentRow.Index].Value.ToString()));
						secretaries.TeacherId = int.Parse(dataGridView9[1, dataGridView9.CurrentRow.Index].Value.ToString());
						db.Secretaries.AddOrUpdate(secretaries); break;
					case 9:
						Deans deans = db.Deans.Find(int.Parse(dataGridView10[0, dataGridView10.CurrentRow.Index].Value.ToString()));
						deans.TeacherId = int.Parse(dataGridView10[1, dataGridView10.CurrentRow.Index].Value.ToString());
						db.Deans.AddOrUpdate(deans); break;
					default: break;
				}
				db.SaveChanges();
				Refreshed(ad);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void видалитиЗаписToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				int ad = tabControl1.SelectedIndex;
				switch (ad) {
					case 0:
						Students students = db.Students.Find(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
						if (students == null) return;
						students.Surname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Name = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Patronymic = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
						students.Date = DateTime.Parse(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
						db.Students.Remove(students); break;
					case 1:
						Teachers teachers = db.Teachers.Find(int.Parse(dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString()));
						teachers.Surname = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
						teachers.Name = dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString();
						teachers.Patronymic = dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString();
						teachers.Date = DateTime.Parse(dataGridView2[4, dataGridView2.CurrentRow.Index].Value.ToString());
						db.Teachers.Remove(teachers); break;
					case 2:
						Groups groups = db.Groups.Find(int.Parse(dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString()));
						groups.DepartmentId = int.Parse(dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString());
						groups.Name = dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString();
						groups.Year = int.Parse(dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString());
						db.Groups.Remove(groups); break;
					case 3:
						Subjects subjects = db.Subjects.Find(int.Parse(dataGridView4[0, dataGridView4.CurrentRow.Index].Value.ToString()));
						subjects.Title = dataGridView4[1, dataGridView4.CurrentRow.Index].Value.ToString();
						subjects.TeacherId = int.Parse(dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString());
						db.Subjects.Remove(subjects); break;
					case 4:
						Faculties faculties = db.Faculties.Find(int.Parse(dataGridView5[0, dataGridView5.CurrentRow.Index].Value.ToString()));
						faculties.Name = dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString();
						faculties.DeanId = int.Parse(dataGridView5[2, dataGridView5.CurrentRow.Index].Value.ToString());
						db.Faculties.Remove(faculties); break;
					case 5:
						Departments departments = db.Departments.Find(int.Parse(dataGridView6[0, dataGridView6.CurrentRow.Index].Value.ToString()));
						departments.Name = dataGridView6[1, dataGridView6.CurrentRow.Index].Value.ToString();
						departments.FacultyId = int.Parse(dataGridView6[2, dataGridView6.CurrentRow.Index].Value.ToString());
						departments.SecretarId = int.Parse(dataGridView6[3, dataGridView6.CurrentRow.Index].Value.ToString());
						db.Departments.Remove(departments); break;
					case 6:
						GroupsSecretaries groupsSecretaries = db.GroupsSecretaries.Find(int.Parse(dataGridView7[0, dataGridView7.CurrentRow.Index].Value.ToString()));
						groupsSecretaries.Session_Begin = DateTime.Parse(dataGridView7[1, dataGridView7.CurrentRow.Index].Value.ToString());
						groupsSecretaries.Session_End = DateTime.Parse(dataGridView7[2, dataGridView7.CurrentRow.Index].Value.ToString());
						groupsSecretaries.SecretarId = int.Parse(dataGridView7[3, dataGridView7.CurrentRow.Index].Value.ToString());
						groupsSecretaries.GroupId = int.Parse(dataGridView7[4, dataGridView7.CurrentRow.Index].Value.ToString());
						db.GroupsSecretaries.Remove(groupsSecretaries); break;
					case 7:
						GroupsStudents groupsStudents = db.GroupsStudents.Find(int.Parse(dataGridView8[0, dataGridView8.CurrentRow.Index].Value.ToString()));
						groupsStudents.StudentId = int.Parse(dataGridView8[1, dataGridView8.CurrentRow.Index].Value.ToString());
						groupsStudents.GroupId = int.Parse(dataGridView8[2, dataGridView8.CurrentRow.Index].Value.ToString());
						db.GroupsStudents.Remove(groupsStudents); break;
					case 8:
						Secretaries secretaries = db.Secretaries.Find(int.Parse(dataGridView9[0, dataGridView9.CurrentRow.Index].Value.ToString()));
						secretaries.TeacherId = int.Parse(dataGridView9[1, dataGridView9.CurrentRow.Index].Value.ToString());
						db.Secretaries.Remove(secretaries); break;
					case 9:
						Deans deans = db.Deans.Find(int.Parse(dataGridView10[0, dataGridView10.CurrentRow.Index].Value.ToString()));
						deans.TeacherId = int.Parse(dataGridView10[1, dataGridView10.CurrentRow.Index].Value.ToString());
						db.Deans.Remove(deans); break;
					default: break;
				}
				db.SaveChanges();
				Refreshed(ad);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void MainForm_Activated(object sender, EventArgs e) {
			OutputBase();
		}

		private void Export_Data_To_Word(DataGridView DGV, string fileName) {
			if (DGV.Rows.Count != 0) {
				int RowCount = DGV.Rows.Count;
				int ColumnCount = DGV.Columns.Count;
				Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
				//add rows
				int r = 0;
				for (int c = 0; c <= ColumnCount - 1; c++) {
					for (r = 0; r <= RowCount - 1; r++) {
						DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
					} //end row loop
				} //end column loop
				Word.Document oDoc = new Word.Document();
				oDoc.Application.Visible = true;
				//page orintation
				oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
				dynamic oRange = oDoc.Content.Application.Selection.Range;
				string oTemp = "";
				for (r = 0; r <= RowCount - 1; r++) {
					for (int c = 0; c <= ColumnCount - 1; c++) {
						oTemp = oTemp + DataArray[r, c] + "\t";
					}
				}

				//table format
				oRange.Text = oTemp;
				object oMissing = Missing.Value;
				object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
				object ApplyBorders = true;
				object AutoFit = true;
				object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

				oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
															Type.Missing, Type.Missing, ref ApplyBorders,
															Type.Missing, Type.Missing, Type.Missing,
															Type.Missing, Type.Missing, Type.Missing,
															Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

				oRange.Select();

				oDoc.Application.Selection.Tables[1].Select();
				oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
				oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
				oDoc.Application.Selection.Tables[1].Rows[1].Select();
				oDoc.Application.Selection.InsertRowsAbove(1);
				oDoc.Application.Selection.Tables[1].Rows[1].Select();

				//header row style
				oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
				oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
				oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

				//add header row manually
				for (int c = 0; c <= ColumnCount - 1; c++) {
					oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
				}

				//table style 
				oDoc.Application.Selection.Tables[1].Rows[1].Select();
				oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

				//header text
				foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections) {
					Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
					headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
					headerRange.Text = "your header text";
					headerRange.Font.Size = 16;
					headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
				}
			}
		}

		private void студентівПоГрупамToolStripMenuItem_Click(object sender, EventArgs e) {
			Export_Data_To_Word(dataGridView1, "List_Students");
		}

		private void списокВикладачівToolStripMenuItem_Click(object sender, EventArgs e) {
			Export_Data_To_Word(dataGridView2, "List_Teachers");
		}

		private void довідкаToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				ReferenceForm form = new ReferenceForm();
				form.ShowDialog();
			}
			catch (Exception) { }
		}

		private void списокПредметівToolStripMenuItem_Click(object sender, EventArgs e) {
			Export_Data_To_Word(dataGridView4, "List_Teachers");
		}

		private void додатковіЗапитиToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				AdditionalRequestForm form = new AdditionalRequestForm();
				form.ShowDialog();
			}
			catch (Exception) { }
		}
	}
}
