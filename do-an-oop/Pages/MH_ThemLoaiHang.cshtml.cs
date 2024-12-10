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
	public class MH_ThemLoaiHangModel : PageModel
    {
        [BindProperty]
        public int MaLoaiHang { get; set; }
        [BindProperty]
        public string TenLoaiHang { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        IXuLyNghiepVu<LoaiHang> _xllh;

        public MH_ThemLoaiHangModel()
        {
            _xllh = ObjectCreator.TaoDoiTuongXuLyLoaiHang();
        }

        public void OnGet()
        {
            ThongBao = "Nhập thông tin loại hàng cần thêm!";
        }

        public void OnPost()
        {
            try
            {
                LoaiHang lh = new LoaiHang(MaLoaiHang, TenLoaiHang);
                _xllh.Them(lh);
                Response.Redirect("/MH_DanhSachLoaiHang");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
