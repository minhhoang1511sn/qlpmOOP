using System;
using System.Drawing;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FEditTable : Form
    {
        private readonly BanBul _banBul = new();
        private readonly HoadonBul _hdBul = new();
        private bool _nutThem, _nutSua;
        private int _sumTable;

        public FEditTable()
        {
            InitializeComponent();
        }

        #region Event

        private void ProcessButton(bool b)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnExit.Enabled = b;
            btnSave.Enabled = btnCancel.Enabled = !b;
        }

        private void ShowDgv()
        {
            var dt = _banBul.load_ban();
            var dgvTable = new TreeNode(@"Danh sách bàn");
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                dgvTable.Nodes.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                dgvTable.Nodes[i].Nodes.Add(dt.Rows[i][2].ToString());
                dgvTable.Nodes[i].Nodes[0].ForeColor = Color.Black;
            }

            dgvListTable.Nodes.Add(dgvTable);
            try
            {
                dgvListTable.SelectedNode = dgvListTable.Nodes[0].Nodes[0];
            }
            catch
            {
                // ignored
            }

            _sumTable = dgvTable.Nodes.Count;
        }

        private void TurnOff()
        {
            txtTableId.Show();
            lb1.Show();
            txtTableName.ReadOnly = true;
            txtStatus.ReadOnly = true;
        }

        private void TurnOn()
        {
            txtTableId.Hide();
            lb1.Hide();
            txtTableName.ReadOnly = false;
            txtStatus.ReadOnly = false;
        }

        private void Insert()
        {
            var banPublic = new BAN_PUBLIC {TEN = txtTableName.Text, TRANGTHAI = txtStatus.Text, ODER = _sumTable};
            _banBul.insert_ban(banPublic);
        }

        private new void Update()
        {
            var banPublic = new BAN_PUBLIC
            {
                IDBAN = int.Parse(txtTableId.Text),
                TEN = txtTableName.Text,
                TRANGTHAI = txtStatus.Text
            };
            _banBul.update_ban(banPublic);
        }

        private void Delete()
        {
            var banPublic = new BAN_PUBLIC();
            var hdPublic = new HOADON_PUBLIC {IDBAN = int.Parse(txtTableId.Text)};
            banPublic.IDBAN = int.Parse(txtTableId.Text);
            _hdBul.delete_hoadon_with_idban(hdPublic);
            _banBul.delete_ban(banPublic);
        }

        private void FEditTable_Load(object sender, EventArgs e)
        {
            ShowDgv();
            ProcessButton(true);
            txtTableId.ReadOnly = true;
            TurnOff();
        }

        public void FEditTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            FTableManager.Table.CreateTable();
            FTableManager.Table.HideShow_ThemBan();
        }

        #endregion

        #region Method

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _nutThem = true;
            ProcessButton(false);
            TurnOn();
            txtTableName.Focus();
            _sumTable += 1;
            txtTableName.Text = "Bàn số: " + _sumTable;
            txtStatus.Text = @"Trống";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _nutSua = true;
            ProcessButton(false);
            TurnOn();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == @"Có người")
            {
                MessageBox.Show(@"Bạn hiện tại đang có người, không thể xóa.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes != MessageBox.Show(@"Muốn xóa một bàn?", @"Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)) return;
                Delete();
                dgvListTable.Nodes.Clear();
                ShowDgv();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_nutThem)
                try
                {
                    Insert();
                    ProcessButton(true);
                    _nutThem = false;
                    TurnOff();
                    dgvListTable.Nodes.Clear();
                    ShowDgv();
                }
                catch
                {
                    MessageBox.Show(@"Trạng thái của bàn là Trống hoặc Có người");
                }
            else if (_nutSua)
                try
                {
                    Update();
                    ProcessButton(true);
                    _nutSua = false;
                    TurnOff();
                    dgvListTable.Nodes.Clear();
                    ShowDgv();
                }
                catch
                {
                    MessageBox.Show(@"Trạng thái của bàn là Trống hoặc Có người");
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_nutThem)
            {
                ProcessButton(true);
                _nutThem = false;
                dgvListTable.Nodes.Clear();
                ShowDgv();
                TurnOff();
            }
            else if (_nutSua)
            {
                ProcessButton(true);
                _nutSua = false;
                TurnOff();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListTable_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (Color.Black == e.Node.ForeColor) e.Cancel = true;
        }

        private void dgvListTable_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var tn = dgvListTable.SelectedNode;
                txtTableId.Text = tn.Name;
                txtTableName.Text = tn.Text;
                txtStatus.Text = tn.Nodes[0].Text;
            }
            catch
            {
                // ignored
            }
        }

        #endregion
    }
}