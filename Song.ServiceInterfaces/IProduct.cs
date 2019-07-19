using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��Ʒ�Ĺ����Լ���Ʒ��صĹ���
    /// </summary>
    public interface IProduct : WeiSha.Common.IBusinessInterface
    {

        #region ��Ʒ��ѯ���ԵĹ���
        /// <summary>
        /// ��Ӳ�Ʒ��ѯ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int MessageAdd(ProductMessage entity);
        /// <summary>
        /// �޸Ĳ�Ʒ��ѯ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MessageSave(ProductMessage entity);
        /// <summary>
        /// ɾ����Ʒ��ѯ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MessageDelete(ProductMessage entity);
        /// <summary>
        /// ����ɾ����Ʒ��ѯ���ԣ�������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void MessageDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ProductMessage MessageSingle(int identify);
        /// <summary>
        /// ��ȡ��ǰ��ѯ���Թ����Ĳ�Ʒ��Ϣ
        /// </summary>
        /// <param name="pmid"></param>
        /// <returns></returns>
        Product ProductByMessage(int pmid);
        /// <summary>
        /// ��ȡ���Է�ҳ��Ϣ
        /// </summary>
        /// <param name="pdid">��Ʒid</param>
        /// <param name="searTxt"></param>
        /// <param name="isAns">�Ƿ�ظ�</param>
        /// <param name="isShow">�Ƿ�������ʾ</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        ProductMessage[] GetProductMessagePager(int? pdid, string searTxt, bool? isAns,bool? isShow, int size, int index, out int countSum);
        ProductMessage[] GetProductMessagePager(string searTxt, bool? isAns, bool? isShow, int size, int index, out int countSum);
        #endregion
        

        #region ��Ʒ����
        /// <summary>
        /// ������Ʒ����
        /// </summary>
        /// <param name="entity"></param>
        void FactoryAdd(ProductFactory entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void FactorySave(ProductFactory entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void FactoryDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ProductFactory FactorySingle(int identify);
        /// <summary>
        /// ��ȡ���в�Ʒ����
        /// </summary>
        /// <param name="isUse"></param>
        /// <returns></returns>
        ProductFactory[] FactoryAll(bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ������Ϣ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        ProductFactory[] FactoryPager(bool? isUse, string searTxt, int size, int index, out int countSum);
        #endregion

        #region ��Ʒ����
        /// <summary>
        /// ������Ʒ����
        /// </summary>
        /// <param name="entity"></param>
        void MaterialAdd(ProductMaterial entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MaterialSave(ProductMaterial entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void MaterialDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ProductMaterial MaterialSingle(int identify);
        /// <summary>
        /// ��ȡ���в�Ʒ����
        /// </summary>
        /// <param name="isUse"></param>
        /// <returns></returns>
        ProductMaterial[] MaterialAll(bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ������Ϣ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        ProductMaterial[] MaterialPager(bool? isUse, string searTxt, int size, int index, out int countSum);
        #endregion

        #region ��Ʒ����
        /// <summary>
        /// ������Ʒ����
        /// </summary>
        /// <param name="entity"></param>
        void OriginAdd(ProductOrigin entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void OriginSave(ProductOrigin entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void OriginDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ProductOrigin OriginSingle(int identify);
        /// <summary>
        /// ��ȡ���в�Ʒ����
        /// </summary>
        /// <param name="isUse"></param>
        /// <returns></returns>
        ProductOrigin[] OriginAll(bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ������Ϣ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        ProductOrigin[] OriginPager(bool? isUse, string searTxt, int size, int index, out int countSum);
        #endregion
    }
}
