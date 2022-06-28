using System;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FMergeTable : Form
    {
        private readonly BanBul _banBul = new();
        private readonly CthdBul _cthdBul = new();
        private readonly HoadonBul _hdBul = new();

        public FMergeTable()
        {
            InitializeComponent();
        }

        private void FMergeTable_Load(object sender, EventArgs e)
        {
            dgvBillInfo.Hide();

            var dt1 = _banBul.load_ban_conguoi();
            cbUsedTable.DataSource = dt1;
            cbUsedTable.DisplayMember = @"TEN";
            cbUsedTableId.DataSource = dt1;
            cbUsedTableId.DisplayMember = @"IDBAN";
            cbUsedTableId.Hide();

            var dt2 = _banBul.load_ban_conguoi();
            cbUsedTable1.DataSource = dt2;
            cbUsedTable1.DisplayMember = @"TEN";
            cbUsedTableId1.DataSource = dt2;
            cbUsedTableId1.DisplayMember = @"IDBAN";
            cbUsedTableId1.Hide();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (cbUsedTable.Text == cbUsedTable1.Text)
            {
                MessageBox.Show(@"Không thể gộp 2 bàn giống nhau.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var hdPublic = new HOADON_PUBLIC {IDBAN = int.Parse(cbUsedTableId.Text)};
                var billId = _hdBul.load_IDHD_WITH_IDBAN(hdPublic);
                var billinfoPublic = new CTHD_PUBLIC {IDHOADON = billId};
                dgvBillInfo.DataSource = _cthdBul.load_cthd(billinfoPublic);
                hdPublic.IDBAN = int.Parse(cbUsedTableId1.Text);
                var billId1 = _hdBul.load_IDHD_WITH_IDBAN(hdPublic);
                billinfoPublic.IDHOADON = billId1;
                for (var i = 0; i < dgvBillInfo.Rows.Count - 1; i++)
                {
                    billinfoPublic.IDDOUONG = int.Parse(dgvBillInfo["IDDOUONG", i].Value.ToString());
                    billinfoPublic.SOLUONG = int.Parse(dgvBillInfo["SOLUONG", i].Value.ToString());
                    _cthdBul.insert_cthd(billinfoPublic);
                }

                billinfoPublic.IDHOADON = billId;
                for (var j = 0; j < dgvBillInfo.Rows.Count - 1; j++)
                {
                    billinfoPublic.IDDOUONG = int.Parse(dgvBillInfo["IDDOUONG", j].Value.ToString());
                    _cthdBul.delete_cthd(billinfoPublic);
                }

                hdPublic.IDBAN = int.Parse(cbUsedTableId.Text);
                _hdBul.delete_hoadon_with_idban(hdPublic);
                var banPublic = new BAN_PUBLIC {IDBAN = int.Parse(cbUsedTableId.Text), TRANGTHAI = "Trống"};
                _banBul.update_trangthaiban(banPublic);
                Close();
            }
        }

        public void FMergeTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            FTableManager.Table.FTableManager_Load(sender, e);
        }
    }
}