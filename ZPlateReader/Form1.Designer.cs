namespace ZPlateReader
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button_scan_dir = new System.Windows.Forms.Button();
			this.backgroundWorker_main = new System.ComponentModel.BackgroundWorker();
			this.label1 = new System.Windows.Forms.Label();
			this.label_work_time = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_scan_dir
			// 
			this.button_scan_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_scan_dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.77358F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_scan_dir.Location = new System.Drawing.Point(12, 12);
			this.button_scan_dir.Name = "button_scan_dir";
			this.button_scan_dir.Size = new System.Drawing.Size(362, 73);
			this.button_scan_dir.TabIndex = 0;
			this.button_scan_dir.Text = "Scan dir..";
			this.button_scan_dir.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(13, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "Working time:";
			// 
			// label_work_time
			// 
			this.label_work_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_work_time.AutoSize = true;
			this.label_work_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_work_time.Location = new System.Drawing.Point(205, 104);
			this.label_work_time.Name = "label_work_time";
			this.label_work_time.Size = new System.Drawing.Size(0, 29);
			this.label_work_time.TabIndex = 1;
			this.label_work_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 149);
			this.Controls.Add(this.label_work_time);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_scan_dir);
			this.Name = "Form1";
			this.Text = "ZPlateReader";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_scan_dir;
		private System.ComponentModel.BackgroundWorker backgroundWorker_main;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label_work_time;
	}
}

