namespace MeetingApp
{
    partial class ViewDocumentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox documentsListBox;
        private System.Windows.Forms.Button closeButton;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.documentsListBox = new System.Windows.Forms.ListBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // documentsListBox
            // 
            this.documentsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.documentsListBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.documentsListBox.FormattingEnabled = true;
            this.documentsListBox.ItemHeight = 18;
            this.documentsListBox.Location = new System.Drawing.Point(10, 10);
            this.documentsListBox.Name = "documentsListBox";
            this.documentsListBox.Size = new System.Drawing.Size(309, 148);
            this.documentsListBox.TabIndex = 0;
            this.documentsListBox.DoubleClick += new System.EventHandler(this.documentsListBox_DoubleClick);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton.BackColor = System.Drawing.Color.DarkOrange;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.closeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closeButton.Location = new System.Drawing.Point(119, 164);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 37);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Kapat";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ViewDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(329, 205);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.documentsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewDocumentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dökümanları Görüntüle";
            this.ResumeLayout(false);

        }
    }
}
