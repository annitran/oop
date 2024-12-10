using QLSP_Entity;
using Newtonsoft.Json;

namespace QLSP_LuuTru
{
    public class LuuTruSanPham : XuLyLuuTru<SanPham>
    {
        private const string filePath = "/Users/anan/Cá nhân/LTHDT/do-an-oop/dssp.json";

        public override string getfilePath()
        {
            return filePath;
        }

        public override bool TimTheoTen(string tenhang)
        {
            List<SanPham> dssp = DocDanhSach();
            foreach (var sp in dssp)
            {
                if (sp.TenHang == tenhang)
                {
                    throw new Exception("Đã tồn tại sản phẩm này!");
                }
            }
            return true;
        }

        public override SanPham TimTheoID(int mahang)
        {
            List<SanPham> dssp = DocDanhSach();
            foreach (var sp in dssp)
            {
                if (sp.MaHang == mahang)
                {
                    return sp;
                }
            }
            return null;
        }

        public override void Them(SanPham sp)
        {
            List<SanPham> dssp = DocDanhSach();
            int maxId = 0;
            foreach (var s in dssp)
            {
                if (s.MaHang > maxId)
                {
                    maxId = s.MaHang;
                }
            }
            sp.MaHang = maxId + 1;
            dssp.Add(sp);
            LuuDanhSach(dssp);
        }

        public override void Sua(SanPham sp)
        {
            List<SanPham> dssp = DocDanhSach();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].MaHang == sp.MaHang)
                {
                    dssp[i] = sp;
                }
            }
            LuuDanhSach(dssp);
        }

        public override void Xoa(int mahang)
        {
            List<SanPham> dssp = DocDanhSach();
            for (int i = dssp.Count - 1; i >= 0; i--)
            {
                if (dssp[i].MaHang == mahang)
                {
                    dssp.RemoveAt(i);
                }
            }
            LuuDanhSach(dssp);
        }
    }
}

