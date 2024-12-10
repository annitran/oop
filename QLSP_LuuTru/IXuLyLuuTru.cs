using System;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public interface IXuLyLuuTru<T>
	{
        string getfilePath();
        List<T> DocDanhSach();
        void LuuDanhSach(List<T> ds);
        bool TimTheoTen(string ten);
        T TimTheoID(int id);

        void Them(T sp);
        void Sua(T sp);
        void Xoa(int id);
    }
}

