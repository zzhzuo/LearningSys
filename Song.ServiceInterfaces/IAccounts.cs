using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;
using WeiSha.Data;
using NPOI.HSSF.UserModel;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �˻�����
    /// </summary>
    public interface IAccounts : WeiSha.Common.IBusinessInterface
    {
        #region �¼�
        /// <summary>
        /// �˻���Ϣ���ʱ
        /// </summary>
        event EventHandler Save;
        event EventHandler Add;
        event EventHandler Delete;
        void OnSave(object sender, EventArgs e);
        void OnAdd(object sender, EventArgs e);
        void OnDelete(object sender, EventArgs e);
        #endregion

        #region �˻�����
        /// <summary>
        /// ע��Э��
        /// </summary>
        /// <returns></returns>
        string RegAgreement();
        /// <summary>
        /// ����˻�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns>����Ѿ����ڸ��˻����򷵻�-1</returns>
        int AccountsAdd(Accounts entity);
        /// <summary>
        /// �޸��˻�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void AccountsSave(Accounts entity);
        /// <summary>
        /// �޸��˻����������޸�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fiels"></param>
        /// <param name="objs"></param>
        void AccountsUpdate(Accounts entity, Field[] fiels, object[] objs);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void AccountsDelete(int identify);
        /// <summary>
        /// ɾ���˻�
        /// </summary>
        /// <param name="entity"></param>
        void AccountsDelete(Song.Entities.Accounts entity);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Accounts AccountsSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���վ�˻�����
        /// </summary>
        /// <param name="accname">�˻�����</param>
        /// <param name="pw">����</param>
        /// <param name="orgid">����id</param>
        /// <returns></returns>
        Accounts AccountsSingle(string accname, string pw, int orgid);
        /// <summary>
        /// ͨ���˺�����ȡ
        /// </summary>
        /// <param name="accname">�˻�����</param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        Accounts AccountsSingle(string accname, int orgid);
        /// <summary>
        /// ͨ���ֻ��Ż�ȡ�˻�
        /// </summary>
        /// <param name="phone">�ֻ���</param>
        /// <param name="isPass">�Ƿ�ͨ�����</param>
        /// <param name="isUse">�Ƿ�����</param>
        /// <returns></returns>
        Accounts AccountsSingle(string phone, bool? isPass, bool? isUse);
        /// <summary>
        /// ��ȡ��һʵ�壬ͨ��id����֤��
        /// </summary>
        /// <param name="id">�˻�Id</param>
        /// <param name="uid">�˻���¼ʱ��������ַ��������ж�ͬһ�˺Ų�ͬ�˵�¼������</param>
        /// <returns></returns>
        Accounts AccountsSingle(int id, string uid);
        /// <summary>
        /// ͨ��QQ��openid��ȡ�˻�
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Accounts Account4QQ(string openid);
        /// <summary>
        /// ͨ��΢�ŵ�openid��ȡ�˻�
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Accounts Account4Weixin(string openid);
        /// <summary>
        /// ͨ�������˺ŵ�id����ȡ��ʦ�˻�
        /// </summary>
        /// <param name="acid"></param>
        /// <returns></returns>
        Teacher GetTeacher(int acid, bool? isPass);
        /// <summary>
        /// ��¼��֤
        /// </summary>
        /// <param name="acc">�˺ţ������֤�����ֻ�</param>
        /// <param name="pw">���루���ģ�δ��md5���ܣ�</param>
        /// <param name="isPass">�Ƿ����ͨ��</param>
        /// <returns></returns>
        Accounts AccountsLogin(string acc, string pw, bool? isPass);
        /// <summary>
        /// ��¼�ж�
        /// </summary>
        /// <param name="accid">�˻�id</param>
        /// <param name="pw">���룬md5���ܺ��</param>
        /// <param name="isPass">�Ƿ����ͨ��</param>
        /// <returns></returns>
        Accounts AccountsLogin(int accid, string pw, bool? isPass);        
        /// <summary>
        /// �ж��˺��Ƿ����
        /// </summary>
        /// <param name="accname">�˺���</param>
        /// <returns></returns>
        Accounts IsAccountsExist(string accname);
        /// <summary>
        /// �ж��˺��Ƿ����
        /// </summary>
        /// <param name="accname"></param>
        /// <returns></returns>
        Accounts IsAccountsExist(int orgid, string accname);
        /// <summary>
        /// ��ǰ���ʺ��Ƿ�����
        /// </summary>
        /// <param name="accname">�˻��ʺ�</param>
        /// <param name="type">�ж����ͣ�Ĭ��Ϊ�˺ţ�1Ϊ�ֻ���,2Ϊ����</param>
        /// <returns></returns>
        Accounts IsAccountsExist(int orgid, string accname, int type);
        /// <summary>
        /// �ж��˻��Ƿ��Ѿ��ڴ棬���ж��˺����ֻ���
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="enity"></param>
        /// <returns></returns>
        Accounts IsAccountsExist(int orgid, Accounts enity);
        /// <summary>
        /// ��ǰ���ʺ��Ƿ�����
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="accname"></param>
        /// <param name="answer">��ȫ�����</param>
        /// <returns></returns>
        Accounts IsAccountsExist(int orgid, string accname, string answer);
        /// <summary>
        /// ��ȡ�˻�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Accounts[] AccountsCount(int orgid, bool? isUse, int count);
        /// <summary>
        /// ��ȡ�˻���Ϣ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="isUse">�Ƿ�����</param>
        /// <param name="sts">�����id�����id�ö��ŷָ�</param>
        /// <param name="count">ȡ��������С��1Ϊ����</param>
        /// <returns></returns>
        List<Accounts> AccountsCount(int orgid, bool? isUse, string sts, int count);
        /// <summary>
        /// �����ж����˻�
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        int AccountsOfCount(int orgid, bool? isUse);
        /// <summary>
        /// ��ҳ��ȡ���е���վ�˻��ʺţ�
        /// </summary>
        /// <param name="size">ÿҳ��ʾ������¼</param>
        /// <param name="index">��ǰ�ڼ�ҳ</param>
        /// <param name="countSum">��¼����</param>
        /// <returns></returns>
        Accounts[] AccountsPager(int orgid, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡĳ�˻��飬���е���վ�˻��ʺţ�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="sortid">ѧԱ����id</param>
        /// <param name="isUse"></param>
        /// <param name="acc">�˻�����</param>
        /// <param name="name">�������ǳ�</param>
        /// <param name="phone">�ֻ���</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Accounts[] AccountsPager(int orgid, int sortid, bool? isUse, string acc,string name, string phone, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡĳ�˻��飬���е���վ�˻��ʺţ�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="sortid">ѧԱ����id</param>
        /// <param name="pid">�Ƽ���id</param>
        /// <param name="isUse"></param>
        /// <param name="acc">�˻�����</param>
        /// <param name="name">�������ǳ�</param>
        /// <param name="phone">�ֻ���</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Accounts[] AccountsPager(int orgid, int sortid, int pid, bool? isUse, string acc, string name, string phone, int size, int index, out int countSum);
        /// <summary>
        /// ѧԱ�˺���Ϣ����
        /// </summary>
        /// <param name="path">�����ļ���·�����������ˣ�</param>
        /// <param name="orgid">����id</param>
        /// <param name="sorts">ѧԱ����id���ö��ŷָ�</param>
        /// <returns></returns>
        string AccountsExport4Excel(string path, int orgid, string sorts);
        /// <summary>
        /// ѧԱ�˻��ŵ���
        /// </summary>
        /// <param name="path">�����ļ���·�����������ˣ�</param>
        /// <param name="orgs">����id,�ö��ŷָ�</param>
        /// <returns></returns>
        string AccountsExport4Excel(string path, string orgs);
        #endregion

        #region �¼��˻����ϼ��˻�
        /// <summary>
        /// �¼���Ա����
        /// </summary>
        /// <param name="acid">��ǰ�˺�ID</param>
        /// <param name="isAll">�Ƿ���������¼���true�����У�falseֻȡֱ���¼�</param>
        /// <returns></returns>
        int SubordinatesCount(int acid, bool isAll);
        /// <summary>
        /// �¼���Ա��ҳ��ȡ
        /// </summary>
        /// <param name="acid">��ǰ�˺�id</param>
        /// <param name="isUse">�Ƿ�����</param>
        /// <param name="acc"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Accounts[] SubordinatesPager(int acid, bool? isUse, string acc, string name, string phone, int size, int index, out int countSum);
        /// <summary>
        /// ��ǰ�˻������и����˻�����������
        /// </summary>
        /// <param name="accid">��ǰ�˻�id</param>
        /// <returns></returns>
        Accounts[] Parents(int accid);
        Accounts[] Parents(Accounts acc);
        #endregion

        #region ���ֹ���
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        PointAccount PointAdd(PointAccount entity);
        /// <summary>
        /// ���ӵ�¼����
        /// </summary>
        /// <param name="acc">ѧԱ�˻�</param>
        /// <returns></returns>
        /// <returns>�˴ε�¼�����ӵĻ�����</returns>
        int PointAdd4Login(Accounts acc);
        /// <summary>
        /// ���ӵ�¼����
        /// </summary>
        /// <param name="acc">ѧԱ�˻�</param>
        /// <param name="source">��Դ��Ϣ</param>
        /// <param name="info">��Ϣ</param>
        /// <param name="remark">��ע</param>
        /// <returns>�˴ε�¼�����ӵĻ�����</returns>
        int PointAdd4Login(Accounts acc,string source,string info,string remark);
        /// <summary>
        /// ���ӷ������ӵķ��ʻ���
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        int PointAdd4Share(Accounts acc);
        /// <summary>
        /// ���ӷ������ӵ�ע�����
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        int PointAdd4Register(Accounts acc);
        /// <summary>
        /// ֧��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        PointAccount PointPay(PointAccount entity);
        /// <summary>
        /// ɾ����ˮ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void PointDelete(PointAccount entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void PointDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        PointAccount PointSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���ˮ��
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        PointAccount PointSingle(string serial);
        /// <summary>
        /// �޸���ˮ��Ϣ
        /// </summary>
        /// <param name="entity"></param>
        void PointSave(PointAccount entity);
        /// <summary>
        /// ��ȡָ�������ļ�¼
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="count"></param>
        /// <returns></returns>
        PointAccount[] PointCount(int orgid, int stid, int type, int count);
        /// <summary>
        /// ����ĳһ��ʱ������Ļ���
        /// </summary>
        /// <param name="acid">ѧԱ�˻�</param>
        /// <param name="formType">��Դ���࣬1��¼��2������ʣ�3����ע�᣻4�һ�; </param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int PointClac(int acid, int formType, DateTime? start, DateTime? end);
        /// <summary>
        /// ��ҳ��ȡ���еĹ��棻
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        PointAccount[] PointPager(int orgid, int stid, int type, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ���еĹ��棻
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="searTxt">����Ϣ����</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        PointAccount[] PointPager(int orgid, int st, int type, string searTxt, DateTime? start, DateTime? end, int size, int index, out int countSum);        
        #endregion

        #region ��ȯ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        CouponAccount CouponAdd(CouponAccount entity);
        /// <summary>
        /// ֧��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        CouponAccount CouponPay(CouponAccount entity);
        /// <summary>
        /// ���ֶһ���ȯ
        /// </summary>
        /// <param name="accid">ѧԱid</param>
        /// <param name="coupon">Ҫ�һ��Ŀ�ȯ����</param>
        /// <returns></returns>
        void CouponExchange(int accid,int coupon);
        /// <summary>
        /// ���ֶһ���ȯ
        /// </summary>
        /// <param name="acc">ѧԱ</param>
        /// <param name="coupon">Ҫ�һ��Ŀ�ȯ����</param>
        void CouponExchange(Accounts acc, int coupon);
        /// <summary>
        /// ɾ����ˮ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void CouponDelete(CouponAccount entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void CouponDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        CouponAccount CouponSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���ˮ��
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        CouponAccount CouponSingle(string serial);
        /// <summary>
        /// �޸���ˮ��Ϣ
        /// </summary>
        /// <param name="entity"></param>
        void CouponSave(CouponAccount entity);
        /// <summary>
        /// ��ȡָ�������ļ�¼
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="count"></param>
        /// <returns></returns>
        CouponAccount[] CouponCount(int orgid, int stid, int type, int count);
        /// <summary>
        /// ����ĳһ��ʱ������Ļ���
        /// </summary>
        /// <param name="acid">ѧԱ�˻�</param>
        /// <param name="formType">��Դ���࣬1�һ���2����֧����5����4����Ա��ֵ��</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int CouponClac(int acid, int formType, DateTime? start, DateTime? end);
        /// <summary>
        /// ��ҳ��ȡ���еĹ��棻
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        CouponAccount[] CouponPager(int orgid, int stid, int type, int size, int index, out int countSum);
        CouponAccount[] CouponPager(int orgid, int stid, int type, DateTime? start, DateTime? end,int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ���еĹ��棻
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="searTxt">����Ϣ����</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        CouponAccount[] CouponPager(int orgid, int st, int type, string searTxt, int size, int index, out int countSum);
        #endregion

        #region �ʽ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        MoneyAccount MoneyIncome(MoneyAccount entity);
        /// <summary>
        /// ֧��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        MoneyAccount MoneyPay(MoneyAccount entity);
        /// <summary>
        /// ͨ����ˮ�Ž����ʽ�֧���������ȷ�ϲ���
        /// </summary>
        /// <param name="serial">��ˮ��</param>
        /// <returns></returns>
        MoneyAccount MoneyConfirm(string serial);
        /// <summary>
        /// ͨ�����׼�¼�Ķ��󣬽����ʽ�֧���������ȷ�ϲ���
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        MoneyAccount MoneyConfirm(MoneyAccount ma);        
        /// <summary>
        /// ɾ����ˮ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void MoneyDelete(MoneyAccount entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void MoneyDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        MoneyAccount MoneySingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰���ˮ��
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        MoneyAccount MoneySingle(string serial);
        /// <summary>
        /// �����ʽ�����
        /// </summary>
        /// <param name="accid">�˺�id</param>
        /// <param name="type">1֧����2���루������ֵ������ȣ�</param>
        /// <param name="from">���ͣ���Դ��1Ϊ����Ա������2Ϊ��ֵ���ֵ��3������֧����4����γ�,5����</param>
        /// <returns></returns>
        decimal MoneySum(int accid, int type, int from);
        /// <summary>
        /// �޸���ˮ��Ϣ
        /// </summary>
        /// <param name="entity"></param>
        void MoneySave(MoneyAccount entity);
        /// <summary>
        /// ��ȡָ�������ļ�¼
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="isSuccess">�Ƿ�����ɹ�</param>
        /// <param name="count"></param>
        /// <returns></returns>
        MoneyAccount[] MoneyCount(int orgid, int stid, int type, bool? isSuccess, int count);
        /// <summary>
        /// ����ĳһ��ʱ��������ֽ�
        /// </summary>
        /// <param name="acid">ѧԱ�˻�</param>
        /// <param name="formType">1Ϊ����Ա������2Ϊ��ֵ���ֵ��3����֧����4����γ�,5����</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int MoneyClac(int acid, int formType, DateTime? start, DateTime? end);
        /// <summary>
        /// ��ҳ��ȡ�ʽ���ˮ��
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        MoneyAccount[] MoneyPager(int orgid, int stid, int type, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ�ʽ���ˮ��
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="searTxt">����Ϣ����</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        MoneyAccount[] MoneyPager(int orgid, int st, int type, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ�ʽ���ˮ��
        /// </summary>
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="st">ѧԱid</param>
        /// <param name="type">���ͣ�֧��Ϊ1��ת��2</param>
        /// <param name="from">��Դ��1Ϊ����Ա��2Ϊ��ֵ�룬3Ϊ����֧��</param>
        /// <param name="searTxt">����Ϣ����</param>
        /// <param name="start">��ʱ��������䣬��Ϊ��ʼʱ��</param>
        /// <param name="end">��ʱ��������䣬��Ϊ����ʱ��</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        MoneyAccount[] MoneyPager(int orgid, int st, int type, int from, string searTxt, DateTime? start, DateTime? end, int size, int index, out int countSum);
        #endregion
        
    }
}
