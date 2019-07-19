﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiSha.Common;
using Song.ServiceInterfaces;
using VTemplate.Engine;
using System.Text.RegularExpressions;

namespace Song.Site.Mobile
{
    /// <summary>
    /// 学员错题的列表
    /// </summary>
    public class QuesError : BasePage
    {
        //课程id
        protected int couid = WeiSha.Common.Request.QueryString["couid"].Int32 ?? 0;
        //当前学员收藏的试题
        Song.Entities.Questions[] collectQues = null;
        protected override void InitPageTemplate(HttpContext context)
        {
            if (Request.ServerVariables["REQUEST_METHOD"] == "GET")
            {
                //传递过来的试题总记录数
                if (!Extend.LoginState.Accounts.IsLogin) this.Response.Redirect("login.ashx");
                //题型
                this.Document.SetValue("quesType", WeiSha.Common.App.Get["QuesType"].Split(','));
                Song.Entities.Accounts st = Extend.LoginState.Accounts.CurrentUser;
                //错题列表
                Song.Entities.Questions[] ques = Business.Do<IStudent>().QuesAll(st.Ac_ID, 0, couid, -1);
                for (int i = 0; i < ques.Length; i++)
                {
                    ques[i] = Extend.Questions.TranText(ques[i]);
                    ques[i].Qus_Title = ques[i].Qus_Title.Replace("&lt;", "<");
                    ques[i].Qus_Title = ques[i].Qus_Title.Replace("&gt;", ">");
                    ques[i].Qus_Title = Extend.Html.ClearHTML(ques[i].Qus_Title, "p", "div", "font", "span");
                }
                this.Document.SetValue("Total", ques.Length);  //试题的总数
                this.Document.SetValue("couid", WeiSha.Common.Request.QueryString["couid"].Int32 ?? 0);
                this.Document.SetValue("ques", ques);              
                this.Document.RegisterGlobalFunction(this.AnswerItems);
                this.Document.RegisterGlobalFunction(this.IsCollect);
                this.Document.RegisterGlobalFunction(this.GetAnswer);
            }
            //此页面的ajax提交，全部采用了POST方式
            if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
            {
                string action = WeiSha.Common.Request.Form["action"].String;
                switch (action)
                {
                    case "delete":
                        delete();
                        break;
                    case "clear":
                        clear();
                        break;  
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void delete()
        {
            //记录的id
            int id = WeiSha.Common.Request.Form["qid"].Int32 ?? 0;
            try
            {
                if (id > 0)
                {
                    if (Extend.LoginState.Accounts.IsLogin)
                    {
                        Song.Entities.Accounts st = Extend.LoginState.Accounts.CurrentUser;
                        Business.Do<IStudent>().QuesDelete(id, st.Ac_ID);
                    }
                }
                Response.Write("1");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.End();
        }
        /// <summary>
        /// 清空
        /// </summary>
        private void clear()
        {
            int couid = WeiSha.Common.Request.Form["couid"].Int32 ?? 0;
            try
            {
                if (couid > 0)
                {
                    if (Extend.LoginState.Accounts.IsLogin)
                    {
                        Song.Entities.Accounts st = Extend.LoginState.Accounts.CurrentUser;
                        Business.Do<IStudent>().QuesClear(couid, st.Ac_ID);
                    }
                }
                Response.Write("1");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.End();
        }

        /// <summary>
        /// 当前试题的选项，仅用于单选与多选
        /// </summary>
        /// <returns>0为没有子级，其它有子级</returns>
        protected object AnswerItems(object[] p)
        {
            Song.Entities.Questions qus = null;
            if (p.Length > 0)
                qus = (Song.Entities.Questions)p[0];
            //当前试题的答案
            Song.Entities.QuesAnswer[] ans = Business.Do<IQuestions>().QuestionsAnswer(qus, null);
            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = Extend.Questions.TranText(ans[i]);
                //ans[i].Ans_Context = ans[i].Ans_Context.Replace("<", "&lt;");
                //ans[i].Ans_Context = ans[i].Ans_Context.Replace(">", "&gt;");
            }
            return ans;
        }
        /// <summary>
        /// 试题是否被当前学员收藏
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        protected object IsCollect(object[] objs)
        {
            int qid = 0;
            if (objs.Length > 0)
                qid = Convert.ToInt32(objs[0]);
            //当前收藏            
            if (collectQues == null)
            {
                if (Extend.LoginState.Accounts.IsLogin)
                {
                    Song.Entities.Accounts st = Extend.LoginState.Accounts.CurrentUser;
                    collectQues = Business.Do<IStudent>().CollectAll4Ques(st.Ac_ID, 0, couid, 0);
                }
                else
                {
                    collectQues = Business.Do<IStudent>().CollectAll4Ques(0, 0, couid, 0);
                }
            }
            if (collectQues != null)
            {
                foreach (Song.Entities.Questions q in collectQues)
                {
                    if (qid == q.Qus_ID) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 试题的答案
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        protected string GetAnswer(object[] objs)
        {
            //当前试题
            Song.Entities.Questions qus = null;
            if (objs.Length > 0) qus = objs[0] as Song.Entities.Questions;
            if (qus == null) return "";
            string ansStr = "";
            if (qus.Qus_Type == 1)
            {
                //当前试题的答案
                Song.Entities.QuesAnswer[] ans = Business.Do<IQuestions>().QuestionsAnswer(qus, null);
                for (int i = 0; i < ans.Length; i++)
                {
                    if (ans[i].Ans_IsCorrect)
                        ansStr += (char)(65 + i);
                }
            }
            if (qus.Qus_Type == 2)
            {
                Song.Entities.QuesAnswer[] ans = Business.Do<IQuestions>().QuestionsAnswer(qus, null);
                for (int i = 0; i < ans.Length; i++)
                {
                    if (ans[i].Ans_IsCorrect)
                        ansStr += (char)(65 + i) + "、";
                }
                ansStr = ansStr.Substring(0, ansStr.LastIndexOf("、"));
            }
            if (qus.Qus_Type == 3)
                ansStr = qus.Qus_IsCorrect ? "正确" : "错误";
            if (qus.Qus_Type == 4)
            {
                if (qus != null && !string.IsNullOrEmpty(qus.Qus_Answer))
                    ansStr = qus.Qus_Answer;
            }
            if (qus.Qus_Type == 5)
            {
                //当前试题的答案
                Song.Entities.QuesAnswer[] ans = Business.Do<IQuestions>().QuestionsAnswer(qus, null);
                for (int i = 0; i < ans.Length; i++)
                    ansStr += (char)(65 + i) + "、" + ans[i].Ans_Context + "<br/>";
            }
            return ansStr;
        }
    }
}