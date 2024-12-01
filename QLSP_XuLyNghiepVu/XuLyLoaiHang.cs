using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyLoaiHang : IXuLyLoaiHang
	{
        private ILuuTruLoaiHang _ltlh;

        public XuLyLoaiHang(ILuuTruLoaiHang ltlh)
        {
            _ltlh = ltlh;
        }

        public List<LoaiHang> HienThi_DSLH(string tuKhoa = "")
        {
            List<LoaiHang> dslh = _ltlh.DocDanhSachLoaiHang();
            List<LoaiHang> ds_tim_kiem = new List<LoaiHang>();
            //lọc theo từ khoá
            if (string.IsNullOrEmpty(tuKhoa))
            {
                return dslh;
            }
            else
            {
                foreach (var lh in dslh)
                {
                    if (lh.TenLoaiHang.Contains(tuKhoa))
                    {
                        ds_tim_kiem.Add(lh);
                    }
                }
                return ds_tim_kiem;
            }
        }

        public LoaiHang TimLoaiHang(int maloaihang)
        {
            return _ltlh.TimTheoID(maloaihang);
        }

        public void ThemLoaiHang(LoaiHang lh)
        {
            LoaiHang? tim_loai_hang = _ltlh.TimLoaiHangTheoTen(lh.TenLoaiHang);
            if (tim_loai_hang != null)
            {
                throw new Exception("Loại hàng này đã tồn tại! Mời nhập lại!");
            }
            _ltlh.Them(lh);
        }

        public void SuaLoaiHang(LoaiHang lh)
        {
            _ltlh.Sua(lh);
        }

        public void XoaLoaiHang(int maloaihang)
        {
            _ltlh.Xoa(maloaihang);
        }
    }
}

