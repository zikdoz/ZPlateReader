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
			this.textbox_plate_idx = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textbox_min_size = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textbox_max_size = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textbox_detect_mode = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textbox_max_text_size = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textbox_type_number = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.checkbox_detect_all_plates = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button_scan_dir
			// 
			this.button_scan_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_scan_dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.77358F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_scan_dir.Location = new System.Drawing.Point(12, 12);
			this.button_scan_dir.Name = "button_scan_dir";
			this.button_scan_dir.Size = new System.Drawing.Size(397, 73);
			this.button_scan_dir.TabIndex = 7;
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
			this.label_work_time.Location = new System.Drawing.Point(240, 104);
			this.label_work_time.Name = "label_work_time";
			this.label_work_time.Size = new System.Drawing.Size(0, 29);
			this.label_work_time.TabIndex = 1;
			this.label_work_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textbox_plate_idx
			// 
			this.textbox_plate_idx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox_plate_idx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textbox_plate_idx.Location = new System.Drawing.Point(201, 161);
			this.textbox_plate_idx.Name = "textbox_plate_idx";
			this.textbox_plate_idx.Size = new System.Drawing.Size(207, 28);
			this.textbox_plate_idx.TabIndex = 0;
			this.textbox_plate_idx.Text = "2";
			this.textbox_plate_idx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(13, 159);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 29);
			this.label2.TabIndex = 3;
			this.label2.Text = "Plate number:";
			// 
			// textbox_min_size
			// 
			this.textbox_min_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox_min_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textbox_min_size.Location = new System.Drawing.Point(201, 214);
			this.textbox_min_size.Name = "textbox_min_size";
			this.textbox_min_size.Size = new System.Drawing.Size(207, 28);
			this.textbox_min_size.TabIndex = 1;
			this.textbox_min_size.Text = "500";
			this.textbox_min_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(13, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 29);
			this.label3.TabIndex = 3;
			this.label3.Text = "Min size:";
			// 
			// textbox_max_size
			// 
			this.textbox_max_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox_max_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textbox_max_size.Location = new System.Drawing.Point(201, 261);
			this.textbox_max_size.Name = "textbox_max_size";
			this.textbox_max_size.Size = new System.Drawing.Size(207, 28);
			this.textbox_max_size.TabIndex = 2;
			this.textbox_max_size.Text = "25000";
			this.textbox_max_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(13, 259);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 29);
			this.label4.TabIndex = 3;
			this.label4.Text = "Max size";
			// 
			// textbox_detect_mode
			// 
			this.textbox_detect_mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox_detect_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textbox_detect_mode.Location = new System.Drawing.Point(201, 306);
			this.textbox_detect_mode.Name = "textbox_detect_mode";
			this.textbox_detect_mode.Size = new System.Drawing.Size(207, 28);
			this.textbox_detect_mode.TabIndex = 3;
			this.textbox_detect_mode.Text = "14";
			this.textbox_detect_mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(13, 304);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(164, 29);
			this.label5.TabIndex = 3;
			this.label5.Text = "Detect mode:";
			// 
			// textbox_max_text_size
			// 
			this.textbox_max_text_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox_max_text_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textbox_max_text_size.Location = new System.Drawing.Point(201, 350);
			this.textbox_max_text_size.Name = "textbox_max_text_size";
			this.textbox_max_text_size.Size = new System.Drawing.Size(207, 28);
			this.textbox_max_text_size.TabIndex = 4;
			this.textbox_max_text_size.Text = "20";
			this.textbox_max_text_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(13, 348);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 29);
			this.label6.TabIndex = 3;
			this.label6.Text = "Max text size:";
			// 
			// textbox_type_number
			// 
			this.textbox_type_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox_type_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textbox_type_number.Location = new System.Drawing.Point(201, 394);
			this.textbox_type_number.Name = "textbox_type_number";
			this.textbox_type_number.Size = new System.Drawing.Size(207, 28);
			this.textbox_type_number.TabIndex = 5;
			this.textbox_type_number.Text = "7";
			this.textbox_type_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(13, 392);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(169, 29);
			this.label7.TabIndex = 3;
			this.label7.Text = "Type number:";
			// 
			// checkbox_detect_all_plates
			// 
			this.checkbox_detect_all_plates.AutoSize = true;
			this.checkbox_detect_all_plates.BackColor = System.Drawing.SystemColors.ControlDark;
			this.checkbox_detect_all_plates.Checked = true;
			this.checkbox_detect_all_plates.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkbox_detect_all_plates.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.checkbox_detect_all_plates.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkbox_detect_all_plates.Location = new System.Drawing.Point(0, 447);
			this.checkbox_detect_all_plates.Name = "checkbox_detect_all_plates";
			this.checkbox_detect_all_plates.Size = new System.Drawing.Size(421, 33);
			this.checkbox_detect_all_plates.TabIndex = 6;
			this.checkbox_detect_all_plates.Text = "Detect all plates";
			this.checkbox_detect_all_plates.UseVisualStyleBackColor = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(421, 480);
			this.Controls.Add(this.checkbox_detect_all_plates);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textbox_type_number);
			this.Controls.Add(this.textbox_max_text_size);
			this.Controls.Add(this.textbox_detect_mode);
			this.Controls.Add(this.textbox_max_size);
			this.Controls.Add(this.textbox_min_size);
			this.Controls.Add(this.textbox_plate_idx);
			this.Controls.Add(this.label_work_time);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_scan_dir);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ZPlateReader";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_scan_dir;
		private System.ComponentModel.BackgroundWorker backgroundWorker_main;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label_work_time;
		private System.Windows.Forms.TextBox textbox_plate_idx;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textbox_min_size;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textbox_max_size;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textbox_detect_mode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textbox_max_text_size;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textbox_type_number;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox checkbox_detect_all_plates;
	}
}

