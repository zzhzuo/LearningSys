using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ���Թ���
    /// </summary>
    public interface ITrPlan : WeiSha.Common.IBusinessInterface
    {

        #region ���Թ���
        /// <summary>
        /// �����ѵ�ƻ�
        /// </summary>
        /// <param name="theme">��ѵ�ƻ�</param>
        /// <param name="groups">�μ���Ա�ķ�Χ</param>
        void TrpAdd(TrPlan theme, List<ExamGroup> groups);
        /// <summary>
        /// �޸���ѵ�ƻ�
        /// </summary>
        /// <param name="theme">��ѵ�ƻ�</param>
        /// <param name="yuanType">ԭ��������</param>
        /// <param name="newType">�²�������</param>
        /// <param name="groups">�μ���Ա�ķ�Χ</param>
        void TrpSave(TrPlan theme, int yuanType, int newType, List<ExamGroup> groups);
        /// <summary>
        /// ɾ����ѵ�ƻ���ʹ������ID
        /// </summary>
        /// <param name="identify">����ID</param>
        void TrpDelete(int identify);
        /// <summary>
        /// ɾ����ѵ�ƻ���ʹ��ҳ��Ψһ��ʶ
        /// </summary>
        /// <param name="identify">ҳ��Ψһ��ʶ</param>
        void TrpDelete(string uid);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        TrPlan TrpSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ�����ͨ��ȫ��Ψһֵ
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        TrPlan TrpSingle(string uid);
        /// <summary>
        /// �ж�ָ���������Ƿ����Ҫ��
        /// </summary>
        /// <param name="uid">ҳ��Ψһ��ʶ</param>
        /// <param name="depId">Ժϵid��Ϊ-1ʱ����Ϊ������</param>
        /// <param name="teamId">����id��Ϊ-1ʱ����Ϊ������</param>
        /// <returns></returns>
        bool TrpJudge(string uid, int depId, int teamId);
        /// <summary>
        /// ��ȡָ�������Ժϵid�Լ�����id��������ѵ�ƻ�
        /// </summary>
        /// <param name="groupType">�������ͣ�1�������ˣ�2����Ժϵ��3�������飻-1������Ժϵ����飩</param>
        /// <param name="depId">Ժϵid��Ϊ-1ʱ�������������</param>
        /// <param name="teamId">����id��Ϊ-1ʱ�������������</param>
        /// <returns></returns>
        TrPlan[] TrpItem(int groupType, int depId, int teamId);
   
        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        /// <param name="time">����</param>
        /// <param name="startH">��ʼʱ��(ʱ)</param>
        /// <param name="startM">��ʼʱ��(��)</param>
        /// <param name="endH">����ʱ��(ʱ)</param>
        /// <param name="endM">����ʱ��(��)</param>
        /// <param name="depId">����Ժϵid</param>
        /// <param name="sbjId">רҵid</param>
        /// <param name="groupType">��������</param>
        /// <param name="result">������</param>
        /// <param name="teacher">��ѵ��ʦ</param>
        /// <param name="content">��ѵ����</param>
        /// <param name="size">ÿҳ��ʾ������</param>
        /// <param name="index">��ǰҳ��</param>
        /// <param name="countSum">������������������</param>
        /// <returns></returns>
        TrPlan[] TrpItem(DateTime? timestall, DateTime? timeend, int? depId, int? sbjId, int? groupType, int? result, string teacher, string content, int size, int index, out int countSum);
        #endregion
    }
}
