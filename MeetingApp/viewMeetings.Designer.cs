namespace MeetingApp
{
    partial class viewMeetings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewMeetings));
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.checkedListBoxParticipants = new System.Windows.Forms.CheckedListBox();
            this.ListMeetingforFilter = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Filterbegin = new System.Windows.Forms.DateTimePicker();
            this.Filterend = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.ParticipantPosition = new System.Windows.Forms.Label();
            this.ParticipantTitle = new System.Windows.Forms.Label();
            this.countofAmeeting = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ParticipantPhone = new System.Windows.Forms.Label();
            this.labelPArticipants = new System.Windows.Forms.Label();
            this.ParticipantEmail = new System.Windows.Forms.Label();
            this.ParticipantName = new System.Windows.Forms.Label();
            this.listofParticipants = new System.Windows.Forms.ListBox();
            this.close_Viewpanel = new System.Windows.Forms.Button();
            this.MeetingTime = new System.Windows.Forms.Label();
            this.MeetingDate = new System.Windows.Forms.Label();
            this.MeetingLocation = new System.Windows.Forms.Label();
            this.MeetingTitle = new System.Windows.Forms.Label();
            this.viewDocument = new System.Windows.Forms.Button();
            this.MeetingNotes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listofMeetings = new System.Windows.Forms.ListBox();
            this.ParticipantCompany = new System.Windows.Forms.PictureBox();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.generateReport = new System.Windows.Forms.Button();
            this.labelsearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refMeeting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ParticipantCompany)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClearSelection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnClearSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSelection.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClearSelection.ForeColor = System.Drawing.Color.Black;
            this.btnClearSelection.Location = new System.Drawing.Point(194, 894);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(144, 37);
            this.btnClearSelection.TabIndex = 54;
            this.btnClearSelection.Text = "Temizle";
            this.btnClearSelection.UseVisualStyleBackColor = false;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.textBoxSearch.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSearch.Location = new System.Drawing.Point(26, 512);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(311, 33);
            this.textBoxSearch.TabIndex = 53;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // checkedListBoxParticipants
            // 
            this.checkedListBoxParticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.checkedListBoxParticipants.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkedListBoxParticipants.FormattingEnabled = true;
            this.checkedListBoxParticipants.Location = new System.Drawing.Point(26, 573);
            this.checkedListBoxParticipants.Name = "checkedListBoxParticipants";
            this.checkedListBoxParticipants.Size = new System.Drawing.Size(311, 290);
            this.checkedListBoxParticipants.TabIndex = 52;
            // 
            // ListMeetingforFilter
            // 
            this.ListMeetingforFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ListMeetingforFilter.FlatAppearance.BorderSize = 0;
            this.ListMeetingforFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.ListMeetingforFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.ListMeetingforFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListMeetingforFilter.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ListMeetingforFilter.ForeColor = System.Drawing.Color.White;
            this.ListMeetingforFilter.Location = new System.Drawing.Point(27, 894);
            this.ListMeetingforFilter.Name = "ListMeetingforFilter";
            this.ListMeetingforFilter.Size = new System.Drawing.Size(157, 37);
            this.ListMeetingforFilter.TabIndex = 51;
            this.ListMeetingforFilter.Text = "Listele";
            this.ListMeetingforFilter.UseVisualStyleBackColor = false;
            this.ListMeetingforFilter.Click += new System.EventHandler(this.ListMeetingforFilter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(180, 484);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 21);
            this.label6.TabIndex = 50;
            this.label6.Text = "-";
            // 
            // Filterbegin
            // 
            this.Filterbegin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Filterbegin.Location = new System.Drawing.Point(26, 479);
            this.Filterbegin.Name = "Filterbegin";
            this.Filterbegin.Size = new System.Drawing.Size(126, 27);
            this.Filterbegin.TabIndex = 49;
            // 
            // Filterend
            // 
            this.Filterend.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Filterend.Location = new System.Drawing.Point(228, 479);
            this.Filterend.Name = "Filterend";
            this.Filterend.Size = new System.Drawing.Size(107, 27);
            this.Filterend.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 23);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10);
            this.label5.Size = new System.Drawing.Size(366, 47);
            this.label5.TabIndex = 26;
            this.label5.Text = "Toplantılar";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParticipantPosition
            // 
            this.ParticipantPosition.AutoEllipsis = true;
            this.ParticipantPosition.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParticipantPosition.Location = new System.Drawing.Point(24, 197);
            this.ParticipantPosition.Name = "ParticipantPosition";
            this.ParticipantPosition.Size = new System.Drawing.Size(221, 17);
            this.ParticipantPosition.TabIndex = 45;
            // 
            // ParticipantTitle
            // 
            this.ParticipantTitle.AutoSize = true;
            this.ParticipantTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParticipantTitle.Location = new System.Drawing.Point(24, 227);
            this.ParticipantTitle.Name = "ParticipantTitle";
            this.ParticipantTitle.Size = new System.Drawing.Size(0, 19);
            this.ParticipantTitle.TabIndex = 44;
            // 
            // countofAmeeting
            // 
            this.countofAmeeting.AutoSize = true;
            this.countofAmeeting.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.countofAmeeting.Location = new System.Drawing.Point(215, 400);
            this.countofAmeeting.Name = "countofAmeeting";
            this.countofAmeeting.Size = new System.Drawing.Size(18, 19);
            this.countofAmeeting.TabIndex = 42;
            this.countofAmeeting.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(22, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "Katıldığı Toplantı Sayısı:";
            // 
            // ParticipantPhone
            // 
            this.ParticipantPhone.AutoEllipsis = true;
            this.ParticipantPhone.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParticipantPhone.Location = new System.Drawing.Point(23, 290);
            this.ParticipantPhone.Name = "ParticipantPhone";
            this.ParticipantPhone.Size = new System.Drawing.Size(312, 110);
            this.ParticipantPhone.TabIndex = 40;
            // 
            // labelPArticipants
            // 
            this.labelPArticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelPArticipants.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPArticipants.ForeColor = System.Drawing.Color.White;
            this.labelPArticipants.Location = new System.Drawing.Point(29, 481);
            this.labelPArticipants.Name = "labelPArticipants";
            this.labelPArticipants.Padding = new System.Windows.Forms.Padding(10);
            this.labelPArticipants.Size = new System.Drawing.Size(366, 42);
            this.labelPArticipants.TabIndex = 39;
            this.labelPArticipants.Text = "Katılımcılar";
            this.labelPArticipants.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParticipantEmail
            // 
            this.ParticipantEmail.AutoSize = true;
            this.ParticipantEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParticipantEmail.Location = new System.Drawing.Point(24, 261);
            this.ParticipantEmail.Name = "ParticipantEmail";
            this.ParticipantEmail.Size = new System.Drawing.Size(0, 19);
            this.ParticipantEmail.TabIndex = 38;
            // 
            // ParticipantName
            // 
            this.ParticipantName.AutoEllipsis = true;
            this.ParticipantName.AutoSize = true;
            this.ParticipantName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ParticipantName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParticipantName.Location = new System.Drawing.Point(24, 166);
            this.ParticipantName.Name = "ParticipantName";
            this.ParticipantName.Size = new System.Drawing.Size(0, 19);
            this.ParticipantName.TabIndex = 37;
            // 
            // listofParticipants
            // 
            this.listofParticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.listofParticipants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listofParticipants.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listofParticipants.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listofParticipants.FormattingEnabled = true;
            this.listofParticipants.ItemHeight = 23;
            this.listofParticipants.Location = new System.Drawing.Point(29, 537);
            this.listofParticipants.Name = "listofParticipants";
            this.listofParticipants.ScrollAlwaysVisible = true;
            this.listofParticipants.Size = new System.Drawing.Size(366, 301);
            this.listofParticipants.TabIndex = 36;
            this.listofParticipants.SelectedIndexChanged += new System.EventHandler(this.listofParticipants_SelectedIndexChanged);
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
            this.close_Viewpanel.Location = new System.Drawing.Point(337, 0);
            this.close_Viewpanel.Name = "close_Viewpanel";
            this.close_Viewpanel.Size = new System.Drawing.Size(25, 25);
            this.close_Viewpanel.TabIndex = 35;
            this.close_Viewpanel.Text = "X";
            this.close_Viewpanel.UseVisualStyleBackColor = false;
            this.close_Viewpanel.Click += new System.EventHandler(this.close_Viewpanel_Click);
            // 
            // MeetingTime
            // 
            this.MeetingTime.AutoSize = true;
            this.MeetingTime.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingTime.Location = new System.Drawing.Point(1402, 21);
            this.MeetingTime.Name = "MeetingTime";
            this.MeetingTime.Size = new System.Drawing.Size(0, 25);
            this.MeetingTime.TabIndex = 34;
            // 
            // MeetingDate
            // 
            this.MeetingDate.AutoSize = true;
            this.MeetingDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingDate.Location = new System.Drawing.Point(1252, 21);
            this.MeetingDate.Name = "MeetingDate";
            this.MeetingDate.Size = new System.Drawing.Size(0, 25);
            this.MeetingDate.TabIndex = 33;
            // 
            // MeetingLocation
            // 
            this.MeetingLocation.AutoEllipsis = true;
            this.MeetingLocation.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingLocation.Location = new System.Drawing.Point(464, 62);
            this.MeetingLocation.Name = "MeetingLocation";
            this.MeetingLocation.Size = new System.Drawing.Size(1018, 40);
            this.MeetingLocation.TabIndex = 32;
            // 
            // MeetingTitle
            // 
            this.MeetingTitle.AutoSize = true;
            this.MeetingTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingTitle.Location = new System.Drawing.Point(463, 15);
            this.MeetingTitle.Name = "MeetingTitle";
            this.MeetingTitle.Size = new System.Drawing.Size(0, 30);
            this.MeetingTitle.TabIndex = 31;
            // 
            // viewDocument
            // 
            this.viewDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.viewDocument.FlatAppearance.BorderSize = 0;
            this.viewDocument.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.viewDocument.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.viewDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewDocument.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.viewDocument.ForeColor = System.Drawing.Color.White;
            this.viewDocument.Location = new System.Drawing.Point(468, 876);
            this.viewDocument.Name = "viewDocument";
            this.viewDocument.Size = new System.Drawing.Size(230, 55);
            this.viewDocument.TabIndex = 30;
            this.viewDocument.Text = "Doküman Görüntüle";
            this.viewDocument.UseVisualStyleBackColor = false;
            this.viewDocument.Click += new System.EventHandler(this.viewDocument_Click);
            // 
            // MeetingNotes
            // 
            this.MeetingNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.MeetingNotes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingNotes.Location = new System.Drawing.Point(468, 102);
            this.MeetingNotes.Margin = new System.Windows.Forms.Padding(0);
            this.MeetingNotes.Name = "MeetingNotes";
            this.MeetingNotes.ReadOnly = true;
            this.MeetingNotes.Size = new System.Drawing.Size(1026, 736);
            this.MeetingNotes.TabIndex = 29;
            this.MeetingNotes.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 56;
            // 
            // listofMeetings
            // 
            this.listofMeetings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.listofMeetings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listofMeetings.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listofMeetings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listofMeetings.FormattingEnabled = true;
            this.listofMeetings.ItemHeight = 23;
            this.listofMeetings.Location = new System.Drawing.Point(29, 134);
            this.listofMeetings.Name = "listofMeetings";
            this.listofMeetings.ScrollAlwaysVisible = true;
            this.listofMeetings.Size = new System.Drawing.Size(366, 324);
            this.listofMeetings.TabIndex = 27;
            this.listofMeetings.SelectedIndexChanged += new System.EventHandler(this.listofMeetings_SelectedIndexChanged);
            // 
            // ParticipantCompany
            // 
            this.ParticipantCompany.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ParticipantCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ParticipantCompany.Location = new System.Drawing.Point(27, 11);
            this.ParticipantCompany.Name = "ParticipantCompany";
            this.ParticipantCompany.Size = new System.Drawing.Size(140, 140);
            this.ParticipantCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ParticipantCompany.TabIndex = 43;
            this.ParticipantCompany.TabStop = false;
            this.ParticipantCompany.Click += new System.EventHandler(this.ParticipantCompany_Click);
            this.ParticipantCompany.MouseEnter += new System.EventHandler(this.ParticipantCompany_MouseEnter);
            this.ParticipantCompany.MouseLeave += new System.EventHandler(this.ParticipantCompany_MouseLeave);
            // 
            // searchTextbox
            // 
            this.searchTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.searchTextbox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.searchTextbox.Location = new System.Drawing.Point(29, 87);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(366, 31);
            this.searchTextbox.TabIndex = 55;
            this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
            // 
            // generateReport
            // 
            this.generateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.generateReport.FlatAppearance.BorderSize = 0;
            this.generateReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.generateReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.generateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.generateReport.ForeColor = System.Drawing.Color.White;
            this.generateReport.Location = new System.Drawing.Point(1257, 876);
            this.generateReport.Name = "generateReport";
            this.generateReport.Size = new System.Drawing.Size(237, 55);
            this.generateReport.TabIndex = 30;
            this.generateReport.Text = "Rapor Oluştur";
            this.generateReport.UseVisualStyleBackColor = false;
            this.generateReport.Click += new System.EventHandler(this.generateReport_Click);
            // 
            // labelsearch
            // 
            this.labelsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.labelsearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelsearch.ForeColor = System.Drawing.Color.White;
            this.labelsearch.Location = new System.Drawing.Point(24, 429);
            this.labelsearch.Name = "labelsearch";
            this.labelsearch.Padding = new System.Windows.Forms.Padding(8);
            this.labelsearch.Size = new System.Drawing.Size(311, 37);
            this.labelsearch.TabIndex = 57;
            this.labelsearch.Text = "Toplantı Arama";
            this.labelsearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.labelsearch);
            this.panel1.Controls.Add(this.Filterend);
            this.panel1.Controls.Add(this.Filterbegin);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ListMeetingforFilter);
            this.panel1.Controls.Add(this.ParticipantPosition);
            this.panel1.Controls.Add(this.btnClearSelection);
            this.panel1.Controls.Add(this.ParticipantTitle);
            this.panel1.Controls.Add(this.checkedListBoxParticipants);
            this.panel1.Controls.Add(this.ParticipantCompany);
            this.panel1.Controls.Add(this.countofAmeeting);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.close_Viewpanel);
            this.panel1.Controls.Add(this.ParticipantPhone);
            this.panel1.Controls.Add(this.ParticipantName);
            this.panel1.Controls.Add(this.ParticipantEmail);
            this.panel1.Location = new System.Drawing.Point(1533, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 944);
            this.panel1.TabIndex = 58;
            // 
            // refMeeting
            // 
            this.refMeeting.BackColor = System.Drawing.Color.SeaGreen;
            this.refMeeting.FlatAppearance.BorderSize = 0;
            this.refMeeting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.refMeeting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(179)))));
            this.refMeeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refMeeting.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.refMeeting.ForeColor = System.Drawing.Color.White;
            this.refMeeting.Location = new System.Drawing.Point(29, 876);
            this.refMeeting.Name = "refMeeting";
            this.refMeeting.Size = new System.Drawing.Size(366, 55);
            this.refMeeting.TabIndex = 30;
            this.refMeeting.Text = "Yenile";
            this.refMeeting.UseVisualStyleBackColor = false;
            this.refMeeting.Click += new System.EventHandler(this.refMeeting_Click);
            // 
            // viewMeetings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1904, 962);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MeetingTime);
            this.Controls.Add(this.MeetingDate);
            this.Controls.Add(this.searchTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPArticipants);
            this.Controls.Add(this.listofParticipants);
            this.Controls.Add(this.MeetingLocation);
            this.Controls.Add(this.MeetingTitle);
            this.Controls.Add(this.refMeeting);
            this.Controls.Add(this.generateReport);
            this.Controls.Add(this.viewDocument);
            this.Controls.Add(this.MeetingNotes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listofMeetings);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "viewMeetings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "viewMeetings";
            ((System.ComponentModel.ISupportInitialize)(this.ParticipantCompany)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckedListBox checkedListBoxParticipants;
        private System.Windows.Forms.Button ListMeetingforFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker Filterbegin;
        private System.Windows.Forms.DateTimePicker Filterend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ParticipantPosition;
        private System.Windows.Forms.Label ParticipantTitle;
        private System.Windows.Forms.PictureBox ParticipantCompany;
        private System.Windows.Forms.Label countofAmeeting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ParticipantPhone;
        private System.Windows.Forms.Label labelPArticipants;
        private System.Windows.Forms.Label ParticipantEmail;
        private System.Windows.Forms.Label ParticipantName;
        private System.Windows.Forms.ListBox listofParticipants;
        private System.Windows.Forms.Button close_Viewpanel;
        private System.Windows.Forms.Label MeetingTime;
        private System.Windows.Forms.Label MeetingDate;
        private System.Windows.Forms.Label MeetingLocation;
        private System.Windows.Forms.Label MeetingTitle;
        private System.Windows.Forms.Button viewDocument;
        private System.Windows.Forms.RichTextBox MeetingNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listofMeetings;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Button generateReport;
        private System.Windows.Forms.Label labelsearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refMeeting;
    }
}