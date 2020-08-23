namespace Pomodoro_Keep_Focus
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMolaDk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestDk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.showGraphs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colPM,
            this.colPMD,
            this.colMola,
            this.colMolaDk,
            this.colRest,
            this.colRestDk});
            this.dataGridView1.Location = new System.Drawing.Point(3, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(739, 288);
            this.dataGridView1.TabIndex = 0;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Tarih";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPM
            // 
            this.colPM.HeaderText = "Yapılan Pomodoro";
            this.colPM.Name = "colPM";
            this.colPM.ReadOnly = true;
            this.colPM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPMD
            // 
            this.colPMD.HeaderText = "Pomodoro (Dakika)";
            this.colPMD.Name = "colPMD";
            this.colPMD.ReadOnly = true;
            this.colPMD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMola
            // 
            this.colMola.HeaderText = "Verilen Mola";
            this.colMola.Name = "colMola";
            this.colMola.ReadOnly = true;
            this.colMola.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMolaDk
            // 
            this.colMolaDk.HeaderText = "Verilen Mola (Dakika)";
            this.colMolaDk.Name = "colMolaDk";
            this.colMolaDk.ReadOnly = true;
            this.colMolaDk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRest
            // 
            this.colRest.HeaderText = "Dinlenme";
            this.colRest.Name = "colRest";
            this.colRest.ReadOnly = true;
            this.colRest.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRestDk
            // 
            this.colRestDk.HeaderText = "Dinlenme (Dakika)";
            this.colRestDk.Name = "colRestDk";
            this.colRestDk.ReadOnly = true;
            this.colRestDk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(-1, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrele";
            // 
            // showGraphs
            // 
            this.showGraphs.Enabled = false;
            this.showGraphs.FlatAppearance.BorderSize = 2;
            this.showGraphs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showGraphs.Location = new System.Drawing.Point(667, 54);
            this.showGraphs.Name = "showGraphs";
            this.showGraphs.Size = new System.Drawing.Size(75, 23);
            this.showGraphs.TabIndex = 3;
            this.showGraphs.Text = "Grafikler";
            this.showGraphs.UseVisualStyleBackColor = true;
            this.showGraphs.Click += new System.EventHandler(this.showGraphs_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(209, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Bütün istatistikleri sil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(351, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Toplam";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(755, 389);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showGraphs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Statistics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "İstatistikler";
            this.Load += new System.EventHandler(this.Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMola;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMolaDk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRestDk;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showGraphs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}