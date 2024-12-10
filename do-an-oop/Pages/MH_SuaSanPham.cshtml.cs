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
	public class MH_SuaSanPhamModel : PageModel
    {
        public SanPham sp { get; set; }

        [BindProperty(SupportsGet = true)]
        public int mahang { get; set; }

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

        public MH_SuaSanPhamModel() : base()
        {
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
            _xllh = ObjectCreator.TaoDoiTuongXuLyLoaiHang();
        }

        public void OnGet()
        {
            try
            {
                dslh = _xllh.HienThi_DanhSach();

                if (mahang == 0)
                {
                    ThongBao = "Mã sản phẩm không hợp lệ!";
                    return;
                }

                sp = _xlsp.TimTheoID(mahang);
                if (sp == null)
                {
                    ThongBao = "Không tìm thấy sản phẩm này!";
                }
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }

        public void OnPost()
        {
            try
            {
                dslh = _xllh.HienThi_DanhSach();

                SanPham sp_sua = new SanPham(mahang, TenHang, NSX, HSD, CtySX, LoaiHang, Gia);
                sp_sua.MaHang = mahang;
                _xlsp.Sua(sp_sua);
                Response.Redirect("/MH_DanhSachSanPham");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
