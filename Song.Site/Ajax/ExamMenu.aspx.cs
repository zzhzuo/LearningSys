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
using WeiSha.Common;

using Song.ServiceInterfaces;
using Song.Entities;
using WeiSha.WebControl;

namespace Song.Site.Ajax
{
    /// <summary>
    /// ϵͳ�������������˵�
    /// </summary>
    public partial class ExamMenu : System.Web.UI.Page
    {
        //�˵�������Դ
        Song.Entities.ManageMenu[] _allMM;
        //���˵���
        private int root = WeiSha.Common.Request.QueryString["root"].Int32 ?? 441;
        //ȡ������С��1ȡ����
        private int level = WeiSha.Common.Request.QueryString["level"].Int32 ?? 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (level == 1)
            {
                Response.Write(_BuildLevelOne());
            }
            else
            {
                if (Extend.LoginState.Admin.IsAdmin)
                {
                    //����ǳ�������Ա���������п��ò˵���
                    _allMM = Business.Do<IManageMenu>().GetAll(true, true, "func");
                }
                else
                {
                    //��ȡ���ܲ˵��������в˵���
                    _allMM = Business.Do<IPurview>().GetAll4Emplyee(Extend.LoginState.Admin.CurrentUserId);
                }
                if (_allMM != null)
                {
                    Response.Write(_BuildMenu(_allMM));
                }
            }
            Response.End();
        }
        /// <summary>
        /// ������һ���˵��������˵�
        /// </summary>
        /// <returns></returns>
        private string _BuildLevelOne()
        {
            Song.Entities.ManageMenu[] mm = Business.Do<IManageMenu>().GetChilds(root, true, true);
            string tm = "";
            foreach (Song.Entities.ManageMenu m in mm)
            {
                tm += " <div class=\"rootItem\"><a href=\"" + m.MM_Link + "\" type=\"" + m.MM_Type + "\">" + m.MM_Name + "</a></div>";
            }
            return tm;
        }
        /// <summary>
        /// ����Ȩ�޲˵�
        /// </summary>
        /// <returns></returns>
        private string _BuildMenu(Song.Entities.ManageMenu[] mm)
        {           
            string tmp = "";
            //��ǰ���ڵ�
            Extend.MenuNode root = new Extend.MenuNode(null, mm);
            if (root.IsChilds)
            {
                //�ݹ������Ӳ˵�
                tmp += this._BuildMenuItem(root.Childs[0], 0, root.Childs[0].MM_Name);
            }
            return tmp;
        }
        //���������˵����Ӳ˵����
        private string _BuildMenuItem(Song.Entities.ManageMenu mm, int level, string path)
        {
            Extend.MenuNode node = new Song.Extend.MenuNode(mm, _allMM);
            //���û���ӽڵ㣬��ֱ�ӷ���
            if (!node.IsChilds) return "";
            //
            string tmp = "";
            //�Ƿ���˵�           
            string itemClass = level == 0 ? "rootItem" : "item";
            string panelClass = level == 0 ? "rootPanel" : "";           
            //һ���˵�����Ҫǰ̨��ʾ�Ĳ˵�
            for (int i = 0; i < node.Childs.Length; i++)
            {
                Song.Entities.ManageMenu m = node.Childs[i];                
                Extend.MenuNode n = new Song.Extend.MenuNode(m, _allMM);
                tmp += " <div class=\"" + itemClass + " " + (n.IsChilds ? "child" : "") + "\" mid=\"" + m.MM_Id + "\" tax=\"" + i + "\">";
                tmp += "<a href=\"" + m.MM_Link + "\" type=\"" + m.MM_Type + "\">" + m.MM_Name + "</a></div>";
                if (n.IsChilds)
                {
                    tmp += "<div class=\"MenuPanel "+panelClass+"\" style=\"display:none;z-index:"+(level+100)+"\" pid=\"" + m.MM_Id + "\">";
                    tmp += this._BuildMenuItem(m, level+1, path + "," + m.MM_Name);
                    tmp += "</div>";
                }
            }
            return tmp;
        }
        //���ɽڵ����ı�
        //node:��ǰ�ڵ�
        //data:��������Դ
        //clas:��ǰ�ڵ��style
        private string _SysBuildNode(Song.Entities.ManageMenu m, string clas, string path)
        {
            Extend.MenuNode node = new Song.Extend.MenuNode(m, _allMM);
            string temp = "<div nodeId=\"" + m.MM_Id + "\"";
            temp += " nodetype=\"" + m.MM_Type + "\" ";
            temp += " title='" + (m.MM_Intro == "" ? m.MM_Name : m.MM_Intro) + "'";
            temp += " isChild=\"" + node.IsChilds + "\"  type=\"" + clas + "\" >";
            //�˵��ڵ���Զ�����ʽ
            string style = " ";
            if (m.MM_Color != String.Empty && m.MM_Color != null) style += "color: " + m.MM_Color + ";";
            if (m.MM_IsBold) style += "font-weight: bold;";
            if (m.MM_IsItalic) style += "font-style: italic;";
            if (m.MM_Font != String.Empty && m.MM_Font != null) style += "font-family: '" + m.MM_Font + "';";
            string name = "<span style=\"" + style + "\">" + m.MM_Name + "</span>";
            if (m.MM_Link != "")
            {
                string link = "";
                link += "<{0} href=\"";                
                link += m.MM_Link + "\" isChild=\"" + node.IsChilds + "\" IsUse=\"" + m.MM_IsUse
                     + "\" width=\"" + m.MM_WinWidth + "\" height=\""+m.MM_WinHeight
                     + "\" path=\"" + path + "\" target=\"_blank\" class=\"a\">";
                link += name + "</{0}>";
                switch(m.MM_Type.ToLower())
                {
                    case "link":
                        link = string.Format(link, "a");
                        break;
                    default:
                        link = link.Replace("{0}", "span");
                        break;
                }

                temp += link;
            }
            else
            {
                temp += name;
            }
            temp += "</div>";
            return temp;
        }
    }
}
