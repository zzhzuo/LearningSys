using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ԺϵԱ���Ĺ���
    /// </summary>
    public interface IEmployee : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int Add(EmpAccount entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Save(EmpAccount entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void Delete(EmpAccount entity);
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
        EmpAccount GetSingle(int identify);
        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="acc">�˺ţ������֤�����ֻ�</param>
        /// <param name="pw">����</param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        EmpAccount EmpLogin(string acc, string pw, int orgid);
        /// <summary>
        /// ���ݹ�˾id��ȡ����˾�Ĺ���Ա
        /// </summary>
        /// <param name="orgid">��˾id</param>
        /// <returns></returns>
        EmpAccount GetAdminByOrgId(int orgid);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�Ա���ֻ�����
        /// </summary>
        /// <param name="name">�ֻ���</param>
        /// <returns></returns>
        EmpAccount GetSingleByPhone(string phoneNumber);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�Ա������
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        EmpAccount GetSingleByName(string name);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�Ա���ʺ�����������
        /// </summary>
        /// <param name="acc">Ա���ʺ�����</param>
        /// <param name="pw">Ա������,MD5�����ַ���</param>
        /// <returns></returns>
        EmpAccount GetSingle(string acc, string pw);
        EmpAccount GetSingle(int orgid, string acc, string pw);
        /// <summary>
        /// ��ȡ��ǰԱ�����ڵ�Ժϵ
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        Depart Get4Depart(int identify);
        /// <summary>
        /// ��ǰԱ���Ƿ�Ϊ��������Ա
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool IsSuperAdmin(int identify);
        /// <summary>
        /// ��ǰԱ���Ƿ�Ϊ������Ա��
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool IsForRoot(int identify);
        /// <summary>
        /// ��ǰ�û��Ƿ�Ϊ��������Ա
        /// </summary>
        /// <param name="acc">��ǰ�û�����</param>
        /// <returns></returns>
        bool IsSuperAdmin(EmpAccount acc);
        /// <summary>
        /// ��ǰԱ���Ƿ�Ϊ����Ա
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool IsAdmin(int identify);
        /// <summary>
        /// ��ǰԱ���Ƿ���ڣ�ͨ���ʺ��жϣ�
        /// </summary>
        /// <param name="orgid">���л�����Id</param>
        /// <param name="acc"></param>
        /// <returns>����Ѿ����ڣ��򷵻�true</returns>
        bool IsExists(int orgid, EmpAccount acc);
        /// <summary>
        /// ��֤�ܷ��¼
        /// </summary>
        /// <param name="accname">Ա���ʺ�</param>
        /// <param name="pw">����</param>
        /// <returns></returns>
        bool LoginCheck(int orgid, string accname, string pw);
        /// <summary>
        /// ͨ���ֻ�������֤����ǰԱ���Ƿ�Ϊ��ְԱ��
        /// </summary>
        /// <param name="phoneNumber">�ֻ���</param>
        /// <returns></returns>
        bool IsOnJob(string phoneNumber);
        /// <summary>
        /// ��ȡ���󣻼�����Ա����
        /// </summary>
        /// <returns></returns>
        EmpAccount[] GetAll(int orgid);        

        EmpAccount[] GetAll(int orgid, int depId, bool? isUse, string searTxt);
        /// <summary>
        /// ��ȡĳ���ֳ�������Ա���ʺţ�
        /// </summary>
        /// <param name="orgid">�ֳ�id</param>
        /// <param name="isUse"></param>
        /// <param name="searTxt">Ա������</param>
        /// <returns></returns>
        EmpAccount[] GetAll4Org(int orgid, bool? isUse, string searTxt);
        
        /// <summary>
        /// ��ҳ��ȡ���е�Ա���ʺţ�
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        EmpAccount[] GetPager(int orgid, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡĳԺϵ�����е�Ա���ʺţ�
        /// </summary>
        /// <param name="dep_id">ԺϵId</param>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        EmpAccount[] GetPager(int orgid, int dep_id, int size, int index, out int countSum);
        EmpAccount[] GetPager(int orgid, int? dep_id, bool? isUse, string searName, int size, int index, out int countSum);

        #region ְ��ͷ�Σ�����
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void TitileAdd(EmpTitle entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void TitleSave(EmpTitle entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void TitleDelete(EmpTitle entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void TitleDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        EmpTitle TitleSingle(int identify);
        /// <summary>
        /// ��ȡ���󣻼�����ְλ��
        /// </summary>
        /// <returns></returns>
        EmpTitle[] TitleAll(int orgid);
        EmpTitle[] TitleAll(int orgid, bool? isUse);
        /// <summary>
        /// ��ȡ��ǰְ�������Ա��
        /// </summary>
        /// <param name="titleid">ְ��Id</param>
        /// <param name="isUse">�Ƿ���ְ</param>
        /// <returns></returns>
        EmpAccount[] Title4Emplyee(int titleid, bool? isUse);       
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns></returns>
        bool TitleIsExist(int orgid,EmpTitle entity);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool TitleRemoveUp(int orgid,int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool TitleRemoveDown(int orgid,int id);
        #endregion

        
    }
}
