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
	public class MH_DanhSachHoaDonModel : PageModel
    {
        public List<HoaDon> DanhSachHoaDon { get; set; }

        [BindProperty]
        public string tukhoa { get; set; } = string.Empty;
        public string ThongBao { get; set; } = string.Empty;

        IXuLyHoaDon _xlhd;

        public MH_DanhSachHoaDonModel()
        {
            _xlhd = ObjectCreator.TaoDoiTuongXuLyHoaDon();
        }

        public void OnGet()
        {
            try
            {
                DanhSachHoaDon = _xlhd.HienThi_DSHD();
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
                DanhSachHoaDon = _xlhd.HienThi_DSHD(tukhoa);
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
