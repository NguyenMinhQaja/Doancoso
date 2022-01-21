using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnCoSo.Model;
namespace DoAnCoSo.Controllers
{
    class XuLyNSX
    {
        private QLNhacCuDataContext db;
        public XuLyNSX()
        {
            db = new QLNhacCuDataContext();
        }
        public IEnumerable<NHASX> DanhSachNSX()
        {
            List<NHASX> dsnsx = new List<NHASX>();
            var query = db.NHASXes.ToList();
            foreach (var nsx in query)
            {
                dsnsx.Add(new NHASX()
                {
                    MaNSX = nsx.MaNSX,
                    TenNSX = nsx.TenNSX
                });
            }    
            return dsnsx;
        }
        public bool KiemTraTonTaiNSX(string p)
        {
            var dssnsx = db.NHASXes.Where(m => m.MaNSX == p).ToList();
            if(dssnsx.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Sửa thông tin nhà sản xuất
        public void SuaNSX(string ma, string ten)
        {
            NHASX nsx = db.NHASXes.Where(m => m.MaNSX == ma).SingleOrDefault();
             nsx.TenNSX = ten;
            db.SubmitChanges();
        }
        //Xoá nhà sản xuất
        public void XoaNSX(string ma)
        {
            NHASX nsx = db.NHASXes.Where(m => m.MaNSX == ma).SingleOrDefault();
            db.NHASXes.DeleteOnSubmit(nsx);
            db.SubmitChanges();
        }
        // lưu nhà sản xuất
        public void LuuNSX(string ma, string ten)
        {
            var Nsxdata = new NHASX()
            {
                MaNSX = ma,
                TenNSX = ten
            };
            db.NHASXes.InsertOnSubmit(Nsxdata);
            db.SubmitChanges();
        }
    }
}
