using Newtonsoft.Json;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public class LuuTruLoaiHang : XuLyLuuTru<LoaiHang>
	{
        private const string filePath = "/Users/anan/Cá nhân/LTHDT/do-an-oop/dslh.json";

        public override string getfilePath()
        {
            return filePath;
        }

        public override bool TimTheoTen(string tenloaihang)
        {
            List<LoaiHang> dslh = DocDanhSach();
            foreach (var s in dslh)
            {
                if (s.TenLoaiHang == tenloaihang)
                {
                    throw new Exception("Đã tồn tại loại hàng này!");
                }
            }
            return true;
        }

        public override LoaiHang TimTheoID(int maloaihang)
        {
            List<LoaiHang> dslh = DocDanhSach();
            foreach (var lh in dslh)
            {
                if (lh.MaLoaiHang == maloaihang)
                {
                    return lh;
                }
            }
            return null;
        }

        public override void Them(LoaiHang lh)
        {
            List<LoaiHang> dslh = DocDanhSach();
            int maxId = 0;
            foreach (var s in dslh)
            {
                if (s.MaLoaiHang > maxId)
                {
                    maxId = s.MaLoaiHang;
                }
            }
            lh.MaLoaiHang = maxId + 1;
            dslh.Add(lh);
            LuuDanhSach(dslh);
        }

        public override void Sua(LoaiHang lh)
        {
            List<LoaiHang> dslh = DocDanhSach();
            for (int i = 0; i < dslh.Count; i++)
            {
                if (dslh[i].MaLoaiHang == lh.MaLoaiHang)
                {
                    dslh[i] = lh;
                }
            }
            LuuDanhSach(dslh);
        }

        public override void Xoa(int maloaihang)
        {
            List<LoaiHang> dslh = DocDanhSach();
            for (int i = dslh.Count - 1; i >= 0; i--)
            {
                if (dslh[i].MaLoaiHang == maloaihang)
                {
                    dslh.RemoveAt(i);
                }
            }
            LuuDanhSach(dslh);
        }
    }
}

