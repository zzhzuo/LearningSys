using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// Ժϵְλ�Ĺ���
    /// </summary>
    public interface IDailyLog : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Add(DailyLog entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(DailyLog entity);
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
        DailyLog GetSingle(int identify);
        /// <summary>
        /// ��ȡĳ��ʱ�����һ����¼���統ǰ��־����һ����־
        /// </summary>
        /// <param name="currTime">��ǰʱ��</param>
        /// <param name="type">��¼���,1Ϊ��־��2Ϊ��־��3Ϊ��־��4Ϊ�����ܽᣬ5Ϊ����ܽ�</param>
        /// <param name="accId">Ա��id</param>
        /// <returns></returns>
        DailyLog GetPrevious(DateTime currTime,string type,int accId);
        /// <summary>
        /// ��ҳ��ȡ���е���Ա��
        /// </summary>
        /// <param name="accId">������Ա��id</param>
        /// <param name="type">���࣬1Ϊ��־��2Ϊ��־��3Ϊ��־��4Ϊ�����ܽᣬ5Ϊ����ܽ�</param>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        DailyLog[] GetPager(int accId, string type,int size, int index, out int countSum);
        DailyLog[] GetPager(int accId, string type, DateTime start,DateTime end, int size, int index, out int countSum);
        
    }
}
