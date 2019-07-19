using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��̳�Ĺ���
    /// </summary>
    public interface IMessageBoard : WeiSha.Common.IBusinessInterface
    {
        #region ��̳����Ĺ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeAdd(MessageBoard entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeSave(MessageBoard entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ThemeDelete(MessageBoard entity);
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
        MessageBoard ThemeSingle(int identify);
        /// <summary>
        /// ȡ����������
        /// </summary>
        /// <param name="searTxt"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        MessageBoard[] ThemeCount(int orgid, int couid, string searTxt, int count);
        MessageBoard[] ThemePager(int orgid, int couid, bool? isDel, bool? isShow, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="isDel">�Ƿ�ɾ��</param>
        /// <param name="couid">�γ�id</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="isAns">�Ƿ�ظ�</param>
        /// <param name="searTxt">�����ַ�</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        MessageBoard[] ThemePager(int orgid, int couid, bool? isDel, bool? isShow, bool? isAns, string searTxt, int size, int index, out int countSum);
        #endregion

        MessageBoard GetSingle(int identify);
        /// <summary>
        /// ��ӻظ�������Ϣ
        /// </summary>
        /// <param name="entity"></param>
        void AnswerAdd(MessageBoard entity);
        /// <summary>
        /// �޸Ļظ���Ϣ
        /// </summary>
        /// <param name="entity"></param>
        void AnswerSave(MessageBoard entity);
        /// <summary>
        /// ɾ���ظ���Ϣ
        /// </summary>
        /// <param name="identify"></param>
        void AnswerDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        MessageBoard AnswerSingle(int identify);
        /// <summary>
        /// ���ӵ��б�
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        MessageBoard[] ListPager(string uid, int size, int index, out int countSum);
    }
}
