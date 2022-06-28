using System;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FStatistic : Form
    {
        public static FStatistic Tkdt;
        private readonly HoadonOldBul _hoadonOldBul = new();
        private bool _bngay, _bthang, _bnam;
        private bool _checktim, _checktimtennv;

        public FStatistic()
        {
            InitializeComponent();
            Tkdt = this;
        }

        #region Method

        private void load_hoadon_old()
        {
            bindingSource1.DataSource = _hoadonOldBul.load_hoadon_old();
            dg_hoadon.DataSource = bindingSource1;
        }

        private void EditDataGrid()
        {
            var dinhdangso = "###,###,##0";
            dg_hoadon.ReadOnly = true;
            dg_hoadon.Columns[0].Visible = false;
            dg_hoadon.Columns[1].HeaderText = @"Mã hóa đơn";
            dg_hoadon.Columns[2].HeaderText = @"Tên bàn";
            dg_hoadon.Columns[3].HeaderText = @"Tên nhân viên";
            dg_hoadon.Columns[4].HeaderText = @"Ngày lập hóa đơn";
            dg_hoadon.Columns[5].HeaderText = @"Thanh toán";
            dg_hoadon.Columns[6].HeaderText = @"Tổng tiền(VNĐ)";
            dg_hoadon.Columns[6].DefaultCellStyle.Format = dinhdangso;
        }

        private void rdNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNgay.Checked)
            {
                cbngay.Enabled = true;
                cbthang.Enabled = false;
                cbnam.Enabled = false;
            }
        }

        private void rdThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThang.Checked)
            {
                cbthang.Enabled = true;
                cbngay.Enabled = false;
                cbnam.Enabled = false;
            }
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNam.Checked)
            {
                cbnam.Enabled = true;
                cbthang.Enabled = false;
                cbngay.Enabled = false;
            }
        }

        #endregion

        #region Event

        private void FStatistic_Load(object sender, EventArgs e)
        {
            load_hoadon_old();
            EditDataGrid();
            lbmahd.Hide();
            cbngay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbngay.Enabled = false;
            cbthang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbthang.Enabled = false;
            cbnam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbnam.Enabled = false;
        }

        private void dg_hoadon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dong = e.RowIndex;
                lbmahd.Text = dg_hoadon.Rows[dong].Cells[1].Value == null
                    ? string.Empty
                    : dg_hoadon.Rows[dong].Cells[1].Value.ToString().Trim();
                dg_hoadon.Rows[dong].Selected = true;
            }
            catch
            {
                // ignored
            }
        }

        private void dg_hoadon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void btXemCthd_Click(object sender, EventArgs e)
        {
            var cthdOld = new FBillInfo {MahoadonOld = int.Parse(lbmahd.Text)};
            cthdOld.ShowDialog();
        }

        private void bttim_Click(object sender, EventArgs e)
        {
            _checktim = true;
            var hdOldPubluc = new HOADON_OLD_PUBLIC {Soban = "Bàn số: " + Soban.Value};
            dg_hoadon.DataSource = _hoadonOldBul.load_timhd_old(hdOldPubluc);
            cbngay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbngay.Enabled = false;
            cbthang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbthang.Enabled = false;
            cbnam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbnam.Enabled = false;
            rdNgay.Checked = false;
            rdThang.Checked = false;
            rdNam.Checked = false;
            cbngay.SelectedIndex = -1;
            cbthang.SelectedIndex = -1;
            cbnam.SelectedIndex = -1;
        }

        public void btlammoi_Click(object sender, EventArgs e)
        {
            FStatistic_Load(sender, e);
            rdNgay.Checked = false;
            rdThang.Checked = false;
            rdNam.Checked = false;
            cbngay.SelectedIndex = -1;
            cbthang.SelectedIndex = -1;
            cbnam.SelectedIndex = -1;
            _checktim = false;
            Soban.Value = 1;
            txttennhanvien.Clear();
        }

        private void bttinhdt_Click(object sender, EventArgs e)
        {
            if (rdNgay.Checked)
            {
                if (cbngay.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn ngày.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var tdt = new FRevenue {Ngay = int.Parse(cbngay.Text)};
                    _bngay = true;
                    tdt.Bngay = _bngay;
                    tdt.FormClosing += tdt.FRevenue_FormClosing;
                    tdt.ShowDialog();
                }
            }
            else if (rdThang.Checked)
            {
                if (cbthang.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn tháng.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var tdt = new FRevenue {Thang = int.Parse(cbthang.Text)};
                    _bthang = true;
                    tdt.Bthang = _bthang;
                    tdt.FormClosing += tdt.FRevenue_FormClosing;
                    tdt.ShowDialog();
                }
            }
            else if (rdNam.Checked)
            {
                if (cbnam.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn năm.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var tdt = new FRevenue {Nam = int.Parse(cbnam.Text)};
                    _bnam = true;
                    tdt.Bnam = _bnam;
                    tdt.FormClosing += tdt.FRevenue_FormClosing;
                    tdt.ShowDialog();
                }
            }
            else if (_checktim)
            {
                var tdt = new FRevenue {Timcheck = true, Tenban = "Bàn số: " + Soban.Value};
                tdt.FormClosing += tdt.FRevenue_FormClosing;
                tdt.ShowDialog();
                _checktim = false;
            }
            else if (_checktimtennv)
            {
                var tdt = new FRevenue {Checkten = true, Tenban = txttennhanvien.Text};
                tdt.FormClosing += tdt.FRevenue_FormClosing;
                tdt.ShowDialog();
                _checktimtennv = false;
            }
            else
            {
                // thực hiện tính tổng doanh thu của tất cả các hóa đơn
                var tdt = new FRevenue();
                tdt.FormClosing += tdt.FRevenue_FormClosing;
                tdt.ShowDialog();
            }
        }


        private void bttimnhanvien_Click(object sender, EventArgs e)
        {
            _checktimtennv = true;
            var hdOldPubluc = new HOADON_OLD_PUBLIC {TENNV = txttennhanvien.Text};
            dg_hoadon.DataSource = _hoadonOldBul.load_timhd_old_TENNV(hdOldPubluc);
            cbngay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbngay.Enabled = false;
            cbthang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbthang.Enabled = false;
            cbnam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbnam.Enabled = false;
            rdNgay.Checked = false;
            rdThang.Checked = false;
            rdNam.Checked = false;
            cbngay.SelectedIndex = -1;
            cbthang.SelectedIndex = -1;
            cbnam.SelectedIndex = -1;
        }

        private void btlammoi1_Click(object sender, EventArgs e)
        {
            FStatistic_Load(sender, e);
            rdNgay.Checked = false;
            rdThang.Checked = false;
            rdNam.Checked = false;
            cbngay.SelectedIndex = -1;
            cbthang.SelectedIndex = -1;
            cbnam.SelectedIndex = -1;
            _checktim = false;
            Soban.Value = 1;
            txttennhanvien.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion
    }
}