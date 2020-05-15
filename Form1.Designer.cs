namespace DatabaseEditorSample {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.gvPersons = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbBirthdate = new System.Windows.Forms.TextBox();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.tbFirstName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gvPersons)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gvPersons
			// 
			this.gvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvPersons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gvPersons.Location = new System.Drawing.Point(0, 156);
			this.gvPersons.MultiSelect = false;
			this.gvPersons.Name = "gvPersons";
			this.gvPersons.RowHeadersWidth = 51;
			this.gvPersons.RowTemplate.Height = 24;
			this.gvPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvPersons.Size = new System.Drawing.Size(800, 294);
			this.gvPersons.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbBirthdate);
			this.groupBox1.Controls.Add(this.tbLastName);
			this.groupBox1.Controls.Add(this.tbFirstName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(800, 150);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// tbBirthdate
			// 
			this.tbBirthdate.Enabled = false;
			this.tbBirthdate.Location = new System.Drawing.Point(185, 84);
			this.tbBirthdate.Name = "tbBirthdate";
			this.tbBirthdate.Size = new System.Drawing.Size(136, 22);
			this.tbBirthdate.TabIndex = 5;
			// 
			// tbLastName
			// 
			this.tbLastName.Location = new System.Drawing.Point(185, 46);
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(136, 22);
			this.tbLastName.TabIndex = 4;
			// 
			// tbFirstName
			// 
			this.tbFirstName.Location = new System.Drawing.Point(185, 9);
			this.tbFirstName.Name = "tbFirstName";
			this.tbFirstName.Size = new System.Drawing.Size(136, 22);
			this.tbFirstName.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Birthdate";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "LastName";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "FirstName";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gvPersons);
			this.Name = "Form1";
			this.Text = "PersonEditor";
			((System.ComponentModel.ISupportInitialize)(this.gvPersons)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gvPersons;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbBirthdate;
		private System.Windows.Forms.TextBox tbLastName;
		private System.Windows.Forms.TextBox tbFirstName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

