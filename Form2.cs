using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimDuongDiNganNhat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private bool _OneObject; // biến bool cho biết người dùng chọn 1 hay nhiều vật thể được đặt
        public bool OneObject
        {
            get { return _OneObject; }
        }
        private bool _Automatic = false;
        public bool Automatic
        {
            get { return _Automatic; }
        }
        private bool _ThuCong = false;
        public bool ThuCong
        {
            get { return _ThuCong; }
        }
        private decimal _Soluong;
        public decimal Soluong
        {
            get { return _Soluong; }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (One.Checked)
                _OneObject = true;
            else if (Many.Checked)
            {
                if (Manual.Checked)
                    _ThuCong = true;
                else if (Auto.Checked)
                {
                    _Automatic = true;
                    if (Number.Value == 0)
                    {
                        MessageBox.Show("Vui lòng chọn số lượng vật thể!!", "Chọn số lượng vật thể", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                        return;
                    }
                    _Soluong = Number.Value;
                }
                _OneObject = false;
            }
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            OK.Focus();
        }

        private void Many_CheckedChanged(object sender, EventArgs e)
        {
            if (Many.Checked)
            {
                Auto.Checked = true;
                this.MinimumSize = this.MaximumSize = new Size(this.Width, this.Height + 70);
                this.Size = new Size(this.Width, this.Height + 70);
                groupBox1.Visible = Auto.Visible = Manual.Visible = true;
                OK.Location = new Point(197, 158);
            }
            else
            {
                this.MinimumSize = this.MaximumSize = new Size(this.Width, this.Height - 70);
                this.Size = new Size(this.Width, this.Height - 70);
                groupBox1.Visible = Auto.Visible = Manual.Visible = false;
                OK.Location = new Point(197, 88);
            }
            OK.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.MaximumSize = new Size(this.Width, this.Height - 70);
            this.Size = new Size(this.Width, this.Height - 70);
            OK.Location = new Point(197, 88);
        }

        private void Auto_CheckedChanged(object sender, EventArgs e)
        {
            if (Auto.Checked) Number.Enabled = true;
            else Number.Enabled = false;
            OK.Focus();
        }
    }
}
