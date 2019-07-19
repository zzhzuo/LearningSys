using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��ʽ�Ĺ���
    /// </summary>
    public interface IStyle : WeiSha.Common.IBusinessInterface
    {
        #region ��������
        /// <summary>
        /// ��ӵ�����Ŀ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void NaviAdd(Navigation entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void NaviSave(Navigation entity);
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void NaviDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Navigation NaviSingle(int identify);
        /// <summary>
        /// ��ȡ���е���
        /// </summary>
        /// <param name="isShow">�Ƿ���ǰ̨��ʾ</param>
        /// <param name="site">վ����࣬��ҵվweb���ֻ�վmobi��΢��վweixin��Ĭ��Ϊweb</param>
        /// <param name="type">ĳһ�ർ��</param>
        /// <param name="orgid">����id</param>
        /// <returns></returns>
        Navigation[] NaviAll(bool? isShow, string site, string type, int orgid);
        Navigation[] NaviAll(bool? isShow, string site, string type, int orgid, int pid);
        /// <summary>
        /// ��ǰ������¼�����
        /// </summary>
        /// <param name="pId">����id�����С�ڵ�0������Ϊ0ʹ��</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <returns></returns>
        Navigation[] NaviChildren(int pid, bool? isShow);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool NaviRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool NaviRemoveDown(int id);
        #endregion

        #region �ֻ�ͼƬ����
        /// <summary>
        /// ����ֻ�ͼƬ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ShowPicAdd(ShowPicture entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ShowPicSave(ShowPicture entity);
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ShowPicDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        ShowPicture ShowPicSingle(int identify);
        /// <summary>
        /// ��ȡ�ֻ�ͼƬ
        /// </summary>
        /// <param name="isShow">�Ƿ���ǰ̨��ʾ</param>
        /// <param name="site">վ����࣬��ҵվweb���ֻ�վmobi��΢��վweixin��Ĭ��Ϊweb</param>       
        /// <param name="orgid">����id</param>
        /// <returns></returns>
        ShowPicture[] ShowPicAll(bool? isShow, string site, int orgid);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ShowPicUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ShowPicDown(int id);
        #endregion
    }
}
