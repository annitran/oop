using QLSP_Entity;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLySanPham
	{
        List<SanPham> HienThi_DSSP(string tuKhoa = "");
        SanPham TimSanPhamTheoID(int mahang);

        void ThemSanPham(SanPham sp);
        void SuaSanPham(SanPham sp);
        void XoaSanPham(int mahang);
    }
}