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
	public class MH_SuaLoaiHangModel : PageModel
    {
        public LoaiHang lh { get; set; }

        [BindProperty(SupportsGet = true)]
        public int maloaihang { get; set; }

        [BindProperty]
        public string TenLoaiHang { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        private IXuLyNghiepVu<LoaiHang> _xllh;

        public MH_SuaLoaiHangModel()
        {
            _xllh = ObjectCreator.TaoDoiTuongXuLyLoaiHang();
        }

        public void OnGet()
        {
            try
            {
                if (maloaihang == 0)
                {
                    ThongBao = "Mã loại hàng không hợp lệ!";
                    return;
                }

                lh = _xllh.TimTheoID(maloaihang);
                if (lh == null)
                {
                    ThongBao = "Không tìm thấy loại hàng này!";
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
                LoaiHang lh_sua = new LoaiHang(maloaihang, TenLoaiHang);
                lh_sua.MaLoaiHang = maloaihang;
                _xllh.Sua(lh_sua);
                Response.Redirect("/MH_DanhSachLoaiHang");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
