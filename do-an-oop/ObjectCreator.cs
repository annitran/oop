using QLSP_Entity;
using QLSP_LuuTru;
using QLSP_XuLyNghiepVu;

namespace do_an_oop
{
	public class ObjectCreator
	{
		public static IXuLyNghiepVu<SanPham> TaoDoiTuongXuLySanPham()
		{
			IXuLyLuuTru<SanPham> ltsp = new LuuTruSanPham();
            return new XuLySanPham(ltsp);
		}

        public static IXuLyNghiepVu<LoaiHang> TaoDoiTuongXuLyLoaiHang()
        {
            IXuLyLuuTru<LoaiHang> ltlh = new LuuTruLoaiHang();
            return new XuLyLoaiHang(ltlh);
        }

        public static IXuLyNghiepVu<HoaDon> TaoDoiTuongXuLyHoaDon()
        {
            IXuLyLuuTru<HoaDon> lthd = new LuuTruHoaDon();
            return new XuLyHoaDon(lthd);
        }
    }
}

