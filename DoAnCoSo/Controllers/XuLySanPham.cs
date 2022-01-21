using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnCoSo.Model;

namespace DoAnCoSo.Controllers
{
    class XuLySanPham
    {
        private QLNhacCuDataContext db;
        public XuLySanPham()
        {
            db = new QLNhacCuDataContext();
        }
        public IEnumerable<SANPHAM> DanhSachSP()
        {
            List<SANPHAM> dssp = new List<SANPHAM>();
            var query = db.SANPHAMs.ToList();
            foreach (var sp in query)
            {
                dssp.Add(new SANPHAM()
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    LOAISP = sp.LOAISP,
                    NHASX = sp.NHASX,
                    GiaNhap = sp.GiaNhap,
                    GiaBan = sp.GiaBan,
                    GhiChu = sp.GhiChu,
                    Hinh = sp.Hinh
                });
            }
            return dssp;
        }
        public bool KiemTraTonTai(string p)
        {
            var dssp = db.SANPHAMs.Where(a => a.MaSP == p).ToList();
            if (dssp.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Lưu thông tin sản phẩm
        public void LuuTruSanPham(string ma, string ten, string loai, string nsx, string gn, string gb, string gc, string hinh)
        {
            var SanPhamdata = new SANPHAM()
            {
                MaSP = ma,
                TenSP = ten,
                MaLoai = loai,
                MaNSX = nsx,
                GiaNhap = gn,
                GiaBan = gb,
                GhiChu = gc,
                Hinh = hinh
            };

            db.SANPHAMs.InsertOnSubmit(SanPhamdata);
            db.SubmitChanges();
        }
        // sửa thông tin sản phẩm
        public void SuaSP(string ma, string ten, string loai, string nsx, string gn, string gb, string gc, string hinh)
        {
            SANPHAM sp = db.SANPHAMs.Where(a => a.MaSP == ma).SingleOrDefault();
            sp.MaSP = ma;
            sp.TenSP = ten;
            sp.MaLoai = loai;
            sp.MaNSX = nsx;
            sp.GiaNhap = gn;
            sp.GiaBan = gb;
            sp.GhiChu = gc;
            sp.Hinh = hinh;
            db.SubmitChanges();
        }
        //Xoá thông tin sản phẩm
        public void XoaSP(string ma)
        {
            SANPHAM sp = db.SANPHAMs.Where(a => a.MaSP == ma).SingleOrDefault();
            db.SANPHAMs.DeleteOnSubmit(sp);
            db.SubmitChanges();
        }
    }
}
