using System;
using System.Globalization;
using System.Windows.Forms;
using BUL;
using Microsoft.Office.Interop.Word;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FRevenue : Form
    {
        private readonly HoadonOldBul _hdOldBul = new();
        private string _trangthai = "";

        public FRevenue()
        {
            InitializeComponent();
        }

        #region Method

        public int Ngay { get; set; }

        public int Thang { get; set; }

        public int Nam { get; set; }

        public bool Bngay { get; set; }

        public bool Bthang { get; set; }

        public bool Bnam { get; set; }

        public bool Timcheck { get; set; }

        public string Tenban { get; set; }

        public bool Checkten { get; set; }

        private void load_dshd_ngay()
        {
            var hdOldPublic = new HOADON_OLD_PUBLIC {NGAY = Ngay};
            dgvListBill.DataSource = _hdOldBul.load_hd_day(hdOldPublic);
        }

        private void load_dshd_thang()
        {
            var hdOldPublic = new HOADON_OLD_PUBLIC {THANG = Thang};
            dgvListBill.DataSource = _hdOldBul.load_hd_month(hdOldPublic);
        }

        private void load_dshd_nam()
        {
            var hdOldPublic = new HOADON_OLD_PUBLIC {NAM = Nam};
            dgvListBill.DataSource = _hdOldBul.load_hd_year(hdOldPublic);
        }

        private void EditDataGrid()
        {
            dgvListBill.ReadOnly = true;
            var editDgv = "###,###,##0";
            dgvListBill.Columns[0].HeaderText = @"Mã hóa đơn";
            dgvListBill.Columns[1].HeaderText = @"Tên";
            dgvListBill.Columns[2].HeaderText = @"Tên nhân viên";
            dgvListBill.Columns[3].HeaderText = @"Ngày lập hóa đơn";
            dgvListBill.Columns[4].HeaderText = @"Thanh toán";
            dgvListBill.Columns[5].HeaderText = @"Tổng tiền";
            dgvListBill.Columns[5].DefaultCellStyle.Format = editDgv;
        }

        private void EditDataGrid_Hd_Ban()
        {
            var editDgv = "###,###,##0";
            dgvListBill.ReadOnly = true;
            dgvListBill.Columns[0].HeaderText = @"Mã hóa đơn";
            dgvListBill.Columns[1].HeaderText = @"Tên bàn";
            dgvListBill.Columns[2].HeaderText = @"Tên nhân viên";
            dgvListBill.Columns[3].HeaderText = @"Ngày lập hóa đơn";
            dgvListBill.Columns[4].HeaderText = @"Thanh toán";
            dgvListBill.Columns[5].HeaderText = @"Tổng tiền(VNĐ)";
            dgvListBill.Columns[5].DefaultCellStyle.Format = editDgv;
        }

        private void Tinhtongtien(int vitri)
        {
            double total = 0;
            for (var i = 0; i < dgvListBill.Rows.Count - 1; ++i)
                total += Convert.ToDouble(dgvListBill.Rows[i].Cells[vitri].Value.ToString());
            txtTotalPrice.Text = total.ToString("###,###,##0");
        }

        private void XuatRaFileWord(DataGridView dgv, string filename)
        {
            if (dgv.Rows.Count != 0)
            {
                var rowCount = dgv.Rows.Count;
                var columnCount = dgv.Columns.Count;
                var dataArray = new object[rowCount + 1, columnCount + 1];

                //add rows
                int r;
                for (var c = 0; c <= columnCount - 1; c++)
                for (r = 0; r <= rowCount - 1; r++)
                    dataArray[r, c] = dgv.Rows[r].Cells[c].Value;

                var oDoc = new Document();
                oDoc.Application.Visible = true;

                //page orientation
                oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                var oTemp = "";
                for (r = 0; r <= rowCount - 1; r++)
                for (var c = 0; c <= columnCount - 1; c++)
                    oTemp = oTemp + dataArray[r, c] + "\t";

                //table format
                oRange.Text = oTemp;

                object separator = WdTableFieldSeparator.wdSeparateByTabs;
                object applyBorders = true;
                object autoFit = true;
                object autoFitBehavior = WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref separator, ref rowCount, ref columnCount,
                    Type.Missing, Type.Missing, ref applyBorders,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, ref autoFit, ref autoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = @"Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (var c = 0; c <= columnCount - 1; c++)
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dgv.Columns[c].HeaderText;

                //table style                        
                oDoc.Application.Selection.Tables[1].set_Style("Table Grid 3");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    var headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                    headerRange.Text = @"Tổng doanh thu theo: " + _trangthai;
                    headerRange.Font.Size = 16;
                    headerRange.Font.Bold = 1;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // thêm một dòng vào file word
                var p = oDoc.Paragraphs.Add();
                var tongtien = p.Range;
                tongtien.Text = @"Tổng doang thu: " + txtTotalPrice.Text + " VNĐ";
                // thai đổi lề of chữ
                tongtien.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                tongtien.InsertParagraphAfter();
                // thêm giờ vào file word
                var p1 = oDoc.Paragraphs.Add();
                var thoigianlap = p1.Range;
                thoigianlap.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                thoigianlap.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                thoigianlap.InsertParagraphAfter();
                //save the file
                oDoc.SaveAs(filename);
            }
        }

        #endregion

        #region Event

        private void FRevenue_Load(object sender, EventArgs e)
        {
            txtTotalPrice.ReadOnly = true;
            groupBox2.Text = @"Tổng doanh thu(VNĐ)";
            if (Bngay)
            {
                _trangthai = @"Ngày";
                load_dshd_ngay();
                EditDataGrid();
                groupBox1.Text = @"Danh sách hóa đơn theo Ngày: " + Ngay;
                Tinhtongtien(5);
            }
            else if (Bthang)
            {
                _trangthai = @"Tháng";
                load_dshd_thang();
                EditDataGrid();
                groupBox1.Text = @"Danh sách hóa đơn theo Tháng: " + Thang;
                Tinhtongtien(5);
            }
            else if (Bnam)
            {
                _trangthai = @"Năm";
                load_dshd_nam();
                EditDataGrid();
                groupBox1.Text = @"Danh sách hóa đơn theo Năm: " + Nam;
                Tinhtongtien(5);
            }
            else if (Timcheck)
            {
                _trangthai = Tenban;
                var hdOldPublic = new HOADON_OLD_PUBLIC {Soban = Tenban};
                dgvListBill.DataSource = _hdOldBul.load_timhd_old(hdOldPublic);
                EditDataGrid_Hd_Ban();
                groupBox1.Text = @"Danh sách hóa đơn theo " + Tenban;
                Tinhtongtien(5);
            }
            else if (Checkten)
            {
                _trangthai = Tenban;
                var hdOldPublic = new HOADON_OLD_PUBLIC {TENNV = Tenban};
                dgvListBill.DataSource = _hdOldBul.load_timhd_old_TENNV(hdOldPublic);
                EditDataGrid_Hd_Ban();
                groupBox1.Text = @"Danh sách hóa đơn của nhân viên: " + Tenban;
                Tinhtongtien(5);
            }
            else
            {
                _trangthai = @"Tất cả các hóa đơn";
                dgvListBill.DataSource = _hdOldBul.load_hoadon_old_NOTID();
                EditDataGrid();
                groupBox1.Text = @"Danh sách tất cả các hóa đơn";
                Tinhtongtien(5);
            }
        }

        internal void FRevenue_FormClosing(object sender, FormClosingEventArgs e)
        {
            FStatistic.Tkdt.btlammoi_Click(sender, e);
        }

        private void bttin_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog {Filter = @"Word Documents (*.docx)|*.docx"};
            save.FileName = save.FileName;
            if (save.ShowDialog() == DialogResult.OK) XuatRaFileWord(dgvListBill, save.FileName);
        }

        #endregion
    }
}