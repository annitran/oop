using System;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public interface ILuuTruHoaDon
	{
        List<HoaDon> DocDanhSachHoaDon();
        void LuuDanhSachHoaDon(List<HoaDon> dshd);
        HoaDon Tim(int sohoadon);

        public void Them(HoaDon hd);
        public void Sua(HoaDon hd);
        public void Xoa(int sohoadon);
    }
}

