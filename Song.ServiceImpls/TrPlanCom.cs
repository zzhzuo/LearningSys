using System;
using System.Collections.Generic;
using System.Text;
using Song.ServiceInterfaces;
using WeiSha.Data;
using Song.Entities;
using WeiSha.Common;
using System.Data.Common;

namespace Song.ServiceImpls
{
    public class TrPlanCom:ITrPlan
    {
        #region ITrPlan ��Ա

        private void addData(Song.Entities.TrPlan theme, List<Song.Entities.ExamGroup> groups)
        {
            Song.Entities.Organization org = Business.Do<IOrganization>().OrganCurrent();
            if (org != null)
            {
                theme.Org_ID = org.Org_ID;
                theme.Org_Name = org.Org_Name;
            }
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    tran.Save<TrPlan>(theme);
                    if (groups != null)
                    {
                        foreach (Song.Entities.ExamGroup g in groups)
                        {
                            tran.Save<ExamGroup>(g);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
                finally
                {
                    tran.Close();
                }
            }
        }
        public void TrpAdd(Song.Entities.TrPlan theme, List<Song.Entities.ExamGroup> groups)
        {
            Song.Entities.Organization org = Business.Do<IOrganization>().OrganCurrent();
            if (org != null)
            {
                theme.Org_ID = org.Org_ID;
                theme.Org_Name = org.Org_Name;
            }
            if (groups == null)
                Gateway.Default.Save<TrPlan>(theme);
            else
                addData(theme, groups);
        }
        public void TrpSave(Song.Entities.TrPlan theme, int yuanType, int newType, List<Song.Entities.ExamGroup> groups)
        {
            //������ô�䣬��ɾ��������е����ݡ�
            if (yuanType != 1)
                Gateway.Default.Delete<ExamGroup>(ExamGroup._.Exam_UID == theme.TrP_UID);
            if (newType == 1)
                Gateway.Default.Save<TrPlan>(theme);
            else
                addData(theme, groups);
        }

        public void TrpDelete(int identify)
        {
            TrPlan tp = this.TrpSingle(identify);
            this.TrpDelete(tp.TrP_UID);
        }

        public void TrpDelete(string uid)
        {
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    tran.Delete<ExamGroup>(ExamGroup._.Exam_UID == uid);
                    tran.Delete<TrPlan>(TrPlan._.TrP_UID == uid);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
                finally
                {
                    tran.Close();
                }
            }
        }

        public Song.Entities.TrPlan TrpSingle(int identify)
        {
            return Gateway.Default.From<TrPlan>().Where(TrPlan._.TrP_Id == identify).ToFirst<TrPlan>();
        }

        public Song.Entities.TrPlan TrpSingle(string uid)
        {
            return Gateway.Default.From<TrPlan>().Where(TrPlan._.TrP_UID == uid).ToFirst<TrPlan>();
        }

        public bool TrpJudge(string uid, int depId, int teamId)
        {
            ExamGroup eg = null;
            if (depId != -1 || teamId != -1)
            {
                eg = Gateway.Default.From<ExamGroup>().Where(ExamGroup._.Exam_UID == uid).ToFirst<ExamGroup>();
            }
            return eg == null ? false : true;
        }

        public Song.Entities.TrPlan[] TrpItem(int groupType, int depId, int teamId)
        {
            if (groupType == 1)
                return Gateway.Default.From<TrPlan>().Where(TrPlan._.TrP_GroupType == groupType).ToArray<TrPlan>();
            else
            {
                //��ȡ���з������������ݵ�Ψһ��ʶ��
                //�ٸ�����Щ��ʶ��ȡ�������ݣ���ʱ������
                return null;
            }
        }

        public Song.Entities.TrPlan[] TrpItem(DateTime? timestall, DateTime? timeend, int? depId, int? sbjId, int? groupType, int? result, string teacher, string content, int size, int index, out int countSum)
        {
            WhereClip wc = new WhereClip();
            if (timestall != null)
            {
                wc.And(TrPlan._.TrP_Time >= (DateTime)timestall);
            }
            if (timeend != null)
            {
                wc.And(TrPlan._.TrP_Time < (DateTime)timeend);
            }
            //Ժϵ
            if (depId != null && depId > 0) wc.And(TrPlan._.Dep_Id == (int)depId);
            //ר��
            if (sbjId != null && sbjId > 0) wc.And(TrPlan._.Sbj_ID == (int)sbjId);
            //����
            if (groupType != null && groupType > 0) wc.And(TrPlan._.TrP_GroupType == (int)groupType);
            //��ɳ̶�
            if (result != null && result > 0) wc.And(TrPlan._.TrP_Result == (int)result);
            //��ʦ
            if (!string.IsNullOrEmpty(teacher) && teacher.Trim() != "")
                wc.And(TrPlan._.TrP_Teacher.Like("%" + teacher.Trim() + "%"));
            //����
            if(!string.IsNullOrEmpty(content) && content.Trim()!="")
                wc.And(TrPlan._.TrP_Content.Like("%" + content.Trim() + "%"));
            countSum = Gateway.Default.Count<TrPlan>(wc);
            return Gateway.Default.From<TrPlan>().Where(wc).OrderBy(TrPlan._.TrP_Id.Desc).ToArray<TrPlan>(size, (index - 1) * size);
        }
        #endregion
    }
}
