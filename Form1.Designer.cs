namespace TimDuongDiNganNhat
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
            this.BanCo = new System.Windows.Forms.Panel();
            this.StartPoint = new System.Windows.Forms.Button();
            this.EndPoint = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.LamMoi = new System.Windows.Forms.Button();
            this.SetObject = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Slow = new System.Windows.Forms.CheckBox();
            this.ShowProcess = new System.Windows.Forms.CheckBox();
            this.AStart = new System.Windows.Forms.RadioButton();
            this.Dijkstra = new System.Windows.Forms.RadioButton();
            this.GreedyFS = new System.Windows.Forms.RadioButton();
            this.BreadthFirstSearch = new System.Windows.Forms.RadioButton();
            this.DeleteOne = new System.Windows.Forms.Button();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.Moving = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.River = new System.Windows.Forms.RadioButton();
            this.Wall = new System.Windows.Forms.RadioButton();
            this.Mountain = new System.Windows.Forms.RadioButton();
            this.Jungle = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BanCo
            // 
            this.BanCo.Location = new System.Drawing.Point(0, 0);
            this.BanCo.Name = "BanCo";
            this.BanCo.Size = new System.Drawing.Size(1156, 676);
            this.BanCo.TabIndex = 0;
            this.BanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.BanCo_Paint);
            this.BanCo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BanCo_MouseDown);
            this.BanCo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BanCo_MouseMove);
            this.BanCo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BanCo_MouseUp);
            // 
            // StartPoint
            // 
            this.StartPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StartPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartPoint.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StartPoint.Location = new System.Drawing.Point(1169, 4);
            this.StartPoint.Name = "StartPoint";
            this.StartPoint.Size = new System.Drawing.Size(181, 50);
            this.StartPoint.TabIndex = 1;
            this.StartPoint.Text = "Điểm bắt đầu";
            this.StartPoint.UseVisualStyleBackColor = false;
            this.StartPoint.Click += new System.EventHandler(this.StartPoint_Click);
            // 
            // EndPoint
            // 
            this.EndPoint.BackColor = System.Drawing.Color.Cyan;
            this.EndPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndPoint.Font = new System.Drawing.Font("Sitka Banner", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.EndPoint.Location = new System.Drawing.Point(1169, 55);
            this.EndPoint.Name = "EndPoint";
            this.EndPoint.Size = new System.Drawing.Size(181, 50);
            this.EndPoint.TabIndex = 2;
            this.EndPoint.Text = "Điểm kết thúc";
            this.EndPoint.UseVisualStyleBackColor = false;
            this.EndPoint.Click += new System.EventHandler(this.EndPoint_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(1169, 451);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(181, 44);
            this.Search.TabIndex = 3;
            this.Search.Text = "Bắt đầu tìm kiếm";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // LamMoi
            // 
            this.LamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LamMoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LamMoi.Location = new System.Drawing.Point(1169, 542);
            this.LamMoi.Name = "LamMoi";
            this.LamMoi.Size = new System.Drawing.Size(181, 44);
            this.LamMoi.TabIndex = 4;
            this.LamMoi.Text = "Làm mới";
            this.LamMoi.UseVisualStyleBackColor = false;
            this.LamMoi.Click += new System.EventHandler(this.LamMoi_Click);
            // 
            // SetObject
            // 
            this.SetObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.SetObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetObject.Font = new System.Drawing.Font("Sitka Banner", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SetObject.Location = new System.Drawing.Point(1169, 177);
            this.SetObject.Name = "SetObject";
            this.SetObject.Size = new System.Drawing.Size(181, 44);
            this.SetObject.TabIndex = 5;
            this.SetObject.Text = "Đặt địa hình";
            this.SetObject.UseVisualStyleBackColor = false;
            this.SetObject.Click += new System.EventHandler(this.SetObject_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.Time);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Slow);
            this.groupBox1.Controls.Add(this.ShowProcess);
            this.groupBox1.Controls.Add(this.AStart);
            this.groupBox1.Controls.Add(this.Dijkstra);
            this.groupBox1.Controls.Add(this.GreedyFS);
            this.groupBox1.Controls.Add(this.BreadthFirstSearch);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(1163, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 226);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn thuật toán cần dùng";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(138, 202);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(47, 17);
            this.Time.TabIndex = 7;
            this.Time.Text = "0.00 s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thời gian tìm kiếm:";
            // 
            // Slow
            // 
            this.Slow.AutoSize = true;
            this.Slow.Location = new System.Drawing.Point(6, 164);
            this.Slow.Name = "Slow";
            this.Slow.Size = new System.Drawing.Size(66, 21);
            this.Slow.TabIndex = 5;
            this.Slow.Text = "label2";
            this.Slow.UseVisualStyleBackColor = true;
            // 
            // ShowProcess
            // 
            this.ShowProcess.AutoSize = true;
            this.ShowProcess.Location = new System.Drawing.Point(6, 127);
            this.ShowProcess.Name = "ShowProcess";
            this.ShowProcess.Size = new System.Drawing.Size(58, 21);
            this.ShowProcess.TabIndex = 4;
            this.ShowProcess.Text = "label";
            this.ShowProcess.UseVisualStyleBackColor = true;
            // 
            // AStart
            // 
            this.AStart.AutoSize = true;
            this.AStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AStart.Location = new System.Drawing.Point(6, 101);
            this.AStart.Name = "AStart";
            this.AStart.Size = new System.Drawing.Size(112, 21);
            this.AStart.TabIndex = 3;
            this.AStart.TabStop = true;
            this.AStart.Text = "Thuật toán A*";
            this.AStart.UseVisualStyleBackColor = true;
            // 
            // Dijkstra
            // 
            this.Dijkstra.AutoSize = true;
            this.Dijkstra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Dijkstra.Location = new System.Drawing.Point(6, 74);
            this.Dijkstra.Name = "Dijkstra";
            this.Dijkstra.Size = new System.Drawing.Size(150, 21);
            this.Dijkstra.TabIndex = 2;
            this.Dijkstra.TabStop = true;
            this.Dijkstra.Text = "Dijkstra\'s Algorithm";
            this.Dijkstra.UseVisualStyleBackColor = true;
            // 
            // GreedyFS
            // 
            this.GreedyFS.AutoSize = true;
            this.GreedyFS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GreedyFS.Location = new System.Drawing.Point(6, 46);
            this.GreedyFS.Name = "GreedyFS";
            this.GreedyFS.Size = new System.Drawing.Size(174, 21);
            this.GreedyFS.TabIndex = 1;
            this.GreedyFS.TabStop = true;
            this.GreedyFS.Text = "Greedy Best First Search";
            this.GreedyFS.UseVisualStyleBackColor = true;
            // 
            // BreadthFirstSearch
            // 
            this.BreadthFirstSearch.AutoSize = true;
            this.BreadthFirstSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BreadthFirstSearch.Location = new System.Drawing.Point(6, 19);
            this.BreadthFirstSearch.Name = "BreadthFirstSearch";
            this.BreadthFirstSearch.Size = new System.Drawing.Size(153, 21);
            this.BreadthFirstSearch.TabIndex = 0;
            this.BreadthFirstSearch.TabStop = true;
            this.BreadthFirstSearch.Text = "Breadth First Search ";
            this.BreadthFirstSearch.UseVisualStyleBackColor = true;
            // 
            // DeleteOne
            // 
            this.DeleteOne.BackColor = System.Drawing.Color.White;
            this.DeleteOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteOne.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DeleteOne.Location = new System.Drawing.Point(1169, 587);
            this.DeleteOne.Name = "DeleteOne";
            this.DeleteOne.Size = new System.Drawing.Size(181, 50);
            this.DeleteOne.TabIndex = 9;
            this.DeleteOne.Text = "Xoá chướng ngại vật";
            this.DeleteOne.UseVisualStyleBackColor = false;
            this.DeleteOne.Click += new System.EventHandler(this.DeleteOne_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.BackColor = System.Drawing.Color.Silver;
            this.DeleteAll.Enabled = false;
            this.DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DeleteAll.Location = new System.Drawing.Point(1169, 638);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(181, 50);
            this.DeleteAll.TabIndex = 10;
            this.DeleteAll.Text = "Xoá hết chướng ngại vật";
            this.DeleteAll.UseVisualStyleBackColor = false;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // Moving
            // 
            this.Moving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Moving.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Moving.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Moving.Location = new System.Drawing.Point(1169, 497);
            this.Moving.Name = "Moving";
            this.Moving.Size = new System.Drawing.Size(181, 44);
            this.Moving.TabIndex = 11;
            this.Moving.Text = "Chuyển động";
            this.Moving.UseVisualStyleBackColor = false;
            this.Moving.Click += new System.EventHandler(this.Moving_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.River);
            this.groupBox2.Controls.Add(this.Wall);
            this.groupBox2.Controls.Add(this.Mountain);
            this.groupBox2.Controls.Add(this.Jungle);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(1163, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 69);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn loại vật cản";
            // 
            // River
            // 
            this.River.AutoSize = true;
            this.River.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.River.Location = new System.Drawing.Point(87, 19);
            this.River.Name = "River";
            this.River.Size = new System.Drawing.Size(76, 17);
            this.River.TabIndex = 3;
            this.River.TabStop = true;
            this.River.Text = "Đặt sông";
            this.River.UseVisualStyleBackColor = true;
            // 
            // Wall
            // 
            this.Wall.AutoSize = true;
            this.Wall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Wall.Location = new System.Drawing.Point(87, 42);
            this.Wall.Name = "Wall";
            this.Wall.Size = new System.Drawing.Size(81, 17);
            this.Wall.TabIndex = 2;
            this.Wall.TabStop = true;
            this.Wall.Text = "Đặt tường";
            this.Wall.UseVisualStyleBackColor = true;
            // 
            // Mountain
            // 
            this.Mountain.AutoSize = true;
            this.Mountain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Mountain.Location = new System.Drawing.Point(6, 42);
            this.Mountain.Name = "Mountain";
            this.Mountain.Size = new System.Drawing.Size(66, 17);
            this.Mountain.TabIndex = 1;
            this.Mountain.TabStop = true;
            this.Mountain.Text = "Đặt núi";
            this.Mountain.UseVisualStyleBackColor = true;
            // 
            // Jungle
            // 
            this.Jungle.AutoSize = true;
            this.Jungle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Jungle.Location = new System.Drawing.Point(6, 19);
            this.Jungle.Name = "Jungle";
            this.Jungle.Size = new System.Drawing.Size(74, 17);
            this.Jungle.TabIndex = 0;
            this.Jungle.TabStop = true;
            this.Jungle.Text = "Đặt rừng";
            this.Jungle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1354, 691);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Moving);
            this.Controls.Add(this.DeleteAll);
            this.Controls.Add(this.DeleteOne);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SetObject);
            this.Controls.Add(this.LamMoi);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.EndPoint);
            this.Controls.Add(this.StartPoint);
            this.Controls.Add(this.BanCo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(830, 608);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm đường đi ngắn nhất";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            //this.Move += new System.EventHandler(this.Form1_Move);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.Panel BanCo;
        private System.Windows.Forms.Button StartPoint;
        private System.Windows.Forms.Button EndPoint;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button LamMoi;
        private System.Windows.Forms.Button SetObject;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton BreadthFirstSearch;
        private System.Windows.Forms.RadioButton GreedyFS;
        private System.Windows.Forms.Button DeleteOne;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.Button Moving;
        private System.Windows.Forms.RadioButton Dijkstra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Wall;
        private System.Windows.Forms.RadioButton Mountain;
        private System.Windows.Forms.RadioButton Jungle;
        private System.Windows.Forms.RadioButton River;
        private System.Windows.Forms.RadioButton AStart;
        private System.Windows.Forms.CheckBox ShowProcess;
        private System.Windows.Forms.CheckBox Slow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Time;
    }
}

