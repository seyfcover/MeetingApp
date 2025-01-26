using System.Windows.Forms;
using System.Drawing;

namespace MeetingApp
{
    partial class InventoryStatus
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewInventory;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryStatus));
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.txtbox_searchItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refItems = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CountInventories = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.AllowUserToAddRows = false;
            this.dataGridViewInventory.AllowUserToDeleteRows = false;
            this.dataGridViewInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(1, 80);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.ReadOnly = true;
            this.dataGridViewInventory.RowTemplate.Height = 25;
            this.dataGridViewInventory.Size = new System.Drawing.Size(984, 534);
            this.dataGridViewInventory.TabIndex = 0;
            this.dataGridViewInventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventory_CellDoubleClick);
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateItem.ForeColor = System.Drawing.Color.White;
            this.btnUpdateItem.Location = new System.Drawing.Point(524, 22);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(194, 35);
            this.btnUpdateItem.TabIndex = 53;
            this.btnUpdateItem.Text = "Demirbaş Ekle";
            this.btnUpdateItem.UseVisualStyleBackColor = false;
            this.btnUpdateItem.Click += new System.EventHandler(this.btnUpdateItem_Click);
            // 
            // txtbox_searchItems
            // 
            this.txtbox_searchItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbox_searchItems.Location = new System.Drawing.Point(80, 25);
            this.txtbox_searchItems.Name = "txtbox_searchItems";
            this.txtbox_searchItems.Size = new System.Drawing.Size(411, 29);
            this.txtbox_searchItems.TabIndex = 54;
            this.txtbox_searchItems.TextChanged += new System.EventHandler(this.txtbox_searchItems_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 55;
            this.label1.Text = "Arama :";
            // 
            // btn_refItems
            // 
            this.btn_refItems.BackColor = System.Drawing.Color.Orange;
            this.btn_refItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_refItems.ForeColor = System.Drawing.Color.White;
            this.btn_refItems.Location = new System.Drawing.Point(748, 22);
            this.btn_refItems.Name = "btn_refItems";
            this.btn_refItems.Size = new System.Drawing.Size(194, 35);
            this.btn_refItems.TabIndex = 53;
            this.btn_refItems.Text = "Yenile";
            this.btn_refItems.UseVisualStyleBackColor = false;
            this.btn_refItems.Click += new System.EventHandler(this.btn_refItems_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(744, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Kayıtlı Demirbaş Sayısı :";
            // 
            // CountInventories
            // 
            this.CountInventories.AutoSize = true;
            this.CountInventories.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.CountInventories.Location = new System.Drawing.Point(913, 60);
            this.CountInventories.Name = "CountInventories";
            this.CountInventories.Size = new System.Drawing.Size(50, 20);
            this.CountInventories.TabIndex = 57;
            this.CountInventories.Text = "label3";
            // 
            // InventoryStatus
            // 
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(984, 613);
            this.Controls.Add(this.CountInventories);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox_searchItems);
            this.Controls.Add(this.btn_refItems);
            this.Controls.Add(this.btnUpdateItem);
            this.Controls.Add(this.dataGridViewInventory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envanter";
            this.Load += new System.EventHandler(this.InventoryStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnUpdateItem;
        private TextBox txtbox_searchItems;
        private Label label1;
        private Button btn_refItems;
        private Label label2;
        private Label CountInventories;
    }
}
