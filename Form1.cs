using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace TimDuongDiNganNhat
{
    public partial class Form1 : Form
    {
        #region Các biến sẽ sử dụng
        private Point StartPos;
        private List<Point> DanhSachVatCan;
        private List<Point> ArrayEndPos;
        private Graphics grs;
        private Main main;
        private Color MauBanCo;
        private Form2 form2;
        #endregion
        public Form1()
        {
            InitializeComponent();
            main = new Main();
            form2 = new Form2();
            grs = BanCo.CreateGraphics();
            ArrayEndPos = new List<Point>();
            DanhSachVatCan = new List<Point>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowProcess.Text = "Hiển thị quá trình tìm\n đường";
            Slow.Text = "Làm chậm quá trình vẽ\n đường đi";
            Jungle.Checked = BreadthFirstSearch.Checked = true;
            MauBanCo = BanCo.BackColor = Color.LightPink;
            main.KhoiTaoToaDo(MauBanCo);
        }
        private const int Rong = 15; private const int Cao = 15;
        private int Dong = 45; private int Cot = 77;
        private void BanCo_Paint(object sender, PaintEventArgs e)
        {
            main.VeLaiOCo(grs, MauBanCo);
            main.VeBanCo(BanCo, grs);
        }

        private bool MouseDowning = false;
        private bool MovePosObject = false;
        private void BanCo_MouseDown(object sender, MouseEventArgs e)
        {
            Color StartColor = Color.Red;
            Color EndColor = Color.DarkOrange;
            int Dong = e.Y / Cao; int Cot = e.X / Rong;
            // xử lí sự kiện nhấn và giữ chuột để đặt vật cản hoặc các điểm kết thúc
            if (e.Button == MouseButtons.Left)
                MouseDowning = true;
            else if(e.Button == MouseButtons.Right) // nhấn chuột phải để đổi vị trí của vật thể
            {
                MouseDowning = true;
                if(main.ToaDo[Dong, Cot] == StartPos || MovePosObject)
                {
                    MovePosObject = true;
                    // xoá ô hiện tại
                    int Row = StartPos.Y / Cao; int Column = StartPos.X / Rong;
                    main.VeOCo(grs, main.ToaDo[Row, Column].X, main.ToaDo[Row, Column].Y, MauBanCo, true);
                    main.OCo[Row, Column].MauOCo = MauBanCo;
                    main.OCo[Row, Column].DanhDau = false;
                    // vẽ ô chuột di chuyển tới
                    StartPos = main.ToaDo[Dong, Cot];
                    main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, StartColor, true);
                    main.OCo[Dong, Cot].MauOCo = StartColor;
                    main.OCo[Dong, Cot].DanhDau = true;         
                }
                else if(ArrayEndPos.IndexOf(main.ToaDo[Dong, Cot]) != -1 || MovePosObject)
                {
                    MovePosObject = true;
                    int Row = main.ToaDo[Dong, Cot].Y / Cao; int Column = main.ToaDo[Dong, Cot].X / Rong;
                    // xoá ô hiện tại
                    main.VeOCo(grs, main.ToaDo[Row, Column].X, main.ToaDo[Row, Column].Y, MauBanCo, true);
                    main.OCo[Row, Column].MauOCo = MauBanCo;
                    ArrayEndPos.RemoveAt(ArrayEndPos.IndexOf(main.ToaDo[Row, Column]));
                    // vẽ ô chuột di chuyển tới
                    main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, EndColor, true);
                    main.OCo[Dong, Cot].MauOCo = EndColor;
                    ArrayEndPos.Add(main.ToaDo[Dong, Cot]);
                }
                return;
            }
            else
                return;
            
            // nếu vị trí nhấn chuột vượt quá khỏi bàn cờ thì thoát ra
            if ((Dong >= this.Dong || Cot >= this.Cot) || (Dong < 0 || Cot < 0))
                return;
            if (Start) // nếu người chơi chọn điểm bắt đầu thì xử lý khác
            {
                StartandEnd++;
                StartPos = main.ToaDo[Dong, Cot];
                main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, StartColor, true);
                main.OCo[Dong, Cot].MauOCo = StartColor;
                main.OCo[Dong, Cot].DanhDau = true; // đánh dấu ô tại điểm bắt đầu, không đánh dấu điểm kết thúc để dễ xử lí
                Start = false;
                return;
            }
            if (End) // nếu người chơi chọn điểm kết thúc thì xử lý khác
            {
                StartandEnd++;
                if ((form2.OneObject || form2.Automatic) && ArrayEndPos.Count == 1)
                    return;
                ArrayEndPos.Add(main.ToaDo[Dong, Cot]);
                main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, EndColor, true);
                main.OCo[Dong, Cot].MauOCo = EndColor;
                return;
            }
            if (DelOne && !SetObject_Clicked)
            {
                if (main.ToaDo[Dong, Cot] != StartPos && ArrayEndPos.IndexOf(main.ToaDo[Dong, Cot]) == -1)
                {
                    if (main.OCo[Dong, Cot].MauOCo != MauBanCo)
                    {
                        main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, MauBanCo, true);
                        main.OCo[Dong, Cot].VatCan = false;
                        main.OCo[Dong, Cot].MauOCo = MauBanCo;
                    }
                }
                return;
            }
            if (SetObject_Clicked && !DelOne)
            {
                // nếu vị trí đặt vật cản trùng với các điểm đã đặt khác thì không cho phép
                if (main.OCo[Dong, Cot].MauOCo != MauBanCo && main.OCo[Dong, Cot].MauOCo != Color.White)
                    return;

                if (Jungle.Checked)
                {
                    main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, Color.LawnGreen, true);
                    main.OCo[Dong, Cot].ChiPhi = 10;
                    main.OCo[Dong, Cot].MauOCo = Color.LawnGreen;
                }
                else if (Mountain.Checked)
                {
                    main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, Color.Brown, true);
                    main.OCo[Dong, Cot].ChiPhi = 20;
                    main.OCo[Dong, Cot].MauOCo = Color.Brown;
                }
                else if (River.Checked)
                {
                    main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, Color.Aqua, true);
                    main.OCo[Dong, Cot].ChiPhi = 15;
                    main.OCo[Dong, Cot].MauOCo = Color.Aqua;
                }
                else if (Wall.Checked)
                {
                    main.OCo[Dong, Cot].VatCan = true;                    
                    main.VeOCo(grs, main.ToaDo[Dong, Cot].X, main.ToaDo[Dong, Cot].Y, Color.SlateGray, true);
                    main.OCo[Dong, Cot].ChiPhi = 99999999999999;
                    main.OCo[Dong, Cot].MauOCo = Color.SlateGray;
                    DanhSachVatCan.Add(main.ToaDo[Dong, Cot]);
                }
            }
        }

        private void BanCo_MouseUp(object sender, MouseEventArgs e)
        {
            if (ObjectMoving && MouseDowning && (SetObject_Clicked || DelOne)) // nếu các vật đang di chuyển và người dùng đặt thêm vật cản thì cập nhật lại đường đi
            {
                main.KhoiTaoToaDo(MauBanCo);
                foreach (Point k in DanhSachVatCan)
                    main.OCo[k.Y / Cao, k.X / Rong].VatCan = true;
                if (!form2.OneObject)
                {
                    if (BreadthFirstSearch.Checked)
                    {
                        if (!main.BreathFirstSearch(StartPos, ArrayEndPos[0], grs, BanCo, Color.LightGreen, false, false, form2.OneObject))
                            return;
                    }
                    else if (Dijkstra.Checked)
                    {
                        if (!main.ThuatToanDijkstra(StartPos, ArrayEndPos[0], grs, BanCo, Color.LightGreen, false, false, form2.OneObject))
                            return;
                    }
                }
                else
                {
                    if (GreedyFS.Checked)
                    {
                        if (!main.GreedyBestFirstSearch(StartPos, ArrayEndPos[0], grs, BanCo, Color.LightGreen, false, false))
                            return;
                    }
                    else if (AStart.Checked)
                    {
                        if (!main.ThuatToanAStart(StartPos, ArrayEndPos[0], grs, BanCo, Color.LightGreen, false, false))
                            return;
                    }
                }
            }
            MouseDowning = false;
        }

        private void BanCo_MouseMove(object sender, MouseEventArgs e)
        {
            int Dong = e.Y / Cao; int Cot = e.X / Rong;
            // nếu vị trí con trỏ chuột trùng với các điểm đầu và điểm đích, hoặc vượt giới hạn bàn thì thoát ra
            if ((Dong >= this.Dong || Cot >= this.Cot) || (Dong < 0 || Cot < 0))
                return;
            if (Dong == StartPos.Y / Cao && Cot == StartPos.X / Rong)
                return;
            else if (ArrayEndPos.IndexOf(main.ToaDo[Dong, Cot]) != -1)
                return;
            // vẽ ô cờ
            if (MouseDowning)
                BanCo_MouseDown(sender, e);
        }

        private bool Start = false;
        private void StartPoint_Click(object sender, EventArgs e)
        {
            Start = true;
            StartPoint.Enabled = false;
        }
        private bool End = false;
        private void EndPoint_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
            End = true;
            EndPoint.Enabled = false;
        }

        #region Tìm kiếm bằng thuật toán
        private int StartandEnd = 0;
        private void Search_Click(object sender, EventArgs e)
        {
            Thread TimKiem = new Thread(ThreadSearch); // đưa thuật toán tìm kiếm vào tiểu trình riêng            
            this.TinhThoiGian = new Stopwatch(); // tạo mới đồng hồ bấm giờ
            Start = End = false;
            MovePosObject = false;
            if (StartandEnd >= 2)
            {
                DeleteAll.Enabled = true;
                TimKiem.IsBackground = true;
                TimKiem.Start();
                StartandEnd = 0;               
            }
            else
                MessageBox.Show("Vui lòng chọn điểm bắt đầu và kết thúc!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetObject_Clicked = DelOne = false;
        }
        private void ThreadSearch() // thuật toán tìm kiếm được đưa vào luồng khác
        {
            TimerCallback TimerCall = new TimerCallback(ThoiGian);
            //Stopwatch d = new Stopwatch();
            System.Threading.Timer timer = new System.Threading.Timer(TimerCall, null, 0, 1);
            //d.Start();
            if (BreadthFirstSearch.Checked)
            {
                if (!main.BreathFirstSearch(StartPos, ArrayEndPos[0], grs, BanCo, Color.LightGreen, ShowProcess.Checked, Slow.Checked, form2.OneObject || form2.Automatic))
                {
                    TinhThoiGian.Stop();
                    timer.Dispose();
                    return;
                }
            }
            else if (GreedyFS.Checked)
            {
                if (!main.GreedyBestFirstSearch(StartPos, ArrayEndPos[0], grs, BanCo, Color.Violet, ShowProcess.Checked, Slow.Checked))
                {
                    TinhThoiGian.Stop();
                    timer.Dispose();
                    return;
                }
            }
            else if (Dijkstra.Checked)
            {
                if (!main.ThuatToanDijkstra(StartPos, ArrayEndPos[0], grs, BanCo, Color.BurlyWood, ShowProcess.Checked, Slow.Checked, form2.OneObject || form2.Automatic))
                {
                    TinhThoiGian.Stop();
                    timer.Dispose();
                    return;
                }
            }
            else if (AStart.Checked)
            {
                if (!main.ThuatToanAStart(StartPos, ArrayEndPos[0], grs, BanCo, Color.Chartreuse, ShowProcess.Checked, Slow.Checked))
                {
                    TinhThoiGian.Stop();
                    timer.Dispose();
                    return;
                }
            }
            // vẽ đường đi cho nhiều mục tiêu
            if (!form2.OneObject && form2.ThuCong)
            {
                foreach (Point point in ArrayEndPos)
                {
                    Point Temp = main.OCo[point.Y / Cao, point.X / Rong].Goc; // lấy gốc của ô hiện tại để vẽ
                    main.VeDuongDi(Temp, StartPos, Slow.Checked, BanCo, grs);
                }
            }
            TinhThoiGian.Stop();
            timer.Dispose();
            //d.Stop();
            //MessageBox.Show(d.Elapsed.Milliseconds.ToString());
            if (form2.OneObject)
                MessageBox.Show("Chi phí tìm đường: " + main.OCo[ArrayEndPos[0].Y / Cao, ArrayEndPos[0].X / Rong].ChiPhi.ToString());              
        }

        private Stopwatch TinhThoiGian; // tạo đồng hồ bấm giờ
        /// <summary>
        /// Tính thời gian tìm kiếm cho thuật toán
        /// </summary>
        private void ThoiGian(object sender)
        {            
            if(!TinhThoiGian.IsRunning)
                TinhThoiGian.Start();            
            if (TinhThoiGian.Elapsed.Milliseconds < 10)
                Invoke(new Action(() => Time.Text = string.Format("{0}.00{1}", TinhThoiGian.Elapsed.Seconds, TinhThoiGian.Elapsed.Milliseconds) + " s"));
            else if (TinhThoiGian.Elapsed.Milliseconds < 100)
                Invoke(new Action(() => Time.Text = string.Format("{0}.0{1}", TinhThoiGian.Elapsed.Seconds, TinhThoiGian.Elapsed.Milliseconds) + " s"));
            else
                Invoke(new Action(() => Time.Text = string.Format("{0}.{1}", TinhThoiGian.Elapsed.Seconds, TinhThoiGian.Elapsed.Milliseconds) + " s"));
        }
        #endregion

        private void LamMoi_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            StartandEnd = 0;
            StartPoint.Enabled = EndPoint.Enabled = Moving.Enabled = true;
            StartPos = new Point(0, 0);
            ArrayEndPos.Clear();
            ObjectMoving = DeleteAll.Enabled = MovePosObject = false;
            StartandEnd = 0;
            main.KhoiTaoToaDo(MauBanCo);
            BanCo.Refresh();
        }

        private bool SetObject_Clicked = false;
        private void SetObject_Click(object sender, EventArgs e)
        {
            SetObject_Clicked = true;
            DelOne = Start = End = false;
        }

        #region Chuyển động của vật thể
        private void ChuyenDong() // xử lí chuyển động của vật
        {
            for (int t = 0; form2.Automatic ? t < form2.Soluong : t < ArrayEndPos.Count; t++)
            {
                Thread MovingObject = new Thread(VatDiChuyen);
                MovingObject.IsBackground = true;
                if (form2.ThuCong)
                    MovingObject.Start(ArrayEndPos[t]);
                else if (form2.Automatic || form2.OneObject)
                    MovingObject.Start(ArrayEndPos[0]); // từ một điểm duy nhất sẽ tạo ra nhiều vật thể với số lượng người dùng đặt
                Thread.Sleep(200);
            }
        }

        private int Number = 0; // số lượng vật thể đã đến đích
        private int NumberStop = 0; // số lượng vật thể không thể đến đích
        private void VatDiChuyen(object ViTriVatThe) // hàm vẽ và xoá vị trí tiếp theo và hiện tại, tạo hiệu ứng chuyển động
        {
            Point point = (Point)ViTriVatThe;
            Graphics gra = BanCo.CreateGraphics();
            while (true)
            {
                int Row = point.Y / Cao;
                int Column = point.X / Rong;
                if (MouseDowning && (SetObject_Clicked || DelOne)) // nếu người dùng đang đặt vật cản thì tạm dừng vật di chuyển...
                {
                    Thread.Sleep(500); // ...trong nửa giây
                    continue;
                }
                else
                {
                    if (main.ToaDo[Row, Column] == StartPos)
                    {
                        Number++;
                        main.OCo[Row, Column].MauOCo = MauBanCo;
                        // tổng số lượng vật thể đã đến đích và không thể đến đích sẽ bằng số lượng vật thể người dùng đặt
                        if (Number + NumberStop == (form2.Automatic ? form2.Soluong : ArrayEndPos.Count))
                        {
                            Invoke(new Action(() => LamMoi.Enabled = GreedyFS.Enabled = AStart.Enabled = true)); // gọi hàm dẫn control
                            MessageBox.Show("Có " + Number.ToString() + " vật đã đến đích!!", "Đến đích", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Number = NumberStop = 0; // reset lại giá trị
                            return;
                        }
                        return;
                    }

                    if (main.OCo[main.OCo[Row, Column].Goc.Y / Cao, main.OCo[Row, Column].Goc.X / Rong].MauOCo != Color.DarkOrange)
                    {
                        if (main.OCo[Row, Column].Goc != new Point(-1, -1))
                        {
                            // xoá ô hiện tại
                            main.VeOCo(gra, main.ToaDo[Row, Column].X, main.ToaDo[Row, Column].Y, MauBanCo, true);
                            main.OCo[Row, Column].MauOCo = MauBanCo;
                            // vẽ ô tiếp theo dựa vào gốc của ô cờ
                            main.VeOCo(gra, main.OCo[Row, Column].Goc.X, main.OCo[Row, Column].Goc.Y, Color.DarkOrange, true);
                            point = main.OCo[Row, Column].Goc;
                            main.OCo[point.Y / Cao, point.X / Rong].MauOCo = Color.DarkOrange;
                            Thread.Sleep(100);
                        }
                        else // trường hợp vật không tìm thấy đường đi đến đích thì thoát ra...
                        {
                            NumberStop++; // ... và tăng biến NumberStop lến 1 đơn vị
                            return;
                        }
                    }
                    else if (main.OCo[main.OCo[Row, Column].Goc.Y / Cao, main.OCo[Row, Column].Goc.X / Rong].MauOCo == Color.DarkOrange)
                        Thread.Sleep(200);
                }
            }
        }

        private bool ObjectMoving = false;
        private Thread NewThread;
        private void Moving_Click(object sender, EventArgs e)
        {
            if (!form2.OneObject) // xoá đường đi của các vật để dễ nhìn
            {
                for (int i = 0; i < this.Dong; i++)
                {
                    for (int j = 0; j < this.Cot; j++)
                    {
                        if (main.OCo[i, j].MauOCo == Color.White)
                            main.VeOCo(grs, main.ToaDo[i, j].X, main.ToaDo[i, j].Y, MauBanCo, false);
                    }
                }
                main.VeBanCo(BanCo, grs);
            }
            LamMoi.Enabled = GreedyFS.Enabled = AStart.Enabled = false; // tắt các thành phần không được sử dụng trong khi vật thể chuyển động        
            ObjectMoving = true;
            NewThread = new Thread(ChuyenDong);
            NewThread.Start();
        }
        #endregion

        private bool DelOne = false;
        private void DeleteOne_Click(object sender, EventArgs e)
        {
            DelOne = true;
            SetObject_Clicked = Start = End = false;
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            StartandEnd = 2;
            main = new Main();
            main.KhoiTaoToaDo(MauBanCo);
            BanCo.Refresh();
            // vẽ lại vị trí của các điểm
            main.VeOCo(grs, main.ToaDo[StartPos.Y / Cao, StartPos.X / Rong].X, main.ToaDo[StartPos.Y / Cao, StartPos.X / Rong].Y, Color.Red, true);
            main.OCo[StartPos.Y / Cao, StartPos.X / Rong].MauOCo = Color.Red;
            main.VeOCo(grs, main.ToaDo[ArrayEndPos[0].Y / Cao, ArrayEndPos[0].X / Rong].X, main.ToaDo[ArrayEndPos[0].Y / Cao, ArrayEndPos[0].X / Rong].Y, 
                Color.DarkOrange, true);
            main.OCo[ArrayEndPos[0].Y / Cao, ArrayEndPos[0].X / Rong].MauOCo = Color.DarkOrange;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
