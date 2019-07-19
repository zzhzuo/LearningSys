using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// Ժϵְλ�Ĺ���
    /// </summary>
    public interface ITask : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int Add(Task entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(Task entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Delete(Task entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void Delete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Task GetSingle(int identify);
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
        /// <summary>
        /// ��ҳ��ȡ����
        /// </summary>
        /// <param name="level">�ȼ�</param>
        /// <param name="size">ÿҳ������Ϣ</param>
        /// <param name="index">�ڼ�ҳ</param>
        /// <param name="countSum">���ݼ�¼������</param>
        /// <returns></returns>
        Task[] GetPager(int level,int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ�Լ��ɷ�����
        /// </summary>
        /// <param name="accId">Ա��id</param>
        /// <param name="isGoback">�Ƿ����˻ص�����</param>
        /// <param name="start">��ʼʱ��</param>
        /// <param name="end">����ʱ��</param>
        /// <param name="state">�����״̬��1��ɣ�2δ��ɣ�3����δ��ɣ�4���ڴ���5�ر�</param>
        /// <param name="level">��������ȼ�</param>
        /// <param name="searStr">�����ַ�</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Task[] GetMyPager(int accId,bool isGoback,DateTime start, DateTime end, string state, int level, string searStr, int size, int index, out int countSum);
        /// <summary>
        /// ��ȡ�Լ��нӵ�����
        /// </summary>
        /// <param name="accId">�н������Ա��Id</param>
        /// <param name="isGoback"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="state"></param>
        /// <param name="level"></param>
        /// <param name="searStr"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Task[] GetWorkerPager(int accId, bool isGoback, DateTime start, DateTime end, string state, int level, string searStr, int size, int index, out int countSum);
    }
}
