using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCoSo.Controllers;
using DoAnCoSo.Model;
namespace DoAnCoSo.View
{
    public partial class frmNhanVien : Form
    {
        XuLyNhanVien xlnv = new XuLyNhanVien();
        bool themmoi = true;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void setButtonNV(bool value)
        {
            btnThemNV.Enabled = value;
            btnSuaNV.Enabled = value;
            btnXoaNV.Enabled = value;
            btnLuuNV.Enabled = !value;
            btnNLNV.Enabled = !value;

            txtMaNV.Enabled = !value;
            txtTenNV.Enabled = !value;
            cbNam.Enabled = !value;
            dateNS.Enabled = !value;
            txtDC.Enabled = !value;
            txtDT.Enabled = !value;
            
        }
        private void ResetValueNV()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cbNam.Checked = false;
            dateNS.Value = DateTime.Now;
            txtDC.Text = "";
            txtDT.Text = "";
            
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            setButtonNV(true);
        }
        private void HienThiDanhSachNhanVien()
        {
            lsvNV.Items.Clear();
            lsvNV.FullRowSelect = true;
            lsvNV.View = System.Windows.Forms.View.Details;
            IEnumerable<NHANVIEN> dssnv = xlnv.DanhSachNV();
            if (dssnv.Count() > 0)
            {
                foreach (NHANVIEN nv in dssnv)
                {
                    ListViewItem lvi;
                    lvi = lsvNV.Items.Add(nv.MaNV.ToString());
                    lvi.SubItems.Add(nv.TenNV.ToString());
                    lvi.SubItems.Add(nv.GioiTinh.ToString());
                    lvi.SubItems.Add(nv.NgaySinh.ToString());
                    lvi.SubItems.Add(nv.DiaChi.ToString());
                    lvi.SubItems.Add(nv.DienThoai.ToString());                   
                }
            }
        }
        //xử lý nút thêm nhân viên
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValueNV();
            setButtonNV(false);
            txtMaNV.Focus();
        }
        //xử lý nút sửa thông tin nhân viên
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (lsvNV.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButtonNV(false);
                txtMaNV.Enabled = true;
                txtTenNV.Focus();
                cbNam.Focus();
                dateNS.Focus();
                txtDC.Focus();
                txtDT.Focus();
                
            }
            else
            {
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //xử lý nút xoá nhân viên
        private void btnXoaNV_Click(object sender, EventArgs e)
        {

        }
        //xử lý nút lưu nhân viên
        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtDC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDC.Focus();
                return;
            }
            if (txtDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDT.Focus();
                return;
            }

            if (themmoi)
            {
                if (xlnv.KiemTraTonTai(txtMaNV.Text.Trim()))
                {
                    MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Focus();
                    return;
                }
                xlnv.LuuTruNhanVien(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), cbNam.Checked, txtDC.Text.Trim(), txtDT.Text.Trim(), dateNS.Value);
                MessageBox.Show("Thêm mới thành công", "Thêm mới nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                xlnv.SuaNhanVien(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), cbNam.Checked, txtDC.Text.Trim(), txtDT.Text.Trim(), dateNS.Value);
                MessageBox.Show("Cập nhật thành công", "Cập nhật nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            HienThiDanhSachNhanVien();
            ResetValueNV();
            setButtonNV(true);
        }
        //xử lý nút nhập lại
        private void btnNLNV_Click(object sender, EventArgs e)
        {
            ResetValueNV();
            txtMaNV.Focus();
        }
        //xử lý nút bỏ qua
        private void btnDong_Click(object sender, EventArgs e)
        {
            setButtonNV(true);
        }

        private void lsvNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNV.SelectedIndices.Count > 0)
            {
                txtMaNV.Text = lsvNV.SelectedItems[0].SubItems[0].Text;
                txtTenNV.Text = lsvNV.SelectedItems[0].SubItems[1].Text;
                cbNam.Text = lsvNV.SelectedItems[0].SubItems[2].Text;
                dateNS.Text = lsvNV.SelectedItems[0].SubItems[3].Text;
                txtDC.Text = lsvNV.SelectedItems[0].SubItems[4].Text;
                txtDT.Text = lsvNV.SelectedItems[0].SubItems[5].Text;
                               
            }
        }
    }
}
