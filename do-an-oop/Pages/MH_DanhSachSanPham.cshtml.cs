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
	public class MH_DanhSachSanPhamModel : PageModel
    {
        public List<SanPham> DanhSachSanPham { get; set; }

        [BindProperty]
        public string tukhoa { get; set; } = string.Empty;
        public string ThongBao { get; set; } = string.Empty;

        private IXuLyNghiepVu<SanPham> _xlsp;

        public MH_DanhSachSanPhamModel()
        {
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
        }

        public void OnGet()
        {
            try
            {
                DanhSachSanPham = _xlsp.HienThi_DanhSach();
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
                DanhSachSanPham = _xlsp.HienThi_DanhSach(tukhoa);
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
