using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// Ժϵְλ�Ĺ���
    /// </summary>
    public interface INotice : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Add(Notice entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(Notice entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Delete(Notice entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void Delete(int identify);
        /// <summary>
        /// ɾ��������������
        /// </summary>
        /// <param name="name">��������</param>
        void Delete(string name);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Notice NoticeSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���������
        /// </summary>
        /// <param name="ttl">��������</param>
        /// <returns></returns>
        Notice NoticeSingle(string ttl);
        /// <summary>
        /// ��ǰ�������һ������
        /// </summary>
        /// <param name="identify"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        Notice NoticePrev(int identify, int orgid);
        /// <summary>
        /// ��ǰ�������һ������
        /// </summary>
        /// <param name="identify"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        Notice NoticeNext(int identify, int orgid);
        /// <summary>
        /// ��ȡ���󣻼����й��棻
        /// </summary>
        /// <returns></returns>
        Notice[] GetAll();
        /// <summary>
        /// ��ȡĳ��Ժϵ�����й��棻
        /// </summary>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <returns></returns>
        Notice[] GetAll(int orgid, bool? isShow);
        /// <summary>
        /// ��ȡָ�������ļ�¼
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isShow"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Notice[] GetCount(int orgid, bool? isShow, int count);
        /// <summary>
        /// ȡ���������
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        int OfCount(int orgid, bool? isShow);
        /// <summary>
        /// ��ҳ��ȡ���еĹ��棻
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        Notice[] GetPager(int orgid, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ���еĹ��棻
        /// </summary>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="searTxt">��ѯ�ַ�</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Notice[] GetPager(int orgid, bool? isShow, string searTxt, int size, int index, out int countSum);
        
    }
}
