using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCoSo.View;


namespace DoAnCoSo
{

    public partial class Form1 : Form
    {
        private Button currentButton;
        
        public Form1()

        {

            InitializeComponent();
            btnCloseChildForm.Visible = false;
        }
        
        //Sự kiện các nút Menu
        private void btnSP_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmSanPham());
            
        }
        private void btnKH_Click(object sender, EventArgs e)
        {

            ActivateButton(sender);
            openChildForm(new frmKhachHang());
 
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmHoaDon());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmNhanVien());
        }

        private void btnDonHang_Leave(object sender, EventArgs e)
        {
            
        }
        private Form activeForm = null;

        //kích hoạt nút
        private void ActivateButton(object btnSender)
        {
            if (btnSender!=null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(46, 51, 73);
                    btnCloseChildForm.Visible = true;
                }
            }            
        }

        //vô hiệu nút
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(24, 30, 54);
                }
            }
        }
        
        //mở giao diện con
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();           
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktopPanel.Controls.Add(childForm);
            panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lalTitle.Text = childForm.Text;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lalTitle.Text = "HOME";
            btnCloseChildForm.Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
    }
}
