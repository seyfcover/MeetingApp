using System.Windows.Forms;

namespace MeetingApp
{
    partial class CandidateCompanies
    {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CandidateCompanies));
            this.DataCompanies = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // DataCompanies
            // 
            this.DataCompanies.AllowUserToAddRows = false;
            this.DataCompanies.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DataCompanies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataCompanies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataCompanies.BackgroundColor = System.Drawing.Color.White;
            this.DataCompanies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataCompanies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataCompanies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataCompanies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataCompanies.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataCompanies.EnableHeadersVisualStyles = false;
            this.DataCompanies.GridColor = System.Drawing.Color.Gainsboro;
            this.DataCompanies.Location = new System.Drawing.Point(1, 0);
            this.DataCompanies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DataCompanies.MultiSelect = false;
            this.DataCompanies.Name = "DataCompanies";
            this.DataCompanies.ReadOnly = true;
            this.DataCompanies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataCompanies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataCompanies.RowTemplate.Height = 40;
            this.DataCompanies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataCompanies.Size = new System.Drawing.Size(779, 450);
            this.DataCompanies.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1, 458);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "Verileri Yenile";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CandidateCompanies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 496);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataCompanies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CandidateCompanies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aday Şirketler";
            ((System.ComponentModel.ISupportInitialize)(this.DataCompanies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void InitializeDataGridViewColumns() {
            // İlk olarak DataGridView'deki mevcut sütunları temizleyelim
            DataCompanies.Columns.Clear();

            // 'Ad' sütunu (Name)
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Ad";
            nameColumn.HeaderText = "Şirket Adı";
            nameColumn.DataPropertyName = "Name";
            DataCompanies.Columns.Add(nameColumn);

            // 'Faaliyet Alanı' sütunu (FieldsOfActivity)
            DataGridViewTextBoxColumn fieldsColumn = new DataGridViewTextBoxColumn();
            fieldsColumn.Name = "FaaliyetAlani";
            fieldsColumn.HeaderText = "Faaliyet Alanı";
            fieldsColumn.DataPropertyName = "FieldsOfActivity";
            DataCompanies.Columns.Add(fieldsColumn);

            // 'Telefon' sütunu (Phone)
            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.Name = "Telefon";
            phoneColumn.HeaderText = "Telefon";
            phoneColumn.DataPropertyName = "Phone";
            DataCompanies.Columns.Add(phoneColumn);

            // 'Puanlar' sütunu (Points)
            DataGridViewTextBoxColumn pointsColumn = new DataGridViewTextBoxColumn();
            pointsColumn.Name = "Puanlar";
            pointsColumn.HeaderText = "Puan";
            pointsColumn.DataPropertyName = "Points";
            DataCompanies.Columns.Add(pointsColumn);
        }


        private System.Windows.Forms.DataGridView DataCompanies;
        private System.Windows.Forms.Button button1;
    }
}
