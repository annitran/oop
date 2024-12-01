using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLyLoaiHang
	{
        List<LoaiHang> HienThi_DSLH(string tuKhoa = "");
        LoaiHang TimLoaiHang(int maloaihang);

        void ThemLoaiHang(LoaiHang lh);
        void SuaLoaiHang(LoaiHang lh);
        void XoaLoaiHang(int maloaihang);
    }
}

