using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCoSo.Model;
using DoAnCoSo.Controllers;

namespace DoAnCoSo.View
{
    public partial class frmSanPham : Form
    {
        private QLNhacCuDataContext db;
        XuLyLoaiSP xll = new XuLyLoaiSP();
        XuLyNSX xlnsx = new XuLyNSX();
        XuLySanPham xlsp = new XuLySanPham();
        bool themmoi = true;
        public frmSanPham()
        {
            InitializeComponent();
        }
        //cài đặt nút cho loại
        public void setButtonLoai(bool value)
        {
            btnThemLoai.Enabled = value;
            btnSuaLoai.Enabled = value;
            btnXoaLoai.Enabled = value;
            btnLuuL.Enabled = !value;
            
            txtMaLoai.Enabled = !value;
            txtTenLoai.Enabled = !value;
            
        }
        //cài đặt nút cho nhà sản xuất
        public void setButtonNSX(bool value)
        {
            btnThemNSX.Enabled = value;
            btnSuaNSX.Enabled = value;
            btnXoaNSX.Enabled = value;
            btnLuuNSX.Enabled = !value;

            txtMaNSX.Enabled = !value;
            txtTenLoai.Enabled = !value;
        }
        //cài đặt nút cho sản phẩm
        public void setButtonSP(bool value)
        {
            btnThemSP.Enabled = value;
            btnSuaSP.Enabled = value;
            btnXoa.Enabled = value;
            btnNL.Enabled = !value;

            txtMaSP.Enabled = !value;
            txtTenSP.Enabled = !value;
            cbLoai.Enabled = !value;
            cbNSX.Enabled = !value;
            txtGiaNhap.Enabled = !value;
            txtGiaBan.Enabled = !value;
            txtGhiChu.Enabled = !value;
            txtHinh.Enabled = !value;

        }
        private void ResetValueLoai()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }
        private void ResetValueNSX()
        {
            txtMaNSX.Text = "";
            txtTenNSX.Text = "";
        }
        private void ResetValueSP()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtGhiChu.Text = "";
            txtHinh.Text = "";    
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            db = new QLNhacCuDataContext();
            HienThiDanhSachLoai();
            HienThiDanhSachNSX();
            HienThiDanhSachSP();
            setButtonLoai(true);
            setButtonNSX(true);
            setButtonSP(true);
            
            //đổ dữ liệu cho combobox loại sản phẩm
            cbLoai.DataSource = db.LOAISPs;
            cbLoai.DisplayMember = "MaLoai";   //thuộc tính hiển thị
            cbLoai.ValueMember = "MaLoai";  //thuôc tính giá trị ngầm

            //đổ dữ liệu cho combobox nhà sản xuất
            cbNSX.DataSource = db.NHASXes;
            cbNSX.DisplayMember = "MaNSX";
            cbNSX.ValueMember = "MaNSX";
        }

        private void HienThiDanhSachLoai()
        {
            lsvLoai.Items.Clear();
            lsvLoai.FullRowSelect = true;
            lsvLoai.View = System.Windows.Forms.View.Details;
            IEnumerable<LOAISP> dssl = xll.DanhSachLoaiSP();
            if(dssl.Count() > 0)
            {
                foreach(LOAISP l in dssl)
                {
                    ListViewItem lvi;
                    lvi = lsvLoai.Items.Add(l.MaLoai.ToString());
                    lvi.SubItems.Add(l.TenLoai.ToString());
                }    
            }    
        }

        private void HienThiDanhSachNSX()
        {
            listView1.Items.Clear();
            listView1.FullRowSelect = true;
            listView1.View = System.Windows.Forms.View.Details;
            IEnumerable<NHASX> dssnsx = xlnsx.DanhSachNSX();
            if(dssnsx.Count() > 0)
            {
                foreach(NHASX nsx in dssnsx)
                {
                    ListViewItem lvi1;
                    lvi1 = listView1.Items.Add(nsx.MaNSX.ToString());
                    lvi1.SubItems.Add(nsx.TenNSX.ToString());
                }    
            }    
        }

        private void HienThiDanhSachSP()
        {
            lsvSP.Items.Clear();
            lsvSP.FullRowSelect = true;
            lsvSP.View = System.Windows.Forms.View.Details;
            IEnumerable<SANPHAM> dsssp = xlsp.DanhSachSP();
            if (dsssp.Count() > 0)
            {
                foreach (SANPHAM sp in dsssp)
                {
                    ListViewItem lvi2;
                    lvi2 = lsvSP.Items.Add(sp.MaSP.ToString());
                    lvi2.SubItems.Add(sp.TenSP.ToString());
                    lvi2.SubItems.Add(sp.MaLoai.ToString());
                    lvi2.SubItems.Add(sp.MaNSX.ToString());
                    lvi2.SubItems.Add(sp.GiaNhap.ToString());
                    lvi2.SubItems.Add(sp.GiaBan.ToString());
                    lvi2.SubItems.Add(sp.GhiChu.ToString());
                    lvi2.SubItems.Add(sp.Hinh.ToString());
                }
            }
        }

        //Xử lý nút cho loại
        //xử lý nút thêm loại
        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValueLoai();
            setButtonLoai(false);
            txtMaLoai.Focus();
        }
        //xử lý nút sửa thông tin loại
        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            if(lsvLoai.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButtonLoai(false);
                txtMaLoai.Enabled = false;
                txtTenLoai.Focus();
            }
            else
                MessageBox.Show("Bạn phải chọn loại sản phẩm cần sửa", "Sửa loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //xử lý nút xoá thông tin loại
        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            if(lsvLoai.SelectedIndices.Count >0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa loại sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xll.XoaLoai(lsvLoai.SelectedItems[0].SubItems[0].Text);
                    lsvLoai.Items.RemoveAt(lsvLoai.SelectedIndices[0]);
                    ResetValueLoai();
                    frmSanPham_Load(sender, e);
                }    
            }    
        }
        //xử lý nút lưu thông tin loại
        private void btnLuuL_Click(object sender, EventArgs e)
        {
            if(txtMaLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
                return;
            }
            if(txtTenLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoai.Focus();
                return;
            }
            if(themmoi)
            {
                if(xll.KiemTraTonTaiLoai(txtMaLoai.Text.Trim()))
                {
                    MessageBox.Show("Mã loại đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoai.Focus();
                    return;
                }
                xll.LuuL(txtMaLoai.Text.Trim(), txtTenLoai.Text.Trim());
                MessageBox.Show("Thêm mới thành công", "Thêm mới loại sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmSanPham_Load(sender, e);
            } 
            else
            {
                xll.SuaLoai(txtMaLoai.Text.Trim(), txtTenLoai.Text.Trim());
                MessageBox.Show("Sửa thành công", "Sửa loại sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmSanPham_Load(sender, e);
            }
            HienThiDanhSachLoai();
            ResetValueLoai();
            setButtonLoai(true);
        }


        //Xử lý nút cho nhà sản xuất
        //Xử lý nút thêm nhà sản xuất
        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValueNSX();
            setButtonNSX(false);
            txtMaNSX.Focus();
        }
        //Xử lý nút sửa thông tin nhà sản xuất
        private void btnSuaNSX_Click(object sender, EventArgs e)
        {
            if (lsvNSX.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButtonNSX(false);
                txtMaNSX.Enabled = false;
                txtTenNSX.Focus();
            }
            else
                MessageBox.Show("Bạn phải chọn nhà sản xuất cần sửa", "Sửa loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Xử lý nút xoá nhà sản xuất
        private void btnXoaNSX_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa nhà xản xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xlnsx.XoaNSX(listView1.SelectedItems[0].SubItems[0].Text);
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    ResetValueNSX();
                    frmSanPham_Load(sender, e);
                }
            }
        }
        //Xử lý nút lưu nhà sản xuất
        private void btnLuuNSX_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNSX.Focus();
                return;
            }
            if (txtTenNSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNSX.Focus();
                return;
            }
            if (themmoi)
            {
                if (xlnsx.KiemTraTonTaiNSX(txtMaNSX.Text.Trim()))
                {
                    MessageBox.Show("Mã NSX đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNSX.Focus();
                    return;
                }
                xlnsx.LuuNSX(txtMaNSX.Text.Trim(), txtTenNSX.Text.Trim());
                MessageBox.Show("Thêm mới thành công", "Thêm mới nhà sản xuất", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmSanPham_Load(sender, e);
            }
            else
            {
                xlnsx.SuaNSX(txtMaNSX.Text.Trim(), txtTenNSX.Text.Trim());
                MessageBox.Show("Sửa thành công", "Sửa nhà sản xuất", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmSanPham_Load(sender, e);
            }
            HienThiDanhSachNSX();
            ResetValueNSX();
            setButtonNSX(true);
        }


        //Xử lý nút cho sản phẩm
        //Xử lý nút thêm sản phẩm
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValueSP();
            setButtonSP(false);
            txtMaSP.Focus();
        }
        //Xử lý nút sửa sản phẩm
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (lsvSP.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButtonSP(false);
                txtMaSP.Enabled = false;
                txtTenSP.Focus();
            }
            else
                MessageBox.Show("Bạn phải chọn sản phẩm cần sửa", "Sửa loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Xử lý nút xoá sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvSP.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xlsp.XoaSP(lsvSP.SelectedItems[0].SubItems[0].Text);
                    lsvSP.Items.RemoveAt(lsvSP.SelectedIndices[0]);
                    ResetValueSP();
                    frmSanPham_Load(sender, e);
                }
            }
        }
        //Xử lý nút Lưu sản phẩm
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSP.Focus();
                return;
            }
            if (txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }
            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaNhap.Focus();
                return;
            }
            if (txtGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaBan.Focus();
                return;
            }
            if (themmoi)
            {
                if (xlsp.KiemTraTonTai(txtMaSP.Text.Trim()))
                {
                    MessageBox.Show("Mã sản phẩm đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSP.Focus();
                    return;
                }
                xlsp.LuuTruSanPham(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), cbLoai.Text.Trim(), cbNSX.Text.Trim(), txtGiaNhap.Text.Trim(), txtGiaBan.Text.Trim(), txtGhiChu.Text.Trim(), txtHinh.Text.Trim());
                MessageBox.Show("Thêm mới thành công", "Thêm mới sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmSanPham_Load(sender, e);
            }
            else
            {
                xlsp.SuaSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), cbLoai.Text.Trim(), cbNSX.Text.Trim(), txtGiaNhap.Text.Trim(), txtGiaBan.Text.Trim(), txtGhiChu.Text.Trim(), txtHinh.Text.Trim());
                MessageBox.Show("Sửa thành công", "Sửa sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmSanPham_Load(sender, e);
            }
            HienThiDanhSachSP();
            ResetValueSP();
            setButtonSP(true);
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            setButtonLoai(true);
            setButtonNSX(true);
            setButtonSP(true);
        }

        private void btnNL_Click(object sender, EventArgs e)
        {
            ResetValueSP();
            txtMaSP.Focus();
        }


        //hiển thị thông tin loại lên textbox
        private void lsvLoai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lsvLoai.SelectedIndices.Count > 0)
            {
                txtMaLoai.Text = lsvLoai.SelectedItems[0].SubItems[0].Text;
                txtTenLoai.Text = lsvLoai.SelectedItems[0].SubItems[1].Text;
                btnSuaLoai.Enabled = true;
                btnXoaLoai.Enabled = true;
            }
        }
        //hiển thị thông tin nhà sản xuất lên textbox
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                txtMaNSX.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtTenNSX.Text = listView1.SelectedItems[0].SubItems[1].Text;
                btnSuaNSX.Enabled = true;
                btnXoaNSX.Enabled = true;
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtHinh.Text = dlgOpen.FileName;
            }

        }

        private void lsvSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSP.SelectedIndices.Count > 0)
            {
                txtMaSP.Text = lsvSP.SelectedItems[0].SubItems[0].Text;
                txtTenSP.Text = lsvSP.SelectedItems[0].SubItems[1].Text;
                cbLoai.Text = lsvSP.SelectedItems[0].SubItems[2].Text;
                cbNSX.Text = lsvSP.SelectedItems[0].SubItems[3].Text;
                txtGiaNhap.Text = lsvSP.SelectedItems[0].SubItems[4].Text;
                txtGiaBan.Text = lsvSP.SelectedItems[0].SubItems[5].Text;
                txtGhiChu.Text = lsvSP.SelectedItems[0].SubItems[6].Text;
                txtHinh.Text = lsvSP.SelectedItems[0].SubItems[7].Text;
                btnSuaSP.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}
