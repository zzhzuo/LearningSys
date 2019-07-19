using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��վ�û��Ĺ���
    /// </summary>
    public interface IUser : WeiSha.Common.IBusinessInterface
    {
        #region ��վ�û������
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void AddGroup(UserGroup entity);        
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SaveGroup(UserGroup entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns>���ɾ���ɹ�������0�����������û�������-1�������Ĭ���飬����-2</returns>
        int DeleteGroup(UserGroup entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns>���ɾ���ɹ�������0�����������û�������-1�������Ĭ���飬����-2</returns>
        int DeleteGroup(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        UserGroup GetGroupSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰��û�������
        /// </summary>
        /// <param name="name">�û�������</param>
        /// <returns></returns>
        UserGroup GetGroupSingle(string name);
        /// <summary>
        /// ��ȡĬ���û���
        /// </summary>
        /// <returns></returns>
        UserGroup GetGroupDefault();
        /// <summary>
        /// ��ȡ���󣻼������û��飻
        /// </summary>
        /// <returns></returns>
        UserGroup[] GetGroupAll();
        UserGroup[] GetGroupAll(bool? isUse);
        /// <summary>
        /// ��ȡĳ��վ�û��������飻
        /// </summary>
        /// <param name="UserId">��վ�û�id</param>
        /// <returns></returns>
        UserGroup GetGroup4User(int UserId);
        /// <summary>
        /// ��ȡĳ�����������վ�û�
        /// </summary>
        /// <param name="grpId">��id</param>
        /// <returns></returns>
        User[] GetUser4Group(int grpId);
        /// <summary>
        /// ��ȡĳ�����������վ�û�
        /// </summary>
        /// <param name="grpId"></param>
        /// <param name="use">�Ƿ����</param>
        /// <returns></returns>
        User[] GetUser4Group(int grpId, bool use);
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="name">������</param>
        /// <returns></returns>
        bool IsGroupExist(string name);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool GroupRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool GroupRemoveDown(int id);
        #endregion

        #region �û�
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns>����Ѿ����ڸ��û����򷵻�-1</returns>
        int AddUser(User entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SaveUser(User entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void DeleteUser(User entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void DeleteUser(int identify);
        /// <summary>
        /// ɾ��������վ�û��ʺ���
        /// </summary>
        /// <param name="name">��վ�û�����</param>
        void DeleteUser(string accname);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        User GetUserSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���վ�û�����
        /// </summary>
        /// <param name="name">�ʺ�����</param>
        /// <returns></returns>
        User GetUserSingle(string accname);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���վ�û��ʺ�����������
        /// </summary>
        /// <param name="acc">��վ�û��ʺ�����</param>
        /// <param name="pw">��վ�û�����,MD5�����ַ���</param>
        /// <returns></returns>
        User GetUserSingle(string accname, string pw);
        /// <summary>
        /// ��¼��֤
        /// </summary>
        /// <param name="acc">��վ�û��ʺ�</param>
        /// <param name="pw">��¼����</param>
        /// <returns></returns>
        bool LoginCheck(string accname, string pw);
        /// <summary>
        /// ��ǰ���ʺ��Ƿ�����
        /// </summary>
        /// <param name="name">�û��ʺ�</param>
        /// <returns></returns>
        bool IsUserExist(string accname);
        /// <summary>
        /// ��ȡ���󣻼�������վ�û���
        /// </summary>
        /// <returns></returns>
        User[] GetUserAll();
        /// <summary>
        /// ��ȡ������վ�û�
        /// </summary>
        /// <param name="isUse">�Ƿ���ְ</param>
        /// <param name="searTxt">�����Ʋ�ѯ</param>
        /// <returns></returns>
        User[] GetUserAll(bool? isUse, string searName);
        /// <summary>
        /// ��ȡĳ���û����������վ�û��ʺţ�
        /// </summary>
        /// <param name="grpid">�û���id,-1ȡȫ����վ�û���0ȡ���ڲ������κ��û������վ�û�</param>
        /// <returns></returns>
        User[] GetUserAll(int grpid, bool? isUse, string searName);
        /// <summary>
        /// ��ȡĳ���û����������վ�û��ʺţ�
        /// </summary>
        /// <param name="grpid">�û���id,-1ȡȫ����վ�û���0ȡ���ڲ������κ��û������վ�û�</param>
        /// <param name="isUse">�Ƿ���ְ</param>
        /// <returns></returns>
        User[] GetUserAll(int grpid, bool isUse);
        /// <summary>
        /// ��ҳ��ȡ���е���վ�û��ʺţ�
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        User[] GetUserPager(int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡĳ�û��飬���е���վ�û��ʺţ�
        /// </summary>
        /// <param name="grpid">�û���Id</param>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        User[] GetUserPager(int grpid, int size, int index, out int countSum);
        User[] GetUserPager(int? grpid, bool? isUse, string searName, int size, int index, out int countSum);
        #endregion
    }
}
