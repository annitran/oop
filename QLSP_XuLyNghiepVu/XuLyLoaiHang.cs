using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyLoaiHang : XuLyNghiepVu<LoaiHang>
	{
        public XuLyLoaiHang(IXuLyLuuTru<LoaiHang> xllt) : base(xllt)
        {

        }

        public override List<LoaiHang> HienThi_DanhSach(string tuKhoa = "")
        {
            List<LoaiHang> dslh = _xllt.DocDanhSach();
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

        public override void Them(LoaiHang lh)
        {
            bool tim_loai_hang = _xllt.TimTheoTen(lh.TenLoaiHang);
            if (tim_loai_hang)
            {
                _xllt.Them(lh);
            }
        }
    }
}

