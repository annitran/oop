using System;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public interface ILuuTruLoaiHang
	{
        List<LoaiHang> DocDanhSachLoaiHang();
        void LuuDanhSachLoaiHang(List<LoaiHang> dslh);
        LoaiHang TimLoaiHangTheoTen(string tenloaihang);
        LoaiHang TimTheoID(int maloaihang);

        void Them(LoaiHang lh);
        void Sua(LoaiHang lh);
        void Xoa(int maloaihang);
    }
}

