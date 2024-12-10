using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
    public class XuLySanPham : XuLyNghiepVu<SanPham>
    {
        //Nếu như lớp cha có phương thức khởi tạo có tham số thì đòi hỏi lớp con phải có phương thức khởi tạo tương ứng
        //và thực hiện gọi phương thức khởi tạo của lớp cha thông qua từ khoá base
        //public <tên lớp>(<danh sách tham số của lớp con>) : base(<danh sách tham số>)

        public XuLySanPham(IXuLyLuuTru<SanPham> xllt) : base(xllt)
        {

        }

        public override List<SanPham> HienThi_DanhSach(string tuKhoa = "")
        {
            List<SanPham> dssp = _xllt.DocDanhSach();
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

        public override void Them(SanPham sp)
        {
            bool tim_san_pham = _xllt.TimTheoTen(sp.TenHang);
            if (tim_san_pham)
            {
                _xllt.Them(sp);
            }
        }
    }
}

