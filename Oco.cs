using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TimDuongDiNganNhat
{
    class Oco
    {
        private bool _DanhDau;
        public bool DanhDau
        {
            set { _DanhDau = value; }
            get { return _DanhDau; }
        }

        private Point _Goc; // thuộc tính này cho phép xác định gốc của ô hiện tại (gốc mà từ đó mở rộng được ra ô hiện tại)
        public Point Goc
        {
            set { _Goc = value; }
            get { return _Goc; }
        }

        private long _ChiPhi; // chi phí hay giá trị của mỗi ô, ô trống sẽ có giá trị bằng 1, ô có vật cản chi phí lớn hơn giá trị này
        public long ChiPhi
        {
            set { _ChiPhi = value; }
            get { return _ChiPhi; }
        }

        private bool _VatCan;
        public bool VatCan
        {
            set { _VatCan = value; }
            get { return _VatCan; }
        }

        private Color _MauOCo;
        public Color MauOCo
        {
            get { return _MauOCo; }
            set { _MauOCo = value; }
        }

        public Oco(bool danhdau, Point goc, long chiphi, bool vatcan, Color mauoco)
        {
            _DanhDau = danhdau;
            _Goc = goc;
            _ChiPhi = chiphi;
            _VatCan = vatcan;
            _MauOCo = mauoco;
        }
    }
}
