using System;
using System.Drawing;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FTableManager : Form
    {
        public static FTableManager Table;

        private readonly BanBul _banBul = new();
        private readonly CthdBul _cthdBul = new();
        private readonly DmdouongBul _dmdouongBul = new();
        private readonly DouongBul _douongBul = new();
        private readonly HoadonBul _hdBul = new();

        private int _idban;
        private int _idhd;
        private int _madouongXoa;
        private int _mahoadonXoa;
        private string _tenban = "";
        private string _trangthaiban = "";

        public FTableManager()
        {
            InitializeComponent();
            Table = this;
        }

        #region Method

        public string Idnv { get; set; }

        public string Quyen { get; set; }

        public void CreateTable()
        {
            flpTable.Controls.Clear();
            var listTable = _banBul.Loaddsban();
            foreach (var dong in listTable)
            {
                var bt = new Button {Tag = dong, Width = 100, Height = 100, Text = dong.TEN + "\n" + dong.TRANGTHAI};
                bt.Click += btn_click;
                bt.BackColor = dong.TRANGTHAI switch
                {
                    "Trống" => Color.YellowGreen,
                    "Có người" => Color.DarkRed,
                    _ => bt.BackColor
                };
                flpTable.Controls.Add(bt);
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            _idban = ((BAN_PUBLIC) ((Button) sender).Tag).IDBAN;
            _tenban = (((Button) sender)?.Tag as BAN_PUBLIC)?.TEN;
            _trangthaiban = (((Button) sender)?.Tag as BAN_PUBLIC)?.TRANGTHAI;
            DSMON.Text = @"Danh sách món ăn của " + _tenban;
            var hdPublic = new HOADON_PUBLIC {IDBAN = _idban};
            var numberOfBillTable = _hdBul.count_hoadon_ban(hdPublic);
            if (numberOfBillTable == 0)
            {
                hdPublic.IDNV = Idnv;
                hdPublic.NGAYLAP = DateTime.Now;
                hdPublic.TRANGTHAI = @"Chưa";
                _hdBul.insert_hoadon(hdPublic);
                CreateTable();
            }

            _idhd = _hdBul.load_IDHD_WITH_IDBAN(hdPublic);
            Load_CTHD(_idhd);
            numericsoluongdoan.Value = 1;
        }

        internal void Load_CTHD(int mahoadon)
        {
            var cthdPublic = new CTHD_PUBLIC {IDHOADON = mahoadon};
            bindingSource1.DataSource = _cthdBul.load_cthd(cthdPublic);
            dg_monan_ofban.DataSource = bindingSource1;
            EditDataGrid();
        }

        private void EditDataGrid()
        {
            dg_monan_ofban.ReadOnly = true;
            var dinhdangso = "###,###,##0";
            dg_monan_ofban.Columns[0].Visible = false;
            dg_monan_ofban.Columns[1].Visible = false;
            dg_monan_ofban.Columns[2].Visible = false;
            dg_monan_ofban.Columns[3].HeaderText = @"Tên món";
            dg_monan_ofban.Columns[4].HeaderText = @"Số lượng";
            dg_monan_ofban.Columns[5].HeaderText = @"Đơn giá (VNĐ)";
            dg_monan_ofban.Columns[5].DefaultCellStyle.Format = dinhdangso;
            dg_monan_ofban.Columns[6].HeaderText = @"Thành tiền (VNĐ)";
            dg_monan_ofban.Columns[6].DefaultCellStyle.Format = dinhdangso;
            dg_monan_ofban.Columns[7].Visible = false;
        }

        private void Quyennv()
        {
            lbAddTable.Hide();
            Soban.Hide();
            btnAddTable.Hide();
            btnEditTable.Visible = false;
        }

        internal void HideShow_ThemBan()
        {
            dg_dsban.DataSource = _banBul.load_ban();
            dg_dsban.Hide();
            if (dg_dsban.Rows.Count > 1)
            {
                lbAddTable.Hide();
                Soban.Hide();
                btnAddTable.Hide();
            }
            else
            {
                lbAddTable.Show();
                Soban.Show();
                btnAddTable.Show();
            }
        }

        #endregion

        #region Events

        internal void FTableManager_Load(object sender, EventArgs e)
        {
            if (Quyen == @"NHANVIEN") Quyennv();
            CreateTable();
            HideShow_ThemBan();
            cbdanhmuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbten.DropDownStyle = ComboBoxStyle.DropDownList;
            cbgia.DropDownStyle = ComboBoxStyle.DropDownList;
            var dt = _dmdouongBul.load_dmdouong();
            cbdanhmuc.DataSource = dt;
            cbdanhmuc.DisplayMember = @"TENDM";
            cbiddm.DataSource = dt;
            cbiddm.DisplayMember = @"IDDM";
            cbiddm.Hide();
            cbiddouong.Hide();
            flpTable.AutoScroll = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (dg_monan_ofban.Rows.Count == 0)
            {
                MessageBox.Show(@"Chọn một bàn rồi thêm món.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (cbten.Text == "")
            {
                MessageBox.Show(@"Chưa chọn món.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var billInfoPublic = new CTHD_PUBLIC();
                var bPublic = new BAN_PUBLIC();
                billInfoPublic.IDHOADON = _idhd;
                billInfoPublic.IDDOUONG = int.Parse(cbiddouong.Text);
                billInfoPublic.SOLUONG = (int) numericsoluongdoan.Value;
                _cthdBul.insert_cthd(billInfoPublic);
                bPublic.IDBAN = _idban;
                bPublic.TRANGTHAI = @"Có người";
                _banBul.update_trangthaiban(bPublic);
                if (_trangthaiban == @"Trống") CreateTable();
                Load_CTHD(_idhd);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dg_monan_ofban.Rows.Count == 0)
            {
                MessageBox.Show(@"Chọn một bàn rồi nhấn vào danh sánh món ăn muốn xóa.", @"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var billInfoPublic = new CTHD_PUBLIC {IDHOADON = _mahoadonXoa, IDDOUONG = _madouongXoa};
                _cthdBul.delete_cthd(billInfoPublic);
                Load_CTHD(_idhd);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dg_monan_ofban.Rows.Count == 0)
            {
                MessageBox.Show(@"Chọn một bàn rồi mới thanh toán hóa đơn.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (dg_monan_ofban.Rows.Count == 1)
            {
                MessageBox.Show(@"Bàn chưa có món, không thể thanh toán.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var tt = new FCheckOut {Idban = _idban, Tenban = _tenban, Idnv = Idnv};
                tt.FormClosing += tt.FCheckOut_FormClosing;
                tt.ShowDialog();
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            var banPublic = new BAN_PUBLIC();
            for (var i = 1; i <= Convert.ToInt32(Soban.Value); i++)
            {
                banPublic.TEN = "Bàn số: " + i;
                banPublic.TRANGTHAI = @"Trống";
                banPublic.ODER = i;
                _banBul.insert_ban(banPublic);
            }

            CreateTable();
            lbAddTable.Hide();
            Soban.Hide();
            btnAddTable.Hide();
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            var editTable = new FEditTable();
            editTable.FormClosing += editTable.FEditTable_FormClosing;
            editTable.ShowDialog();
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            var switchTable = new FSwitchTable();
            switchTable.FormClosing += switchTable.FSwitchTable_FormClosing;
            switchTable.ShowDialog();
        }

        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            var mergeTable = new FMergeTable();
            mergeTable.FormClosing += mergeTable.FMergeTable_FormClosing;
            mergeTable.ShowDialog();
        }

        private void cbFood_Click(object sender, EventArgs e)
        {
            try
            {
                var drinkPublic = new DOUONG_PUBLIC {IDDM = int.Parse(cbiddm.Text)};
                var dt = _douongBul.load_douongvoi_where(drinkPublic);
                cbten.DataSource = dt;
                cbten.DisplayMember = @"TENDOUONG";
                cbgia.DataSource = dt;
                cbgia.DisplayMember = @"DONGIA";
                cbiddouong.DataSource = dt;
                cbiddouong.DisplayMember = @"IDDOUONG";
            }
            catch
            {
                MessageBox.Show(@"Danh mục trống.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvListFoodOfTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvListFoodOfTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dong = e.RowIndex;
                _mahoadonXoa = int.Parse(dg_monan_ofban.Rows[dong].Cells[1].Value == null
                    ? string.Empty
                    : dg_monan_ofban.Rows[dong].Cells[1].Value.ToString().Trim());
                _madouongXoa = int.Parse(dg_monan_ofban.Rows[dong].Cells[2].Value == null
                    ? string.Empty
                    : dg_monan_ofban.Rows[dong].Cells[2].Value.ToString().Trim());
            }
            catch
            {
                // ignored
            }
        }

        #endregion
    }
}