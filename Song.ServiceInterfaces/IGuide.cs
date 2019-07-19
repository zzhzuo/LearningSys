using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ����ָ�ϵĹ���
    /// </summary>
    public interface IGuide : WeiSha.Common.IBusinessInterface
    {
        #region ����ָ��
        /// <summary>
        /// ��ӿ���ָ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void GuideAdd(Guide entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void GuideSave(Guide entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void GuideDelete(Guide entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void GuideDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Guide GuideSingle(int identify);
        /// <summary>
        /// ��ǰ�γ̹������һ���γ̹���
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Guide GuidePrev(Guide entity);
        /// <summary>
        /// ��ǰ�γ̹������һ���γ̹���
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Guide GuideNext(Guide entity);
        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="couid">�γ�id</param>
        /// <param name="gcid">����id</param>
        /// <param name="count"></param>
        /// <returns></returns>
        Guide[] GuideCount(int orgid, int couid, int gcid, int count);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="couid">�γ�id</param>
        /// <param name="gcid">����ָ�Ϸ���</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Guide[] GetGuidePager(int orgid, int couid, int gcid, string searTxt, bool? isShow, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="couid"></param>
        /// <param name="gcids">����ָ�Ϸ���,���id�����ŷָ�</param>
        /// <param name="searTxt"></param>
        /// <param name="isShow"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Guide[] GetGuidePager(int orgid, int couid, string gcids, string searTxt, bool? isShow, int size, int index, out int countSum);

        #endregion

        #region ����ָ�Ϸ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ColumnsAdd(GuideColumns entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ColumnsSave(GuideColumns entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ColumnsDelete(GuideColumns entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ColumnsDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        GuideColumns ColumnsSingle(int identify);
        /// <summary>
        /// ��ȡͬһ�����µ��������ţ�
        /// </summary>
        ///<param name="couid">�γ�id</param>
        ///<param name="pid">ѧ��id</param>
        /// <returns></returns>
        int ColumnsMaxTaxis(int couid,int pid);
        /// <summary>
        /// ��ȡ���󣻼����з��ࣻ
        /// </summary>
        /// <returns></returns>
        GuideColumns[] GetColumnsAll(int couid, bool? isUse);
        /// <summary>
        /// ��ȡ��ǰ�����µ��ӷ���
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        GuideColumns[] GetColumnsChild(int couid, int pid, bool? isUse);
        /// <summary>
        /// �Ƿ����Ӽ�
        /// </summary>
        /// <param name="couid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        bool ColumnsIsChildren(int couid, int pid, bool? isUse);
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns></returns>
        bool ColumnsIsExist(int couid, int pid, GuideColumns entity);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ColumnsRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ColumnsRemoveDown(int id);

        #endregion
    }
}
