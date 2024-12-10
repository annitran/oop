using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace do_an_oop.Pages
{
	public class MH_ThemSanPhamModel : PageModel
    {
        [BindProperty]
        public int MaHang { get; set; }
        [BindProperty]
        public string TenHang { get; set; }
        [BindProperty]
        public DateTime NSX { get; set; }
        [BindProperty]
        public DateTime HSD { get; set; }
        [BindProperty]
        public string CtySX { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        [BindProperty]
        public int Gia { get; set; }

        public List<LoaiHang> dslh { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        private IXuLyNghiepVu<SanPham> _xlsp;
        private IXuLyNghiepVu<LoaiHang> _xllh;

        public MH_ThemSanPhamModel() : base()
        {
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
            _xllh = ObjectCreator.TaoDoiTuongXuLyLoaiHang();
        }

        public void OnGet()
        {
            ThongBao = "Nhập thông tin sản phẩm cần thêm!";
            dslh = _xllh.HienThi_DanhSach();
        }

        public void OnPost()
        {
            try
            {
                dslh = _xllh.HienThi_DanhSach();

                SanPham sp = new SanPham(MaHang, TenHang, NSX, HSD, CtySX, LoaiHang, Gia);
                _xlsp.Them(sp);
                Response.Redirect("/MH_DanhSachSanPham");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
