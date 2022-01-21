using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnCoSo.Model;
namespace DoAnCoSo.Controllers
{
    class XuLyNhanVien
    {
        private QLNhacCuDataContext db;
        public XuLyNhanVien()
        {
            db = new QLNhacCuDataContext();
        }
        public IEnumerable<NHANVIEN> DanhSachNV()
        {
            List<NHANVIEN> dsnv = new List<NHANVIEN>();
            var query = db.NHANVIENs.ToList();
            foreach (var nv in query)
            {
                dsnv.Add(new NHANVIEN()
                {
                    MaNV = nv.MaNV,
                    TenNV = nv.TenNV,
                    GioiTinh = nv.GioiTinh,
                    DiaChi = nv.DiaChi,
                    DienThoai = nv.DienThoai,
                    NgaySinh = nv.NgaySinh
                });
            }
            return dsnv;
        }
        public bool KiemTraTonTai(string p)
        {
            var dsnv = db.NHANVIENs.Where(a => a.MaNV == p).ToList();
            if (dsnv.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Lưu thông tin nhân viên
        public void LuuTruNhanVien(string ma, string ten, bool gt, string dc, string dt, DateTime ns)
        {
            var NhanViendata = new NHANVIEN()
            {
                MaNV = ma,
                TenNV = ten,
                GioiTinh = gt,
                DiaChi = dc,
                DienThoai = dt,
                NgaySinh = ns              
            };
            
            db.NHANVIENs.InsertOnSubmit(NhanViendata);
            db.SubmitChanges();
        }
        // sửa thông tin nhân viên
        public void SuaNhanVien(string ma, string ten, bool gt, string dc, string dt, DateTime ns)
        {
            NHANVIEN nv = db.NHANVIENs.Where(a => a.MaNV == ma).SingleOrDefault();
            nv.TenNV = ten;
            nv.GioiTinh = gt;
            nv.DiaChi = dc;
            nv.DienThoai = dt;
            nv.NgaySinh = ns;
            db.SubmitChanges();
        }
        //Xoá thông tin nhân viên
        public void XoaNhanVien(string ma)
        {
            NHANVIEN nv = db.NHANVIENs.Where(a => a.MaNV == ma).SingleOrDefault();
            db.NHANVIENs.DeleteOnSubmit(nv);
            db.SubmitChanges();
        }
    }
}
