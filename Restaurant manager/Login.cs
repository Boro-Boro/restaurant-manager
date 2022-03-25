using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiCuaHang
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtDangNhap.Text;
            string passWord = txtMatKhau.Text;  
            if (userName == "duythanh3333" && passWord == "123")
            {
              
                QuanLy quanLy = new QuanLy();
                MessageBox.Show("Đăng nhập thành công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.None);
                this.Hide();
                quanLy.ShowDialog();
                this.Show();
                SetDefault();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                SetDefault();
            }
        }
        public void SetDefault()
        {
            foreach (Control ctr in pnlDangNhap.Controls)
            {
                
                
                    if (ctr is TextBox)
                    {
                        TextBox txt = (TextBox)ctr;
                        txt.Text = "";
                    }
                    else
                    {
                        if (ctr is ComboBox)
                        {
                            ComboBox cb = (ComboBox)ctr;
                            cb.Text = "";
                        }
                        else
                        {
                            if (ctr is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)ctr;
                                dtp.Value = DateTime.Now;
                            }
                        }
                    }
                    
            } 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?","Thông Báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
