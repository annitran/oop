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
	public class MH_DanhSachHangHetHSDModel : PageModel
    {
        private IXuLyNghiepVu<SanPham> _xlsp;
        private IXuLyNghiepVu<HoaDon> _xlhd;

        public List<SanPham> DanhSachSanPham { get; set; }
        public List<HoaDon> DanhSachHoaDon { get; set; }

        public string ThongBao { get; set; } = string.Empty;

        public MH_DanhSachHangHetHSDModel()
        {
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
            _xlhd = ObjectCreator.TaoDoiTuongXuLyHoaDon();
        }

        public void OnGet()
        {
            DanhSachSanPham = _xlsp.HienThi_DanhSach();
            DanhSachHoaDon = _xlhd.HienThi_DanhSach();

            foreach (var sp in DanhSachSanPham)
            {
                if (sp.HSD < DateTime.Now)
                {
                    sp.SoLuongHangTonKho = _xlhd.ThongKe_HangTonKho(sp.MaHang);
                }
            }
        }
    }
}
