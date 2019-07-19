using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �ڲ����ӵĹ���
    /// </summary>
    public interface IInternalLink : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ����ڲ�����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LinkAdd(InternalLink entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LinkSave(InternalLink entity);
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void LinkDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        InternalLink LinkSingle(int identify);
        /// <summary>
        /// ��ȡĳ��Ժϵ�����������
        /// </summary>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <returns></returns>
        InternalLink[] LinkAll(bool? isUse);
        /// ��ҳ��ȡ���е������
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        InternalLink[] LinkPager(string searTxt, bool? isUse, int size, int index, out int countSum);

    }
}
