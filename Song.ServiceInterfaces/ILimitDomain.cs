using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ���������Ĺ���
    /// </summary>
    public interface ILimitDomain : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void DomainAdd(LimitDomain entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void DomainSave(LimitDomain entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void DomainDelete(int identify);       
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        LimitDomain DomainSingle(int identify);
        /// <summary>
        /// ��ȡָ��������ʵ��
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        LimitDomain[] DomainCount(bool? isUse, int count);
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        bool DomainIsExist(LimitDomain entity);
        /// <summary>
        /// ��ǰ�����Ƿ����
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        bool DomainIsExist(string domain);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="search"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        LimitDomain[] DomainPager(bool? isUse, string search, int size, int index, out int countSum);
    }
}
