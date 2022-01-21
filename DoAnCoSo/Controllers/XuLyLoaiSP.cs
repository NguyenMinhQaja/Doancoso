using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnCoSo.Model;

namespace DoAnCoSo.Controllers
{
    class XuLyLoaiSP
    {
        private QLNhacCuDataContext db;
        public XuLyLoaiSP()
        {
            db = new QLNhacCuDataContext();
        }
        public IEnumerable<LOAISP> DanhSachLoaiSP()
        {
            List<LOAISP> dsl = new List<LOAISP>();
            var query = db.LOAISPs.ToList();
            foreach (var l in query)
            {
                dsl.Add(new LOAISP()
                {
                    MaLoai = l.MaLoai,
                    TenLoai = l.TenLoai
                });
            }
            return dsl;
        }
        public bool KiemTraTonTaiLoai(string p)
        {
            var dssl = db.LOAISPs.Where(m => m.MaLoai == p).ToList();
            if(dssl.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Sửa loại sản phẩm
        public void SuaLoai(string ma, string ten)
        {
            LOAISP l = db.LOAISPs.Where(m => m.MaLoai == ma).SingleOrDefault();
            l.TenLoai = ten;
            db.SubmitChanges();
        }
        //Xoá loại sản phẩm
        public void XoaLoai(string ma)
        {
            LOAISP l = db.LOAISPs.Where(m => m.MaLoai == ma).SingleOrDefault();
            db.LOAISPs.DeleteOnSubmit(l);
            db.SubmitChanges();
        }
        //Lưu 
        public void LuuL(string ma, string ten)
        {
            var Loaidata = new LOAISP()
            {
                MaLoai = ma,
                TenLoai = ten
            };
            db.LOAISPs.InsertOnSubmit(Loaidata);
            db.SubmitChanges();
        }
    }
}
