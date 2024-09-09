using System;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(int maxProgress) {
            InitializeComponent();
            progressBar1.Maximum = maxProgress;
        }

        public void UpdateProgress(int progress) {
            if (progress <= progressBar1.Maximum) {
                progressBar1.Value = progress;
            }
        }
    }
}