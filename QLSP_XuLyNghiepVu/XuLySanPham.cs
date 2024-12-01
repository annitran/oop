using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
    public class XuLySanPham : IXuLySanPham
    {
        private ILuuTruSanPham _ltsp;

        public XuLySanPham(ILuuTruSanPham ltsp)
        {
            _ltsp = ltsp;
        }

        public List<SanPham> HienThi_DSSP(string tuKhoa = "")
        {
            List<SanPham> dssp = _ltsp.DocDanhSachSanPham();
            List<SanPham> ds_tim_kiem = new List<SanPham>();
            //lọc sản phẩm theo từ khoá
            if (string.IsNullOrEmpty(tuKhoa))
            {
                return dssp;
            }
            else
            {
                foreach (var sp in dssp)
                {
                    if (sp.TenHang.Contains(tuKhoa))
                    {
                        ds_tim_kiem.Add(sp);
                    }
                }
                return ds_tim_kiem;
            }
        }

        public SanPham TimSanPhamTheoID(int mahang)
        {
            return _ltsp.TimSanPhamTheoID(mahang);
        }

        public void ThemSanPham(SanPham sp)
        {
            SanPham? tim_san_pham = _ltsp.TimSanPhamTheoTen(sp.TenHang);
            if (tim_san_pham != null)
            {
                throw new Exception("Sản phẩm này đã tồn tại! Mời nhập lại!");
            }
            _ltsp.Them(sp);
        }

        public void SuaSanPham(SanPham sp)
        {
            _ltsp.Sua(sp);
        }

        public void XoaSanPham(int mahang)
        {
            _ltsp.Xoa(mahang);
        }
    }
}

