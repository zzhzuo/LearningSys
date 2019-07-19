using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Song.Entities;
using WeiSha.Data;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ��վ���ݵĹ���
    /// </summary>
    public interface IContents : WeiSha.Common.IBusinessInterface
    {
        #region �������µĹ���
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ArticleAdd(Article entity);
        /// <summary>
        /// �޸���������
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ArticleSave(Article entity);
        /// <summary>
        /// ʹ��ǰ�������������һ��������id�������������Ч�ʸ���
        /// </summary>
        /// <param name="id">�������µ�id</param>
        /// <param name="addNum">ÿ��������Ӽ�����</param>
        /// <returns></returns>
        int ArticleAddNumber(int id, int addNum);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ArticleDelete(Article entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">����ʵ��</param>
        /// <param name="tran">�������</param>
        void ArticleDelete(Article entity, DbTrans tran);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ArticleDelete(int identify);
        /// <summary>
        /// ɾ��������������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀid</param>
        void ArticleDeleteAll(int orgid, int colid);
        /// <summary>
        /// ��׼�����Ƿ���ɾ��״̬�����������վ
        /// </summary>
        /// <param name="identify"></param>
        void ArticleIsDelete(int identify);
        /// <summary>
        /// ���»�ԭ���ӻ���վ�ص������б�
        /// </summary>
        /// <param name="identify"></param>
        void ArticleRecover(int identify);
        /// <summary>
        /// ͨ�����
        /// </summary>
        /// <param name="identify">����id</param>
        /// <param name="verMan">�����</param>
        void ArticlePassVerify(int identify, string verMan);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Article ArticleSingle(int identify);
        /// <summary>
        /// ��ǰ���ŵ���һ������
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        Article ArticlePrev(int identify, int orgid);
        /// <summary>
        /// ��ǰ���ŵ���һ������
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        Article ArticleNext(int identify, int orgid);
        /// <summary>
        /// ��ǰ�������ڵ�ר��
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        Special[] Article4Special(int identify);
        /// <summary>
        /// ��������Ŀ��ȡ��������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colId">��Ŀid,���idС��0����ȡȫ��</param>
        /// <param name="topNum">��ȡ��¼��</param>
        /// <param name="order">��ȡ���Ĭ��nullȡ�����ö������ȣ�hot�ȵ����ȣ�flux�����������,imgΪͼƬ����</param>
        /// <returns></returns>
        Article[] ArticleCount(int orgid, int colId, int topNum, string order);
        /// <summary>
        /// ͳ����������
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="colId"></param>
        /// <returns></returns>
        int ArticleOfCount(int orgid, int colId);
        /// <summary>
        /// ��ҳ��ȡ����
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀid,���idС��0����ȡȫ��<</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="searTxt">���������</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Article[] ArticlePager(int orgid, int? colid, bool? isShow, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ����Ŀ�����⣬�Ƿ��������ҳ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid"></param>
        /// <param name="isVerify">�Ƿ����</param>
        /// <param name="isDel">�Ƿ�ɾ��</param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Article[] ArticlePager(int orgid, int? colid, bool? isVerify, bool? isDel, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ��ҳ��ȡ����
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">������Ŀ</param>
        /// <param name="searTxt">������ļ������ַ���</param>
        /// <param name="isVerify">�Ƿ����</param>
        /// <param name="isDel">�Ƿ�ɾ��</param>
        /// <param name="isTop">�Ƿ��ö�</param>
        /// <param name="isHot">�Ƿ��ȵ�</param>
        /// <param name="isRec">�Ƿ��Ƽ�</param>
        /// <param name="isImg">�Ƿ���ͼƬ����</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Article[] ArticlePager(int orgid, int? colid, string searTxt, bool? isVerify, bool? isDel, bool? isTop, bool? isHot, bool? isRec, bool? isImg, int size, int index, out int countSum);
        #endregion

        #region ����ר�����
        /// <summary>
        /// �������ר��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int SpecialAdd(Special entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SpecialSave(Special entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void SpecialDelete(Special entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void SpecialDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Special SpecialSingle(int identify);
        /// <summary>
        /// ��ǰר����Ͻ������
        /// </summary>
        /// <param name="identify"></param>
        /// <param name="searTxt"></param>
        /// <returns></returns>
        Article[] Special4Article(int identify, string searTxt);
        /// <summary>
        /// ��ǰר����Ͻ������
        /// </summary>
        /// <param name="identify">ר��id</param>
        /// <param name="searTxt">��������Ϣ</param>
        /// <param name="num">ȡ������</param>
        /// <param name="type">��ȡ���Ĭ��nullȡ�����ö������ȣ�hot�ȵ����ȣ�maxFlux�����������</param>
        /// <returns></returns>
        Article[] Special4Article(int identify, string searTxt, int num, string type);
        /// <summary>
        /// ȡ����ר��
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="isShow"></param>
        /// <param name="isUse"></param>
        /// <param name="count">ȡ������</param>
        /// <returns></returns>
        Special[] SpecialCount(int orgid, bool? isShow, bool? isUse, int count);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool SpecialUp(int orgid, int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool SpecialDown(int orgid, int id);
        /// <summary>
        /// ����ר�������µĹ���
        /// </summary>
        /// <param name="spId"></param>
        /// <param name="artId"></param>
        /// <returns></returns>
        bool SpecialAndArticle(int spId, int artId);
        /// <summary>
        /// ɾ��ר�������µĹ���
        /// </summary>
        /// <param name="spId"></param>
        /// <param name="artId"></param>
        /// <returns></returns>
        bool SpecialAndArticleDel(int spId, int artId);
        /// <summary>
        /// ר���б�
        /// </summary>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Special[] SpecialPager(string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// ר���µ������б�
        /// </summary>
        /// <param name="spId">ר��id</param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Article[] SpecialArticlePager(int spId, string searTxt, int size, int index, out int countSum);
        Article[] SpecialArticlePager(int spId, string searTxt, int size, int index, out int countSum, bool? isShow, bool? isUse);
        Article[] SpecialArticlePager(int spId, string searTxt, int size, int index, out int countSum, bool? isDel, bool? isShow, bool? isUse);
        Article[] SpecialArticle(int spId, string searTxt, int count);
        /// <summary>
        /// ר���µ�����
        /// </summary>
        /// <param name="spId">ר��Id</param>
        /// <param name="searTxt">�������ַ�</param>
        /// <param name="isDel">�Ƿ�ɾ��</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="isUse">�Ƿ�ʹ��</param>
        /// <param name="count">ȡ��������С�ڵ���0��ȡ����</param>
        /// <param name="type">��ȡ���Ĭ��nullȡ�����ö������ȣ�hot�ȵ����ȣ�maxFlux�����������</param>
        /// <returns></returns>
        Article[] SpecialArticle(int spId, string searTxt, bool? isDel, bool? isShow, bool? isUse, int count, string type);
        #endregion

        #region �������۹���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int NoteAdd(NewsNote entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void NoteSave(NewsNote entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void NoteDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        NewsNote NoteSingle(int identify);
        /// <summary>
        /// ���ŵ�����
        /// </summary>
        /// <param name="artid">����id</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="count"></param>
        /// <returns></returns>
        NewsNote[] NoteCount(int artid, bool? isShow, int count);
        /// <summary>
        /// ���µ�����
        /// </summary>
        /// <param name="artid">����id</param>
        /// <param name="searTxt"></param>
        /// <param name="isShow"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        NewsNote[] NotePager(int artid, string searTxt, bool? isShow, int size, int index, out int countSum);
        #endregion

        #region ͼƬ��Ϣ�Ĺ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int PictureAdd(Picture entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void PictureSave(Picture entity);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void PictureDelete(int identify);
        void PictureDelete(Picture entity);
        /// <summary>
        /// ɾ������ͼƬ
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀid</param>
        void PictureDeleteAll(int orgid, int colid);
        /// <summary>
        /// ��ע�Ƿ���ɾ��״̬�����������վ
        /// </summary>
        /// <param name="identify"></param>
        void PictureIsDelete(int identify);
        /// <summary>
        /// ͼƬ��ԭ���ӻ���վ�ص��б�
        /// </summary>
        /// <param name="identify"></param>
        void PictureRecover(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Picture PictureSingle(int identify);
        /// <summary>
        /// ���õ�ǰͼƬΪ������
        /// </summary>
        /// <param name="colid">������Ŀ��id</param>
        /// <param name="pid">��ǰͼƬ��Id</param>
        void PictureSetCover(int colid, int pid);
        void PictureSetCover(string uid, int pid);
        /// <summary>
        /// ��ȡͼƬ��Ϣ
        /// </summary>
        /// <param name="colid">��Ŀid</param>
        /// <param name="isDel">�Ƿ�ɾ��</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="searTxt">������Ϣ</param>
        /// <param name="count">��ȡ������</param>
        /// <returns></returns>
        Picture[] PictureCount(int orgid, int? colid, bool? isDel, bool? isShow, string searTxt, int count);
        Picture[] PictureCount(int orgid, string uid, bool? isDel, bool? isShow, string searTxt, int count);
        /// <summary>
        /// �������ҳ
        /// </summary>
        /// <param name="colid">��Ŀid</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>        
        Picture[] PicturePager(int orgid, int? colid, bool? isDel, string searTxt, int size, int index, out int countSum);
        Picture[] PicturePager(int orgid, int? colid, bool? isDel, bool? isShow, string searTxt, int size, int index, out int countSum);
        Picture[] PicturePager(int orgid, int? colid, bool? isDel, bool? isShow, string searTxt, bool? isHot, bool? isRec, bool? isTop, int size, int index, out int countSum);
        #endregion   
     
        #region ��Ʒ����
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int ProductAdd(Product entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void ProductSave(Product entity);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ProductUp(int orgid, int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool ProductDown(int orgid, int id);
        /// <summary>
        /// ʹ��ǰ��Ʒ���������һ
        /// </summary>
        /// <param name="id">��Ʒ��id</param>
        /// <param name="addNum">ÿ��������Ӽ�����</param>
        /// <returns></returns>
        int ProductNumber(int id, int addNum);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void ProductDelete(int identify);
        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀ����id</param>
        void ProductDeleteAll(int orgid, int colid);
        /// <summary>
        /// ��׼�����Ƿ���ɾ��״̬�����������վ
        /// </summary>
        /// <param name="identify"></param>
        void ProductIsDelete(int identify);
        /// <summary>
        /// ���»�ԭ���ӻ���վ�ص������б�
        /// </summary>
        /// <param name="identify"></param>
        void ProductRecover(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Product ProductSingle(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�ȫ��ΨһֵUID��
        /// </summary>
        /// <param name="uid">ȫ��Ψһֵ</param>
        /// <returns></returns>
        Product ProductSingle(string uid);
        /// <summary>
        /// ����Ŀ��ҳ
        /// </summary>
        /// <param name="nc_id">��Ŀid��Ϊ���򷵻�����</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Product[] ProductPager(int orgid, int? colid, int size, int index, out int countSum);
        Product[] ProductPager(int orgid, int? colid, string searTxt, bool? isDel, int size, int index, out int countSum);
        /// <summary>
        /// ����Ŀ��ҳ
        /// </summary>
        /// <param name="ps_id">��Ŀid</param>
        /// <param name="searTxt">Ҫ��������Ϣ</param>
        /// <param name="isDel">�Ƿ�ɾ����</param>
        /// <param name="isUse">�Ƿ�ʹ�õ�</param>
        /// <param name="type">�������������hot,����new���Ƽ�rec,�����flux</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Product[] ProductPager(int orgid, int? colid, string searTxt, bool? isDel, bool? isUse, bool? isNew, bool? isRec, string type, int size, int index, out int countSum);
        /// <summary>
        /// ��ȡ��Ʒ�б�����ҳ
        /// </summary>
        /// <param name="ps_id"></param>
        /// <param name="count"></param>
        /// <param name="isDel"></param>
        /// <param name="isUse"></param>
        /// <param name="type">�����ȡ������hot,����new���Ƽ�rec</param>
        /// <returns></returns>
        Product[] ProductCount(int orgid, int? colid, int count, bool? isDel, bool? isUse, string type);
            
        #endregion

        #region ��Դ��Ϣ�Ĺ���

        #region ��Դ
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int DownloadAdd(Download entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void DownloadSave(Download entity);
        /// <summary>
        /// ʹ��ǰ���ص����������һ��������id�������������Ч�ʸ���
        /// </summary>
        /// <param name="id">������Ϣ��id</param>
        /// <param name="addNum">ÿ��������Ӽ�����</param>
        /// <returns></returns>
        int DownloadNumber(int id, int addNum);
        /// <summary>
        /// ʹ��ǰ������Ϣ����������һ
        /// </summary>
        /// <param name="file">�ļ���</param>
        /// <param name="addNum">ÿ�����Ӽ�����</param>
        /// <returns></returns>
        int DownloadNumber(string file, int addNum);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void DownloadDelete(int identify);
        void DownloadDelete(Download entity);
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀid</param>
        void DownloadDeleteAll(int orgid, int colid);
        /// <summary>
        /// ��׼�����Ƿ���ɾ��״̬�����������վ
        /// </summary>
        /// <param name="identify"></param>
        void DownloadIsDelete(int identify);
        /// <summary>
        /// ���»�ԭ���ӻ���վ�ص������б�
        /// </summary>
        /// <param name="identify"></param>
        void DownloadRecover(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Download DownloadSingle(int identify);
        /// <summary>
        ///  ��ȡ��һʵ����󣬰�ȫ��Ψһ��
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        Download DownloadSingle(string uid);
        /// <summary>
        /// ��ҳ����
        /// </summary>
        /// <param name="colid"></param>
        /// <param name="isDel"></param>
        /// <param name="searTxt"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Download[] DownloadPager(int orgid, int? colid, bool? isDel, string searTxt, int size, int index, out int countSum);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colid"></param>
        /// <param name="type">�������𣬰��ȵ�hot,���Ƽ�rec�����ö�top��������new��������flux</param>
        /// <param name="isDel"></param>
        /// <param name="isShow"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>
        Download[] DownloadPager(int orgid, int? colid, string type, bool? isDel, bool? isShow, int size, int index, out int countSum);
        Download[] DownloadPager(int orgid, int? colid, string searTxt, string type, bool? isDel, bool? isShow, bool? isHot, bool? isRec, bool? isTop, int size, int index, out int countSum);
        /// <summary>
        /// ��ȡ�������ϵ���Ϣ
        /// </summary>
        /// <param name="dc_id">����id,Ϊ0ȡ������Ϣ</param>
        /// <param name="type">�������𣬰��ȵ�hot,���Ƽ�rec�����ö�top��������new��������flux</param>
        /// <param name="isDel"></param>
        /// <param name="isShow"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Download[] DownloadCount(int orgid, int? colid, string type, bool? isDel, bool? isShow, int count);
        #endregion

        #region ���ص���Դ����
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int DownloadTypeAdd(DownloadType entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void DownloadTypeSave(DownloadType entity);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void DownloadTypeDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        DownloadType DownloadTypeSingle(int identify);
        /// <summary>
        /// ȡ��������¼
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DownloadType[] DownloadTypeCount(int orgid, bool? isUse, int count);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool DownloadTypeUp(int orgid, int identify);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool DownloadTypeDown(int orgid, int identify);
        #endregion

        #region ���õ�ϵͳ
        /// <summary>
        /// ��������е�����ϵͳ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int DownloadOSAdd(DownloadOS entity);
        /// <summary>
        /// �޸������е�����ϵͳ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void DownloadOSSave(DownloadOS entity);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void DownloadOSDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        DownloadOS DownloadOSSingle(int identify);
        /// <summary>
        /// ȡ��������¼
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DownloadOS[] DownloadOSCount(int orgid, bool? isUse, int count);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool DownloadOSUp(int orgid, int identify);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        bool DownloadOSDown(int orgid, int identify);
        #endregion

        #endregion

        #region ��Ƶ��Ϣ�Ĺ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        int VideoAdd(Video entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void VideoSave(Video entity);
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void VideoDelete(int identify);
        void VideoDelete(Video entity);
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀ����id</param>
        void VideoDeleteAll(int orgid, int colid);
        /// <summary>
        /// ��ע�Ƿ���ɾ��״̬�����������վ
        /// </summary>
        /// <param name="identify"></param>
        void VideoIsDelete(int identify);
        /// <summary>
        /// ��Ƶ��ԭ���ӻ���վ�ص��б�
        /// </summary>
        /// <param name="identify"></param>
        void VideoRecover(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        Video VideoSingle(int identify);
        /// <summary>
        /// ���õ�ǰ��ƵΪ������
        /// </summary>
        /// <param name="colid">��ǰ����</param>
        /// <param name="vid">��ǰ��Ƶ��Id</param>
        void VideoSetCover(int colid, int vid);
        /// <summary>
        /// ��ȡ��Ƶ��Ϣ
        /// </summary>
        /// <param name="colid">��Ƶ����</param>
        /// <param name="isDel">�Ƿ�ɾ��</param>
        /// <param name="isShow">�Ƿ���ʾ</param>
        /// <param name="searTxt">������Ϣ</param>
        /// <param name="count">��ȡ������</param>
        /// <returns></returns>
        Video[] VideoCount(int orgid, int? colid, bool? isDel, bool? isShow, string searTxt, int count);
        Video[] VideoPager(int orgid, int? colid, int size, int index, out int countSum);
        /// <summary>
        /// �������ҳ
        /// </summary>
        /// <param name="colid">��Ƶ����</param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="countSum"></param>
        /// <returns></returns>        
        Video[] VideoPager(int orgid, int? colid, bool? isDel, string searTxt, int size, int index, out int countSum);
        Video[] VideoPager(int orgid, int? colid, bool? isDel, bool? isShow, string searTxt, int size, int index, out int countSum);
        Video[] VideoPager(int orgid, int? colid, bool? isDel, bool? isShow, bool? isHot, bool? isRec, bool? isTop, string searTxt, int size, int index, out int countSum);
        #endregion       
        
    }
}
