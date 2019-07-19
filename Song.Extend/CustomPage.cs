using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Song.Extend;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;
using Song.ServiceInterfaces;
using WeiSha.Common;

namespace Song.Extend
{
    public class CustomPage : System.Web.UI.Page
    {
        /// <summary>
        /// ϵͳ�汾��
        /// </summary>
        protected static string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /// <summary>
        /// ���ýű�,��alert��
        /// </summary>
        public Extend.Scripts Scripts
        {
            get
            {
                return new Scripts(this);
            }
        }
        /// <summary>
        /// ��ȡ��ǰҳ���Ψһid
        /// </summary>
        /// <returns></returns>
        public string getUID()
        {
            if (ViewState["UID"] != null)
            {
                return ViewState["UID"].ToString();
            }
            ViewState["UID"] = WeiSha.Common.Request.UniqueID();
            return ViewState["UID"].ToString();
        }
        protected override void OnInitComplete(EventArgs e)
        {
            //������Ӧ��Javascript�ű���
            string scriptPath = "~/Manage/CoreScripts/";
            scriptPath = this.ResolveUrl(scriptPath);
            //�ű���
            string[] scriptFile = new string[] {
                "jquery.js", 
                "GridView.js",
                "Extend.js",
                "PageExt.js",
                "Verify.js",
                "HoldMode.js"               
            };
            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("\r\n"));
            foreach (string file in scriptFile)
            {
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<script type=\"text/javascript\" src=\""+scriptPath+file+"?ver=" + version + "\"></script>\r\n"));
            }
            //�����Ӧ��css�ļ���js�ļ�
            string name = WeiSha.Common.Request.Page.Name;
            if (System.IO.File.Exists(WeiSha.Common.Request.Page.PhysicsPath + "styles/public.css"))
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link href=\"styles/public.css?ver=" + version + "\" type=\"text/css\" rel=\"stylesheet\" />\r\n"));
            //�����
            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link href=\"/Utility/iconfont/iconfont.css?ver=" + version + "\" type=\"text/css\" rel=\"stylesheet\" />\r\n"));
            if (System.IO.File.Exists(WeiSha.Common.Request.Page.PhysicsPath + "styles/"+ name+".css" ))
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link href=\"styles/" + name + ".css?ver=" + version + "\" type=\"text/css\" rel=\"stylesheet\" />\r\n"));
            if (System.IO.File.Exists(WeiSha.Common.Request.Page.PhysicsPath + "scripts/"+name+".js"))
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<script type=\"text/javascript\" src=\"scripts/" + name + ".js?ver=" + version + "\"></script>\r\n"));
            //Response.Write(Extend.ManageSession.Session.Name);
            #region ��֤�Ƿ��¼

            //������ڹ����¼״̬
            if (LoginState.Admin.IsLogin)
            {
                //����д��session
                LoginState.Admin.Write();
                //�ж�Ȩ��
                LoginState.Admin.VerifyPurview();
                //��¼����
                if (!this.IsPostBack)
                {
                    bool isWorkLogs = Business.Do<ISystemPara>()["SysIsWorkLogs"].Boolean ?? true;
                    if (Extend.LoginState.Admin.isForRoot)
                        if (isWorkLogs) Business.Do<ILogs>().AddOperateLogs();
                }
            }
            else
            {
                //�������ѧԱ��¼״̬
                if (LoginState.Accounts.IsLogin)
                {                    
                   
                    //��ǰҳ�����ڵĹ���ģ�����ƣ��������/Manage�ļ��е�·������Ϊÿһ��ģ����ManageĿ¼����һ������Ŀ¼
                    string module = WeiSha.Common.Request.Page.Module;
                    if (module.ToLower() != "student")
                    {

                        Song.Entities.Teacher th = LoginState.Accounts.Teacher;
                        if (th == null)
                        {
                            Response.Write("δ��¼���򲻾��в���Ȩ�ޡ�");
                            Response.End();
                        }
                    }
                }
                else
                {
                    Response.Write("δ��¼����ͬһ�˺�����ص�¼����ǰ��¼״̬��ȡ����");
                    Response.End();
                }
            }
            //catch (System.Data.DataException ex)
            //{
            //    Message.ExceptionShow(ex);
            //}
            //catch (NBear.Common.ExceptionForNoLogin ex)
            //{
            //    Message.ExceptionShow(ex);
            //}
            //catch (NBear.Common.ExceptionForLicense ex)
            //{
            //    Message.License(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Message.ExceptionShow(ex);
            //}
            #endregion
            //this.Form.Attributes.Add("onsubmit", "this.action=document.location.href");
            
            base.OnInitComplete(e);
        }

        /// <summary>
        /// ���¼��ص�ǰҳ��
        /// </summary>
        protected void Reload()
        {
            string url = Request.Path;
            this.Response.Redirect(url);
        }
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public Message Message
        {
            get { return new Message(this); }
        }
        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <param name="alert"></param>
        public void Alert(string alert)
        {
            alert = alert.Replace("\r","");
            alert = alert.Replace("\n", "");
            new Extend.Scripts(this).Alert(alert);
        }
        /// <summary>
        /// ����JavaScript��ʾ��ʾ,��ʾ�꣬�رմ��ڣ�һ�����ڵ���������ɺ����ʾ
        /// </summary>
        /// <param name="say"></param>
        public void AlertAndClose(string say)
        {
            if (!string.IsNullOrWhiteSpace(say) && say.Trim() != "")
            {
                say = say.Replace("\r", "\n");
                say = "<script type=\"text/javascript\">alert(\"" + say + "\");new top.PageBox().Close();</script>";
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Alert", say, true);
                Page.ClientScript.RegisterStartupScript(typeof(string), "alert", say);
                //Page.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", say); 
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// ����JavaScript��ʾ��ʾ,��ʾ�꣬�رմ��ڣ�һ�����ڵ���������ɺ����ʾ
        /// </summary>
        /// <param name="say"></param>
        public void AlertCloseAndRefresh(string say)
        {
            if (!string.IsNullOrWhiteSpace(say) && say.Trim() != "")
            {
                say = say.Replace("\r", "\n");
                say = "<script type=\"text/javascript\">alert(\"" + say + "\"); window.top.PageBox.CloseAndRefresh(window.name);</script>";
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Alert", say, true);
                Page.ClientScript.RegisterStartupScript(typeof(string), "alert", say);
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// ����JavaScript��ʾ��ʾ,��ʾ�꣬�رմ��ڣ�
        /// </summary>
        /// <param name="say"></param>
        public void Close(string say)
        {
            if (!string.IsNullOrWhiteSpace(say) && say.Trim() != "")
            {
                say = say.Replace("\r", "\n");
                say = "<script type=\"text/javascript\">alert(\"" + say + "\");new top.PageBox().CloseAndRefresh();</script>";
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Alert", say, true);
            }
            else
            {
                say = "<script type=\"text/javascript\">new top.PageBox().CloseAndRefresh();</script>";
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Alert", say, true);
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), "close", say);
        }
        /// <summary>
        /// �رմ��ڣ�
        /// </summary>
        public void Close()
        {
            string say = "";
            say = "<script type=\"text/javascript\">new top.PageBox().Close();</script>";
            //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Alert", say, true);
            Page.ClientScript.RegisterStartupScript(typeof(string), "close", say);

        }
        /// <summary>
        /// ִ��js�ű�����
        /// </summary>
        /// <param name="func"></param>
        /// <param name="values"></param>
        public void JsFunction(string func, params string[] values)
        {
            string script = "<script language='JavaScript' type='text/javascript'>{js}</script>";            
            string para = "";
            for (int i = 0; i < values.Length; i++)
            {
                para += "\"" + values[i] + "\"";
                if (i < values.Length-1) para += ",";
            }
            string js = func + "(" + para + ");";
            script = script.Replace("{js}", js);
            if (this == null) return;
            if (!ClientScript.IsStartupScriptRegistered(this.GetType(), "JsFunction"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "JsFunction", script);
            }
        }
        #region ��ѯ�ַ������
        /// <summary>
        /// ����ѯ����Ŀؼ�ת����query�ַ���
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        protected string SearchQuery(System.Web.UI.WebControls.Panel panel)
        {
            return new SearchQuery(panel).QueryString();
        }
        protected string SearchQuery()
        {
            return new SearchQuery(this).QueryString();
        }
        /// <summary>
        /// ���ӵ�ַ�Ĳ���
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string AddPara(string url, string key, object value)
        {
            string query = string.Empty;
            if (url.IndexOf('?') > -1)
            {
                query = url.Substring(url.IndexOf('?') + 1);
                url = url.Substring(0, url.IndexOf('?'));
            }
            if (string.IsNullOrWhiteSpace(query)) return string.Format("{0}?{1}={2}", url, key, value.ToString());
            //������
            string[] arr = query.Split('&');
            string tmQuery = string.Empty;
            bool isExist = false;
            for (int i = 0; i < arr.Length;i++ )
            {
                string[] t = arr[i].Split('=');
                if (t.Length < 2) continue;
                if (key.ToLower() == t[0].ToLower())
                {
                    t[1] = value.ToString();
                    isExist = true;
                }
                tmQuery += string.Format("{0}={1}&", t[0], t[1]);
            }
            if (!isExist) tmQuery += string.Format("{0}={1}&", key, value.ToString());
            if (tmQuery.EndsWith("&")) tmQuery = tmQuery.Substring(0, tmQuery.Length - 1);          
            return url + "?" + tmQuery;
        }
        /// <summary>
        /// ����ƴ��ҳ��Ĳ�ѯ�ִ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string AddPara(string key, object value)
        {
            return this.AddPara(this.Page.Request.RawUrl, key, value);            
        }
        /// <summary>
        /// ����ѯ�ִ��󶨵���ѯ�ؼ���
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        protected void SearchBind(System.Web.UI.WebControls.Panel panel)
        {
            new SearchQuery(panel).SearchBind();
        }
        protected void SearchBind()
        {
            new SearchQuery(this).SearchBind();
        }
        #endregion

        #region ��ʵ���ֵ�󶨵��ؼ�
        protected void EntityBind(WeiSha.Data.Entity entity)
        {
            if (entity == null) return;
            _entityBind(this, entity);
        }
        protected void EntityBind(System.Web.UI.WebControls.Panel panel,WeiSha.Data.Entity entity)
        {
            if (entity == null) return;
            _entityBind(panel, entity);            
        }
        /// <summary>
        /// �ݹ����ÿؼ���ֵ
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        protected void _entityBind(System.Web.UI.Control control, WeiSha.Data.Entity entity)
        {
            foreach (Control c in control.Controls)
            {
                if (string.IsNullOrWhiteSpace(c.ID)) continue;
                _entityBindSingle(c, entity);
            }
            foreach (Control c in control.Controls)
                _entityBind(c,entity);
        }
        /// <summary>
        /// �򵥸��ؼ���
        /// </summary>
        /// <param name="control"></param>
        /// <param name="entity"></param>
        private void _entityBindSingle(System.Web.UI.Control c, WeiSha.Data.Entity entity)
        {
            //����ʵ������
            Type info = entity.GetType();
            PropertyInfo[] properties = info.GetProperties();
            for (int j = 0; j < properties.Length; j++)
            {
                PropertyInfo pi = properties[j];
                if (c.ID.Equals(pi.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    //��ǰ���Ե�ֵ
                    object obj = info.GetProperty(pi.Name).GetValue(entity, null);
                    if (obj != null) _controlBindFunc(c, obj);
                    break;
                }                
            }
        }
        /// <summary>
        /// ��ؼ���ֵ
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void _controlBindFunc(System.Web.UI.Control c, object value)
        {
            //�����˵�����ѡ�б���ѡ�б�
            if (c is DropDownList || c is CheckBoxList || c is RadioButtonList)
            {
                ListControl ddl = c as ListControl;
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(value.ToString()));
            }
            //�����
            if (c is TextBox || c is Label || c is Literal)
            {
                ITextControl txt = c as ITextControl;
                if (value == null) return;                
                if (c is Literal)
                {
                    txt.Text = value.ToString();
                    return;
                }
                WebControl wc = c as WebControl;
                //��ʽ���ַ�
                string fmt = wc.Attributes["Format"] == null ? null : wc.Attributes["Format"];                    
                if (fmt == null)
                {
                    txt.Text = value.ToString();
                    return;
                }                                                               
                if (value is System.DateTime)
                    txt.Text = System.Convert.ToDateTime(value).ToString(fmt);
                if (value is int)
                    txt.Text = System.Convert.ToInt32(value).ToString(fmt);
                if (value is float)
                    txt.Text = System.Convert.ToSingle(value).ToString(fmt);
                if (value is double)
                    txt.Text = System.Convert.ToDouble(value).ToString(fmt); 
                if(value is decimal)
                    txt.Text = System.Convert.ToDecimal(value).ToString(fmt); 
                
            }            
            //��ѡ���ѡ
            if (c is CheckBox || c is RadioButton)
                (c as CheckBox).Checked = Convert.ToBoolean(value);
        }
        #endregion

        #region ��ʵ��ӽ���ؼ���ȡֵ����
        /// <summary>
        /// ��ָ��ʵ���������
        /// </summary>
        /// <param name="entity"></param>
        protected WeiSha.Data.Entity EntityFill(WeiSha.Data.Entity entity)
        {
            return _entityFill(this, entity);
        }
        private WeiSha.Data.Entity _entityFill(System.Web.UI.Control control, WeiSha.Data.Entity entity)
        {
            foreach (Control c in control.Controls)
            {
                if (string.IsNullOrWhiteSpace(c.ID)) continue;
                //����ʵ������
                Type info = entity.GetType();
                PropertyInfo[] properties = info.GetProperties();
                for (int j = 0; j < properties.Length; j++)
                {
                    PropertyInfo pi = properties[j];
                    if (pi.Name == c.ID)
                    {
                        entity = _entityFillSingle(c, entity, pi.Name);
                        break;
                    }
                   
                }
            }
            foreach (Control c in control.Controls)
                entity = _entityFill(c, entity);
            return entity;
        }
        private WeiSha.Data.Entity _entityFillSingle(System.Web.UI.Control c, WeiSha.Data.Entity entity, string piName)
        {
            string value = "";
            //�����˵�����ѡ�б���ѡ�б�
            if (c is DropDownList || c is CheckBoxList || c is RadioButtonList)
            {
                ListControl ddl = c as ListControl;
                value = ddl.SelectedValue;
            }
            //�����
            if (c is TextBox)
            {
                TextBox tb = c as TextBox;
                value = tb.Text;
            }
            //��ѡ���ѡ
            if (c is CheckBox || c is RadioButton)
            {
                CheckBox cb = c as CheckBox;
                value = cb.Checked.ToString();
            }
            //��ȡֵ��ת�ĳ����Ե��������ͣ�����ֵ
            var property = entity.GetType().GetProperty(piName);
            object tm = string.IsNullOrEmpty(value) ? null : WeiSha.Common.DataConvert.ChangeType(value, property.PropertyType);
            property.SetValue(entity,tm , null);
            return entity;
        }
        #endregion

    }
    
}
