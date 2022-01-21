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
    
    public partial class frmKhachHang : Form
    {
        XuLyKhachHang xlkh = new XuLyKhachHang();
        bool themmoi = true;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void setButtonKH(bool value)
        {
            btnThemKH.Enabled = value;
            btnSuaKH.Enabled = value;
            btnXoaKH.Enabled = value;
            btnLuu.Enabled = !value;
            btnNLKH.Enabled = !value;

            txtMaKH.Enabled = !value;
            txtTenKH.Enabled = !value;
            txtDC.Enabled = !value;
            txtDT.Enabled = !value;
            txtGmail.Enabled = !value;

        }
        private void ResetValueKH()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDC.Text = "";
            txtDT.Text = "";
            txtGmail.Text = "";
        }
        private void HienThiDanhSachKH()
        {
            lsvKH.Items.Clear();
            lsvKH.FullRowSelect = true;
            lsvKH.View = System.Windows.Forms.View.Details;
            IEnumerable<KHACHHANG> dsskh = xlkh.DanhSachKH();
            if (dsskh.Count() > 0)
            {
                foreach (KHACHHANG kh in dsskh)
                {
                    ListViewItem lvi;
                    lvi = lsvKH.Items.Add(kh.MaKH.ToString());
                    lvi.SubItems.Add(kh.TenKH.ToString());
                    lvi.SubItems.Add(kh.DiaChi.ToString());
                    lvi.SubItems.Add(kh.DienThoai.ToString());
                    lvi.SubItems.Add(kh.Gmail.ToString());
                }
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKH();
            setButtonKH(true);
        }
        
       
        

        private void btnNLKH_Click(object sender, EventArgs e)
        {
            ResetValueKH();
            txtMaKH.Focus();
        }
        //thêm khách hàng
        private void btnThemKH_Click_1(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValueKH();
            setButtonKH(false);
            txtMaKH.Focus();
        }
        //sửa thông tin khách hàng
        private void btnSuaKH_Click_1(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButtonKH(false);
                txtMaKH.Enabled = false;
                txtTenKH.Focus();
                txtDC.Focus();
                txtDT.Focus();
                txtGmail.Focus();
            }
            else
                MessageBox.Show("Bạn phải chọn loại sản phẩm cần sửa", "Sửa loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //xoá thông tin khách hàng
        private void btnXoaKH_Click_1(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa loại sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xlkh.XoaKH(lsvKH.SelectedItems[0].SubItems[0].Text);
                    lsvKH.Items.RemoveAt(lsvKH.SelectedIndices[0]);
                    ResetValueKH();
                }
            }
        }
        //lưu thông tin khách hàng
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (themmoi)
            {
                if (xlkh.KiemTraTonTai(txtMaKH.Text.Trim()))
                {
                    MessageBox.Show("Mã khách hàng đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKH.Focus();
                    return;
                }
                xlkh.LuuKH(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDC.Text.Trim(), txtDT.Text.Trim(), txtGmail.Text.Trim());
                MessageBox.Show("Thêm mới thành công", "Thêm mới khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                xlkh.SuaKH(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDC.Text.Trim(), txtDT.Text.Trim(), txtGmail.Text.Trim());
                MessageBox.Show("Sửa thành công", "Sửa loại sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            HienThiDanhSachKH();
            ResetValueKH();
            setButtonKH(true);
        }

        private void lsvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {
                txtMaKH.Text = lsvKH.SelectedItems[0].SubItems[0].Text;
                txtTenKH.Text = lsvKH.SelectedItems[0].SubItems[1].Text;
                txtDC.Text = lsvKH.SelectedItems[0].SubItems[2].Text;
                txtDT.Text = lsvKH.SelectedItems[0].SubItems[3].Text;
                txtGmail.Text = lsvKH.SelectedItems[0].SubItems[4].Text;
                btnSuaKH.Enabled = true;
                btnXoaKH.Enabled = true;
                btnLuu.Enabled = !true;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            setButtonKH(true);
        }
    }   
}
