using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ͨѶ¼�Ĺ���
    /// </summary>
    public interface IAddressList : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���������Ϣ
        /// </summary>
        void Clear();

        #region ͨѶ¼
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void AddressAdd(AddressList entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void AddressSave(AddressList entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void AddressDelete(AddressList entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void AddressDelete(int identify);
        /// <summary>
        /// ɾ������
        /// </summary>
        void AddressDeleteAll();
        /// <summary>
        /// ɾ��������Ա����
        /// </summary>
        /// <param name="name">��Ա����</param>
        void AddressDelete(string name);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        AddressList AddressSingle(int identify);
        AddressList AddressSingle(string mobiTel);
        /// <summary>
        /// ��ȡĳ��Ժϵ��������Ա��
        /// </summary>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <returns></returns>
        List<AddressList> AddressAll();

        List<AddressList> AddressAll(int? sortId);
        /// <summary>
        /// ��ҳ��ȡ���е���Ա��
        /// </summary>
        /// <param name="accId">������Ա��id</param>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        List<AddressList> AddressPager(int accId, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ���е���Ա��
        /// </summary>
        /// <param name="accId">������Ա��id</param>
        /// <param name="typeName">����id</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        List<AddressList> AddressPager(int accId, string typeName, string personName, int size, int index, out int countSum);
        #endregion

        #region ͨѶ¼����
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int SortAdd(AddressSort entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortSave(AddressSort entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortDelete(AddressSort entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void SortDelete(int identify);
        /// <summary>
        /// ������з���
        /// </summary>
        void SortDeleteAll();
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        AddressSort SortSingle(int identify);
        /// <summary>
        /// ��ȡĳ��Ժϵ��������Ա��
        /// </summary>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <returns></returns>
        List<AddressSort> SortAll(bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ��
        /// </summary>
        /// <param name="accId">������Ա��id</param>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        List<AddressSort> SortPager(int accId, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ���е���Ա��
        /// </summary>
        /// <param name="accId">������Ա��id</param>
        /// <param name="sortName">��������</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        List<AddressSort> SortPager(int accId, string sortName, int size, int index, out int countSum);
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
