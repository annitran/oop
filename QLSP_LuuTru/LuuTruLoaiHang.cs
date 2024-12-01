using Newtonsoft.Json;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public class LuuTruLoaiHang : ILuuTruLoaiHang
	{
        private const string filePath = "/Users/anan/Cá nhân/LTHDT/do-an-oop/dslh.json";

        public List<LoaiHang> DocDanhSachLoaiHang()
        {
            StreamReader file = new StreamReader(filePath);
            string dslh_json = file.ReadToEnd();
            var dslh = JsonConvert.DeserializeObject<List<LoaiHang>>(dslh_json);
            file.Close();

            return dslh;
        }

        public void LuuDanhSachLoaiHang(List<LoaiHang> dslh)
        {
            string dslh_json = JsonConvert.SerializeObject(dslh, Formatting.Indented);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(dslh_json);
            file.Close();
        }

        public LoaiHang TimLoaiHangTheoTen(string tenloaihang)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            foreach (var s in dslh)
            {
                if (s.TenLoaiHang == tenloaihang)
                {
                    return s;
                }
            }
            return null;
        }

        public LoaiHang TimTheoID(int maloaihang)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            foreach (var lh in dslh)
            {
                if (lh.MaLoaiHang == maloaihang)
                {
                    return lh;
                }
            }
            return null;
        }

        public void Them(LoaiHang lh)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
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
            LuuDanhSachLoaiHang(dslh);
        }

        public void Sua(LoaiHang lh)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            for (int i = 0; i < dslh.Count; i++)
            {
                if (dslh[i].MaLoaiHang == lh.MaLoaiHang)
                {
                    dslh[i] = lh;
                }
            }
            LuuDanhSachLoaiHang(dslh);
        }

        public void Xoa(int maloaihang)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            for (int i = dslh.Count - 1; i >= 0; i--)
            {
                if (dslh[i].MaLoaiHang == maloaihang)
                {
                    dslh.RemoveAt(i);
                }
            }
            LuuDanhSachLoaiHang(dslh);
        }
    }
}

