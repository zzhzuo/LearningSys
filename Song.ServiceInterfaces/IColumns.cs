using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��վ���ݵ���Ŀ����
    /// </summary>
    public interface IColumns : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int Add(Columns entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(Columns entity);
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="xml"></param>
        void SaveOrder(string xml);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void Delete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Columns Single(int identify);
        /// <summary>
        /// ��ȡ������Ŀ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        Columns[] All(int orgid, bool? isUse);
        /// <summary>
        /// ȡĳһ�����Ŀ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="type">��Ŀ���ͣ���ƷProduct������news��ͼƬPicture,��Ƶvideo,����download,��ҳarticle</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Columns[] ColumnCount(int orgid, string type, bool? isUse, int count);
        /// <summary>
        /// ȡĳһ�����Ŀ
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="pid">����id</param>
        /// <param name="type">��Ŀ���ͣ���ƷProduct������news��ͼƬPicture,��Ƶvideo,����download,��ҳarticle</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Columns[] ColumnCount(int orgid, int pid, string type, bool? isUse, int count);
        /// <summary>
        /// ��ǰ��Ŀ�µ��Ӽ���Ŀ
        /// </summary>
        /// <param name="pid">��ǰ��Ŀid,���0����ȡ������Ŀ</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        Columns[] Children(int pid, bool? isUse);
        /// <summary>
        /// �Ƿ����¼���Ŀ
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        bool  IsChildren(int pid, bool? isUse);
        /// <summary>
        /// ��ǰ�����µ������ӷ���id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> TreeID(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool RemoveUp(int orgid, int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool RemoveDown(int orgid, int id);
        
    }
}
