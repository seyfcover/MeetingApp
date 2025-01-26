namespace MeetingApp
{
    partial class UserPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPanel));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplantıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şirketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.akedemisyenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplantıToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.şirketToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.personelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.akademisyenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şirketAkademisyenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takvimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilgilerimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelofMeetings = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.aramaToolStripMenuItem,
            this.takvimToolStripMenuItem,
            this.raporToolStripMenuItem,
            this.bilgilerimToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1532, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toplantıToolStripMenuItem,
            this.şirketToolStripMenuItem,
            this.akedemisyenToolStripMenuItem});
            this.yeniToolStripMenuItem.Image = global::MeetingApp.Properties.Resources.calendar_add_icon_264057;
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(64, 44);
            this.yeniToolStripMenuItem.Text = "Yeni";
            // 
            // toplantıToolStripMenuItem
            // 
            this.toplantıToolStripMenuItem.Name = "toplantıToolStripMenuItem";
            this.toplantıToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.toplantıToolStripMenuItem.Text = "Faaliyet";
            this.toplantıToolStripMenuItem.Click += new System.EventHandler(this.toplantıToolStripMenuItem_Click);
            // 
            // şirketToolStripMenuItem
            // 
            this.şirketToolStripMenuItem.Name = "şirketToolStripMenuItem";
            this.şirketToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.şirketToolStripMenuItem.Text = "Şirket ve Personel";
            this.şirketToolStripMenuItem.Click += new System.EventHandler(this.şirketToolStripMenuItem_Click);
            // 
            // akedemisyenToolStripMenuItem
            // 
            this.akedemisyenToolStripMenuItem.Name = "akedemisyenToolStripMenuItem";
            this.akedemisyenToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.akedemisyenToolStripMenuItem.Text = "Akademisyen";
            this.akedemisyenToolStripMenuItem.Click += new System.EventHandler(this.akedemisyenToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toplantıToolStripMenuItem1,
            this.şirketToolStripMenuItem1,
            this.personelToolStripMenuItem1,
            this.akademisyenToolStripMenuItem});
            this.düzenleToolStripMenuItem.Image = global::MeetingApp.Properties.Resources.calendar_time_add_schedule_planning_icon_264061;
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(91, 44);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // toplantıToolStripMenuItem1
            // 
            this.toplantıToolStripMenuItem1.Name = "toplantıToolStripMenuItem1";
            this.toplantıToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.toplantıToolStripMenuItem1.Text = "Faaliyet";
            this.toplantıToolStripMenuItem1.Click += new System.EventHandler(this.toplantıToolStripMenuItem1_Click);
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
            this.aramaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şirketAkademisyenToolStripMenuItem});
            this.aramaToolStripMenuItem.Image = global::MeetingApp.Properties.Resources.target_icon_264154;
            this.aramaToolStripMenuItem.Name = "aramaToolStripMenuItem";
            this.aramaToolStripMenuItem.Size = new System.Drawing.Size(81, 44);
            this.aramaToolStripMenuItem.Text = "Arama";
            this.aramaToolStripMenuItem.Click += new System.EventHandler(this.aramaToolStripMenuItem_Click);
            // 
            // şirketAkademisyenToolStripMenuItem
            // 
            this.şirketAkademisyenToolStripMenuItem.Name = "şirketAkademisyenToolStripMenuItem";
            this.şirketAkademisyenToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.şirketAkademisyenToolStripMenuItem.Text = "Şirket / Akademisyen";
            this.şirketAkademisyenToolStripMenuItem.Click += new System.EventHandler(this.şirketAkademisyenToolStripMenuItem_Click);
            // 
            // takvimToolStripMenuItem
            // 
            this.takvimToolStripMenuItem.Image = global::MeetingApp.Properties.Resources.schedule_icon_264140;
            this.takvimToolStripMenuItem.Name = "takvimToolStripMenuItem";
            this.takvimToolStripMenuItem.Size = new System.Drawing.Size(82, 44);
            this.takvimToolStripMenuItem.Text = "Takvim";
            this.takvimToolStripMenuItem.Click += new System.EventHandler(this.takvimToolStripMenuItem_Click);
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.Image = global::MeetingApp.Properties.Resources.briefcase_suitcase_icon_264054;
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(77, 44);
            this.raporToolStripMenuItem.Text = "Rapor";
            this.raporToolStripMenuItem.Click += new System.EventHandler(this.raporToolStripMenuItem_Click);
            // 
            // bilgilerimToolStripMenuItem
            // 
            this.bilgilerimToolStripMenuItem.Image = global::MeetingApp.Properties.Resources.seal_icon_264141;
            this.bilgilerimToolStripMenuItem.Name = "bilgilerimToolStripMenuItem";
            this.bilgilerimToolStripMenuItem.ShowShortcutKeys = false;
            this.bilgilerimToolStripMenuItem.Size = new System.Drawing.Size(159, 44);
            this.bilgilerimToolStripMenuItem.Text = "Talep ve Bilgilerim";
            this.bilgilerimToolStripMenuItem.Click += new System.EventHandler(this.bilgilerimToolStripMenuItem_Click);
            // 
            // panelofMeetings
            // 
            this.panelofMeetings.AutoScroll = true;
            this.panelofMeetings.BackColor = System.Drawing.Color.White;
            this.panelofMeetings.Location = new System.Drawing.Point(0, 49);
            this.panelofMeetings.Margin = new System.Windows.Forms.Padding(11);
            this.panelofMeetings.Name = "panelofMeetings";
            this.panelofMeetings.Size = new System.Drawing.Size(1532, 793);
            this.panelofMeetings.TabIndex = 11;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 842);
            this.Controls.Add(this.panelofMeetings);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Paneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserPanel_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şirketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem akedemisyenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplantıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplantıToolStripMenuItem1;
        private System.Windows.Forms.Panel panelofMeetings;
        private System.Windows.Forms.ToolStripMenuItem takvimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şirketToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem personelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem akademisyenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şirketAkademisyenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilgilerimToolStripMenuItem;
    }
}
