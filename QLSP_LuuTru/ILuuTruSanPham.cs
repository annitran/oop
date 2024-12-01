using System;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public interface ILuuTruSanPham
	{
        List<SanPham> DocDanhSachSanPham();
        void LuuDanhSachSanPham(List<SanPham> dssp);
        SanPham TimSanPhamTheoTen(string tenhang);
        SanPham TimSanPhamTheoID(int mahang);

        void Them(SanPham sp);
        void Sua(SanPham sp);
        void Xoa(int mahang);
    }
}