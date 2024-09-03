using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görüşmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.addAcademian = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.şirketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şirketToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.personelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.akademisyenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takvimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.istatistiklerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.adayŞirketlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelofMeetings = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.aramaToolStripMenuItem,
            this.takvimToolStripMenuItem,
            this.istatistiklerToolStripMenuItem,
            this.makeReport,
            this.adayŞirketlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1904, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıToolStripMenuItem,
            this.görüşmeToolStripMenuItem,
            this.addCompany,
            this.addAcademian});
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(70, 44);
            this.yeniToolStripMenuItem.Text = "Yeni";
            // 
            // kullanıcıToolStripMenuItem
            // 
            this.kullanıcıToolStripMenuItem.Name = "kullanıcıToolStripMenuItem";
            this.kullanıcıToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.kullanıcıToolStripMenuItem.Text = "Kullanıcı";
            this.kullanıcıToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıToolStripMenuItem_Click);
            // 
            // görüşmeToolStripMenuItem
            // 
            this.görüşmeToolStripMenuItem.Name = "görüşmeToolStripMenuItem";
            this.görüşmeToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.görüşmeToolStripMenuItem.Text = "Toplantı";
            this.görüşmeToolStripMenuItem.Click += new System.EventHandler(this.addMeeting_Click);
            // 
            // addCompany
            // 
            this.addCompany.Name = "addCompany";
            this.addCompany.Size = new System.Drawing.Size(193, 24);
            this.addCompany.Text = "Şirket ve Personel";
            this.addCompany.Click += new System.EventHandler(this.addCompany_Click);
            // 
            // addAcademian
            // 
            this.addAcademian.Name = "addAcademian";
            this.addAcademian.Size = new System.Drawing.Size(193, 24);
            this.addAcademian.Text = "Akademisyen";
            this.addAcademian.Click += new System.EventHandler(this.addAcademian_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıToolStripMenuItem1,
            this.şirketToolStripMenuItem,
            this.şirketToolStripMenuItem1,
            this.personelToolStripMenuItem1,
            this.akademisyenToolStripMenuItem});
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(97, 44);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // kullanıcıToolStripMenuItem1
            // 
            this.kullanıcıToolStripMenuItem1.Name = "kullanıcıToolStripMenuItem1";
            this.kullanıcıToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.kullanıcıToolStripMenuItem1.Text = "Kullanıcı";
            this.kullanıcıToolStripMenuItem1.Click += new System.EventHandler(this.kullanıcıToolStripMenuItem1_Click);
            // 
            // şirketToolStripMenuItem
            // 
            this.şirketToolStripMenuItem.Name = "şirketToolStripMenuItem";
            this.şirketToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.şirketToolStripMenuItem.Text = "Toplantı";
            this.şirketToolStripMenuItem.Click += new System.EventHandler(this.şirketToolStripMenuItem_Click);
            // 
            // şirketToolStripMenuItem1
            // 
            this.şirketToolStripMenuItem1.Name = "şirketToolStripMenuItem1";
            this.şirketToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.şirketToolStripMenuItem1.Text = "Şirket";
            this.şirketToolStripMenuItem1.Click += new System.EventHandler(this.şirketToolStripMenuItem1_Click);
            // 
            // personelToolStripMenuItem1
            // 
            this.personelToolStripMenuItem1.Name = "personelToolStripMenuItem1";
            this.personelToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.personelToolStripMenuItem1.Text = "Personel";
            this.personelToolStripMenuItem1.Click += new System.EventHandler(this.personelToolStripMenuItem1_Click);
            // 
            // akademisyenToolStripMenuItem
            // 
            this.akademisyenToolStripMenuItem.Name = "akademisyenToolStripMenuItem";
            this.akademisyenToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.akademisyenToolStripMenuItem.Text = "Akademisyen";
            this.akademisyenToolStripMenuItem.Click += new System.EventHandler(this.akademisyenToolStripMenuItem_Click);
            // 
            // aramaToolStripMenuItem
            // 
            this.aramaToolStripMenuItem.Name = "aramaToolStripMenuItem";
            this.aramaToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.aramaToolStripMenuItem.Size = new System.Drawing.Size(87, 44);
            this.aramaToolStripMenuItem.Text = "Arama";
            this.aramaToolStripMenuItem.Click += new System.EventHandler(this.aramaToolStripMenuItem_Click);
            // 
            // takvimToolStripMenuItem
            // 
            this.takvimToolStripMenuItem.Name = "takvimToolStripMenuItem";
            this.takvimToolStripMenuItem.Size = new System.Drawing.Size(66, 44);
            this.takvimToolStripMenuItem.Text = "Takvim";
            this.takvimToolStripMenuItem.Click += new System.EventHandler(this.takvimToolStripMenuItem_Click);
            // 
            // istatistiklerToolStripMenuItem
            // 
            this.istatistiklerToolStripMenuItem.Name = "istatistiklerToolStripMenuItem";
            this.istatistiklerToolStripMenuItem.Size = new System.Drawing.Size(92, 44);
            this.istatistiklerToolStripMenuItem.Text = "İstatistikler";
            this.istatistiklerToolStripMenuItem.Click += new System.EventHandler(this.istatistiklerToolStripMenuItem_Click);
            // 
            // makeReport
            // 
            this.makeReport.Name = "makeReport";
            this.makeReport.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.makeReport.Size = new System.Drawing.Size(83, 44);
            this.makeReport.Text = "Rapor";
            this.makeReport.Click += new System.EventHandler(this.makeReport_Click);
            // 
            // adayŞirketlerToolStripMenuItem
            // 
            this.adayŞirketlerToolStripMenuItem.Name = "adayŞirketlerToolStripMenuItem";
            this.adayŞirketlerToolStripMenuItem.Size = new System.Drawing.Size(113, 44);
            this.adayŞirketlerToolStripMenuItem.Text = "Aday Şirketler";
            this.adayŞirketlerToolStripMenuItem.Click += new System.EventHandler(this.adayŞirketlerToolStripMenuItem_Click);
            // 
            // panelofMeetings
            // 
            this.panelofMeetings.AutoScroll = true;
            this.panelofMeetings.BackColor = System.Drawing.Color.White;
            this.panelofMeetings.Location = new System.Drawing.Point(0, 49);
            this.panelofMeetings.Margin = new System.Windows.Forms.Padding(11);
            this.panelofMeetings.Name = "panelofMeetings";
            this.panelofMeetings.Size = new System.Drawing.Size(1904, 962);
            this.panelofMeetings.TabIndex = 10;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.panelofMeetings);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPanel_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüşmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCompany;
        private System.Windows.Forms.ToolStripMenuItem addAcademian;
        private System.Windows.Forms.ToolStripMenuItem aramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeReport;
        private ToolStripMenuItem düzenleToolStripMenuItem;
        private ToolStripMenuItem şirketToolStripMenuItem;
        private ToolStripMenuItem şirketToolStripMenuItem1;
        private ToolStripMenuItem personelToolStripMenuItem1;
        private ToolStripMenuItem akademisyenToolStripMenuItem;
        private ToolStripMenuItem kullanıcıToolStripMenuItem;
        private ToolStripMenuItem kullanıcıToolStripMenuItem1;
        private Panel panelofMeetings;
        private ToolStripMenuItem takvimToolStripMenuItem;
        private ToolStripMenuItem adayŞirketlerToolStripMenuItem;
        private ToolStripMenuItem istatistiklerToolStripMenuItem;
    }
}