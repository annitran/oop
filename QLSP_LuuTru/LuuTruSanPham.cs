using QLSP_Entity;
using Newtonsoft.Json;

namespace QLSP_LuuTru
{
    public class LuuTruSanPham : ILuuTruSanPham
    {
        private const string filePath = "/Users/anan/Cá nhân/LTHDT/do-an-oop/dssp.json";

        public List<SanPham> DocDanhSachSanPham()
        {
            StreamReader file = new StreamReader(filePath);
            string dssp_json = file.ReadToEnd();
            var dssp = JsonConvert.DeserializeObject<List<SanPham>>(dssp_json);
            file.Close();

            return dssp;
        }

        public void LuuDanhSachSanPham(List<SanPham> dssp)
        {
            string dssp_json = JsonConvert.SerializeObject(dssp, Formatting.Indented);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(dssp_json);
            file.Close();
        }

        public SanPham TimSanPhamTheoTen(string tenhang)
        {
            List<SanPham> dssp = DocDanhSachSanPham();
            foreach (var sp in dssp)
            {
                if (sp.TenHang == tenhang)
                {
                    return sp;
                }
            }
            return null;
        }

        public SanPham TimSanPhamTheoID(int mahang)
        {
            List<SanPham> dssp = DocDanhSachSanPham();
            foreach (var sp in dssp)
            {
                if (sp.MaHang == mahang)
                {
                    return sp;
                }
            }
            return null;
        }

        public void Them(SanPham sp)
        {
            List<SanPham> dssp = DocDanhSachSanPham();
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
            LuuDanhSachSanPham(dssp);
        }

        public void Sua(SanPham sp)
        {
            List<SanPham> dssp = DocDanhSachSanPham();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].MaHang == sp.MaHang)
                {
                    dssp[i] = sp;
                }
            }
            LuuDanhSachSanPham(dssp);
        }

        public void Xoa(int mahang)
        {
            List<SanPham> dssp = DocDanhSachSanPham();
            for (int i = dssp.Count - 1; i >= 0; i--)
            {
                if (dssp[i].MaHang == mahang)
                {
                    dssp.RemoveAt(i);
                }
            }
            LuuDanhSachSanPham(dssp);
        }
    }
}

