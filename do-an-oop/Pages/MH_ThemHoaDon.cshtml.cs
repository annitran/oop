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
	public class MH_ThemHoaDonModel : PageModel
    {
        [BindProperty]
        public int SoHoaDon { get; set; }
        [BindProperty]
        public DateTime NgayHoaDon { get; set; }
        [BindProperty]
        public string LoaiHoaDon { get; set; }
        [BindProperty]
        public int MaHang { get; set; }
        [BindProperty]
        public string TenHang { get; set; }
        [BindProperty]
        public int SoLuong { get; set; }

        public List<SanPham> dssp { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        IXuLyNghiepVu<HoaDon> _xlhd;
        IXuLyNghiepVu<SanPham> _xlsp;

        public MH_ThemHoaDonModel()
        {
            _xlhd = ObjectCreator.TaoDoiTuongXuLyHoaDon();
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
        }

        public void OnGet()
        {
            dssp = _xlsp.HienThi_DanhSach();
            ThongBao = "Nhập thông tin hoá đơn cần thêm!";
        }

        public void OnPost()
        {
            try
            {
                dssp = _xlsp.HienThi_DanhSach();

                HoaDon hd = new HoaDon(SoHoaDon, NgayHoaDon, LoaiHoaDon, MaHang, TenHang, SoLuong);
                _xlhd.Them(hd);
                Response.Redirect("/MH_DanhSachHoaDon");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
