using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ѧ�ƹ���
    /// </summary>
    public interface ISubject : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���ѧ����רҵ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int SubjectAdd(Subject entity);
        /// <summary>
        /// �������רҵ�������ڵ���ʱ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="names">רҵ���ƣ��������ö��ŷָ��Ķ������</param>
        /// <returns></returns>
        Subject SubjectBatchAdd(int orgid, string names);
        /// <summary>
        /// �Ƿ��Ѿ�����רҵ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="pid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Subject SubjectIsExist(int orgid, int pid, string name);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SubjectSave(Subject entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void SubjectDelete(int identify);
        /// <summary>
        /// ���רҵ�µ���������
        /// </summary>
        /// <param name="identify"></param>
        void SubjectClear(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Subject SubjectSingle(int identify);
        /// <summary>
        /// ��ǰרҵ�µ�������רҵid
        /// </summary>
        /// <param name="sbjid">��ǰרҵid</param>
        /// <returns></returns>
        List<int> TreeID(int sbjid);
        /// <summary>
        /// ��ȡרҵ���ƣ����Ϊ�༶������ϸ�������
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        string SubjectName(int identify);
        /// <summary>
        /// ��ǰרҵ���Ƿ�����רҵ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="identify">��ǰרҵId</param>
        /// <returns>���Ӽ�������true</returns>
        bool SubjectIsChildren(int orgid, int identify, bool? isUse);
        /// <summary>
        /// ��ȡѧ��/רҵ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Subject[] SubjectCount(bool? isUse, int count);
        /// <summary>
        /// ��ȡѧ��/רҵ
        /// </summary>
        /// <param name="orgid">����ID</param>
        /// <param name="sear">�����ؼ���</param>
        /// <param name="isUse"></param>
        /// <param name="pid">�ϼ�ID</param>
        /// <param name="count"></param>
        /// <returns></returns>
        Subject[] SubjectCount(int orgid, string sear, bool? isUse, int pid, int count);
        /// <summary>
        /// ȡָ��������ѧ�ƻ�רҵ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="sear"></param>
        /// <param name="isUse"></param>
        /// <param name="pid"></param>
        /// <param name="order">����ʽ��defĬ���������Ƽ���������ţ���tax�������,rec���Ƽ�</param>
        /// <param name="index">��ʼ����</param>
        /// <param name="size">ȡ������</param>
        /// <returns></returns>
        Subject[] SubjectCount(int orgid, string sear, bool? isUse, int pid, string order, int index, int size);
        /// <summary>
        /// ��ȡѧ��/רҵ
        /// </summary>
        /// <param name="orgid">����ID</param>
        /// <param name="sear">�����ؼ���</param>
        /// <param name="isUse"></param>
        /// <param name="pid">�ϼ�ID</param>
        /// <param name="count"></param>
        /// <returns></returns>
        Subject[] SubjectCount(int orgid, int depid, string sear, bool? isUse, int pid, int count);
        /// <summary>
        /// ��ǰרҵ���ϼ�����
        /// </summary>
        /// <param name="sbjid"></param>
        /// <param name="isself">�Ƿ��������</param>
        /// <returns></returns>
        List<Subject> Parents(int sbjid, bool isself);
        /// <summary>
        /// ����רҵ����
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="pid">�ϼ�id</param>
        /// <param name="count"></param>
        /// <returns></returns>
        int SubjectOfCount(int orgid, bool? isUse, int pid);
        /// <summary>
        /// ��ǰѧ���µ���������
        /// </summary>
        /// <param name="orgid">��ǰ����</param>
        /// <param name="identify"></param>
        /// <param name="qusType">��������</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Questions[] QusForSubject(int orgid, int identify, int qusType, bool? isUse, int count);
        /// <summary>
        /// ��ȡרҵ���µ���������
        /// </summary>
        /// <param name="orgid">��ǰ����</param>
        /// <param name="identify">רҵid</param>
        /// <param name="qusType">�������</param>
        /// <param name="isUse">�Ƿ����õ�����</param>
        /// <returns></returns>
        int QusCountForSubject(int orgid, int identify, int qusType, bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Subject[] SubjectPager(int orgid, int depid, bool? isUse, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool RemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool RemoveDown(int id);

    }
}
