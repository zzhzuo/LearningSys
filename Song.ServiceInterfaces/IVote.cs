using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// Ժϵְλ�Ĺ���
    /// </summary>
    public interface IVote : WeiSha.Common.IBusinessInterface
    {
        #region ��������Ĳ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ThemeAdd(Vote entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeSave(Vote entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeDelete(Vote entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ThemeDelete(int identify);
        /// <summary>
        /// ��ȡ���⣬�����ǰ���ⲻ���ڣ��򷵻����µĵ�������
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        Vote GetTheme(int identify);
        /// <summary>
        /// ��ȡ���м򵥵��������
        /// </summary>
        /// <param name="isShow"></param>
        /// <param name="isUse"></param>
        /// <param name="count">���С�ڵ���0����ȡ����</param>
        /// <returns></returns>
        Vote[] GetSimpleTheme(bool? isShow, bool? isUse,int count);
        #endregion

        #region ������Ĳ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ItemAdd(Vote entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ItemSave(Vote entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ItemDelete(Vote entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ItemDelete(int identify);
        #endregion
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Vote GetSingle(int identify);
        /// <summary>
        /// ��ĳ��ѡ�����һ��ͶƱ��
        /// </summary>
        /// <param name="identify"></param>
        void AddResult(int identify);
        /// <summary>
        /// ��ĳ��ѡ�����ָ��ͶƱ��
        /// </summary>
        /// <param name="identify"></param>
        /// <param name="num">ָ����Ʊ��</param>
        void AddResult(int identify,int num);
        /// <summary>
        /// ��ȡĳ������ĵ�������
        /// </summary>
        /// <param name="uniqueid"></param>
        /// <returns></returns>
        DataTable GetVoteItem(string uniqueid);
        /// <summary>
        /// ��ȡĳ����������������õ�����Ʊ��
        /// </summary>
        /// <param name="uniqueid"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        Vote[] GetVoteItem(string uniqueid, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="isShow"></param>
        /// <param name="isUse"></param>
        /// <param name="type">�������ͣ�1Ϊ�򵥵��飬2Ϊ���Ϸ����������</param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Vote[] GetPager(bool? isShow, bool? isUse,int type, string searTxt, int size, int index, out int countSum);
        Vote[] GetPager(bool? isShow, bool? isUse, int type, string searTxt, DateTime start, DateTime end, int size, int index, out int countSum);
    }
}
