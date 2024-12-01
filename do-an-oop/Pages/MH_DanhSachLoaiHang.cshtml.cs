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
	public class MH_DanhSachLoaiHangModel : PageModel
    {
        public List<LoaiHang> DanhSachLoaiHang { get; set; }

        [BindProperty]
        public string tukhoa { get; set; } = string.Empty;
        public string ThongBao { get; set; } = string.Empty;

        private IXuLyLoaiHang _xllh;

        public MH_DanhSachLoaiHangModel()
        {
            _xllh = ObjectCreator.TaoDoiTuongXuLyLoaiHang();
        }

        public void OnGet()
        {
            try
            {
                DanhSachLoaiHang = _xllh.HienThi_DSLH();
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
                DanhSachLoaiHang = _xllh.HienThi_DSLH(tukhoa);
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
