namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.GUI
{
    partial class fm_DangNhap_NVHieu
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
            this.tb_TK_Hieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MK_Hieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangNhap_Hieu = new System.Windows.Forms.Button();
            this.btn_DoiMK_Hieu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_TK_Hieu
            // 
            this.tb_TK_Hieu.Location = new System.Drawing.Point(285, 93);
            this.tb_TK_Hieu.Name = "tb_TK_Hieu";
            this.tb_TK_Hieu.Size = new System.Drawing.Size(196, 22);
            this.tb_TK_Hieu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài Khoản";
            // 
            // tb_MK_Hieu
            // 
            this.tb_MK_Hieu.Location = new System.Drawing.Point(285, 168);
            this.tb_MK_Hieu.Name = "tb_MK_Hieu";
            this.tb_MK_Hieu.Size = new System.Drawing.Size(196, 22);
            this.tb_MK_Hieu.TabIndex = 0;
            this.tb_MK_Hieu.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu";
            // 
            // btnDangNhap_Hieu
            // 
            this.btnDangNhap_Hieu.Location = new System.Drawing.Point(237, 291);
            this.btnDangNhap_Hieu.Name = "btnDangNhap_Hieu";
            this.btnDangNhap_Hieu.Size = new System.Drawing.Size(110, 40);
            this.btnDangNhap_Hieu.TabIndex = 2;
            this.btnDangNhap_Hieu.Text = "Đăng nhập";
            this.btnDangNhap_Hieu.UseVisualStyleBackColor = true;
            this.btnDangNhap_Hieu.Click += new System.EventHandler(this.btnDangNhap_Hieu_Click);
            // 
            // btn_DoiMK_Hieu
            // 
            this.btn_DoiMK_Hieu.Location = new System.Drawing.Point(412, 291);
            this.btn_DoiMK_Hieu.Name = "btn_DoiMK_Hieu";
            this.btn_DoiMK_Hieu.Size = new System.Drawing.Size(110, 40);
            this.btn_DoiMK_Hieu.TabIndex = 3;
            this.btn_DoiMK_Hieu.Text = "Đổi mật khẩu";
            this.btn_DoiMK_Hieu.UseVisualStyleBackColor = true;
            this.btn_DoiMK_Hieu.Click += new System.EventHandler(this.btn_DoiMK_Hieu_Click);
            // 
            // fm_DangNhap_NVHieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_DoiMK_Hieu);
            this.Controls.Add(this.btnDangNhap_Hieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_MK_Hieu);
            this.Controls.Add(this.tb_TK_Hieu);
            this.Name = "fm_DangNhap_NVHieu";
            this.Text = "fm_DangNhap_NVHieu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_TK_Hieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MK_Hieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDangNhap_Hieu;
        private System.Windows.Forms.Button btn_DoiMK_Hieu;
    }
}