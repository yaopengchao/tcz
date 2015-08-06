using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public class PrintDataGridView
    {
        private static List<DataGridViewCellPrint> CellPrintList = new List<DataGridViewCellPrint>();
        private static PageSetupDialog pageSetup = null;
        private static int printRowCount = 0;

        private static bool IsPrint = true;
        private static bool IsRole = true;
        private static int PoXTmp = 0;
        private static int PoYTmp = 0;
        private static int WidthTmp = 0;
        private static int HeightTmp = 0;
        private static int RowIndex = 0;

        /// <summary>
        /// 打印DataGridView控件
        /// </summary>
        /// <param name="dataGridView">DataGridView控件</param>
        /// <param name="includeColumnText">是否包括列标题</param>
        /// <param name="e">为 System.Drawing.Printing.PrintDocument.PrintPage 事件提供数据。</param>
        /// <param name="PoX">起始X坐标</param>
        /// <param name="PoY">起始Y坐标</param>
        public static void Print(DataGridView dataGridView, bool includeColumnText, PrintPageEventArgs eValue, ref int PoX, ref int PoY)
        {
            //pageSetup = new PageSetupDialog();
            //pageSetup.PageSettings = eValue.PageSettings;
            // //pageSetup.Document=;
            //pageSetup.ShowDialog();
            try
            {
                if (PrintDataGridView.IsPrint)
                {
                    PrintDataGridView.printRowCount = 0;
                    PrintDataGridView.IsPrint = false;
                    PrintDataGridView.DataGridViewCellVsList(dataGridView, includeColumnText);
                    if (PrintDataGridView.CellPrintList.Count == 0)
                        return;
                    if (PoX > eValue.MarginBounds.Left)
                        PrintDataGridView.IsRole = true;
                    else
                        PrintDataGridView.IsRole = false;
                    PrintDataGridView.PoXTmp = PoX;
                    PrintDataGridView.PoYTmp = PoY;
                    PrintDataGridView.RowIndex = 0;
                    WidthTmp = 0;
                    HeightTmp = 0;
                }
                if (PrintDataGridView.printRowCount != 0)
                {
                    if (IsRole)
                    {
                        PoX = PoXTmp = eValue.MarginBounds.Left;
                        PoY = PoYTmp = eValue.MarginBounds.Top;
                    }
                    else
                    {
                        PoX = PoXTmp;
                        PoY = PoYTmp;
                    }
                }
                while (PrintDataGridView.printRowCount < PrintDataGridView.CellPrintList.Count)
                {
                    DataGridViewCellPrint CellPrint = CellPrintList[PrintDataGridView.printRowCount];
                    if (RowIndex == CellPrint.RowIndex)
                        PoX = PoX + WidthTmp;
                    else
                    {
                        PoX = PoXTmp;
                        PoY = PoY + HeightTmp;
                        if (PoY + HeightTmp > eValue.MarginBounds.Bottom)
                        {
                            HeightTmp = 0;
                            eValue.HasMorePages = true;
                            return;
                        }
                    }
                    using (SolidBrush solidBrush = new SolidBrush(CellPrint.BackColor))
                    {
                        RectangleF rectF1 = new RectangleF(PoX, PoY, CellPrint.Width, CellPrint.Height);
                        eValue.Graphics.FillRectangle(solidBrush, rectF1);
                        using (Pen pen = new Pen(Color.Black, 1))
                            eValue.Graphics.DrawRectangle(pen, Rectangle.Round(rectF1));
                        solidBrush.Color = CellPrint.ForeColor;
                        eValue.Graphics.DrawString(CellPrint.FormattedValue, CellPrint.Font, solidBrush, new Point(PoX + 1, PoY + 2));
                    }
                    WidthTmp = CellPrint.Width;
                    HeightTmp = CellPrint.Height;
                    RowIndex = CellPrint.RowIndex;
                    PrintDataGridView.printRowCount++;
                }
                PoY = PoY + HeightTmp;
                eValue.HasMorePages = false;
                PrintDataGridView.IsPrint = true;
            }
            catch (Exception ex)
            {
                eValue.HasMorePages = false;
                PrintDataGridView.IsPrint = true;
                throw ex;
            }

        }

        /// <summary>
        /// 将DataGridView控件内容转变到 CellPrintList
        /// </summary>
        /// <param name="dataGridView">DataGridView控件</param>
        /// <param name="includeColumnText">是否包括列标题</param>
        private static void DataGridViewCellVsList(DataGridView dataGridView, bool includeColumnText)
        {
            CellPrintList.Clear();
            try
            {
                int rowsCount = dataGridView.Rows.Count;
                int colsCount = dataGridView.Columns.Count;

                //最后一行是供输入的行时，不用读数据。
                if (dataGridView.Rows[rowsCount - 1].IsNewRow)
                    rowsCount--;
                //包括列标题
                if (includeColumnText)
                {
                    for (int columnsIndex = 0; columnsIndex < colsCount; columnsIndex++)
                    {
                        if (dataGridView.Columns[columnsIndex].Visible)
                        {
                            DataGridViewCellPrint CellPrint = new DataGridViewCellPrint();
                            CellPrint.FormattedValue = dataGridView.Columns[columnsIndex].HeaderText;
                            CellPrint.RowIndex = 0;
                            CellPrint.ColumnIndex = columnsIndex;
                            CellPrint.Font = dataGridView.Columns[columnsIndex].HeaderCell.Style.Font;
                            CellPrint.BackColor = Color.Silver;// dataGridView.ColumnHeadersDefaultCellStyle.BackColor;
                            CellPrint.ForeColor = dataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
                            CellPrint.Width = dataGridView.Columns[columnsIndex].Width;
                            CellPrint.Height = dataGridView.ColumnHeadersHeight;
                            CellPrintList.Add(CellPrint);
                        }
                    }
                }
                //读取单元格数据
                for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
                {
                    for (int columnsIndex = 0; columnsIndex < colsCount; columnsIndex++)
                    {
                        if (dataGridView.Columns[columnsIndex].Visible)
                        {
                            DataGridViewCellPrint CellPrint = new DataGridViewCellPrint();
                            CellPrint.FormattedValue = dataGridView.Rows[rowIndex].Cells[columnsIndex].FormattedValue.ToString();
                            if (includeColumnText)
                                CellPrint.RowIndex = rowIndex + 1;//假如包括列标题则从行号1开始
                            else
                                CellPrint.RowIndex = rowIndex;
                            CellPrint.ColumnIndex = columnsIndex;
                            CellPrint.Font = dataGridView.Rows[rowIndex].Cells[columnsIndex].Style.Font;
                            System.Drawing.Color TmpColor = System.Drawing.Color.Empty;
                            if (System.Drawing.Color.Empty != dataGridView.Rows[rowIndex].Cells[columnsIndex].Style.BackColor)
                                TmpColor = dataGridView.Rows[rowIndex].Cells[columnsIndex].Style.BackColor;
                            else if (System.Drawing.Color.Empty != dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor)
                                TmpColor = dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor;
                            else
                                TmpColor = dataGridView.DefaultCellStyle.BackColor;
                            CellPrint.BackColor = TmpColor;
                            TmpColor = System.Drawing.Color.Empty;
                            if (System.Drawing.Color.Empty != dataGridView.Rows[rowIndex].Cells[columnsIndex].Style.ForeColor)
                                TmpColor = dataGridView.Rows[rowIndex].Cells[columnsIndex].Style.ForeColor;
                            else if (System.Drawing.Color.Empty != dataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor)
                                TmpColor = dataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor;
                            else
                                TmpColor = dataGridView.DefaultCellStyle.ForeColor;
                            CellPrint.ForeColor = TmpColor;
                            CellPrint.Width = dataGridView.Columns[columnsIndex].Width;
                            CellPrint.Height = dataGridView.Rows[rowIndex].Height;
                            CellPrintList.Add(CellPrint);
                        }
                    }
                }


            }
            catch { throw; }
        }

    }
}





