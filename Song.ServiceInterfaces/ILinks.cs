using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �������ӵĹ���
    /// </summary>
    public interface ILinks : WeiSha.Common.IBusinessInterface
    {
        #region ����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LinksAdd(Links entity);
        /// <summary>
        /// ���������ӣ���������Ľ������ӣ�
        /// </summary>
        /// <param name="entity"></param>
        void LinksApply(Links entity);
        /// <summary>
        /// ͨ����ˣ�����������Ľ������ӽ�����ˣ�
        /// </summary>
        /// <param name="identify"></param>
        void LinksVerify(Links entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LinksSave(Links entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LinksDelete(Links entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void LinksDelete(int identify);
        /// <summary>
        /// ɾ����������������
        /// </summary>
        /// <param name="name">����������</param>
        void LinksDelete(int orgid, string name);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Links LinksSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����������
        /// </summary>
        /// <param name="ttl">����������</param>
        /// <returns></returns>
        Links LinksSingle(int orgid, string ttl);
        /// <summary>
        /// ��ȡͬһ�����µ��������ţ�
        /// </summary>
        /// <param name="sortId">����Id</param>
        /// <returns></returns>
        int LinksMaxTaxis(int orgid, int sortId);
        /// ��ȡĳ��Ժϵ�����������
        /// </summary>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <returns></returns>
        Links[] GetLinksAll(int orgid, bool? isShow);
        /// <summary>
        /// ȡ��������
        /// </summary>
        /// <param name="sortId">����Id�����Ϊ����ȡ����</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <param name="count">ȡ��������¼�����С�ڵ���0����ȡ����</param>
        /// <returns></returns>
        Links[] GetLinks(int orgid, int sortId, bool? isShow, bool? isUse, int count);
        Links[] GetLinks(int orgid, string sortName, bool? isShow, bool? isUse, int count);
        /// <summary>
        /// ��ҳ��ȡ���е������
        /// </summary>
        /// <param name="sortId">����id</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Links[] GetLinksPager(int orgid, int sortId, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ����������
        /// </summary>
        /// <param name="sortId">����id</param>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="searTxt">�����ַ�</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Links[] GetLinksPager(int orgid, int sortId, bool? isUse, bool? isShow, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ����������
        /// </summary>
        /// <param name="sortId"></param>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="isVeri">�Ƿ�ͨ�����</param>
        /// <param name="isApply">�Ƿ��������</param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Links[] GetLinksPager(int orgid, int sortId, bool? isUse, bool? isShow, bool? isVeri, bool? isApply, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ���е������
        /// </summary>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Links[] GetLinksPager(int orgid, bool? isShow, int size, int index, out int countSum);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool LinksRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool LinksRemoveDown(int id);

        #endregion

        #region �������ӷ�����

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int SortAdd(LinksSort entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortSave(LinksSort entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortDelete(LinksSort entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void SortDelete(int identify);
        /// <summary>
        /// ɾ��������������
        /// </summary>
        /// <param name="name">��������</param>
        void SortDelete(string name);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        LinksSort SortSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���������
        /// </summary>
        /// <param name="name">��������</param>
        /// <returns></returns>
        LinksSort SortSingle(string name);
        /// <summary>
        /// ��ȡͬһ�����µ��������ţ�
        /// </summary>
        /// <param name="parentId">��Id</param>
        /// <returns></returns>
        int SortMaxTaxis(int orgid, int parentId);
        /// <summary>
        /// ��ȡ���󣻼����з��ࣻ
        /// </summary>
        /// <returns></returns>
        LinksSort[] GetSortAll(int orgid, bool? isUse, bool? isShow);
        /// <summary>
        /// ȡָ���������������ӷ���
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        LinksSort[] GetSortCount(int orgid, bool? isUse, bool? isShow, int count);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="isShow"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        LinksSort[] GetSortPager(int orgid, bool? isUse, bool? isShow, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns></returns>
        bool SortIsExist(int orgid, LinksSort entity);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool SortRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool SortRemoveDown(int id);

        #endregion
    }
}
