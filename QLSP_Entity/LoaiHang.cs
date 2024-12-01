using System;
namespace QLSP_Entity
{
	public class LoaiHang
	{
		public int MaLoaiHang { get; set; }
		public string TenLoaiHang { get; set; }

		public LoaiHang(int maloaihang, string tenloaihang)
		{
			if (maloaihang <= 0)
			{
				throw new Exception("Mã loại hàng không hợp lệ! Mời nhập lại!");
			}

            if (string.IsNullOrEmpty(tenloaihang))
            {
                throw new Exception("Tên loại hàng không hợp lệ! Mời nhập lại!");
            }

			this.MaLoaiHang = maloaihang;
			this.TenLoaiHang = tenloaihang;
        }
	}
}

