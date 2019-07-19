using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �༶����
    /// </summary>
    public interface ITeam : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ��Ӱ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int TeamAdd(Team entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void TeamSave(Team entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void TeamDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Team TeamSingle(int identify);
        /// <summary>
        /// ��ȡ�༶
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Team[] GetTeam(bool? isUse, int count);
        Team[] GetTeam(bool? isUse, int? depid, int count);
        /// <summary>
        /// ��ҳ��ȡ
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Team[] GetTeamPager(bool? isUse, string searTxt, int size, int index, out int countSum);
        Team[] GetTeamPager(int depid,bool? isUse, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool RemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool RemoveDown(int id);

    }
}
