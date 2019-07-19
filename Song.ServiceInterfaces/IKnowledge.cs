using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ֪ʶ�����
    /// </summary>
    public interface IKnowledge : WeiSha.Common.IBusinessInterface
    {
        #region ֪ʶ�����
        /// <summary>
        /// ���֪ʶ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int KnowledgeAdd(Knowledge entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void KnowledgeSave(Knowledge entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void KnowledgeDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Knowledge KnowledgeSingle(int identify);
        /// <summary>
        /// ��ǰ֪ʶ����һ��֪ʶ
        /// </summary>
        /// <param name="couid">�γ�id����С��0ʱȡ���У�����0ʲôҲ��ȡ��</param>
        /// <param name="kns">����Id</param>
        /// <param name="id"></param>
        /// <returns></returns>
        Knowledge KnowledgePrev(int couid, int kns, int id);
        /// <summary>
        /// ��ǰ֪ʶ����һ��֪ʶ
        /// </summary>
        /// <param name="couid">�γ�id����С��0ʱȡ���У�����0ʲôҲ��ȡ��</param>
        /// <param name="kns">����Id</param>
        /// <param name="id"></param>
        /// <returns></returns>
        Knowledge KnowledgeNext(int couid, int kns, int id);
        /// <summary>
        /// ��ȡ֪ʶ��
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="kns">����id</param>
        /// <param name="count"></param>
        /// <returns></returns>
        Knowledge[] KnowledgeCount(int orgid, bool? isUse, int kns, int count);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="couid">�γ�id����С��0ʱȡ���У�����0ʲôҲ��ȡ��</param>
        /// <param name="kns"></param>
        /// <param name="searTxt"></param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Knowledge[] KnowledgeCount(int orgid, int couid, int kns, string searTxt, bool? isUse, int count);
        /// <summary>
        /// �����ж�����
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="kns"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        int KnowledgeOfCount(int orgid, int kns, bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="kns">����id</param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Knowledge[] KnowledgePager(int orgid, bool? isUse, int kns, string searTxt, int size, int index, out int countSum);
        Knowledge[] KnowledgePager(int orgid, int couid, int kns, bool? isUse, bool? isHot, bool? isRec, bool? isTop, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ǰ�γ̵�֪ʶ��
        /// </summary>
        /// <param name="couid"></param>
        /// <param name="kns">����id�����ŷָ�</param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Knowledge[] KnowledgePager(int couid, string kns, string searTxt, int size, int index, out int countSum);
        #endregion

        #region ֪ʶ��������
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int SortAdd(KnowledgeSort entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SortSave(KnowledgeSort entity);
        /// <summary>
        /// �޸ķ�������
        /// </summary>
        /// <param name="xml"></param>
        void SortSaveOrder(string xml);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void SortDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        KnowledgeSort SortSingle(int identify);
        /// <summary>
        /// ��ȡ���з���
        /// </summary>
        /// <param name="orgid">��������</param>
        /// <param name="couid">�γ�id����С��0ʱȡ���У�����0ʲôҲ��ȡ��</param>
        /// <param name="IsUse"></param>
        /// <returns></returns>
        KnowledgeSort[] GetSortAll(int orgid, int couid, bool? isUse);
        /// <summary>
        /// ��ȡ���з���
        /// </summary>
        /// <param name="orgid">��������id</param>
        /// <param name="couid">�γ�id����С��0ʱȡ���У�����0ʲôҲ��ȡ��</param>
        /// <param name="pid">��id���༶���ࣩ</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        KnowledgeSort[] GetSortAll(int orgid, int couid, int pid, bool? isUse);
        /// <summary>
        /// ��ȡ��ǰ�������һ���Ӷ���
        /// </summary>
        /// <param name="couid">�γ�id����С��0ʱȡ���У�����0ʲôҲ��ȡ��</param>
        /// <param name="pid">�ϼ�</param>
        /// <returns>��ǰ�������һ���Ӷ���</returns>
        KnowledgeSort[] GetSortChilds(int pid, int couid, bool? isUse);
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
