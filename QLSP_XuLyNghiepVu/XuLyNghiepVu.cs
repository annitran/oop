using System;
using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public abstract class XuLyNghiepVu<T> : IXuLyNghiepVu<T>
    {
        public IXuLyLuuTru<T> _xllt;

        public XuLyNghiepVu(IXuLyLuuTru<T> xllt)
        {
            _xllt = xllt;
        }

        public abstract List<T> HienThi_DanhSach(string tuKhoa = "");

        public T TimTheoID(int id)
        {
            return _xllt.TimTheoID(id);
        }

        public abstract void Them(T sp);

        public void Sua(T sp)
        {
            _xllt.Sua(sp);
        }

        public void Xoa(int id)
        {
            _xllt.Xoa(id);
        }

        public virtual int ThongKe_HangTonKho(int id)
        {
            return 0;
        }
    }
}