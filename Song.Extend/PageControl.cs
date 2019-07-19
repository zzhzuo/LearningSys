using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Song.Extend
{
    public class PageControl
    {
        #region ��������
        private static readonly PageControl _p = new PageControl();
        /// <summary>
        /// ��ȡϵͳ����
        /// </summary>
        public static PageControl Gateway
        {
            get
            {
                return _p;
            }
        }
        private PageControl()
        {
        }
        #endregion
        /// <summary>
        /// ���������ڵĿؼ����Ƿ�Ϊ����״̬
        /// </summary>
        /// <param name="container"></param>
        /// <param name="isEnabled"></param>
        public void SetInnnerEnabled(System.Web.UI.Control container,bool isEnabled)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is WebControl)
                {
                    ((WebControl)ctrl).Enabled = isEnabled;
                }
                if (ctrl is HtmlControl)
                {
                    ((HtmlControl)ctrl).Disabled = !isEnabled;
                }
            }
        }
        /// <summary>
        /// ���������ڵĿؼ����Ƿ���ʾ
        /// </summary>
        /// <param name="container"></param>
        /// <param name="isVisible"></param>
        public void SetInnnerVisible(System.Web.UI.Control container, bool isVisible)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is WebControl)
                {
                    ((WebControl)ctrl).Visible = isVisible;
                }
                if (ctrl is HtmlControl)
                {
                    ((HtmlControl)ctrl).Visible = isVisible;
                }
            }
        }
    }
}
