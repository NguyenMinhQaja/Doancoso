
namespace DoAnCoSo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lalTitle = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.PanelLogo = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelMenu.Controls.Add(this.btnThoat);
            this.panelMenu.Controls.Add(this.btnNhanVien);
            this.panelMenu.Controls.Add(this.btnDonHang);
            this.panelMenu.Controls.Add(this.btnKH);
            this.panelMenu.Controls.Add(this.btnSP);
            this.panelMenu.Controls.Add(this.PanelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 624);
            this.panelMenu.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnThoat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnThoat.Image = global::DoAnCoSo.Properties.Resources.close2;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(0, 320);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(220, 60);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "    Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnNhanVien.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNhanVien.Image = global::DoAnCoSo.Properties.Resources.staff__1_;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 260);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(220, 60);
            this.btnNhanVien.TabIndex = 4;
            this.btnNhanVien.Text = "    Nhân Viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDonHang.FlatAppearance.BorderSize = 0;
            this.btnDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnDonHang.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnDonHang.Image = global::DoAnCoSo.Properties.Resources.check_list;
            this.btnDonHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHang.Location = new System.Drawing.Point(0, 200);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(220, 60);
            this.btnDonHang.TabIndex = 3;
            this.btnDonHang.Text = "    Đơn Hàng";
            this.btnDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDonHang.UseVisualStyleBackColor = false;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            this.btnDonHang.Leave += new System.EventHandler(this.btnDonHang_Leave);
            // 
            // btnKH
            // 
            this.btnKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKH.FlatAppearance.BorderSize = 0;
            this.btnKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnKH.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnKH.Image = global::DoAnCoSo.Properties.Resources.customer;
            this.btnKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKH.Location = new System.Drawing.Point(0, 140);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(220, 60);
            this.btnKH.TabIndex = 2;
            this.btnKH.Text = "    Khách Hàng";
            this.btnKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // btnSP
            // 
            this.btnSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSP.FlatAppearance.BorderSize = 0;
            this.btnSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnSP.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSP.Image = global::DoAnCoSo.Properties.Resources.shopping_cart__1_;
            this.btnSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSP.Location = new System.Drawing.Point(0, 80);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(220, 60);
            this.btnSP.TabIndex = 1;
            this.btnSP.Text = "    Sản Phẩm";
            this.btnSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnCloseChildForm);
            this.panel1.Controls.Add(this.lalTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 80);
            this.panel1.TabIndex = 1;
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::DoAnCoSo.Properties.Resources.close;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(75, 80);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lalTitle
            // 
            this.lalTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lalTitle.AutoSize = true;
            this.lalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lalTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lalTitle.Location = new System.Drawing.Point(435, 27);
            this.lalTitle.Name = "lalTitle";
            this.lalTitle.Size = new System.Drawing.Size(85, 29);
            this.lalTitle.TabIndex = 0;
            this.lalTitle.Text = "HOME";
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.BackgroundImage = global::DoAnCoSo.Properties.Resources.Hinh_nen;
            this.panelDesktopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(220, 80);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelDesktopPanel.Size = new System.Drawing.Size(944, 544);
            this.panelDesktopPanel.TabIndex = 2;
            // 
            // PanelLogo
            // 
            this.PanelLogo.Controls.Add(this.btnLogo);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(220, 80);
            this.PanelLogo.TabIndex = 0;
            // 
            // btnLogo
            // 
            this.btnLogo.Image = global::DoAnCoSo.Properties.Resources.logo;
            this.btnLogo.Location = new System.Drawing.Point(3, 3);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(220, 80);
            this.btnLogo.TabIndex = 0;
            this.btnLogo.UseVisualStyleBackColor = true;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 624);
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Quản Lý Nhạc Cụ";
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lalTitle;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.FlowLayoutPanel PanelLogo;
        private System.Windows.Forms.Button btnLogo;
    }
}

