using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// Ժϵְλ�Ĺ���
    /// </summary>
    public interface IOrganization : WeiSha.Common.IBusinessInterface
    {
        #region ��������
        /// <summary>
        /// ��ӻ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void OrganAdd(Organization entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void OrganSave(Organization entity);
        /// <summary>
        /// ����Ĭ�ϻ���
        /// </summary>
        /// <returns></returns>
        void OrganSetDefault(int identify);
        /// <summary>
        /// ϵͳĬ�ϲ��õĻ�����ע������Root����)
        /// </summary>
        /// <returns></returns>
        Organization OrganDefault();
        /// <summary>
        /// ����ϵͳ����Ļ�����ע����Root����)
        /// </summary>
        /// <returns></returns>
        Organization OrganRoot();
        /// <summary>
        /// ��ǰ����,ͨ�����������жϣ�����������򷵻�Ĭ�ϻ���
        /// </summary>
        /// <returns></returns>
        Organization OrganCurrent();
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        Organization OrganSingle(int identify);
        /// <summary>
        /// ��������ɾ����˾��
        /// </summary>
        /// <param name="identify">����id</param>
        void OrganDelete(int identify);
        /// <summary>
        /// ���ɵ�ǰ�������ֻ��˶�ά��
        /// </summary>
        void OrganBuildQrCode();
        void OrganBuildQrCode(Organization entity);
        /// <summary>
        /// ȡ���л���
        /// </summary>
        /// <param name="isUse">�Ƿ�����</param>
        /// <param name="level">�����ȼ�</param>
        /// <returns></returns>
        Organization[] OrganAll(bool? isUse, int level);
        /// <summary>
        /// ��ȡָ�������Ķ���
        /// </summary>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <param name="isShow">�Ƿ���ǰ����ʾ</param>
        /// <param name="level">�����ȼ�</param>
        /// <param name="count">ȡ������</param>
        /// <returns></returns>
        Organization[] OrganCount(bool? isUse, bool? isShow, int level, int count);
        /// <summary>
        /// ������ʱ�ļ�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="day">���������֮ǰ��</param>
        void OrganClearTemp(int orgid,int day);
        /// <summary>
        /// ����ǰ����������
        /// </summary>
        /// <param name="orgid"></param>
        void OrganClear(int orgid);
        /// <summary>
        /// ��������
        /// </summary>
        List<Organization> OrganBuildCache();
        /// <summary>
        /// ��ҳ��ȡ����
        /// </summary>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <param name="level">�����ȼ�</param>
        /// <param name="searTxt">�������ƹؼ���</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Organization[] OrganPager(bool? isUse, int level, string searTxt, int size, int index, out int countSum);

        #endregion

        #region �����ȼ�
        /// <summary>
        /// ��ӻ����ȼ�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LevelAdd(OrganLevel entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void LevelSave(OrganLevel entity);
        /// <summary>
        /// ����Ĭ�ϵȼ���Ĭ�ϵȼ�ֻ��һ��
        /// </summary>
        /// <param name="identify"></param>
        void LevelSetDefault(int identify);
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        OrganLevel LevelSingle(int identify);
        /// <summary>
        /// Ĭ�ϵĻ����ȼ�
        /// </summary>
        /// <returns></returns>
        OrganLevel LevelDefault();
        /// <summary>
        /// ��ȡ���ж���
        /// </summary>
        /// <returns></returns>
        OrganLevel[] LevelAll(bool? isUse);
        /// <summary>
        /// ��������ɾ����˾��
        /// </summary>
        /// <param name="identify">����id</param>
        void LevelDelete(int identify);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool LevelUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool LevelDown(int id);
        #endregion

    }
}
