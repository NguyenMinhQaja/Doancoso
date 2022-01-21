using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnCoSo.Model;

namespace DoAnCoSo.Controllers
{
    class XuLyKhachHang
    {
        private QLNhacCuDataContext db;
        public XuLyKhachHang()
        {
            db = new QLNhacCuDataContext();
        }

        public IEnumerable<KHACHHANG> DanhSachKH()
        {
            List<KHACHHANG> dskh = new List<KHACHHANG>();
            var query = db.KHACHHANGs.ToList();
            foreach (var kh in query)
            {
                dskh.Add(new KHACHHANG()
                {
                    MaKH = kh.MaKH,
                    TenKH = kh.TenKH,
                    DiaChi = kh.DiaChi,
                    DienThoai = kh.DienThoai,
                    Gmail = kh.Gmail
                });
            }    
            return dskh;
        }
        public bool KiemTraTonTai(string p)
        {
            var dsskh = db.KHACHHANGs.Where(m => m.MaKH == p).ToList();
            if(dsskh.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Sửa thông tin khách hàng
        public void SuaKH(string ma, string ten, string diachi, string dt, string gmail)
        {
            KHACHHANG kh = db.KHACHHANGs.Where(m => m.MaKH == ma).SingleOrDefault();
            kh.TenKH = ten;
            kh.DiaChi = diachi;
            kh.DienThoai = dt;
            kh.Gmail = gmail;
            db.SubmitChanges();
        }
        //Xoá thông tin khách hàng
        public void XoaKH(string ma)
        {
            KHACHHANG kh = db.KHACHHANGs.Where(m => m.MaKH == ma).SingleOrDefault();
            db.KHACHHANGs.DeleteOnSubmit(kh);
            db.SubmitChanges();
        }
        //Lưu 
        public void LuuKH(string ma, string ten, string diachi, string dt, string gmail)
        {
            var KHdata = new KHACHHANG()
            {
                MaKH = ma,
                TenKH = ten,
                DiaChi = diachi,
                DienThoai = dt,
                Gmail = gmail
            };
            db.KHACHHANGs.InsertOnSubmit(KHdata);
            db.SubmitChanges();
        }
    }
}
