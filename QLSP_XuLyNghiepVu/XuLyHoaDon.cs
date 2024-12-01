using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyHoaDon : IXuLyHoaDon
	{
        private ILuuTruHoaDon _lthd;

        public XuLyHoaDon(ILuuTruHoaDon lthd)
        {
            _lthd = lthd;
        }

        public List<HoaDon> HienThi_DSHD(string tukhoa = "")
        {
            var dshd = _lthd.DocDanhSachHoaDon();
            var ds_tim_kiem = new List<HoaDon>();
            //lọc theo từ khoá
            if (string.IsNullOrEmpty(tukhoa))
            {
                return dshd;
            }
            else
            {
                foreach (var hd in dshd)
                {
                    if (hd.TenHang.Contains(tukhoa) || hd.LoaiHoaDon.Contains(tukhoa))
                    {
                        ds_tim_kiem.Add(hd);
                    }
                }
                return ds_tim_kiem;
            }
        }

        public HoaDon TimHoaDon(int sohoadon)
        {
            return _lthd.Tim(sohoadon);
        }

        public void ThemHoaDon(HoaDon hd)
        {
            HoaDon? tim_hoa_don = _lthd.Tim(hd.SoHoaDon);
            if (tim_hoa_don != null)
            {
                throw new Exception("Số hoá đơn này đã tồn tại! Mời nhập lại!");
            }
            _lthd.Them(hd);
        }

        public void SuaHoaDon(HoaDon hd)
        {
            _lthd.Sua(hd);
        }

        public void XoaHoaDon(int sohoadon)
        {
            _lthd.Xoa(sohoadon);
        }

        public int ThongKe_HangTonKho(int mahang)
        {
            List<HoaDon> dshd = _lthd.DocDanhSachHoaDon();

            int SoLuongNhap = 0;
            int SoLuongBan = 0;

            for (int i = 0; i < dshd.Count; i++)
            {
                if (dshd[i].MaHang == mahang)
                {
                    if (dshd[i].LoaiHoaDon == "Hoá đơn nhập hàng")
                    {
                        SoLuongNhap += dshd[i].SoLuong;
                    }
                    else if (dshd[i].LoaiHoaDon == "Hoá đơn bán hàng")
                    {
                        SoLuongBan += dshd[i].SoLuong;
                    }
                }
            }
            return SoLuongNhap - SoLuongBan;
        }
    }
}

