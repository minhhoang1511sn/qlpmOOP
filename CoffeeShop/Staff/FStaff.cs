using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FStaff : Form
    {
        private readonly NhanvienBul _nvBul = new();
        private readonly TaikhoanBul _tkBul = new();
        private int _manv;
        private bool _nutThem, _nutSua;

        public FStaff()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #region Method

        private void Xulybuttion(bool b)
        {
            btThem.Enabled = dgvStaff.Enabled = btTim.Enabled = btLamMoi.Enabled = txttim.Enabled =
                btSua.Enabled = btXoa.Enabled = b;
            btLuu.Enabled = btHuy.Enabled = !b;
        }

        private void Mo()
        {
            txttennv.ReadOnly = false;
            datengaysinh.Enabled = true;
            txtsdt.ReadOnly = false;
            cbgioitinh.Enabled = true;
            txtmatkhau.ReadOnly = false;
            cbquyen.Enabled = true;
            txttentk.ReadOnly = false;
            txtmanv.Hide();
            lbmanv.Hide();
        }

        private void Tat()
        {
            txttennv.ReadOnly = true;
            datengaysinh.Enabled = false;
            txtsdt.ReadOnly = true;
            cbgioitinh.Enabled = false;
            txtmatkhau.ReadOnly = true;
            cbquyen.Enabled = false;
            txttentk.ReadOnly = true;
            txtmanv.Show();
            lbmanv.Show();
        }

        private void LoadDataGrid()
        {
            bindingSource1.DataSource = _nvBul.load_nhanvien();
            dgvStaff.DataSource = bindingSource1;
        }

        private void EditDataGrid()
        {
            dgvStaff.ReadOnly = true;
            dgvStaff.Columns[0].HeaderText = @"Mã nhân viên";
            dgvStaff.Columns[1].HeaderText = @"Tên nhân viên";
            dgvStaff.Columns[2].HeaderText = @"Ngày sinh";
            dgvStaff.Columns[3].HeaderText = @"Số điện thoại";
            dgvStaff.Columns[4].HeaderText = @"Giới tính";
            dgvStaff.Columns[5].HeaderText = @"Tên tài khoản";
            dgvStaff.Columns[6].HeaderText = @"Mật khẩu";
            dgvStaff.Columns[7].HeaderText = @"Quyền";
        }

        private void InsertStaff()
        {
            _manv = _nvBul.count_nhanvien();
            var nvPublic = new NHANVIEN_PUBLIC
            {
                IDNV = "NV" + _manv,
                TENNV = txttennv.Text,
                NGAYSINH = DateTime.Parse(datengaysinh.Text),
                SDT = txtsdt.Text,
                GIOITINH = cbgioitinh.Text
            };
            _nvBul.insert_nhanvien(nvPublic);
        }

        private void InsertAccount()
        {
            var tkPublic = new TAIKHOAN_PUBLIC
            {
                TENTK = txttentk.Text,
                MATKHAU = txtmatkhau.Text,
                QUYEN = cbquyen.Text,
                IDNV = "NV" + _manv
            };
            _tkBul.insert_taikhoan(tkPublic);
        }

        private void UpdateStaff()
        {
            var staffPublic = new NHANVIEN_PUBLIC
            {
                IDNV = txtmanv.Text,
                TENNV = txttennv.Text,
                NGAYSINH = DateTime.Parse(datengaysinh.Text),
                SDT = txtsdt.Text,
                GIOITINH = cbgioitinh.Text
            };
            _nvBul.update_nhanvien(staffPublic);
        }

        private void UpdateAccount()
        {
            var accountPublic = new TAIKHOAN_PUBLIC
            {
                TENTK = txttentk.Text,
                MATKHAU = txtmatkhau.Text,
                QUYEN = cbquyen.Text,
                IDNV = txtmanv.Text
            };
            _tkBul.update_taikhoan(accountPublic);
        }

        private void DeleteAccount()
        {
            var accountPublic = new TAIKHOAN_PUBLIC {TENTK = txttentk.Text};
            _tkBul.delete_taikhoan(accountPublic);
        }

        private void DeleteStaff()
        {
            var staffPublic = new NHANVIEN_PUBLIC {IDNV = txtmanv.Text};
            _nvBul.delete_nhanvien(staffPublic);
        }

        private void DeleteStaff_Error()
        {
            var staffPublic = new NHANVIEN_PUBLIC {IDNV = "NV" + _manv};
            _nvBul.delete_nhanvien(staffPublic);
        }

        #endregion

        #region Event

        private void FStaff_Load(object sender, EventArgs e)
        {
            Xulybuttion(true);
            LoadDataGrid();
            EditDataGrid();
            dgvStaff.Rows[0].Selected = true;
            txtmanv.ReadOnly = true;
            txttentk.ReadOnly = true;
            Tat();
            cbquyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            _nutThem = true;
            Mo();
            Xulybuttion(false);
            txttennv.Focus();
            Clear();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            _nutSua = true;
            Mo();
            txttentk.ReadOnly = true;
            Xulybuttion(false);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(@"Muốn xóa một nhân viên?", @"Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question))
            {
                DeleteAccount();
                DeleteStaff();
                LoadDataGrid();
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (_nutThem)
            {
                if (txttennv.TextLength == 0)
                    MessageBox.Show(@"Chưa điền tên nhân viên.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (datengaysinh.Value.Year == DateTime.Today.Year)
                    MessageBox.Show(@"Chưa chọn ngày sinh.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtsdt.TextLength == 0)
                    MessageBox.Show(@"Chưa nhập số điện thoại.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (cbgioitinh.Text == "")
                    MessageBox.Show(@"Chưa chọn giới tính.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txttentk.TextLength == 0)
                    MessageBox.Show(@"Chưa điền tên tài khoản.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtmatkhau.TextLength == 0)
                    MessageBox.Show(@"Chưa điền mật khẩu.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txtmatkhau.TextLength < 6)
                    MessageBox.Show(@"Mật khẩu quá ngắn, phải lớn hơn 6 ký tự.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (cbquyen.Text == "")
                    MessageBox.Show(@"Chưa chọn quyền.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txttentk.TextLength <= 3)
                    MessageBox.Show(@"Tên tài khoản quá ngắn, phải dài hơn 3 ký tự.", @"Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txttennv.TextLength >= 100)
                    MessageBox.Show(@"Tên nhân viên quá dài.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtsdt.TextLength >= 13)
                    MessageBox.Show(@"Số điện thoại quá dài.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txttentk.TextLength >= 50)
                    MessageBox.Show(@"Tên tài quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txtmatkhau.TextLength > 20)
                    MessageBox.Show(@"Mật khẩu quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    try
                    {
                        _nutThem = false;
                        InsertStaff();
                        InsertAccount();
                        LoadDataGrid();
                        Tat();
                        Xulybuttion(true);
                    }
                    catch (SqlException loi)
                    {
                        if (loi.Message.Contains("Violation of PRIMARY KEY constraint 'PK_TENTK'"))
                        {
                            MessageBox.Show(@"Tên tài khoản bị trùng.", @"Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            DeleteStaff_Error();
                            _nutThem = true;
                        }
                    }
            }
            else if (_nutSua)
            {
                if (txttennv.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền tên nhân viên.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (datengaysinh.Value.Year == DateTime.Today.Year)
                {
                    MessageBox.Show(@"Chưa chọn ngày sinh.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txtsdt.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa nhập số điện thoại.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (cbgioitinh.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn giới tính.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txttentk.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền tên tài khoản.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txtmatkhau.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền mật khẩu.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtmatkhau.TextLength < 6)
                {
                    MessageBox.Show(@"Mật khẩu quá ngắn, phải lớn hơn 6 ký tự.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (cbquyen.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn quyền.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txttentk.TextLength <= 3)
                {
                    MessageBox.Show(@"Tên tài khoản quá ngắn, phải dài hơn 3 ký tự.", @"Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txttennv.TextLength >= 100)
                {
                    MessageBox.Show(@"Tên nhân viên quá dài.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txtsdt.TextLength >= 13)
                {
                    MessageBox.Show(@"Số điện thoại quá dài.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txttentk.TextLength >= 50)
                {
                    MessageBox.Show(@"Tên tài quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtmatkhau.TextLength > 20)
                {
                    MessageBox.Show(@"Mật khẩu quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    UpdateStaff();
                    UpdateAccount();

                    Tat();
                    Xulybuttion(true);
                    _nutSua = false;
                    LoadDataGrid();
                }
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            if (_nutThem)
            {
                LoadDataGrid();
                Xulybuttion(true);
                Tat();
                _nutThem = false;
            }
            else if (_nutSua)
            {
                Tat();
                Xulybuttion(true);
                _nutSua = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            if (txttim.TextLength == 0)
            {
                MessageBox.Show(@"Chưa nhập tên nhân viên cần tìm.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var nvPublic = new NHANVIEN_PUBLIC {TIMTEN = txttim.Text};
                dgvStaff.DataSource = _nvBul.Tim_nv(nvPublic);
                dgvStaff.Rows[0].Selected = true;
            }
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            dgvStaff.DataSource = _nvBul.load_nhanvien();
            txttim.Clear();
        }

        private void dgvStaff_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dong = e.RowIndex;
                txtmanv.Text = dgvStaff.Rows[dong].Cells[0].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[0].Value.ToString().Trim();
                txttennv.Text = dgvStaff.Rows[dong].Cells[1].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[1].Value.ToString().Trim();
                datengaysinh.Text = dgvStaff.Rows[dong].Cells[2].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[2].Value.ToString().Trim();
                txtsdt.Text = dgvStaff.Rows[dong].Cells[3].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[3].Value.ToString().Trim();
                cbgioitinh.Text = dgvStaff.Rows[dong].Cells[4].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[4].Value.ToString().Trim();
                txttentk.Text = dgvStaff.Rows[dong].Cells[5].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[5].Value.ToString().Trim();
                txtmatkhau.Text = dgvStaff.Rows[dong].Cells[6].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[6].Value.ToString().Trim();
                cbquyen.Text = dgvStaff.Rows[dong].Cells[7].Value == null
                    ? string.Empty
                    : dgvStaff.Rows[dong].Cells[7].Value.ToString().Trim();
            }
            catch
            {
                // ignored
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox) sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void dgvStaff_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void txttentk_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txttennv_Leave(object sender, EventArgs e)
        {
            
        }

        private void txttennv_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Clear()
        {
            txttennv.Clear();
            datengaysinh.ResetText();
            txtsdt.Clear();
            cbgioitinh.SelectedIndex = -1;
            txttentk.Clear();
            txtmatkhau.Clear();
            cbquyen.SelectedIndex = -1;
        }

        #endregion
    }
}