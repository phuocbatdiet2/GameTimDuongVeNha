namespace TimDuongDiNganNhat
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.One = new System.Windows.Forms.RadioButton();
            this.Many = new System.Windows.Forms.RadioButton();
            this.OK = new System.Windows.Forms.Button();
            this.Manual = new System.Windows.Forms.RadioButton();
            this.Auto = new System.Windows.Forms.RadioButton();
            this.Number = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Number)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn số lượng vật thể bạn muốn đặt?";
            // 
            // One
            // 
            this.One.AutoSize = true;
            this.One.Location = new System.Drawing.Point(29, 41);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(79, 17);
            this.One.TabIndex = 1;
            this.One.TabStop = true;
            this.One.Text = "Một vật thể";
            this.One.UseVisualStyleBackColor = true;
            // 
            // Many
            // 
            this.Many.AutoSize = true;
            this.Many.Location = new System.Drawing.Point(29, 64);
            this.Many.Name = "Many";
            this.Many.Size = new System.Drawing.Size(89, 17);
            this.Many.TabIndex = 2;
            this.Many.TabStop = true;
            this.Many.Text = "Nhiều vật thể";
            this.Many.UseVisualStyleBackColor = true;
            this.Many.CheckedChanged += new System.EventHandler(this.Many_CheckedChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(197, 158);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Manual
            // 
            this.Manual.AutoSize = true;
            this.Manual.Location = new System.Drawing.Point(6, 42);
            this.Manual.Name = "Manual";
            this.Manual.Size = new System.Drawing.Size(71, 17);
            this.Manual.TabIndex = 6;
            this.Manual.TabStop = true;
            this.Manual.Text = "Thủ công";
            this.Manual.UseVisualStyleBackColor = true;
            this.Manual.Visible = false;
            // 
            // Auto
            // 
            this.Auto.AutoSize = true;
            this.Auto.Location = new System.Drawing.Point(6, 19);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(66, 17);
            this.Auto.TabIndex = 5;
            this.Auto.TabStop = true;
            this.Auto.Text = "Tự động";
            this.Auto.UseVisualStyleBackColor = true;
            this.Auto.Visible = false;
            this.Auto.CheckedChanged += new System.EventHandler(this.Auto_CheckedChanged);
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(83, 19);
            this.Number.Maximum = new decimal(new int[] {
            3465,
            0,
            0,
            0});
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(46, 20);
            this.Number.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Auto);
            this.groupBox1.Controls.Add(this.Number);
            this.groupBox1.Controls.Add(this.Manual);
            this.groupBox1.Location = new System.Drawing.Point(0, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn cách bạn muốn đặt vật";
            this.groupBox1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 185);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Many);
            this.Controls.Add(this.One);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số lượng vật thể";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            //this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Number)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton One;
        private System.Windows.Forms.RadioButton Many;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.RadioButton Manual;
        private System.Windows.Forms.RadioButton Auto;
        private System.Windows.Forms.NumericUpDown Number;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}