using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��ֵ�����
    /// </summary>
    public interface IRecharge : WeiSha.Common.IBusinessInterface
    { 
        #region ��ֵ�����ù���
        /// <summary>
        /// ��ӳ�ֵ��������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void RechargeSetAdd(RechargeSet entity);
        /// <summary>
        /// �޸ĳ�ֵ��������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void RechargeSetSave(RechargeSet entity);
        /// <summary>
        /// ɾ����ֵ��������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void RechargeSetDelete(RechargeSet entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void RechargeSetDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        RechargeSet RechargeSetSingle(int identify);
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="orgid">���ڻ���id</param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        RechargeSet[] RechargeSetCount(int orgid, bool? isEnable, int count);
        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <returns></returns>
        int RechargeSetOfCount(int orgid, bool? isEnable);
        /// <summary>
        /// ��ҳ��ȡ��ֵ��������
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        RechargeSet[] RechargeSetPager(int orgid, bool? isEnable, string searTxt, int size, int index, out int countSum);
        #endregion

        #region ��ֵ�����
        /// <summary>
        /// ��ӳ�ֵ��������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void RechargeCodeAdd(RechargeCode entity);
        /// <summary>
        /// �޸ĳ�ֵ��������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void RechargeCodeSave(RechargeCode entity);
        /// <summary>
        /// ɾ����ֵ��������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void RechargeCodeDelete(RechargeCode entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void RechargeCodeDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        RechargeCode RechargeCodeSingle(int identify);
        /// <summary>
        /// У���ֵ���Ƿ���ڣ������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        RechargeCode CouponCheckCode(string code);
        /// <summary>
        /// ʹ�øó�ֵ��
        /// </summary>
        /// <param name="entity"></param>
        void CouponUseCode(RechargeCode entity);
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="orgid">���ڻ���id</param>
        /// <param name="orgid">����id</param>
        /// <param name="rsid">�����������id</param>
        /// <param name="isEnable">�Ƿ�����</param>
        /// <param name="isUsed">�Ƿ��Ѿ�ʹ��</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        RechargeCode[] RechargeCodeCount(int orgid, int rsid, bool? isEnable, bool? isUsed, int count);
        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="orgid">����id</param>
        /// <param name="rsid">�����������id</param>
        /// <param name="isEnable">�Ƿ�����</param>
        /// <param name="isUsed">�Ƿ��Ѿ�ʹ��</param>
        /// <returns></returns>
        int RechargeCodeOfCount(int orgid, int rsid, bool? isEnable, bool? isUsed);
        /// <summary>
        /// ����Excel��ʽ�ĳ�ֵ����Ϣ
        /// </summary>
        /// <param name="path">�����ļ���·�����������ˣ�</param>
        /// <param name="orgid">����id</param>
        /// <param name="rsid">��ֵ���������id</param>
        /// <returns></returns>
        string RechargeCode4Excel(string path, int orgid, int rsid);
        /// <summary>
        /// ��ҳ��ȡ��ֵ��������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="rsid">�����������id</param>
        /// <param name="isEnable">�Ƿ�����</param>
        /// <param name="isUsed">�Ƿ��Ѿ�ʹ��</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        RechargeCode[] RechargeCodePager(int orgid, int rsid, bool? isEnable, bool? isUsed, int size, int index, out int countSum);
        RechargeCode[] RechargeCodePager(int orgid, int rsid, string code, bool? isEnable, bool? isUsed, int size, int index, out int countSum);
        #endregion
    }
}
