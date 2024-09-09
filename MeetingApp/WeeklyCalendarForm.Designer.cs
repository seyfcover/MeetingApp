using System.Windows.Forms;

namespace MeetingApp
{
    partial class WeeklyCalendarForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDays;
        private System.Windows.Forms.Label lblWeekRange;
        private System.Windows.Forms.Button btnPreviousWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel headerPanel;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeeklyCalendarForm));
            this.tableLayoutPanelDays = new System.Windows.Forms.TableLayoutPanel();
            this.lblWeekRange = new System.Windows.Forms.Label();
            this.btnPreviousWeek = new System.Windows.Forms.Button();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDays
            // 
            this.tableLayoutPanelDays.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelDays.ColumnCount = 7;
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanelDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDays.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanelDays.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDays.Name = "tableLayoutPanelDays";
            this.tableLayoutPanelDays.RowCount = 2;
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDays.Size = new System.Drawing.Size(1532, 743);
            this.tableLayoutPanelDays.TabIndex = 0;
            // 
            // lblWeekRange
            // 
            this.lblWeekRange.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWeekRange.BackColor = System.Drawing.Color.Transparent;
            this.lblWeekRange.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWeekRange.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblWeekRange.Location = new System.Drawing.Point(457, 9);
            this.lblWeekRange.Name = "lblWeekRange";
            this.lblWeekRange.Size = new System.Drawing.Size(632, 30);
            this.lblWeekRange.TabIndex = 0;
            this.lblWeekRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousWeek
            // 
            this.btnPreviousWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnPreviousWeek.FlatAppearance.BorderSize = 0;
            this.btnPreviousWeek.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.btnPreviousWeek.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.btnPreviousWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousWeek.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPreviousWeek.ForeColor = System.Drawing.Color.White;
            this.btnPreviousWeek.Location = new System.Drawing.Point(10, 10);
            this.btnPreviousWeek.Name = "btnPreviousWeek";
            this.btnPreviousWeek.Size = new System.Drawing.Size(150, 30);
            this.btnPreviousWeek.TabIndex = 1;
            this.btnPreviousWeek.Text = "Önceki Hafta";
            this.btnPreviousWeek.Click += new System.EventHandler(this.btnPreviousWeek_Click);
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnNextWeek.FlatAppearance.BorderSize = 0;
            this.btnNextWeek.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.btnNextWeek.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.btnNextWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextWeek.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNextWeek.ForeColor = System.Drawing.Color.White;
            this.btnNextWeek.Location = new System.Drawing.Point(1372, 10);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(150, 30);
            this.btnNextWeek.TabIndex = 2;
            this.btnNextWeek.Text = "Sonraki Hafta";
            this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1372, 750);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1206, 750);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Click += new System.EventHandler(this.refCalendar_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackgroundImage = global::MeetingApp.Properties.Resources.back;
            this.headerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerPanel.Controls.Add(this.btnNextWeek);
            this.headerPanel.Controls.Add(this.btnPreviousWeek);
            this.headerPanel.Controls.Add(this.lblWeekRange);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1532, 50);
            this.headerPanel.TabIndex = 1;
            // 
            // WeeklyCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1532, 793);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelDays);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WeeklyCalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Haftalık Takvim";
            this.Load += new System.EventHandler(this.WeeklyCalendarForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
