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
	public class MH_XoaSanPhamModel : PageModel
    {
        public SanPham sp { get; set; }

        [BindProperty(SupportsGet = true)]
        public int mahang { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        private IXuLySanPham _xlsp;

        public MH_XoaSanPhamModel() : base()
        {
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
        }

        public void OnGet()
        {
            try
            {
                if (mahang == 0)
                {
                    ThongBao = "Mã sản phẩm không hợp lệ!";
                    return;
                }

                sp = _xlsp.TimSanPhamTheoID(mahang);
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
                _xlsp.XoaSanPham(mahang);
                Response.Redirect("/MH_DanhSachSanPham");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
