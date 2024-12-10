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
	public class MH_XoaLoaiHangModel : PageModel
    {
        public LoaiHang lh { get; set; }

        [BindProperty(SupportsGet = true)]
        public int maloaihang { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        private IXuLyNghiepVu<LoaiHang> _xllh;

        public MH_XoaLoaiHangModel()
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
                _xllh.Xoa(maloaihang);
                Response.Redirect("/MH_DanhSachLoaiHang");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
