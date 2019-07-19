using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;
using WeiSha.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��ʦ�Ĺ���
    /// </summary>
    public interface ITeacher : WeiSha.Common.IBusinessInterface
    {       

        #region ��ʦ����
        /// <summary>
        /// ��ӽ�ʦ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns>����Ѿ����ڸý�ʦ���򷵻�-1</returns>
        int TeacherAdd(Teacher entity);
        /// <summary>
        /// �޸Ľ�ʦ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void TeacherSave(Teacher entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void TeacherDelete(int identify);
        /// <summary>
        /// ɾ��������վ��ʦ�ʺ���
        /// </summary>
        /// <param name="name">��վ��ʦ����</param>
        void TeacherDelete(string accname, int orgid);
        /// <summary>
        /// ɾ����ʦ
        /// </summary>
        /// <param name="entity"></param>
        void TeacherDelete(Teacher entity);
        void TeacherDelete(Teacher entity, DbTrans tran);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Teacher TeacherSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰��˺ţ�
        /// </summary>
        /// <param name="accname"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        Teacher TeacherSingle(string accname, int orgid);
        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="acc">�˺ţ������֤�����ֻ�</param>
        /// <param name="pw">����</param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        Teacher TeacherLogin(string acc, string pw, int orgid);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���վ��ʦ����
        /// </summary>
        /// <param name="name">�ʺ�����</param>
        /// <returns></returns>
        Teacher TeacherSingle(string accname, string pw, int orgid);
        /// <summary>
        /// ��ǰ���ʺ��Ƿ�����
        /// </summary>
        /// <param name="name">��ʦ�ʺ�</param>
        /// <returns></returns>
        bool IsTeacherExist(int orgid, string accname);
        bool IsTeacherExist(int orgid, Teacher entity);
        /// <summary>
        /// ��ȡ���󣻼�������վ��ʦ��
        /// </summary>
        /// <returns></returns>
        Teacher[] TeacherAll(int orgid,bool? isUse);
        /// <summary>
        /// ��ȡ��ʦ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Teacher[] TeacherCount(int orgid, bool? isUse, int count);
        /// <summary>
        /// ��ȡ��ʦ����
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        int TeacherOfCount(int orgid, bool? isUse);
        /// <summary>
        /// ����Excel��ʽ�Ľ�ʦ��Ϣ
        /// </summary>
        /// <param name="path">�����ļ���·�����������ˣ�</param>
        /// <param name="orgid">����id</param>
        /// <param name="sortid">��ʦ����id��С��0Ϊȫ��</param>
        /// <returns></returns>
        string TeacherExport4Excel(string path, int orgid, int sortid);
        /// <summary>
        /// ��ҳ��ȡ���е���վ��ʦ�ʺţ�
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        Teacher[] TeacherPager(int orgid, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡĳ��ʦ�飬���е���վ��ʦ�ʺţ�
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="thsid">��ʦ����id</param>
        /// <param name="isUse"></param>
        /// <param name="isShow">�Ƿ���ǰ̨��ʾ</param>
        /// <param name="searName"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Teacher[] TeacherPager(int orgid, int thsid, bool? isUse, bool? isShow, string searName, int size, int index, out int countSum);        
        #endregion

        #region ��ʦ�������
        /// <summary>
        /// ���ѧ������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortAdd(TeacherSort entity);
        /// <summary>
        /// �޸�ѧ������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortSave(TeacherSort entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns>���ɾ���ɹ�������0����������ѧ��������-1�������Ĭ���飬����-2</returns>
        int SortDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        TeacherSort SortSingle(int identify);
        /// <summary>
        /// ��ȡĬ��ѧ����
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <returns></returns>
        TeacherSort SortDefault(int orgid);
        /// <summary>
        /// ����Ĭ��ѧ������
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="identify"></param>
        /// <returns></returns>
        void SortSetDefault(int orgid, int identify);
        /// <summary>
        /// ��ȡ���󣻼�����ѧ���飻
        /// </summary>
        /// <returns></returns>
        TeacherSort[] SortAll(int orgid, bool? isUse);
        /// <summary>
        /// ��ȡָ�������Ķ���
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        TeacherSort[] SortCount(int orgid, bool? isUse, int count);
        /// <summary>
        /// ��ȡĳ��վѧ���������飻
        /// </summary>
        /// <param name="TeacherId">��վѧ��id</param>
        /// <returns></returns>
        TeacherSort Sort4Teacher(int studentId);
        /// <summary>
        /// ��ȡĳ�����������վѧ��
        /// </summary>
        /// <param name="sortid">����id</param>
        /// <returns></returns>
        Teacher[] Teacher4Sort(int sortid, bool? isUse);
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        bool SortIsExist(TeacherSort entity);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool SortRemoveUp(int orgid, int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool SortRemoveDown(int orgid, int id);
        #endregion

        #region ��ʦ��������
        /// <summary>
        /// ��ӽ�ʦ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns>����Ѿ����ڸý�ʦ���򷵻�-1</returns>
        int HistoryAdd(TeacherHistory entity);
        /// <summary>
        /// �޸Ľ�ʦ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void HistorySave(TeacherHistory entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void HistoryDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        TeacherHistory HistorySingle(int identify);
        /// <summary>
        /// ��ȡ���󣻼�������վ��ʦ��
        /// </summary>
        /// <returns></returns>
        TeacherHistory[] HistoryAll(int thid);
        /// <summary>
        /// ��ȡ��ʦ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        TeacherHistory[] HistoryCount(int thid, int count);        
        #endregion

        #region ��ʦ���۹���
        /// <summary>
        /// ��ӽ�ʦ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns></returns>
        int CommentAdd(TeacherComment entity);
        /// <summary>
        /// �޸Ľ�ʦ������Ϣ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void CommentSave(TeacherComment entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void CommentDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        TeacherComment CommentSingle(int identify);
        /// <summary>
        /// ĳ���ڣ����һ��ѧԱ����ʦ������
        /// </summary>
        /// <param name="thid">��ʦid</param>
        /// <param name="accid">ѧԱid</param>
        /// <param name="day">��ǰ����</param>
        /// <returns></returns>
        TeacherComment CommentSingle(int thid, int accid, int day);
        /// <summary>
        /// �����ʦ�����֣��ӵ�ǰ����֮ǰ�Ķ�������
        /// </summary>
        /// <param name="thid">���ֽ�ʦ��id</param>
        /// <param name="day">�ӵ�ǰ����֮ǰ�Ķ������ڣ�С�ڻ����0��ʾȡ����</param>
        /// <returns></returns>
        double CommentScore(int thid, int day);
        /// <summary>
        /// �����ʦ�����֣�ͨ����ʼʱ��
        /// </summary>
        /// <param name="thid">���ֽ�ʦ��id</param>
        /// <param name="start">��ʼʱ��</param>
        /// <param name="end">����ʱ��</param>
        /// <returns></returns>
        double CommentScore(int thid, DateTime? start, DateTime? end);
        /// <summary>
        /// ��ȡ��ʦ������
        /// </summary>
        /// <param name="thid">��ʦid</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        TeacherComment[] CommentCount(int thid, bool? isUse, bool? isShow, int count);
        /// <summary>
        /// ��ʦ��������
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="day">�������ڵ�����</param>
        /// <param name="count">��ȡ����</param>
        /// <returns></returns>
        TeacherComment[] CommentOrder(int orgid, bool? isUse, bool? isShow, int day, int count);
        /// <summary>
        /// ĳ���ڣ�ѧԱ����ʦ��������
        /// </summary>
        /// <param name="thid">��ʦid</param>
        /// <param name="accid">ѧԱid</param>
        /// <param name="day">��ǰ����</param>
        /// <returns></returns>
        int CommentOfCount(int thid, int accid, int day);
        /// <summary>
        /// ��ǰ�����µ����н�ʦ������Ϣ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        TeacherComment[] CommentPager(int orgid, bool? isUse, bool? isShow, int size, int index, out int countSum);
        /// <summary>
        /// ��ǰ������ĳ����ʦ��������Ϣ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="thid">��ʦid</param>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        TeacherComment[] CommentPager(int orgid, int thid, bool? isUse, bool? isShow, int size, int index, out int countSum);
        /// <summary>
        /// ��ǰ������ĳ����ʦ��������Ϣ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="thname">��ʦ����</param>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        TeacherComment[] CommentPager(int orgid, string thname, bool? isUse, bool? isShow, int size, int index, out int countSum);
        #endregion
    }
}
