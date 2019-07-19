using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ���Ź���
    /// </summary>
    public interface ISMS : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MessageAdd(SmsMessage entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MessageSave(SmsMessage entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MessageDelete(SmsMessage entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void MessageDelete(int identify);       
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        SmsMessage GetSingle(int identify);        
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="type">1Ϊ��Է��࣬2Ϊ��Ը��ˣ�3Ϊ���Ա��</param>
        /// <param name="box">1Ϊ�ݸ��䣬2Ϊ�ѷ��ͣ�3Ϊ������</param>
        /// <param name="state">1Ϊ���ͳɹ���2Ϊ����ʧ�ܣ�3Ϊ����ʧ��</param>
        /// <param name="search">�����ݼ���</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        SmsMessage[] MessagePager(int? type, int? box, int? state,string search, int size, int index, out int countSum);


        /// <summary>
        /// ���Ͷ�����֤��
        /// </summary>
        /// <param name="phone">�ֻ���</param>
        /// <param name="keyname">д��cookis��keyֵ����</param>
        /// <returns>�Ƿ��ͳɹ�</returns>
        bool SendVcode(string phone, string keyname);
        /// <summary>
        /// ��ʽ���������ݣ���һЩ�滻��ת��ʵ������
        /// </summary>
        /// <param name="msg">�������ݡ����а������������{vcode}��֤�룬{platform}ƽ̨���ƣ�{org}�������,{date}ʱ�䡣</param>
        /// <param name="rnd">����ַ�</param>
        /// <returns></returns>
        string MessageFormat(string msg, string rnd);
    }
}
