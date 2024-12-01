using System;
using Newtonsoft.Json;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public class LuuTruHoaDon : ILuuTruHoaDon
	{
        private const string filePath = "/Users/anan/Cá nhân/LTHDT/do-an-oop/dshd.json";

        public List<HoaDon> DocDanhSachHoaDon()
        {
            StreamReader file = new StreamReader(filePath);
            string dshd_json = file.ReadToEnd();
            var dshd = JsonConvert.DeserializeObject<List<HoaDon>>(dshd_json);
            file.Close();

            return dshd;
        }

        public void LuuDanhSachHoaDon(List<HoaDon> dshd)
        {
            string dshd_json = JsonConvert.SerializeObject(dshd, Formatting.Indented);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(dshd_json);
            file.Close();
        }

        public HoaDon Tim(int sohoadon)
        {
            List<HoaDon> dshd = DocDanhSachHoaDon();
            foreach (var hd in dshd)
            {
                if (hd.SoHoaDon == sohoadon)
                {
                    return hd;
                }
            }
            return null;
        }

        public void Them(HoaDon hd)
        {
            List<HoaDon> dshd = DocDanhSachHoaDon();
            int maxId = 0;
            foreach (var s in dshd)
            {
                if (s.SoHoaDon > maxId)
                {
                    maxId = s.SoHoaDon;
                }
            }
            hd.SoHoaDon = maxId + 1;
            dshd.Add(hd);
            LuuDanhSachHoaDon(dshd);
        }

        public void Sua(HoaDon hd)
        {
            List<HoaDon> dshd = DocDanhSachHoaDon();
            for (int i = 0; i < dshd.Count; i++)
            {
                if (dshd[i].SoHoaDon == hd.SoHoaDon)
                {
                    dshd[i] = hd;
                }
            }
            LuuDanhSachHoaDon(dshd);
        }

        public void Xoa(int sohoadon)
        {
            List<HoaDon> dshd = DocDanhSachHoaDon();
            for (int i = dshd.Count - 1; i >= 0; i--)
            {
                if (dshd[i].SoHoaDon == sohoadon)
                {
                    dshd.RemoveAt(i);
                }
            }
            LuuDanhSachHoaDon(dshd);
        }
    }
}

