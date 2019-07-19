using System;
using System.Collections.Generic;
using System.Text;

namespace Song.Extend
{
    public class Scripts
    {
        private System.Web.UI.Page _page=null;
        public Scripts(System.Web.UI.Page page)
        {
            this._page = page;
        }
        /// <summary>
        /// ����JavaScript��ʾ��ʾ,����ʾ��Ϣ����ҳ��ͷ����Ҳ����˵����ʾ��ʾʱ��ҳ��Ϊ�հף�
        /// </summary>
        /// <param name="say">Ҫ��ʾ����Ϣ</param>
        public void Alert(string say)
        {
            if (say != "")
            {
                say = say.Replace("\\", "\\\\");
                say = say.Replace("\r", "");
                say = say.Replace("\n", "");
                string script = "<script language='JavaScript' type='text/javascript'>alert('{say}');</script>";
                script = script.Replace("{say}", say);
                if (this._page == null) return;
                if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "alert"))
                {
                    _page.ClientScript.RegisterStartupScript(_page.GetType(), "alert", script);
                }
            }
        }
        public void AlertAndFresh(string say)
        {
            if (say != "")
            {
                say = say.Replace("\\", "\\\\");
                string script = "<script language='JavaScript' type='text/javascript'>alert('{say}');window.location.href=window.location.href;</script>";
                script = script.Replace("{say}", say);
                if (this._page == null) return;
                if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "alert"))
                {
                    _page.ClientScript.RegisterStartupScript(_page.GetType(), "alert", script);
                }
            }
        }
        /// <summary>
        /// ����JavaScript��ʾ��ʾ,��ʾ�꣬�رմ��ڣ�һ�����ڵ���������ɺ����ʾ
        /// </summary>
        /// <param name="say"></param>
        public void AlertAndClose(string say)
        {
            if (say != "")
            {
                say = say.Replace("\\", "\\\\");
                string script = "<script language='JavaScript' type='text/javascript'>alert('{say}');window.close();</script>";
                script = script.Replace("{say}", say);
                if (this._page == null) return;
                if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "AlertAndClose"))
                {
                    _page.ClientScript.RegisterStartupScript(_page.GetType(), "AlertAndClose", script);
                }               
            }
        }
        /// <summary>
        /// ����JavaScript�رմ��ڣ�
        /// </summary>
        public void Close()
        {            
            string script = "<script language='JavaScript' type='text/javascript'>window.close();</script>";
            if (this._page == null) return;
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "Close"))
            {
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "Close", script);
            }          
        }
        /// <summary>
        /// ����JavaScriptʵ��ҳ��ת��
        /// </summary>
        public void GoUrl(string url)
        {
            string script = "<script type=\"text/javascript\">window.parent.location.href='" + url + "';</script>";
            if (this._page == null) return;
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "GoUrl"))
            {
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "GoUrl", script);
            }
        }
    }
}
