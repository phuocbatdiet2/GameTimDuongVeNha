using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
namespace TimDuongDiNganNhat
{
    class Main
    {
        public Point[,] ToaDo;
        public Oco[,] OCo;
        private const int Rong = 15; private const int Cao = 15;
        private int Dong = 45; private int Cot = 77;
        public Main()
        {
            ToaDo = new Point[Dong, Cot];
            OCo = new Oco[Dong, Cot];
        }

        #region Các phương thức nền tảng
        public void KhoiTaoToaDo(Color MauBanCo)
        {
            for (int i = 0; i < this.Dong; i++)
            {
                for (int j = 0; j < this.Cot; j++)
                {
                    ToaDo[i, j] = new Point(j * Rong, i * Cao);
                    OCo[i, j] = new Oco(false, new Point(-1, -1), 1, false, MauBanCo);
                }
            }
        }
        private List<Point> DanhSachHangXom(Point curr) // lập danh sách các ô kề ô hiện tại
        {
            List<Point> Neightbor = new List<Point>();
            int Dong = curr.Y / Cao;
            int Cot = curr.X / Rong;
            // xét phương dọc
            if (Dong + 1 < this.Dong)
            {
                if (!OCo[Dong + 1, Cot].VatCan && !OCo[Dong + 1, Cot].DanhDau)
                    Neightbor.Add(ToaDo[Dong + 1, Cot]);
            }
            if (Dong - 1 >= 0)
            {
                if (!OCo[Dong - 1, Cot].VatCan && !OCo[Dong - 1, Cot].DanhDau)
                    Neightbor.Add(ToaDo[Dong - 1, Cot]);
            }
            // xét phương ngang
            if (Cot + 1 < this.Cot)
            {
                if (!OCo[Dong, Cot + 1].VatCan && !OCo[Dong, Cot + 1].DanhDau)
                    Neightbor.Add(ToaDo[Dong, Cot + 1]);
            }
            if (Cot - 1 >= 0)
            {
                if (!OCo[Dong, Cot - 1].VatCan && !OCo[Dong, Cot - 1].DanhDau)
                    Neightbor.Add(ToaDo[Dong, Cot - 1]);
            }
            // xét phương chéo
            if (Dong + 1 < this.Dong && Cot + 1 < this.Cot)
            {
                if (!OCo[Dong + 1, Cot + 1].VatCan && !OCo[Dong + 1, Cot + 1].DanhDau)
                    Neightbor.Add(ToaDo[Dong + 1, Cot + 1]);
            }
            if (Dong - 1 >= 0 && Cot - 1 >= 0)
            {
                if (!OCo[Dong - 1, Cot - 1].VatCan && !OCo[Dong - 1, Cot - 1].DanhDau)
                    Neightbor.Add(ToaDo[Dong - 1, Cot - 1]);
            }
            if (Cot + 1 < this.Cot && Dong - 1 >= 0)
            {
                if (!OCo[Dong - 1, Cot + 1].VatCan && !OCo[Dong - 1, Cot + 1].DanhDau)
                    Neightbor.Add(ToaDo[Dong - 1, Cot + 1]);
            }
            if (Cot - 1 >= 0 && Dong + 1 < this.Dong)
            {
                if (!OCo[Dong + 1, Cot - 1].VatCan && !OCo[Dong + 1, Cot - 1].DanhDau)
                    Neightbor.Add(ToaDo[Dong + 1, Cot - 1]);
            }
            return Neightbor;
        }
        public void VeOCo(Graphics g, int x, int y, Color color, bool VeOco)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, Rong, Cao);
            if (VeOco) // tham số bool cho biết có cần vẽ lại ô hiện tại không
            {
                // vẽ lại các đường thẳng tại nơi vẽ ô cờ
                g.DrawLine(new Pen(Color.Black), x, y, x, y + Cao);
                g.DrawLine(new Pen(Color.Black), x, y, x + Rong, y);
                // vẽ hai cạnh kề tiếp theo
                g.DrawLine(new Pen(Color.Black), x + Rong, y, x + Rong, y + Cao);
                g.DrawLine(new Pen(Color.Black), x, y + Cao, x+ Rong, y + Cao);
            }
        }
        public void VeLaiOCo(Graphics g, Color MauBanCo)
        {
            for (int i = 0; i < this.Dong; i++)
            {
                for (int j = 0; j < this.Cot; j++)
                {
                    if (OCo[i, j].MauOCo != MauBanCo)
                        VeOCo(g, ToaDo[i, j].X, ToaDo[i, j].Y, OCo[i, j].MauOCo, false);
                }
            }
        }
        public void XoaOCo(Graphics g, Color color, int x, int y)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, Rong, Cao);
        }
        public void VeBanCo(Panel BanCo, Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i <= Dong; i++) // Dòng
            {
                g.DrawLine(pen, 0, i * Cao, Rong * Cot, i * Cao);
            }
            for (int i = 0; i <= Cot; i++) // Cột
            {
                g.DrawLine(pen, i * Rong, 0, i * Rong, Cao * Dong);
            }
        }
        #endregion

        #region Các thuật toán tìm kiếm
        public bool BreathFirstSearch(Point start, Point end, Graphics g, Panel BanCo, Color color, bool HienThi /*có hiển thị quá trình quét hay không*/,
        bool QuayCham /*làm chậm tốc độ tìm đường để quan sát*/, bool OneObject /*tham số bool cho biết có một hay nhiều mục tiêu*/)
        {
            Queue queue = new Queue(); // sử dụng hàng đợi thường xuyên
            Point point = new Point(0, 0);            
            queue.Enqueue(ToaDo[start.Y / Cao, start.X / Rong]);

            while (true)
            {
                if (queue.Count > 0)
                    point = (Point)queue.Dequeue();
                int Dong = point.Y / Cao;
                int Cot = point.X / Rong;
                // vẽ phương dọc
                OCo[Dong, Cot].DanhDau = true;
                foreach (Point Neight in DanhSachHangXom(ToaDo[Dong, Cot]))
                {
                    int Row = Neight.Y / Cao; int Column = Neight.X / Rong;
                    OCo[Row, Column].ChiPhi += OCo[Dong, Cot].ChiPhi;
                    OCo[Row, Column].Goc = ToaDo[Dong, Cot];
                    OCo[Row, Column].DanhDau = true;
                    if (Neight == end && OneObject)
                    {
                        VeDuongDi(point, start, QuayCham, BanCo, g);
                        return true;
                    }
                    if (HienThi)
                        VeOCo(g, ToaDo[Row, Column].X, ToaDo[Row, Column].Y, color, HienThi);
                    queue.Enqueue(ToaDo[Row, Column]); // thêm ô này vào hàng đợi
                }

                // nếu hàng đợi rỗng thì việc tìm kiếm thất bại
                if (queue.Count == 0)
                {
                    if (!OneObject) return true;
                    MessageBox.Show("Không tìm thấy đường đi đến điểm kết thúc!!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        public bool GreedyBestFirstSearch(Point start, Point end, Graphics g, Panel BanCo, Color color, bool HienThi /*có hiển thị quá trình quét hay không*/,
        bool QuayCham /*làm chậm tốc độ tìm đường để quan sát*/)
        {
            var HangDoi = new PriorityQueue<Point>(); // sử dụng hàng đợi ưu tiên
            Point point = new Point(0, 0);
            double Distance_Start = HamDanhGia(ToaDo[start.Y / Cao, start.X / Rong], end);
            HangDoi.Enqueue(ToaDo[start.Y / Cao, start.X / Rong], Distance_Start);

            while (true)
            {
                //===============================================================
                if (HangDoi.Count > 0)
                    point = (Point)HangDoi.Dequeue();
                int Dong = point.Y / Cao;
                int Cot = point.X / Rong;
                // vẽ phương dọc
                OCo[Dong, Cot].DanhDau = true;
                foreach (Point Neight in DanhSachHangXom(ToaDo[Dong, Cot]))
                {
                    int Row = Neight.Y / Cao; int Column = Neight.X / Rong;
                    OCo[Row, Column].Goc = ToaDo[Dong, Cot];
                    OCo[Row, Column].ChiPhi += OCo[Dong, Cot].ChiPhi;
                    OCo[Row, Column].DanhDau = true;
                    if (Neight == end)
                    {
                        VeDuongDi(point, start, QuayCham, BanCo, g);
                        return true;
                    }
                    if (HienThi)
                        VeOCo(g, ToaDo[Row, Column].X, ToaDo[Row, Column].Y, color, HienThi);
                    HangDoi.Enqueue(ToaDo[Row, Column], HamDanhGia(ToaDo[Row, Column], end)); // thêm ô này vào hàng đợi
                }

                // nếu hàng đợi rỗng thì việc tìm kiếm thất bại
                if (HangDoi.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đường đi đến điểm kết thúc!!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private double HamDanhGia(Point current, Point end) // hàm đánh giá khoảng cách
        {
            //return Math.Sqrt(Math.Pow(end.X - current.X, 2) + Math.Pow(end.Y - current.Y, 2));
            //return Math.Abs(end.X - current.X) + Math.Abs(end.Y - current.Y);
            double dx = Math.Abs(end.X - current.X);
            double dy = Math.Abs(end.Y - current.Y);
            return Math.Min(dx, dy);
        }

        public bool ThuatToanDijkstra(Point start, Point end, Graphics g, Panel BanCo, Color color, bool HienThi /*có hiển thị quá trình quét hay không*/,
        bool QuayCham /*làm chậm tốc độ tìm đường để quan sát*/, bool OneObject /*tham số bool cho biết có một hay nhiều mục tiêu*/)
        {
            var HangDoi = new PriorityQueue<Point>(); // sử dụng hàng đợi ưu tiên
            Point point = new Point(0, 0);
            HangDoi.Enqueue(start, OCo[start.Y / Cao, start.X / Rong].ChiPhi);

            while (true)
            {
                if (HangDoi.Count > 0)
                    point = HangDoi.Dequeue();
                int Dong = point.Y / Cao;
                int Cot = point.X / Rong;
                // vẽ phương dọc
                OCo[Dong, Cot].DanhDau = true;
                foreach (Point Neight in DanhSachHangXom(ToaDo[Dong, Cot]))
                {
                    int Row = Neight.Y / Cao; int Column = Neight.X / Rong;
                    OCo[Row, Column].Goc = ToaDo[Dong, Cot];
                    OCo[Row, Column].ChiPhi += OCo[Dong, Cot].ChiPhi;
                    OCo[Row, Column].DanhDau = true;
                    if (Neight == end && OneObject)
                    {
                        VeDuongDi(point, start, QuayCham, BanCo, g);
                        return true;
                    }
                    if (HienThi)
                        VeOCo(g, ToaDo[Row, Column].X, ToaDo[Row, Column].Y, color, HienThi);
                    HangDoi.Enqueue(ToaDo[Row, Column], OCo[Row, Column].ChiPhi); // thêm ô này vào hàng đợi
                }

                // nếu hàng đợi rỗng thì việc tìm kiếm thất bại
                if (HangDoi.Count == 0)
                {
                    if (!OneObject) return true;
                    MessageBox.Show("Không tìm thấy đường đi đến điểm kết thúc!!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        public bool ThuatToanAStart(Point start, Point end, Graphics g, Panel BanCo, Color color, bool HienThi /*có hiển thị quá trình quét hay không*/,
        bool QuayCham /*làm chậm tốc độ tìm đường để quan sát*/)
        {
            var HangDoi = new PriorityQueue<Point>(); // sử dụng hàng đợi ưu tiên
            Point point = new Point(0, 0);
            HangDoi.Enqueue(ToaDo[start.Y / Cao, start.X / Rong], HamDanhGia(ToaDo[start.Y / Cao, start.X / Rong], end));

            while (true)
            {
                //===============================================================
                if (HangDoi.Count > 0)
                    point = (Point)HangDoi.Dequeue();
                int Dong = point.Y / Cao;
                int Cot = point.X / Rong;
                // vẽ phương dọc
                OCo[Dong, Cot].DanhDau = true;
                foreach (Point Neight in DanhSachHangXom(ToaDo[Dong, Cot]))
                {
                    int Row = Neight.Y / Cao; int Column = Neight.X / Rong;
                    OCo[Row, Column].Goc = ToaDo[Dong, Cot];
                    OCo[Row, Column].ChiPhi += OCo[Dong, Cot].ChiPhi;
                    OCo[Row, Column].DanhDau = true;
                    if (Neight == end)
                    {
                        VeDuongDi(point, start, QuayCham, BanCo, g);
                        return true;
                    }
                    if (HienThi)
                        VeOCo(g, ToaDo[Row, Column].X, ToaDo[Row, Column].Y, color, HienThi);
                    HangDoi.Enqueue(ToaDo[Row, Column], OCo[Row, Column].ChiPhi + HamDanhGia(ToaDo[Row, Column], end)); // thêm ô này vào hàng đợi
                }

                // nếu hàng đợi rỗng thì việc tìm kiếm thất bại
                if (HangDoi.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đường đi đến điểm kết thúc!!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }
        /// <summary>
        /// Hàm vẽ đường đi cho vật thể
        /// </summary>
        public bool VeDuongDi(Point point, Point start, bool QuayCham, Panel BanCo, Graphics g)
        {
            Color MauDuongDi = Color.White; // màu để vẽ đường đi
            if (ToaDo[point.Y / Cao, point.X / Rong] != start)
            {
                if (OCo[point.Y / Cao, point.X / Rong].Goc != new Point(-1, -1)) // nếu ô hiện tại có "gốc" thì mới xét
                {                    
                    if (OCo[point.Y / Cao, point.X / Rong].MauOCo == BanCo.BackColor)
                    {
                        VeOCo(g, ToaDo[point.Y / Cao, point.X / Rong].X, ToaDo[point.Y / Cao, point.X / Rong].Y, MauDuongDi, QuayCham);
                        OCo[point.Y / Cao, point.X / Rong].MauOCo = MauDuongDi;
                    }
                    // vẽ màu khác khi gặp vật cản (có thể qua)
                    else if (OCo[point.Y / Cao, point.X / Rong].MauOCo != MauDuongDi && OCo[point.Y / Cao, point.X / Rong].MauOCo != Color.DarkOrange /*màu của vật thể*/)
                    {
                        VeOCo(g, ToaDo[point.Y / Cao, point.X / Rong].X, ToaDo[point.Y / Cao, point.X / Rong].Y, Color.Blue, QuayCham);
                        OCo[point.Y / Cao, point.X / Rong].MauOCo = Color.Blue;
                    }
                    point = OCo[point.Y / Cao, point.X / Rong].Goc;
                    if (QuayCham) Thread.Sleep(60);
                    // dùng thuật toán đệ quy để vẽ đường đi
                    if (VeDuongDi(point, start, QuayCham, BanCo, g))
                        return true;
                }
                else
                    return false;
            }
            else
            {
                if (!QuayCham) VeBanCo(BanCo, g);
                return true;
            }
            return false;
        }
        #endregion        
    }

    class PriorityQueue<KieuGiaTri> // hàng đợi ưu tiên
    {
         private List<Tuple<KieuGiaTri, double>> DanhSach = new List<Tuple<KieuGiaTri, double>>();

         public int Count
         {
             get { return DanhSach.Count; }
         }

         public void Enqueue(KieuGiaTri item, double UuTien)
         {
            DanhSach.Add(Tuple.Create(item, UuTien));
         }

         public KieuGiaTri Dequeue()
         {
            int bestIndex = 0;

            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (DanhSach[i].Item2 < DanhSach[bestIndex].Item2)
                    bestIndex = i;
            }
            KieuGiaTri bestItem = DanhSach[bestIndex].Item1;
            DanhSach.RemoveAt(bestIndex);
            return bestItem;
         }
    }
}
