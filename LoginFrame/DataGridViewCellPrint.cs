using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginFrame
{
    public class DataGridViewCellPrint
    {
        private string _FormattedValue = "";
        private int _RowIndex = -1;
        private int _ColumnIndex = -1;
        private System.Drawing.Color _ForeColor = System.Drawing.Color.Black;
        private System.Drawing.Color _BackColor = System.Drawing.Color.White;
        private int _Width = 100;
        private int _Height = 23;
        private System.Drawing.Font _Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        /// <summary>
        /// 获取或设置单元格的字体。
        /// </summary>
        public System.Drawing.Font Font
        {
            set { if (null != value) _Font = value; }
            get { return _Font; }
        }
        /// <summary>
        /// 获取为显示进行格式化的单元格的值。
        /// </summary>
        public string FormattedValue
        {
            set { _FormattedValue = value; }
            get { return _FormattedValue; }
        }
        /// <summary>
        /// 获取或设置列的当前宽度 （以像素为单位）。默认值为 100。
        /// </summary>
        public int Width
        {
            set { _Width = value; }
            get { return _Width; }
        }
        /// <summary>
        /// 获取或设置列标题行的高度（以像素为单位）。默认值为 23。
        /// </summary>
        public int Height
        {
            set { _Height = value; }
            get { return _Height; }
        }
        /// <summary>
        /// 获取或设置行号。
        /// </summary>
        public int RowIndex
        {
            set { _RowIndex = value; }
            get { return _RowIndex; }
        }
        /// <summary>
        /// 获取或设置列号。
        /// </summary>
        public int ColumnIndex
        {
            set { _ColumnIndex = value; }
            get { return _ColumnIndex; }
        }
        /// <summary>
        /// 获取或设置前景色。
        /// </summary>
        public System.Drawing.Color ForeColor
        {
            set { _ForeColor = value; }
            get { return _ForeColor; }
        }
        /// <summary>
        /// 获取或设置背景色。
        /// </summary>
        public System.Drawing.Color BackColor
        {
            set { _BackColor = value; }
            get { return _BackColor; }
        }

    }
}
