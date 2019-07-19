using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �ֻ��ͻ��˵Ĺ���
    /// </summary>
    public interface IMobileUser : WeiSha.Common.IBusinessInterface
    {        
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int Add(MobileUser entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(MobileUser entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Delete(MobileUser entity);
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
        MobileUser GetSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰��绰����
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        MobileUser GetSingle(string phone);
        /// <summary>
        /// ��ȡ�û�������
        /// </summary>
        /// <returns></returns>
        int GetCount();        
        /// <summary>
        /// ��ҳ��ȡ���е���վ�û��ʺţ�
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        MobileUser[] GetPager(int size, int index, out int countSum);
    }
}
