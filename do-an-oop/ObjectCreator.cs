using QLSP_LuuTru;
using QLSP_XuLyNghiepVu;

namespace do_an_oop
{
	public class ObjectCreator
	{
		public static IXuLySanPham TaoDoiTuongXuLySanPham()
		{
			ILuuTruSanPham ltsp = new LuuTruSanPham();
            return new XuLySanPham(ltsp);
		}

        public static IXuLyLoaiHang TaoDoiTuongXuLyLoaiHang()
        {
            ILuuTruLoaiHang ltlh = new LuuTruLoaiHang();
            return new XuLyLoaiHang(ltlh);
        }

        public static IXuLyHoaDon TaoDoiTuongXuLyHoaDon()
        {
            ILuuTruHoaDon lthd = new LuuTruHoaDon();
            return new XuLyHoaDon(lthd);
        }
    }
}

