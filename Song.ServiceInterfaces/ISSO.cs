using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;
using System.Data.Common;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �����¼�Ĺ���
    /// </summary>
    public interface ISSO : WeiSha.Common.IBusinessInterface
    {        
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Add(SingleSignOn entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(SingleSignOn entity);
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
        SingleSignOn GetSingle(int identify);
        /// <summary>
        /// ͨ��Ӧ��appid��ȡ����
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        SingleSignOn GetSingle(string appid);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="isuse">�Ƿ�����</param>
        /// <returns></returns>
        SingleSignOn[] GetAll(bool? isuse);
        /// <summary>
        /// ĳ�����壨�����ţ������и���
        /// </summary>
        /// <param name="uid">�����Ψһ��ʶ</param>
        /// <param name="type">����</param>
        /// <returns></returns>
        SingleSignOn[] GetAll(bool? isuse,string type);        
    }
}
