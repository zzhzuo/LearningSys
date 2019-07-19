using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// �½ڹ���
    /// </summary>
    public interface IOutline : WeiSha.Common.IBusinessInterface
    {
        #region �½ڹ���
        /// <summary>
        /// ����½�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void OutlineAdd(Outline entity);
        /// <summary>
        /// ��������½ڣ������ڵ���ʱ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="sbjid">רҵid</param>
        /// <param name="couid">�γ̣���γ̣�id</param>
        /// <param name="names">���ƣ��������ö��ŷָ��Ķ������</param>
        /// <returns></returns>
        Outline OutlineBatchAdd(int orgid, int sbjid, int couid, string names);
        /// <summary>
        /// �Ƿ��Ѿ������½�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="sbjid">רҵid</param>
        /// <param name="couid">�γ̣���γ̣�id</param>
        /// <param name="pid">�ϼ�id</param>
        /// <param name="name"></param>
        /// <returns></returns>
        Outline OutlineIsExist(int orgid, int sbjid, int couid, int pid, string name);
        /// <summary>
        /// �޸��½�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void OutlineSave(Outline entity);
        /// <summary>
        /// �����½ڣ�����ʱ���������ɻ���
        /// </summary>
        /// <param name="entity"></param>
        void OutlineInput(Outline entity);
        /// <summary>
        /// �����γ��½ڵ�Excel
        /// </summary>
        /// <param name="path"></param>
        /// <param name="couid">�γ�ID</param>
        /// <returns></returns>
        string OutlineExport4Excel(string path, int couid);
        /// <summary>
        /// ɾ���½�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void OutlineDelete(Outline entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void OutlineDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Outline OutlineSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�Ψһֵ����UID��
        /// </summary>
        /// <param name="uid">ȫ��Ψһֵ</param>
        /// <returns></returns>
        Outline OutlineSingle(string uid);
        /// <summary>
        /// ��ȡĳ���γ��ڵ��½ڣ�������ȡ
        /// </summary>
        /// <param name="couid">�γ�ID</param>
        /// <param name="names">�༶����</param>
        /// <returns></returns>
        Outline OutlineSingle(int couid, List<string> names);        
        /// <summary>
        /// ��ǰ�½��µ��������½�id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> TreeID(int id);
        /// <summary>
        /// ��ȡĳ���γ��µ�һ���½�
        /// </summary>
        /// <param name="couid">�γ�Id</param>
        /// <param name="isUse">�Ƿ����ֻ��������½�,nullȡ���з�Χ��trueֻ��������õ��½�,false��֮</param>
        /// <returns></returns>
        Outline OutlineFirst(int couid, bool? isUse);
        /// <summary>
        /// ��ȡ�½����ƣ����Ϊ�༶������ϸ�������
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        string OutlineName(int identify);
        /// <summary>
        /// ��ȡ���пγ��½�
        /// </summary>
        /// <param name="couid">�����γ�id</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        Outline[] OutlineAll(int couid, bool? isUse);
        /// <summary>
        /// �������νṹ���½��б�
        /// </summary>
        /// <param name="outlines"></param>
        /// <returns></returns>
        DataTable OutlineTree(Song.Entities.Outline[] outlines);
        /// <summary>
        /// ����½�������͸���
        /// </summary>
        /// <param name="identify"></param>
        void OutlineClear(int identify);
        /// <summary>
        /// ������Ч�½�
        /// </summary>
        /// <param name="couid">�γ�ID</param>
        /// <returns></returns>
        int OutlineCleanup(int couid);
        ///// <summary>
        ///// ��������
        ///// </summary>
        ///// <returns></returns>
        //List<Outline> OutlineBuildCache();
        /// <summary>
        /// ��ȡָ�������Ŀγ��б�
        /// </summary>
        /// <param name="couid">�����γ�id</param>
        /// <param name="isUse"></param>
        /// <param name="count">ȡ��������¼�����С�ڵ���0����ȡ����</param>
        /// <returns></returns>
        Outline[] OutlineCount(int couid, string search, bool? isUse, int count);
        /// <summary>
        /// ȡָ���������½�
        /// </summary>
        /// <param name="couid"></param>
        /// <param name="pid">��id</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Outline[] OutlineCount(int couid, int pid, bool? isUse, int count);
        /// <summary>
        /// ȡָ���������½�
        /// </summary>
        /// <param name="orgid">����Id</param>
        /// <param name="sbjid">רҵid</param>
        /// <param name="couid">�γ�id</param>
        /// <param name="pid">�½��ϼ�Id</param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Outline[] OutlineCount(int orgid, int sbjid, int couid, int pid, bool? isUse, int count);
        /// <summary>
        /// ��ǰ�γ��µ��½���
        /// </summary>
        /// <param name="couid">�γ�id</param>
        /// <param name="pid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        int OutlineOfCount(int couid, int pid, bool? isUse);
        int OutlineOfCount(int orgid, int sbjid, int couid, int pid, bool? isUse);
        /// <summary>
        /// ��ǰ�γ��µ��½���
        /// </summary>
        /// <param name="couid">�γ�id</param>
        /// <param name="pid">��id</param>
        /// <param name="isUse">�Ƿ�����</param>
        /// <param name="isVideo">�Ƿ�����Ƶ</param>
        /// <param name="isFinish">�½��Ƿ����</param>
        /// <returns></returns>
        int OutlineOfCount(int couid, int pid, bool? isUse, bool? isVideo, bool? isFinish);
        /// <summary>
        /// �Ƿ����Ӽ��½�
        /// </summary>
        /// <param name="couid">�γ�id</param>
        /// <param name="pid">��id</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        bool OutlineIsChildren(int couid, int pid, bool? isUse);
        /// <summary>
        /// ��ǰ�½��Ƿ�������
        /// </summary>
        /// <param name="olid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        bool OutlineIsQues(int olid, bool? isUse);
        /// <summary>
        /// ��ǰ�½ڵ��Ӽ��½�
        /// </summary>
        /// <param name="couid"></param>
        /// <param name="pid"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        Outline[] OutlineChildren(int couid, int pid, bool? isUse, int count);
        /// <summary>
        /// ��ҳȡ�γ��½ڵ���Ϣ
        /// </summary>
        /// <param name="couid">�����γ�id</param>
        /// <param name="isUse"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Outline[] OutlinePager(int couid, bool? isUse, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ǰ�½ڵ�����
        /// </summary>
        /// <param name="olid"></param>
        /// <param name="type"></param>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Questions[] QuesCount(int olid, int type, bool? isUse, int count);        
        /// <summary>
        /// ��ǰ�½��ж��ٵ�����
        /// </summary>
        /// <param name="olid"></param>
        /// <param name="type"></param>
        /// <param name="isUse"></param>
        /// <param name="isAll">�Ƿ�ȡ���У���ǰ�½����������½ڵ�����һ���㣩</param>
        /// <returns></returns>
        int QuesOfCount(int olid, int type, bool? isUse, bool isAll);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool OutlineUp(int couid, int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool OutlineDown(int couid, int id);
        /// <summary>
        /// ����ǰ�½�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool OutlineToLeft(int couid, int id);
        /// <summary>
        /// ����ǰ�½��˼�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool OutlineToRight(int couid, int id);
        #endregion

        #region �½��¼�
        /// <summary>
        /// ����½�����Ƶ�����¼�
        /// </summary>
        /// <param name="entity"></param>
        void EventAdd(OutlineEvent entity);
        /// <summary>
        /// �޸Ĳ����¼�
        /// </summary>
        /// <param name="entity"></param>
        void EventSave(OutlineEvent entity);
        /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="entity"></param>
        void EventDelete(OutlineEvent entity);
        /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="identify"></param>
        void EventDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        OutlineEvent EventSingle(int identify);
        /// <summary>
        /// �����½��������¼�
        /// </summary>
        /// <param name="couid">�γ�ID</param>
        /// <param name="olid">�½�ID��������Ϊ�㣬�����ȡ����</param>
        /// <param name="type">�¼����ͣ�1Ϊ���ѣ�2Ϊ֪ʶչʾ��3�������ʣ�4ʵʱ���������磬ѡ��ĳ�����ת��ĳ�룩</param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        OutlineEvent[] EventAll(int couid, int olid, int type, bool? isUse);
        /// <summary>
        /// �����½��������¼�
        /// </summary>
        /// <param name="couid">�γ�ID</param>
        /// <param name="uid">�½ڵ�ȫ��Ψһֵ</param>
        /// <param name="type"></param>
        /// <param name="isUse"></param>
        /// <returns></returns>
        OutlineEvent[] EventAll(int couid, string uid, int type, bool? isUse);
        /// <summary>
        /// ��ȡ�������͵���Ϣ
        /// </summary>
        /// <param name="oeid"></param>
        /// <returns></returns>
        DataTable EventQues(int oeid);
        /// <summary>
        /// ��ȡʱ�䷴������Ϣ
        /// </summary>
        /// <param name="oeid"></param>
        /// <returns></returns>
        DataTable EventFeedback(int oeid);
        #endregion

        #region �¼�
        /// <summary>
        /// ���½ڸ���ʱ
        /// </summary>
        event EventHandler Save;
        event EventHandler Add;
        event EventHandler Delete;
        void OnSave(object sender, EventArgs e);
        void OnAdd(object sender, EventArgs e);
        void OnDelete(object sender, EventArgs e);
        #endregion
    }
}
