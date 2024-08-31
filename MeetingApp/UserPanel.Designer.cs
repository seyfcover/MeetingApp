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
            this.şirketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.akedemisyenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplantıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplantıToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takvimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.istatistiklerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.raporToolStripMenuItem,
            this.takvimToolStripMenuItem,
            this.istatistiklerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1207, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şirketToolStripMenuItem,
            this.personelToolStripMenuItem,
            this.akedemisyenToolStripMenuItem,
            this.toplantıToolStripMenuItem});
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.yeniToolStripMenuItem.Text = "Yeni";
            // 
            // şirketToolStripMenuItem
            // 
            this.şirketToolStripMenuItem.Name = "şirketToolStripMenuItem";
            this.şirketToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.şirketToolStripMenuItem.Text = "Şirket";
            this.şirketToolStripMenuItem.Click += new System.EventHandler(this.şirketToolStripMenuItem_Click);
            // 
            // personelToolStripMenuItem
            // 
            this.personelToolStripMenuItem.Name = "personelToolStripMenuItem";
            this.personelToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.personelToolStripMenuItem.Text = "Personel";
            this.personelToolStripMenuItem.Click += new System.EventHandler(this.personelToolStripMenuItem_Click);
            // 
            // akedemisyenToolStripMenuItem
            // 
            this.akedemisyenToolStripMenuItem.Name = "akedemisyenToolStripMenuItem";
            this.akedemisyenToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.akedemisyenToolStripMenuItem.Text = "Akedemisyen";
            this.akedemisyenToolStripMenuItem.Click += new System.EventHandler(this.akedemisyenToolStripMenuItem_Click);
            // 
            // toplantıToolStripMenuItem
            // 
            this.toplantıToolStripMenuItem.Name = "toplantıToolStripMenuItem";
            this.toplantıToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.toplantıToolStripMenuItem.Text = "Toplantı";
            this.toplantıToolStripMenuItem.Click += new System.EventHandler(this.toplantıToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toplantıToolStripMenuItem1});
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // toplantıToolStripMenuItem1
            // 
            this.toplantıToolStripMenuItem1.Name = "toplantıToolStripMenuItem1";
            this.toplantıToolStripMenuItem1.Size = new System.Drawing.Size(132, 24);
            this.toplantıToolStripMenuItem1.Text = "Toplantı";
            this.toplantıToolStripMenuItem1.Click += new System.EventHandler(this.toplantıToolStripMenuItem1_Click);
            // 
            // aramaToolStripMenuItem
            // 
            this.aramaToolStripMenuItem.Name = "aramaToolStripMenuItem";
            this.aramaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.aramaToolStripMenuItem.Text = "Arama";
            this.aramaToolStripMenuItem.Click += new System.EventHandler(this.aramaToolStripMenuItem_Click);
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.raporToolStripMenuItem.Text = "Rapor";
            this.raporToolStripMenuItem.Click += new System.EventHandler(this.raporToolStripMenuItem_Click);
            // 
            // takvimToolStripMenuItem
            // 
            this.takvimToolStripMenuItem.Name = "takvimToolStripMenuItem";
            this.takvimToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.takvimToolStripMenuItem.Text = "Takvim";
            this.takvimToolStripMenuItem.Click += new System.EventHandler(this.takvimToolStripMenuItem_Click);
            // 
            // istatistiklerToolStripMenuItem
            // 
            this.istatistiklerToolStripMenuItem.Name = "istatistiklerToolStripMenuItem";
            this.istatistiklerToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.istatistiklerToolStripMenuItem.Text = "İstatistikler";
            this.istatistiklerToolStripMenuItem.Click += new System.EventHandler(this.istatistiklerToolStripMenuItem_Click);
            // 
            // panelofMeetings
            // 
            this.panelofMeetings.AutoScroll = true;
            this.panelofMeetings.BackColor = System.Drawing.Color.White;
            this.panelofMeetings.Location = new System.Drawing.Point(0, 33);
            this.panelofMeetings.Margin = new System.Windows.Forms.Padding(11);
            this.panelofMeetings.Name = "panelofMeetings";
            this.panelofMeetings.Size = new System.Drawing.Size(1207, 646);
            this.panelofMeetings.TabIndex = 11;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 678);
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
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şirketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem akedemisyenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplantıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplantıToolStripMenuItem1;
        private System.Windows.Forms.Panel panelofMeetings;
        private System.Windows.Forms.ToolStripMenuItem takvimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem istatistiklerToolStripMenuItem;
    }
}
