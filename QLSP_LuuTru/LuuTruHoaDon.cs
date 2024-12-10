using System;
using Newtonsoft.Json;
using QLSP_Entity;

namespace QLSP_LuuTru
{
	public class LuuTruHoaDon : XuLyLuuTru<HoaDon>
	{
        private const string filePath = "/Users/anan/Cá nhân/LTHDT/do-an-oop/dshd.json";

        public override string getfilePath()
        {
            return filePath;
        }

        public override HoaDon TimTheoID(int sohoadon)
        {
            List<HoaDon> dshd = DocDanhSach();
            foreach (var hd in dshd)
            {
                if (hd.SoHoaDon == sohoadon)
                {
                    return hd;
                }
            }
            return null;
        }

        public override void Them(HoaDon hd)
        {
            List<HoaDon> dshd = DocDanhSach();
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
            LuuDanhSach(dshd);
        }

        public override void Sua(HoaDon hd)
        {
            List<HoaDon> dshd = DocDanhSach();
            for (int i = 0; i < dshd.Count; i++)
            {
                if (dshd[i].SoHoaDon == hd.SoHoaDon)
                {
                    dshd[i] = hd;
                }
            }
            LuuDanhSach(dshd);
        }

        public override void Xoa(int sohoadon)
        {
            List<HoaDon> dshd = DocDanhSach();
            for (int i = dshd.Count - 1; i >= 0; i--)
            {
                if (dshd[i].SoHoaDon == sohoadon)
                {
                    dshd.RemoveAt(i);
                }
            }
            LuuDanhSach(dshd);
        }
    }
}

