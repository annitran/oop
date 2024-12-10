using System;
using QLSP_Entity;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLyNghiepVu<T>
	{
        List<T> HienThi_DanhSach(string tuKhoa = "");
        T TimTheoID(int id);

        void Them(T sp);
        void Sua(T sp);
        void Xoa(int id);

        int ThongKe_HangTonKho(int id);
    }
}