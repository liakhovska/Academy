namespace Academy {
	partial class SearchForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.додатиЗаписToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.редагуватиЗаписToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.видалитиЗаписToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioButton4
			// 
			this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(279, 49);
			this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(141, 20);
			this.radioButton4.TabIndex = 21;
			this.radioButton4.Text = "Дата народження";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(168, 49);
			this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(103, 20);
			this.radioButton3.TabIndex = 20;
			this.radioButton3.Text = "По батькові";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(112, 49);
			this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(48, 20);
			this.radioButton2.TabIndex = 19;
			this.radioButton2.Text = "Ім\'я";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(16, 49);
			this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(88, 20);
			this.radioButton1.TabIndex = 18;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Прізвище";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 77);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(774, 499);
			this.dataGridView1.TabIndex = 16;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox1.Location = new System.Drawing.Point(16, 15);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(745, 22);
			this.textBox1.TabIndex = 15;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиЗаписToolStripMenuItem,
            this.редагуватиЗаписToolStripMenuItem,
            this.видалитиЗаписToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(169, 70);
			// 
			// додатиЗаписToolStripMenuItem
			// 
			this.додатиЗаписToolStripMenuItem.Name = "додатиЗаписToolStripMenuItem";
			this.додатиЗаписToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.додатиЗаписToolStripMenuItem.Text = "Додати запис";
			this.додатиЗаписToolStripMenuItem.Click += new System.EventHandler(this.додатиЗаписToolStripMenuItem_Click);
			// 
			// редагуватиЗаписToolStripMenuItem
			// 
			this.редагуватиЗаписToolStripMenuItem.Name = "редагуватиЗаписToolStripMenuItem";
			this.редагуватиЗаписToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.редагуватиЗаписToolStripMenuItem.Text = "Редагувати запис";
			this.редагуватиЗаписToolStripMenuItem.Click += new System.EventHandler(this.редагуватиЗаписToolStripMenuItem_Click);
			// 
			// видалитиЗаписToolStripMenuItem
			// 
			this.видалитиЗаписToolStripMenuItem.Name = "видалитиЗаписToolStripMenuItem";
			this.видалитиЗаписToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.видалитиЗаписToolStripMenuItem.Text = "Видалити запис";
			this.видалитиЗаписToolStripMenuItem.Click += new System.EventHandler(this.видалитиЗаписToolStripMenuItem_Click);
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 576);
			this.Controls.Add(this.radioButton4);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SearchForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Пошук";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem додатиЗаписToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem редагуватиЗаписToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem видалитиЗаписToolStripMenuItem;
	}
}