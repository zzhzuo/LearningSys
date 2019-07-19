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
    public partial class QuesRandom : System.Web.UI.Page
    {       
        //�Ծ�id������id,ѧ��id
        private int tpid = WeiSha.Common.Request.Form["tpid"].Int32 ?? 0;
        private int examid = WeiSha.Common.Request.Form["examid"].Int32 ?? 0;
        private int stid = WeiSha.Common.Request.Form["stid"].Int32 ?? 0;
        //��ȡ��ǰѧ���µ������Ծ�
        protected void Page_Load(object sender, EventArgs e)
        {
            //��ȡ������Ϣ
            Song.Entities.ExamResults exr = Business.Do<IExamination>().ResultSingle(examid, tpid, stid);
            //ȡ����
            List<Song.Entities.Questions> quesList = new List<Questions>();
            if (exr == null)
            {
                //ȡ���ǵ�һ�δ򿪣�������������⣬��Ϊ��ȡ�Ծ�
                Song.Entities.TestPaper tp = Business.Do<ITestPaper>().PagerSingle(tpid);
                //�Ѷ�����
                int diff1 = tp.Tp_Diff > tp.Tp_Diff2 ? (int)tp.Tp_Diff2 : (int)tp.Tp_Diff;
                int diff2 = tp.Tp_Diff > tp.Tp_Diff2 ? (int)tp.Tp_Diff : (int)tp.Tp_Diff2;
                //��ȡ������
                Song.Entities.TestPaperItem[] tpi = Business.Do<ITestPaper>().GetItemForAll(tp);
                foreach (Song.Entities.TestPaperItem pi in tpi)
                {
                    //���ͣ�������Ŀ��������ռ���ٷ֣�
                    int type = (int)pi.TPI_Type;
                    int count = (int)pi.TPI_Count;
                    float num = (float)pi.TPI_Number;
                    int per = (int)pi.TPI_Percent;
                    if (count < 1) continue;
                    Song.Entities.Questions[] ques = Business.Do<IQuestions>().QuesRandom(tp.Org_ID, (int)tp.Sbj_ID, -1, -1, type, diff1, diff2, true, count);
                    float surplus = num;
                    for (int i = 0; i < ques.Length; i++)
                    {
                        //��ǰ����ķ���
                        float curr = ((float)pi.TPI_Number) / ques.Length;
                        curr = ((float)Math.Round(curr * 10)) / 10;
                        if (i < ques.Length - 1)
                        {
                            ques[i].Qus_Number = curr;
                            surplus = surplus - curr;
                        }
                        else
                        {
                            ques[i].Qus_Number = surplus;
                        }
                    }
                    foreach (Song.Entities.Questions q in ques)
                        quesList.Add(replaceText(q));
                }

            }
            else
            {
                //����Ѿ���������
                if (exr.Exr_IsSubmit)
                {
                    //����Ѿ�������������������
                    Response.Write("2");
                    Response.End();
                }
                else
                {
                    quesList = Business.Do<IExamination>().QuesForResults(exr.Exr_Results);
                }
            }
            
            string tm = "[";
            for (int i = 0; i < quesList.Count; i++)
            {
                string json = quesList[i].ToJson();
                //����ǵ�ѡ�⣬���ѡ�⣬�������
                if (quesList[i].Qus_Type == 1 || quesList[i].Qus_Type == 2 || quesList[i].Qus_Type == 5)
                    tm += getAnserJson(quesList[i], json);
                else
                    tm += json;
                if (i < quesList.Count - 1) tm += ",";
            }
            tm += "]";
            Response.Write(tm);
            Response.End();
        }
        private string getAnserJson(Song.Entities.Questions q, string json)
        {
            //��ǰ����Ĵ�
            Song.Entities.QuesAnswer[] ans = Business.Do<IQuestions>().QuestionsAnswer(q, null);
            string ansStr = "[";
            for (int i = 0; i < ans.Length; i++)
            {
                ansStr += ans[i].ToJson();
                if (i < ans.Length - 1) ansStr += ",";
            }
            ansStr += "]";
            json = json.Replace("}", ",\"Answer\":" + ansStr + "}");
            return json;
        }
        /// <summary>
        /// ���������е��ı�����
        /// </summary>
        /// <param name="qs"></param>
        /// <returns></returns>
        private Song.Entities.Questions replaceText(Song.Entities.Questions qs)
        {
            qs.Qus_Title = qs.Qus_Title == null ? "" : qs.Qus_Title;
            qs.Qus_Title = qs.Qus_Title.Replace("\r","");
            qs.Qus_Title = qs.Qus_Title.Replace("\n", "");
            qs.Qus_Title = qs.Qus_Title.Replace("\"", "��");
            qs.Qus_Title = qs.Qus_Title.Replace("\t", "");
            //
            qs.Qus_Explain = qs.Qus_Explain == null ? "" : qs.Qus_Explain;
            if (qs.Qus_Explain != string.Empty)
            {
                qs.Qus_Explain = qs.Qus_Explain.Replace("\r", "");
                qs.Qus_Explain = qs.Qus_Explain.Replace("\n", "");
                qs.Qus_Explain = qs.Qus_Explain.Replace("\"", "��");
                qs.Qus_Explain = qs.Qus_Title.Replace("\t", "");
            }
            //
            if (qs.Qus_Answer != string.Empty)
            {
                qs.Qus_Answer = qs.Qus_Answer == null ? "" : qs.Qus_Answer;
                qs.Qus_Answer = qs.Qus_Answer.Replace("\r", "");
                qs.Qus_Answer = qs.Qus_Answer.Replace("\n", "");
                qs.Qus_Answer = qs.Qus_Answer.Replace("\"", "��");
                qs.Qus_Answer = qs.Qus_Title.Replace("\t", "");
            }
            return qs;
        }
    }
}
