using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ����Ĺ���
    /// </summary>
    public interface IProfitSharing: WeiSha.Common.IBusinessInterface
    {
        #region ���󷽰��Ĺ���
        /// <summary>
        /// ��ӷ�������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ThemeAdd(ProfitSharing entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeSave(ProfitSharing entity);
        /// <summary>
        /// ��ǰ���󷽰�
        /// </summary>
        /// <returns></returns>
        ProfitSharing ThemeCurrent();
        /// <summary>
        /// �����ķ��󷽰�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <returns></returns>
        ProfitSharing ThemeCurrent(int orgid);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeDelete(ProfitSharing entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ThemeDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ProfitSharing ThemeSingle(int identify);
        /// <summary>
        /// ��ȡ���󣻼����з��ࣻ
        /// </summary>
        /// <returns></returns>
        ProfitSharing[] ThemeAll(bool? isUse);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ThemeRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ThemeRemoveDown(int id);
        #endregion

        #region ����ȼ���������
        /// <summary>
        /// ��ӷ�����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ProfitAdd(ProfitSharing entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ProfitSave(ProfitSharing entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ProfitDelete(ProfitSharing entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ProfitDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ProfitSharing ProfitSingle(int identify);
        /// <summary>
        /// ���󷽰��ķ����
        /// </summary>
        /// <param name="theme">���������id</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        ProfitSharing[] ProfitAll(int theme, bool? isUse);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ProfitRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ProfitRemoveDown(int id);
        #endregion

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="couid">�γ�id,��Ҫ֪����ǰ�γ����ĸ��������ĸ������ȼ����Ӷ���ȡ���󷽰�</param>
        /// <param name="money">���ѵ��ʽ���</param>
        /// <param name="coupon">���ѵĿ���</param>
        /// <returns></returns>
        ProfitSharing[] Clac(int couid, double money, double coupon);
        ProfitSharing[] Clac(Course cou, double money, double coupon);
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="cou">��ǰ�γ�</param>
        /// <param name="acc">��ǰѧԱ�˻�</param>
        /// <param name="money">���ѵ��ʽ���</param>
        /// <param name="coupon">���ѵĿ���</param>
        void Distribution(Course cou, Accounts acc, double money, double coupon);
        #endregion
    }
}
