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

using Song.ServiceInterfaces;
using Song.Entities;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using WeiSha.Common;
namespace Song.Site.Json
{
    public partial class ExamResults : System.Web.UI.Page
    {       
        //�Ծ�id������id,Ա��id
        private int tpid = WeiSha.Common.Request.Form["tpid"].Int32 ?? 0;
        private int examid = WeiSha.Common.Request.Form["examid"].Int32 ?? 0;
        private int accid = WeiSha.Common.Request.Form["accid"].Int32 ?? 0;
        //��ȡ��ǰѧ���µ������Ծ�
        protected void Page_Load(object sender, EventArgs e)
        {
            //��ȡ������Ϣ
            Song.Entities.ExamResults exr = Business.Do<IExamination>().ResultSingle(examid, tpid, accid);           
            if (exr == null)
            {
                Response.Write("0");

            }
            else
            {
                Response.Write(exr.Exr_Results);
            }  
            Response.End();
        }       
    }
}
