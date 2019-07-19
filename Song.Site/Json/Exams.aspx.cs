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
    public partial class Exams : System.Web.UI.Page
    {       

        protected void Page_Load(object sender, EventArgs e)
        {
            //׼����ʼ�Ŀ���
            DateTime start = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime end = start.AddDays(1);
            List<Song.Entities.Examination> kn = null;
            int stid = Extend.LoginState.Accounts.CurrentUser.Ac_ID;
            //��ȡ������Ҫ�μӵĿ���
            kn = Business.Do<IExamination>().GetSelfExam(stid,start, null);
            if (kn == null || kn.Count < 1)
            {
                //���û������Ŀ��ԣ�����ʾ�����Ŀ���
                kn = Business.Do<IExamination>().GetCountExam(stid,start, null, true, -1);
            }
            string tm = "[";
            for (int i = 0; i < kn.Count; i++)
            {
                kn[i].Exam_Intro = "";
                tm += "" + kn[i].ToJson();
                if (i < kn.Count - 1) tm += ",";
            }
            tm += "]";
            Response.Write(tm);
            Response.End();
        }
    }
}
