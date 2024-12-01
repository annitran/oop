namespace QLSP_Entity
{
    public class SanPham
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }
        public string CtySX { get; set; }
        public string LoaiHang { get; set; }
        public int Gia { get; set; }
        public int SoLuongHangTonKho { get; set; }

        public SanPham(int mahang, string tenhang, DateTime nsx, DateTime hsd, string ctysx, string loaihang, int gia)
        {
            if (mahang <= 0)
            {
                throw new Exception("Mã sản phẩm không hợp lệ! Mời nhập lại!");
            }

            if (string.IsNullOrEmpty(tenhang))
            {
                throw new Exception("Tên sản phẩm không hợp lệ! Mời nhập lại!");
            }

            if (nsx == DateTime.MinValue)
            {
                throw new Exception("Ngày sản xuất không hợp lệ! Mời nhập lại!");
            }

            if (hsd == DateTime.MinValue)
            {
                throw new Exception("Hạn sử dụng không hợp lệ! Mời nhập lại!");
            }

            if (string.IsNullOrEmpty(ctysx))
            {
                throw new Exception("Tên công ty sản xuất không hợp lệ! Mời nhập lại!");
            }

            if (string.IsNullOrEmpty(loaihang))
            {
                throw new Exception("Loại hàng không hợp lệ! Mời nhập lại!");
            }

            if (gia <= 0)
            {
                throw new Exception("Giá sản phẩm không hợp lệ! Mời nhập lại!");
            }

            this.MaHang = mahang;
            this.TenHang = tenhang;
            this.NSX = nsx;
            this.HSD = hsd;
            this.CtySX = ctysx;
            this.LoaiHang = loaihang;
            this.Gia = gia;
        }
    }
}