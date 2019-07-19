using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Reflection;

namespace Song.Extend
{
    public class Message
    {
        private System.Web.UI.Page _page;
        public Message(System.Web.UI.Page page)
        {
            this._page = page;
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="msg"></param>
        public void Alert(Exception ex)
        {
            this.Alert(ex.Message);
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="msg"></param>
        public string Alert(string msg)
        {
            msg = _tranString(msg);
            string scripts = "<script type=\"text/javascript\">{0}</script>";
            scripts = string.Format(scripts, "top.window.Alert('"+msg+"',null,null);");
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "Message"))
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "Message", scripts);
            return msg;
        }
        /// <summary>
        /// ������ʾ��Ϣ
        /// </summary>
        /// <param name="msg"></param>
        public string Prompt(string msg)
        {
            msg = _tranString(msg);
            string scripts = "<script type=\"text/javascript\">{0}</script>";
            scripts = string.Format(scripts, "top.window.Prompt('" + msg + "',null,null);");
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "Message"))
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "Message", scripts);
            return msg;
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="msg"></param>
        public string Warning(string msg)
        {
            msg = _tranString(msg);
            string scripts = "<script type=\"text/javascript\">{0}</script>";
            scripts = string.Format(scripts, "top.window.Warning('" + msg + "',null,null);");
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "Message"))
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "Message", scripts);
            return msg;
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="msg"></param>
        public string License(string msg)
        {
            msg = _tranString(msg);
            string scripts = "<script type=\"text/javascript\">{0}</script>";
            scripts = string.Format(scripts, "top.window.License('" + msg + "',null,null);");
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "Message"))
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "Message", scripts);
            return msg;
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <param name="state"></param>
        private string Login(string state)
        {
            string scripts = "<script type=\"text/javascript\">{0}</script>";
            scripts = string.Format(scripts, "top.OpenLoginBox("+state+");");
            if (!_page.ClientScript.IsStartupScriptRegistered(_page.GetType(), "Message"))
                _page.ClientScript.RegisterStartupScript(_page.GetType(), "Message", scripts);
            return state;
        }
        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private string _tranString(string msg)
        {
            msg = msg.Replace("\n", "<br/>");
            msg = msg.Replace("\r", "<br/>");
            return msg;
        }
        /// <summary>
        /// ͨ���쳣���ƣ����������Ϣ
        /// </summary>
        /// <param name="ex"></param>
        public string ExceptionShow(Exception ex)
        {
            //Object[] attrs = System.Reflection.Assembly.GetExecutingAssembly().
            //   GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            //if (attrs.Length > 0)
            //{
            //    String sCompMode = (attrs[0] as AssemblyDescriptionAttribute).Description;
            //}
            this.Alert(ex.Message);
            return "";
            //�Զ����쳣
            //if (ex is WeiSha.Common.ExceptionForNoLogin)return this.Login("false");
            //if (ex is WeiSha.Common.ExceptionForAlert) return this.Alert(ex.Message);
            //if (ex is WeiSha.Common.ExceptionForPrompt) return this.Prompt(ex.Message);
            //if (ex is WeiSha.Common.ExceptionForWarning) return this.Warning(ex.Message);
            //if (ex is WeiSha.Common.ExceptionForLicense) return this.License(ex.Message);
            //if (ex is System.NullReferenceException) return this.Alert(ex.Message);
            //������ص��쳣
            //if (ex is System.Data.Common.DbException) return this.Alert(ex.Message);
            //
            //if (ex is System.Exception) throw ex;
            //return ex.Message;
        }
    }
}
