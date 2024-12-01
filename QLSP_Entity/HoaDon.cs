namespace QLSP_Entity
{
	public class HoaDon
	{
        public int SoHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public string LoaiHoaDon { get; set; }
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }

        public HoaDon(int sohoadon, DateTime ngayhoadon, string loaihoadon, int mahang, string tenhang, int soluong)
        {
            if (sohoadon <= 0)
            {
                throw new Exception("Số hoá đơn không hợp lệ! Mời nhập lại!");
            }

            if (ngayhoadon == DateTime.MinValue)
            {
                throw new Exception("Ngày hoá đơn không hợp lệ! Mời nhập lại!");
            }

            if (string.IsNullOrEmpty(loaihoadon))
            {
                throw new Exception("Loại hoá đơn không hợp lệ! Mời nhập lại!");
            }

            if (soluong <= 0)
            {
                throw new Exception("Số lượng không hợp lệ! Mời nhập lại!");
            }

            this.SoHoaDon = sohoadon;
            this.NgayHoaDon = ngayhoadon;
            this.LoaiHoaDon = loaihoadon;
            this.MaHang = mahang;
            this.TenHang = tenhang;
            this.SoLuong = soluong;
        }
    }
}

