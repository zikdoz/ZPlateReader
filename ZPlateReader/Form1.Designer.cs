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
			this.openFileDialog_main = new System.Windows.Forms.OpenFileDialog();
			this.button_test = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// openFileDialog_main
			// 
			this.openFileDialog_main.Filter = "Jpeg files (*.jpg)|*.jpg|Bmp files (*.bmp)|*.bmp|Png files (*.png)|*.png|All file" +
    "s (*.*)|*.*";
			this.openFileDialog_main.FilterIndex = 4;
			this.openFileDialog_main.RestoreDirectory = true;
			// 
			// button_test
			// 
			this.button_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.77358F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_test.Location = new System.Drawing.Point(12, 12);
			this.button_test.Name = "button_test";
			this.button_test.Size = new System.Drawing.Size(208, 73);
			this.button_test.TabIndex = 0;
			this.button_test.Text = "hit meh";
			this.button_test.UseVisualStyleBackColor = true;
			this.button_test.Click += new System.EventHandler(this.button_test_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 559);
			this.Controls.Add(this.button_test);
			this.Name = "Form1";
			this.Text = "ZPlateReader";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog_main;
		private System.Windows.Forms.Button button_test;
	}
}

