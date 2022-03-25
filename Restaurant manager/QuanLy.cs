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
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }
        public bool CheckControl()
        {
            if (string.IsNullOrWhiteSpace(txtCuaHangSo.Text))
            {
                MessageBox.Show("Bạn chưa nhập cửa hàng số mấy!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCuaHangSo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbxKhuVuc.Text))
            {
                MessageBox.Show("Bạn chưa chọn khu vực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxKhuVuc.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenQuanLy.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên của quản lý!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenQuanLy.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại của quản lý!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Bạn chưa nhập email của quản lý!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        int indexLv = -1;
        int tongcuahang = 1;
        List<DanhSachModel> danhSachs = new List<DanhSachModel>();
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (CheckControl())
            {
                DanhSachModel ds = new DanhSachModel();
                ds.stt = tongcuahang;
                ds.CuaHangSo = txtCuaHangSo.Text;
                ds.KhuVuc = cbxKhuVuc.Text;
                ds.DiaChi = txtDiaChi.Text;
                ds.Ngay = dtpNgay.Text;
                ds.TenQuanLy = txtTenQuanLy.Text;
                ds.SDT = txtSDT.Text;
                ds.Email = txtEmail.Text;
                danhSachs.Add(ds);

                ListViewItem listViewItem = new ListViewItem(new string[] { ds.stt.ToString(), ds.CuaHangSo, ds.KhuVuc, ds.DiaChi, ds.Ngay, ds.TenQuanLy, ds.SDT, ds.Email });
                lvDanhSachCuaHang.Items.Add(listViewItem);
                tongcuahang += 1;

                MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                SetDefault();
            }

        }
        public void SetDefault()
        {
            foreach (Control ctr in gbxThongTinCuaHang.Controls)
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

        private void lvDanhSachCuaHang_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem viewItem = e.Item;
            txtCuaHangSo.Text = viewItem.SubItems[1].Text;
            cbxKhuVuc.Text = viewItem.SubItems[2].Text;
            txtDiaChi.Text = viewItem.SubItems[3].Text;
            dtpNgay.Text = viewItem.SubItems[4].Text;
            txtTenQuanLy.Text = viewItem.SubItems[5].Text;
            txtSDT.Text = viewItem.SubItems[6].Text;
            txtEmail.Text = viewItem.SubItems[7].Text;
            indexLv = e.ItemIndex;
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (indexLv < 0)
            {
                MessageBox.Show("Chưa chọn thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lvDanhSachCuaHang.Items[indexLv].SubItems[1].Text = txtCuaHangSo.Text;
            lvDanhSachCuaHang.Items[indexLv].SubItems[2].Text = cbxKhuVuc.Text;
            lvDanhSachCuaHang.Items[indexLv].SubItems[3].Text = txtDiaChi.Text;
            lvDanhSachCuaHang.Items[indexLv].SubItems[4].Text = dtpNgay.Text;
            lvDanhSachCuaHang.Items[indexLv].SubItems[5].Text = txtTenQuanLy.Text;
            lvDanhSachCuaHang.Items[indexLv].SubItems[6].Text = txtSDT.Text;
            lvDanhSachCuaHang.Items[indexLv].SubItems[7].Text = txtEmail.Text;
            indexLv = -1;
            
            MessageBox.Show("Cập Nhập Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            SetDefault();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if( indexLv < 0)
            {
                MessageBox.Show("Chưa chọn cửa hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lvDanhSachCuaHang.Items.RemoveAt(indexLv);
                indexLv = -1;
                
                MessageBox.Show("Xóa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                SetDefault();
            }    
        }

        private void QuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(tukhoa))
            {
                lvDanhSachCuaHang.Items.Clear();
                List<DanhSachModel> kqtimkiem = new List<DanhSachModel>();
                kqtimkiem = danhSachs.Where(s => s.CuaHangSo.Contains(tukhoa) || s.KhuVuc.Contains(tukhoa) || s.DiaChi.Contains(tukhoa) || s.Ngay == tukhoa || s.TenQuanLy.Contains(tukhoa) || s.SDT.Contains(tukhoa) || s.Email.Contains(tukhoa)).ToList();
                if (kqtimkiem .Count != 0)
                {
                    for (int i = 0 ; i < kqtimkiem.Count ; i++)
                    {
                        DanhSachModel danhSach = kqtimkiem[i];
                        ListViewItem listViewItem = new ListViewItem(new string[] { danhSach.stt.ToString(), danhSach.CuaHangSo, danhSach.KhuVuc, danhSach.DiaChi, danhSach.Ngay, danhSach.TenQuanLy, danhSach.SDT, danhSach.Email });
                        lvDanhSachCuaHang.Items.Add(listViewItem);
                    }

                }
            }
            else
            {
                MessageBox.Show("Nhập từ khóa cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            for (int i=0;i<10;i++)
            {
                DanhSachModel danhSach = new DanhSachModel();
                danhSach.stt = (i);
                danhSach.CuaHangSo = "" + (i).ToString();
                danhSach.KhuVuc = "" + (i).ToString();
                danhSach.DiaChi = "" + (i).ToString();
                danhSach.Ngay = "" + (i).ToString();
                danhSach.TenQuanLy = "" + (i).ToString();
                danhSach.SDT = "0000000000" + (i).ToString();
                danhSach.Email = "abc@uef.edu.vn" + (i).ToString();
                danhSachs.Add(danhSach);
            }
        }

        
    }
}
