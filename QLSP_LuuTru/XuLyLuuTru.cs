using System;
using Newtonsoft.Json;
using QLSP_Entity;

namespace QLSP_LuuTru
{
    public abstract class XuLyLuuTru<T> : IXuLyLuuTru<T>
    {
        public abstract string getfilePath();

        public List<T> DocDanhSach()
        {
            StreamReader file = new StreamReader(getfilePath());
            string ds_json = file.ReadToEnd();
            var ds = JsonConvert.DeserializeObject<List<T>>(ds_json);
            file.Close();

            return ds;
        }

        public void LuuDanhSach(List<T> ds)
        {
            string ds_json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            StreamWriter file = new StreamWriter(getfilePath());
            file.Write(ds_json);
            file.Close();
        }

        public virtual bool TimTheoTen(string ten)
        {
            return false;
        }

        public abstract T TimTheoID(int id);

        public abstract void Them(T sp);

        public abstract void Sua(T sp);

        public abstract void Xoa(int id);
    }
}

