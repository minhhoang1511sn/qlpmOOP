using System;
using System.Globalization;
using System.Windows.Forms;
using BUL;
using Microsoft.Office.Interop.Word;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FBillInfo : Form
    {
        private readonly CthdOldBul _cthdOldBul = new();

        public FBillInfo()
        {
            InitializeComponent();
        }

        #region Method

        public int MahoadonOld { get; set; }

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
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
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
                    headerRange.Text = "Chi tiết của mã hóa đơn: " + MahoadonOld;
                    headerRange.Font.Size = 16;
                    headerRange.Font.Bold = 1;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // thêm một dòng vào file word
                var p = oDoc.Paragraphs.Add();
                var tongtien = p.Range;
                tongtien.Text = "Tổng tiền: " + rttongtien.Text + " VNĐ";
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

        private void Tinhtongtien()
        {
            double tongtien = 0;
            for (var i = 0; i < dg_chtd_old.Rows.Count - 1; ++i)
                tongtien += Convert.ToDouble(dg_chtd_old.Rows[i].Cells[3].Value.ToString());
            rttongtien.Text = tongtien.ToString("###,###,##0");
        }

        private void EditDataGrid()
        {
            dg_chtd_old.ReadOnly = true;
            var dinhdangso = "###,###,##0";
            dg_chtd_old.Columns[0].HeaderText = @"Tên món";
            dg_chtd_old.Columns[1].HeaderText = @"Số lượng";
            dg_chtd_old.Columns[2].HeaderText = @"Đơn giá (VNĐ)";
            dg_chtd_old.Columns[2].DefaultCellStyle.Format = dinhdangso;
            dg_chtd_old.Columns[3].HeaderText = @"Thành tiền (VNĐ)";
            dg_chtd_old.Columns[3].DefaultCellStyle.Format = dinhdangso;
        }

        #endregion


        #region Event

        private void FBillInfo_Load(object sender, EventArgs e)
        {
            groupBox1.Text = @"Chi tiết của mã hóa đơn: " + MahoadonOld;
            var cthdOldPublic = new CTHD_OLD_PUBLIC {IDHOADON_OLD = MahoadonOld};
            dg_chtd_old.DataSource = _cthdOldBul.load_cthd_old_printer(cthdOldPublic);
            EditDataGrid();
            rttongtien.ReadOnly = true;
            Tinhtongtien();
        }

        private void inChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog {Filter = @"Word Documents (*.docx)|*.docx"};
            save.FileName = save.FileName;
            if (save.ShowDialog() == DialogResult.OK) XuatRaFileWord(dg_chtd_old, save.FileName);
        }

        #endregion

        private void dg_chtd_old_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}