namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.GUI
{
    partial class frm_DangNhap_Hieu
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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_TenDN_Hieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MatKhau_Hieu = new System.Windows.Forms.TextBox();
            this.btn_DangNhap_Hieu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đăng nhập";
            // 
            // tb_TenDN_Hieu
            // 
            this.tb_TenDN_Hieu.Location = new System.Drawing.Point(310, 150);
            this.tb_TenDN_Hieu.Name = "tb_TenDN_Hieu";
            this.tb_TenDN_Hieu.Size = new System.Drawing.Size(166, 26);
            this.tb_TenDN_Hieu.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên đăng nhập";
            // 
            // tb_MatKhau_Hieu
            // 
            this.tb_MatKhau_Hieu.Location = new System.Drawing.Point(310, 220);
            this.tb_MatKhau_Hieu.Name = "tb_MatKhau_Hieu";
            this.tb_MatKhau_Hieu.Size = new System.Drawing.Size(166, 26);
            this.tb_MatKhau_Hieu.TabIndex = 8;
            this.tb_MatKhau_Hieu.UseSystemPasswordChar = true;
            // 
            // btn_DangNhap_Hieu
            // 
            this.btn_DangNhap_Hieu.Location = new System.Drawing.Point(310, 321);
            this.btn_DangNhap_Hieu.Name = "btn_DangNhap_Hieu";
            this.btn_DangNhap_Hieu.Size = new System.Drawing.Size(151, 37);
            this.btn_DangNhap_Hieu.TabIndex = 9;
            this.btn_DangNhap_Hieu.Text = "Đăng nhập";
            this.btn_DangNhap_Hieu.UseVisualStyleBackColor = true;
            this.btn_DangNhap_Hieu.Click += new System.EventHandler(this.btn_DangNhap_Hieu_Click);
            // 
            // frm_DangNhap_Hieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_DangNhap_Hieu);
            this.Controls.Add(this.tb_MatKhau_Hieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_TenDN_Hieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_DangNhap_Hieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_DangNhap_Hieu";
           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_TenDN_Hieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MatKhau_Hieu;
        private System.Windows.Forms.Button btn_DangNhap_Hieu;
    }
}