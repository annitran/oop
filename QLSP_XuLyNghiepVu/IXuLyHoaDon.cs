using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLyHoaDon
	{
        List<HoaDon> HienThi_DSHD(string tukhoa = "");
        HoaDon TimHoaDon(int maloaihang);

        void ThemHoaDon(HoaDon lh);
        void SuaHoaDon(HoaDon lh);
        void XoaHoaDon(int maloaihang);
        int ThongKe_HangTonKho(int mahang);
    }
}

