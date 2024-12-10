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
	public class MH_XoaHoaDonModel : PageModel
    {
        public HoaDon hd { get; set; }

        [BindProperty(SupportsGet = true)]
        public int sohoadon { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        private IXuLyNghiepVu<HoaDon> _xlhd;

        public MH_XoaHoaDonModel()
        {
            _xlhd = ObjectCreator.TaoDoiTuongXuLyHoaDon();
        }

        public void OnGet()
        {
            try
            {
                if (sohoadon == 0)
                {
                    ThongBao = "Số hoá đơn không hợp lệ!";
                    return;
                }

                hd = _xlhd.TimTheoID(sohoadon);
                if (hd == null)
                {
                    ThongBao = "Không tìm thấy hoá đơn này!";
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
                _xlhd.Xoa(sohoadon);
                Response.Redirect("/MH_DanhSachHoaDon");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
