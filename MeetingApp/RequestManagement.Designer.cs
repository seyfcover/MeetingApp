using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    partial class RequestManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestManagement));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMyRequests = new System.Windows.Forms.DataGridView();
            this.btnDelRequest = new System.Windows.Forms.Button();
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(20, 464);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(299, 35);
            this.btnConfirm.TabIndex = 54;
            this.btnConfirm.Text = "Talep Onayla";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirmRequest_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(875, 39);
            this.label2.TabIndex = 55;
            this.label2.Text = "Talepler";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMyRequests
            // 
            this.dgvMyRequests.AllowUserToAddRows = false;
            this.dgvMyRequests.AllowUserToDeleteRows = false;
            this.dgvMyRequests.AllowUserToResizeColumns = false;
            this.dgvMyRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMyRequests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMyRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMyRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyRequests.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvMyRequests.Location = new System.Drawing.Point(16, 91);
            this.dgvMyRequests.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMyRequests.MultiSelect = false;
            this.dgvMyRequests.Name = "dgvMyRequests";
            this.dgvMyRequests.ReadOnly = true;
            this.dgvMyRequests.RowHeadersVisible = false;
            this.dgvMyRequests.RowHeadersWidth = 51;
            this.dgvMyRequests.RowTemplate.Height = 24;
            this.dgvMyRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyRequests.Size = new System.Drawing.Size(875, 354);
            this.dgvMyRequests.TabIndex = 56;
            this.dgvMyRequests.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyRequests_CellDoubleClick);
            // 
            // btnDelRequest
            // 
            this.btnDelRequest.BackColor = System.Drawing.Color.Maroon;
            this.btnDelRequest.Enabled = false;
            this.btnDelRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelRequest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelRequest.ForeColor = System.Drawing.Color.White;
            this.btnDelRequest.Location = new System.Drawing.Point(592, 464);
            this.btnDelRequest.Name = "btnDelRequest";
            this.btnDelRequest.Size = new System.Drawing.Size(299, 35);
            this.btnDelRequest.TabIndex = 54;
            this.btnDelRequest.Text = "Talep Sil";
            this.btnDelRequest.UseVisualStyleBackColor = false;
            this.btnDelRequest.Visible = false;
            this.btnDelRequest.Click += new System.EventHandler(this.btnDelRequest_Click);
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.BackColor = System.Drawing.Color.AliceBlue;
            this.txtboxSearch.Location = new System.Drawing.Point(96, 57);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(603, 31);
            this.txtboxSearch.TabIndex = 57;
            this.txtboxSearch.TextChanged += new System.EventHandler(this.txtboxSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(705, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(186, 31);
            this.btnRefresh.TabIndex = 54;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 58;
            this.label1.Text = "Arama :";
            // 
            // RequestManagement
            // 
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(903, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.dgvMyRequests);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelRequest);
            this.Controls.Add(this.btnConfirm);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RequestManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talep Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label2;
        private DataGridView dgvMyRequests;
        private Button btnDelRequest;
        private TextBox txtboxSearch;
        private Button btnRefresh;
        private Label label1;
    }
}
