using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyHoaDon : XuLyNghiepVu<HoaDon>
	{
        public XuLyHoaDon(IXuLyLuuTru<HoaDon> xllt) : base(xllt)
        {

        }

        public override List<HoaDon> HienThi_DanhSach(string tukhoa = "")
        {
            var dshd = _xllt.DocDanhSach();
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

        public override void Them(HoaDon hd)
        {
            HoaDon? tim_hoa_don = _xllt.TimTheoID(hd.SoHoaDon);
            if (tim_hoa_don != null)
            {
                throw new Exception("Số hoá đơn này đã tồn tại! Mời nhập lại!");
            }
            _xllt.Them(hd);
        }

        public override int ThongKe_HangTonKho(int mahang)
        {
            List<HoaDon> dshd = _xllt.DocDanhSach();

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

