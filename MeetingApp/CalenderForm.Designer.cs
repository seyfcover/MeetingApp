namespace MeetingApp
{
    partial class CalenderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDays;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.Label lblMonthYear;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalenderForm));
            this.tableLayoutPanelDays = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close_Viewpanel = new System.Windows.Forms.Button();
            this.refCalendar = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDays
            // 
            this.tableLayoutPanelDays.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanelDays.ColumnCount = 7;
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.28571F));
            this.tableLayoutPanelDays.Location = new System.Drawing.Point(1, -1);
            this.tableLayoutPanelDays.Name = "tableLayoutPanelDays";
            this.tableLayoutPanelDays.RowCount = 6;
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanelDays.Size = new System.Drawing.Size(1203, 644);
            this.tableLayoutPanelDays.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MeetingApp.Properties.Resources.back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.close_Viewpanel);
            this.panel1.Controls.Add(this.refCalendar);
            this.panel1.Controls.Add(this.btnNextMonth);
            this.panel1.Controls.Add(this.btnPreviousMonth);
            this.panel1.Controls.Add(this.lblMonthYear);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 89);
            this.panel1.TabIndex = 4;
            // 
            // close_Viewpanel
            // 
            this.close_Viewpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.close_Viewpanel.FlatAppearance.BorderSize = 0;
            this.close_Viewpanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.close_Viewpanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.close_Viewpanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Viewpanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.close_Viewpanel.ForeColor = System.Drawing.Color.White;
            this.close_Viewpanel.Location = new System.Drawing.Point(1167, 3);
            this.close_Viewpanel.Name = "close_Viewpanel";
            this.close_Viewpanel.Size = new System.Drawing.Size(25, 25);
            this.close_Viewpanel.TabIndex = 36;
            this.close_Viewpanel.Text = "X";
            this.close_Viewpanel.UseVisualStyleBackColor = false;
            this.close_Viewpanel.Click += new System.EventHandler(this.close_Viewpanel_Click);
            // 
            // refCalendar
            // 
            this.refCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.refCalendar.FlatAppearance.BorderSize = 0;
            this.refCalendar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.refCalendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.refCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refCalendar.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.refCalendar.ForeColor = System.Drawing.Color.White;
            this.refCalendar.Location = new System.Drawing.Point(991, 54);
            this.refCalendar.Name = "refCalendar";
            this.refCalendar.Size = new System.Drawing.Size(131, 30);
            this.refCalendar.TabIndex = 31;
            this.refCalendar.Text = "Yenile";
            this.refCalendar.UseVisualStyleBackColor = false;
            this.refCalendar.Click += new System.EventHandler(this.refCalendar_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnNextMonth.Location = new System.Drawing.Point(1139, 33);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(64, 51);
            this.btnNextMonth.TabIndex = 3;
            this.btnNextMonth.Text = ">>";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnPreviousMonth.Location = new System.Drawing.Point(3, 36);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(64, 51);
            this.btnPreviousMonth.TabIndex = 1;
            this.btnPreviousMonth.Text = "<<";
            this.btnPreviousMonth.UseVisualStyleBackColor = true;
            this.btnPreviousMonth.Click += new System.EventHandler(this.btnPreviousMonth_Click);
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.AutoSize = true;
            this.lblMonthYear.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthYear.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMonthYear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMonthYear.Location = new System.Drawing.Point(73, 42);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(223, 45);
            this.lblMonthYear.TabIndex = 3;
            this.lblMonthYear.Text = "Ağustos 2024";
            this.lblMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalenderForm
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1205, 643);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanelDays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalenderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CalenderForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refCalendar;
        private System.Windows.Forms.Button close_Viewpanel;
    }
}
