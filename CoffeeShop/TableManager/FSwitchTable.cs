using System;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FSwitchTable : Form
    {
        private readonly BanBul _banBul = new();
        private readonly HoadonBul _hdBul = new();

        public FSwitchTable()
        {
            InitializeComponent();
        }

        private void FSwitchTable_Load(object sender, EventArgs e)
        {
            var dt = _banBul.load_ban_trong();
            cbTableName.DataSource = dt;
            cbTableName.DisplayMember = @"TEN";
            cbEmptyTableId.DataSource = dt;
            cbEmptyTableId.DisplayMember = @"IDBAN";

            var dt1 = _banBul.load_ban_conguoi();
            cbUsedTable.DataSource = dt1;
            cbUsedTable.DisplayMember = @"TEN";
            cbUsedTableId.DataSource = dt1;
            cbUsedTableId.DisplayMember = @"IDBAN";
            cbUsedTableId.Hide();
            cbEmptyTableId.Hide();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (cbUsedTable.Text == "")
            {
                MessageBox.Show(@"Không có bàn nào để chuyển.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var hdPublic = new HOADON_PUBLIC();
                var banPublic = new BAN_PUBLIC();
                hdPublic.IDBAN = int.Parse(cbUsedTableId.Text);
                var maHoaDonBanCoNguoi = _hdBul.load_IDHD_WITH_IDBAN(hdPublic);
                hdPublic.IDHOADON = maHoaDonBanCoNguoi;
                hdPublic.IDBAN = int.Parse(cbEmptyTableId.Text); // mã bàn mới
                _hdBul.update_hoadon_doiban(hdPublic);
                banPublic.IDBAN = int.Parse(cbUsedTableId.Text); //update thành Trống
                banPublic.TRANGTHAI = @"Trống";
                _banBul.update_trangthaiban(banPublic);
                banPublic.IDBAN = int.Parse(cbEmptyTableId.Text); //update thành Có người
                banPublic.TRANGTHAI = @"Có người";
                _banBul.update_trangthaiban(banPublic);
                FSwitchTable_Load(sender, e);
                Close();
            }
        }

        public void FSwitchTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            FTableManager.Table.FTableManager_Load(sender, e);
        }
    }
}