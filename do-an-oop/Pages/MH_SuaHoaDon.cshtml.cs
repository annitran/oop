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
	public class MH_SuaHoaDonModel : PageModel
    {
        public HoaDon hd { get; set; }

        [BindProperty(SupportsGet = true)]
        public int sohoadon { get; set; }

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

        public MH_SuaHoaDonModel()
        {
            _xlhd = ObjectCreator.TaoDoiTuongXuLyHoaDon();
            _xlsp = ObjectCreator.TaoDoiTuongXuLySanPham();
        }

        public void OnGet()
        {
            try
            {
                dssp = _xlsp.HienThi_DanhSach();

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
                dssp = _xlsp.HienThi_DanhSach();

                HoaDon hd_sua = new HoaDon(sohoadon, NgayHoaDon, LoaiHoaDon, MaHang, TenHang, SoLuong);
                hd_sua.SoLuong = sohoadon;
                _xlhd.Sua(hd_sua);
                Response.Redirect("/MH_DanhSachHoaDon");
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
}
