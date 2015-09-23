using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{

    /// <summary>
    /// 自定义按钮  支持双击事件
    /// </summary>
    public class ButtonEx : Button
    {
        public new event EventHandler DoubleClick;

        DateTime clickTime;
        bool isClicked = false;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (isClicked)
            {
                TimeSpan span = DateTime.Now - clickTime;
                if (span.Milliseconds < SystemInformation.DoubleClickTime)
                {
                    DoubleClick(this, e);
                    isClicked = false;
                }
            }
            else
            {
                isClicked = true;
                clickTime = DateTime.Now;
            }
        }
    }
}
