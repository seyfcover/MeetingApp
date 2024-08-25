using System;

namespace MeetingApp
{
    partial class HeatMapForm
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
            this.plotViewHeatMap = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // plotViewHeatMap
            // 
            this.plotViewHeatMap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plotViewHeatMap.Location = new System.Drawing.Point(0, 0);
            this.plotViewHeatMap.Name = "plotViewHeatMap";
            this.plotViewHeatMap.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewHeatMap.Size = new System.Drawing.Size(1042, 367);
            this.plotViewHeatMap.TabIndex = 0;
            this.plotViewHeatMap.Text = "plotView1";
            this.plotViewHeatMap.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewHeatMap.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewHeatMap.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // HeatMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1042, 367);
            this.ControlBox = false;
            this.Controls.Add(this.plotViewHeatMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HeatMapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeatMapForm";
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotViewHeatMap;
    }
}