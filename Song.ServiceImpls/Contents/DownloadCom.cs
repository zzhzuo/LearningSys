using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using WeiSha.Common;
using Song.Entities;

using WeiSha.Data;
using Song.ServiceInterfaces;
using System.Resources;
using System.Reflection;

namespace Song.ServiceImpls
{
    public partial class ContentsCom : IContents
    {
        public int DownloadAdd(Download entity)
        {
            Song.Entities.Columns nc = Business.Do<IColumns>().Single((int)entity.Col_Id);
            if (nc != null) entity.Col_Name = nc.Col_Name;
            //���ڻ���
            Song.Entities.Organization org = Business.Do<IOrganization>().OrganCurrent();
            if (org != null)
            {
                entity.Org_ID = org.Org_ID;
                entity.Org_Name = org.Org_Name;
            }
            return Gateway.Default.Save<Download>(entity);
        }

        public void DownloadSave(Download entity)
        {
            if (entity.Col_Name == "")
            {
                Song.Entities.Columns nc = Business.Do<IColumns>().Single((int)entity.Col_Id);
                if (nc != null) entity.Col_Name = nc.Col_Name;
            }
            Gateway.Default.Save<Download>(entity);
        }

        public int DownloadNumber(int id, int addNum)
        {
            object obj = Gateway.Default.Max<Download>(Download._.Dl_LookNumber, Download._.Dl_Id == id);
            int i = obj is int ? (int)obj : 0;
            //����������ӣ���ֱ�ӷ��ص�ǰ�����
            if (addNum < 1) return i;
            //���Ӽ���
            i += addNum;
            Gateway.Default.Update<Download>(new Field[] { Download._.Dl_LookNumber }, new object[] { i }, Download._.Dl_Id == id);
            return i;
        }

        public int DownloadNumber(string file, int addNum)
        {
            object obj = Gateway.Default.Max<Download>(Download._.Dl_DownNumber, Download._.Dl_FilePath == file);
            int i = obj is int ? (int)obj : 0;
            //����������ӣ���ֱ�ӷ��ص�ǰ�����
            if (addNum < 1) return i;
            //���Ӽ���
            i += addNum;
            Gateway.Default.Update<Download>(new Field[] { Download._.Dl_DownNumber }, new object[] { i }, Download._.Dl_FilePath == file);
            return i;
        }

        public void DownloadDelete(int identify)
        {
            Song.Entities.Download entity = this.DownloadSingle(identify);
            if (entity == null) return;
            DownloadDelete(entity);
        }
        public void DownloadDelete(Download entity)
        {
            //ɾ��ͼƬ
            WeiSha.WebControl.FileUpload.Delete("Download", entity.Dl_Logo);
            WeiSha.WebControl.FileUpload.Delete("Download", entity.Dl_FilePath);
            //ɾ������            
            Gateway.Default.Delete<Download>(entity);
        }
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀid</param>
        public void DownloadDeleteAll(int orgid, int colid)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Download._.Org_ID == orgid);
            if (colid > 0) wc.And(Download._.Col_Id == colid);
            Song.Entities.Download[] entities = Gateway.Default.From<Download>().Where(wc).ToArray<Download>();
            foreach (Song.Entities.Download entity in entities)
            {
                DownloadDelete(entity);
            }
        }
        public void DownloadIsDelete(int identify)
        {
            Gateway.Default.Update<Download>(new Field[] { Download._.Dl_IsDel }, new object[] { true }, Download._.Dl_Id == identify);
        }

        public void DownloadRecover(int identify)
        {
            Gateway.Default.Update<Download>(new Field[] { Download._.Dl_IsDel }, new object[] { false }, Download._.Dl_Id == identify);
        }

        public Download DownloadSingle(int identify)
        {
            return Gateway.Default.From<Download>().Where(Download._.Dl_Id == identify).ToFirst<Download>();
        }

        public Download DownloadSingle(string uid)
        {
            return Gateway.Default.From<Download>().Where(Download._.Dl_Uid == uid).ToFirst<Download>();
        }
        public Download[] DownloadPager(int orgid, int? colid, bool? isDel, string searTxt, int size, int index, out int countSum)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Download._.Org_ID == orgid);
            if (colid != null && colid > 0)
                wc.And(Download._.Col_Id == colid);
            if (isDel != null)
                  wc.And(Download._.Dl_IsDel == isDel);
            if (searTxt.Trim() != "" && searTxt != null)
                wc.And(Download._.Dl_Name.Like("%" + searTxt + "%"));
            countSum = Gateway.Default.Count<Download>(wc);
            return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_CrtTime.Desc).ToArray<Download>(size, (index - 1) * size);
        }

        public Download[] DownloadPager(int orgid, int? colid, string type, bool? isDel, bool? isShow, int size, int index, out int countSum)
        {

            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Download._.Org_ID == orgid);
            if (colid != null && colid > 0)
                wc.And(Download._.Col_Id == colid);
            if (isDel != null)
                wc.And(Download._.Dl_IsDel == isDel);
            if (isShow != null)
                wc.And(Download._.Dl_IsShow == isShow); 
            countSum = Gateway.Default.Count<Download>(wc);
            if (type != null)
            {
                switch (type.ToLower())
                {
                    case "hot":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsHot.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "rec":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsRec.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "top":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsTop.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "new":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_CrtTime.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "flux":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_DownNumber.Desc).ToArray<Download>(size, (index - 1) * size);
                }
            }
            return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsTop.Desc && Download._.Dl_CrtTime.Desc).ToArray<Download>(size, (index - 1) * size);
        }
        public Download[] DownloadPager(int orgid, int? colid, string searTxt, string type, bool? isDel, bool? isShow, bool? isHot, bool? isRec, bool? isTop, int size, int index, out int countSum)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Download._.Org_ID == orgid);
            if (colid != null && colid > 0)
                wc.And(Download._.Col_Id == colid);
            if (isDel != null) wc.And(Download._.Dl_IsDel == isDel);
            if (isShow != null) wc.And(Download._.Dl_IsShow == isShow);
            if (isHot != null) wc.And(Download._.Dl_IsHot == isHot);
            if (isRec != null) wc.And(Download._.Dl_IsRec == isRec);
            if (isTop != null) wc.And(Download._.Dl_IsTop == isTop);
            if (searTxt.Trim() != "" && searTxt != null)
                wc.And(Download._.Dl_Name.Like("%" + searTxt + "%"));
            countSum = Gateway.Default.Count<Download>(wc);
            if (type != null)
            {
                switch (type.ToLower())
                {
                    case "hot":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsHot.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "rec":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsRec.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "top":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsTop.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "new":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_CrtTime.Desc).ToArray<Download>(size, (index - 1) * size);
                    case "flux":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_DownNumber.Desc).ToArray<Download>(size, (index - 1) * size);
                }
            }
            return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsTop.Desc && Download._.Dl_CrtTime.Desc).ToArray<Download>(size, (index - 1) * size);
        }
        public Download[] DownloadCount(int orgid, int? colid, string type, bool? isDel, bool? isShow, int count)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Download._.Org_ID == orgid);
            if (colid != null && colid > 0)
                   wc.And(Download._.Col_Id == colid);
            if (isDel != null)
                   wc.And(Download._.Dl_IsDel == isDel);            
            if (isShow != null)           
                wc.And(Download._.Dl_IsShow == isShow);           
            if (type != null)
            {
                switch (type.ToLower())
                {
                    case "hot":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsHot.Desc).ToArray<Download>(count);
                    case "rec":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsRec.Desc).ToArray<Download>(count);
                    case "top":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsTop.Desc).ToArray<Download>(count);
                    case "new":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_CrtTime.Desc).ToArray<Download>(count);
                    case "flux":
                        return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_DownNumber.Desc).ToArray<Download>(count);
                }
            }
            return Gateway.Default.From<Download>().Where(wc).OrderBy(Download._.Dl_IsTop.Desc && Download._.Dl_CrtTime.Desc).ToArray<Download>(count);
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        public int DownloadTypeAdd(DownloadType entity)
        {
            object obj = Gateway.Default.Max<DownloadType>(DownloadType._.Dty_Tax, DownloadType._.Dty_Id > -1);
            entity.Dty_Tax = obj is int ? (int)obj + 1 : 0;
            //���ڻ���
            Song.Entities.Organization org = Gateway.Default.From<Organization>().Where(Organization._.Org_ID == entity.Org_Id).ToFirst<Organization>();
            if (org != null) entity.Org_Name = org.Org_Name;
            return Gateway.Default.Save<DownloadType>(entity);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        public void DownloadTypeSave(DownloadType entity)
        {
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    tran.Save<DownloadType>(entity);
                    tran.Update<Download>(new Field[] { Download._.Dty_Type }, new object[] { entity.Dty_Name }, Download._.Dty_Id == entity.Dty_Id);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                finally
                {
                    tran.Close();
                }
            }
        }
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        public void DownloadTypeDelete(int identify)
        {
            Gateway.Default.Delete<DownloadType>(DownloadType._.Dty_Id == identify);
        }
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        public DownloadType DownloadTypeSingle(int identify)
        {
            return Gateway.Default.From<DownloadType>().Where(DownloadType._.Dty_Id == identify).ToFirst<DownloadType>();
        }
        /// <summary>
        /// ȡ��������¼
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DownloadType[] DownloadTypeCount(int orgid, bool? isUse, int count)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(DownloadType._.Org_Id == orgid);
            if (isUse != null) wc.And(DownloadType._.Dty_IsUse == (bool)isUse);
            return Gateway.Default.From<DownloadType>().Where(wc).OrderBy(DownloadType._.Dty_Tax.Asc).ToArray<DownloadType>(count);        
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        public bool DownloadTypeUp(int orgid, int identify)
        {
            //��ǰ����
            DownloadType current = Gateway.Default.From<DownloadType>().Where(DownloadType._.Dty_Id == identify).ToFirst<DownloadType>();
            int tax = (int)current.Dty_Tax;
            //��һ�����󣬼��ֳ������ֳ�������ֱ�ӷ���false;
            DownloadType prev = Gateway.Default.From<DownloadType>()
                .Where(DownloadType._.Dty_Tax < tax && DownloadType._.Org_Id == orgid).OrderBy(DownloadType._.Dty_Tax.Desc).ToFirst<DownloadType>();
            if (prev == null) return false;

            //���������
            current.Dty_Tax = prev.Dty_Tax;
            prev.Dty_Tax = tax;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            try
            {
                tran.Save<DownloadType>(current);
                tran.Save<DownloadType>(prev);
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Close();
            }  
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        public bool DownloadTypeDown(int orgid, int identify)
        {
            //��ǰ����
            DownloadType current = Gateway.Default.From<DownloadType>().Where(DownloadType._.Dty_Id == identify).ToFirst<DownloadType>();
            int tax = (int)current.Dty_Tax;
            //��һ�����󣬼��ܵܶ��󣻵ܵܲ�����ֱ�ӷ���false;
            DownloadType next = Gateway.Default.From<DownloadType>()
                .Where(DownloadType._.Dty_Tax > tax && DownloadType._.Org_Id == orgid).OrderBy(DownloadType._.Dty_Tax.Asc).ToFirst<DownloadType>();
            if (next == null) return false;

            //���������
            current.Dty_Tax = next.Dty_Tax;
            next.Dty_Tax = tax;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            try
            {
                tran.Save<DownloadType>(current);
                tran.Save<DownloadType>(next);
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Close();
            }  
        }


        /// <summary>
        /// ��������е�����ϵͳ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        public int DownloadOSAdd(DownloadOS entity)
        {
            object obj = Gateway.Default.Max<DownloadOS>(DownloadOS._.Dos_Tax, DownloadOS._.Dos_Id > -1);
            entity.Dos_Tax = obj is int ? (int)obj + 1 : 0;
            //���ڻ���
            Song.Entities.Organization org = Gateway.Default.From<Organization>().Where(Organization._.Org_ID == entity.Org_Id).ToFirst<Organization>();
            if (org != null) entity.Org_Name = org.Org_Name;
            return Gateway.Default.Save<DownloadOS>(entity);

        }
        /// <summary>
        /// �޸������е�����ϵͳ
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        public void DownloadOSSave(DownloadOS entity)
        {
            Gateway.Default.Save<DownloadOS>(entity);
        }
        /// <summary>
        /// ����ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        public void DownloadOSDelete(int identify)
        {
            Gateway.Default.Delete<DownloadOS>(DownloadOS._.Dos_Id == identify);
        }
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        public DownloadOS DownloadOSSingle(int identify)
        {
            return Gateway.Default.From<DownloadOS>().Where(DownloadOS._.Dos_Id == identify).ToFirst<DownloadOS>();
        }
        /// <summary>
        /// ȡ��������¼
        /// </summary>
        /// <param name="isUse"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DownloadOS[] DownloadOSCount(int orgid, bool? isUse, int count)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(DownloadOS._.Org_Id == orgid);
            if (isUse != null) wc.And(DownloadOS._.Dos_IsUse == (bool)isUse);
            return Gateway.Default.From<DownloadOS>().Where(wc).OrderBy(DownloadOS._.Dos_Tax.Asc).ToArray<DownloadOS>(count); 
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        public bool DownloadOSUp(int orgid, int identify)
        {
            //��ǰ����
            DownloadOS current = Gateway.Default.From<DownloadOS>().Where(DownloadOS._.Dos_Id == identify).ToFirst<DownloadOS>();
            int tax = (int)current.Dos_Tax;
            //��һ�����󣬼��ֳ������ֳ�������ֱ�ӷ���false;
            DownloadOS prev = Gateway.Default.From<DownloadOS>()
                .Where(DownloadOS._.Dos_Tax < tax && DownloadOS._.Org_Id==orgid).OrderBy(DownloadOS._.Dos_Tax.Desc).ToFirst<DownloadOS>();
            if (prev == null) return false;

            //���������
            current.Dos_Tax = prev.Dos_Tax;
            prev.Dos_Tax = tax;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            try
            {
                tran.Save<DownloadOS>(current);
                tran.Save<DownloadOS>(prev);
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Close();
            }  
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        public bool DownloadOSDown(int orgid, int identify)
        {
            //��ǰ����
            DownloadOS current = Gateway.Default.From<DownloadOS>().Where(DownloadOS._.Dos_Id == identify).ToFirst<DownloadOS>();
            int tax = (int)current.Dos_Tax;
            //��һ�����󣬼��ܵܶ��󣻵ܵܲ�����ֱ�ӷ���false;
            DownloadOS next = Gateway.Default.From<DownloadOS>()
                .Where(DownloadOS._.Dos_Tax > tax && DownloadOS._.Org_Id == orgid).OrderBy(DownloadOS._.Dos_Tax.Asc).ToFirst<DownloadOS>();
            if (next == null) return false;

            //���������
            current.Dos_Tax = next.Dos_Tax;
            next.Dos_Tax = tax;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            try
            {
                tran.Save<DownloadOS>(current);
                tran.Save<DownloadOS>(next);
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Close();
            }  
        }

        
    }
}
