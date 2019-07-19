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
        public int ProductAdd(Product entity)
        {
            //����ʱ��
            entity.Pd_CrtTime = DateTime.Now;
            Song.Entities.Columns nc = Business.Do<IColumns>().Single((int)entity.Col_Id);
            if (nc != null) entity.Col_Name = nc.Col_Name;
            //��Ӷ��󣬲����������
            object obj = Gateway.Default.Max<Product>(Product._.Pd_Tax, Product._.Col_Id == entity.Col_Id);
            entity.Pd_Tax = obj is int ? (int)obj + 1 : 0;
            //���ڻ���
            Song.Entities.Organization org = Business.Do<IOrganization>().OrganCurrent();
            if (org != null)
            {
                entity.Org_ID = org.Org_ID;
                entity.Org_Name = org.Org_Name;
            }
            return Gateway.Default.Save<Product>(entity);
        }

        public void ProductSave(Product entity)
        {            
            Song.Entities.Columns nc = Business.Do<IColumns>().Single((int)entity.Col_Id);
            if (nc != null) entity.Col_Name = nc.Col_Name;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    tran.Save<Product>(entity);
                    //�����Ĳ�Ʒ��Ϣʱ��ͬ�����Ĳ�Ʒ���ԵĲ�Ʒ����
                    tran.Update<ProductMessage>(new Field[] { ProductMessage._.Pd_Name }, new object[] { entity.Pd_Name }, ProductMessage._.Pd_Id == entity.Pd_Id);
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

        public bool ProductUp(int orgid, int id)
        {
            //��ǰ����
            Product current = Gateway.Default.From<Product>().Where(Product._.Pd_Id == id).ToFirst<Product>();
            int tax = (int)current.Pd_Tax;
            //��һ�����󣬼��ֳ������ֳ�������ֱ�ӷ���false;
            Product prev = Gateway.Default.From<Product>()
                .Where(Product._.Pd_Tax < tax && Product._.Col_Id == current.Col_Id && Product._.Org_ID == orgid)
                .OrderBy(Product._.Pd_Tax.Desc).ToFirst<Product>();
            if (prev == null) return false;

            //���������
            current.Pd_Tax = prev.Pd_Tax;
            prev.Pd_Tax = tax;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    tran.Save<Product>(current);
                    tran.Save<Product>(prev);
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

        public bool ProductDown(int orgid, int id)
        {
            //��ǰ����
            Product current = Gateway.Default.From<Product>().Where(Product._.Pd_Id == id).ToFirst<Product>();
            int tax = (int)current.Pd_Tax;
            //��һ�����󣬼��ܵܶ��󣻵ܵܲ�����ֱ�ӷ���false;
            Product next = Gateway.Default.From<Product>()
                .Where(Product._.Pd_Tax > tax && Product._.Col_Id == current.Col_Id && Product._.Org_ID == orgid)
                .OrderBy(Product._.Pd_Tax.Asc).ToFirst<Product>();
            if (next == null) return false;
            //���������
            current.Pd_Tax = next.Pd_Tax;
            next.Pd_Tax = tax;
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    tran.Save<Product>(current);
                    tran.Save<Product>(next);
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

        public int ProductNumber(int id, int addNum)
        {
            object obj = Gateway.Default.Max<Product>(Product._.Pd_Number, Product._.Pd_Id == id);
            int i = obj is int ? (int)obj : 0;
            //����������ӣ���ֱ�ӷ��ص�ǰ�����
            if (addNum < 1) return i;
            //���Ӽ���
            i += addNum;
            Gateway.Default.Update<Product>(new Field[] { Product._.Pd_Number }, new object[] { i }, Product._.Pd_Id == id);
            return i;
        }

        public void ProductDelete(int identify)
        {
            Song.Entities.Product entity = this.ProductSingle(identify);
            using (DbTrans tran = Gateway.Default.BeginTrans())
            {
                try
                {
                    _ProductDelete(entity,tran);
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
        /// ����ɾ��
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="colid">��Ŀ����id</param>
        public void ProductDeleteAll(int orgid, int colid)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Product._.Org_ID == orgid);
            if (colid > 0) wc.And(Product._.Col_Id == colid);
            Song.Entities.Product[] entities = Gateway.Default.From<Product>().Where(wc).ToArray<Product>();
            DbTrans tran = Gateway.Default.BeginTrans();
            foreach (Song.Entities.Product entity in entities)
            {
                _ProductDelete(entity, tran);
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        private void _ProductDelete(Product entity, DbTrans tran)
        {
            //ɾ����Ʒ������
            tran.Delete<ProductMessage>(ProductMessage._.Pd_Id == entity.Pd_Id);
            // ɾ����ƷͼƬ
            //Song.Entities.ProductPicture[] pps = this.PictureAll(entity.Pd_Id, null);
            //foreach (ProductPicture p in pps)
            //{
            //    this._PictureDelete(p);
            //}
            //ɾ����Ʒ����Ϣ
            string resPath = WeiSha.Common.Upload.Get["Product"].Physics;
            WeiSha.WebControl.FileUpload.Delete("Product", entity.Pd_Logo);
            //ɾ����ά���ļ�
            if (System.IO.File.Exists(resPath + entity.Pd_QrCode))
            {
                System.IO.File.Delete(resPath + entity.Pd_QrCode);
            }
            tran.Delete<Product>(Product._.Pd_Id == entity.Pd_Id);
        }
        public void ProductIsDelete(int identify)
        {
            Gateway.Default.Update<Product>(new Field[] { Product._.Pd_IsDel }, new object[] { true }, Product._.Pd_Id == identify);
        }

        public void ProductRecover(int identify)
        {
            Gateway.Default.Update<Product>(new Field[] { Product._.Pd_IsDel }, new object[] { false }, Product._.Pd_Id == identify);
        }

        public Product ProductSingle(int identify)
        {
            return Gateway.Default.From<Product>().Where(Product._.Pd_Id == identify).ToFirst<Product>();
        }

        public Product ProductSingle(string uid)
        {
            return Gateway.Default.From<Product>().Where(Product._.Pd_Uid == uid).ToFirst<Product>();
        }

        public Product[] ProductPager(int orgid, int? colid, int size, int index, out int countSum)
        {
            WhereClip wc = Product._.Pd_IsDel == false;
            if (orgid > 0) wc.And(Product._.Org_ID == orgid);  
            if (colid != null && colid > 0) wc.And(Product._.Col_Id == colid);        
            countSum = Gateway.Default.Count<Product>(wc);
            return Gateway.Default.From<Product>().Where(wc).OrderBy(Product._.Pd_Tax.Asc).ToArray<Product>(size, (index - 1) * size);
        }

        public Product[] ProductPager(int orgid, int? colid, string searTxt, bool? isDel, int size, int index, out int countSum)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Product._.Org_ID == orgid);
            if (colid != null && colid > 0) wc.And(Product._.Col_Id == colid);
            if (isDel != null) wc.And(Product._.Pd_IsDel == (bool)isDel);
            if (searTxt != null && searTxt.Trim() != "")
                wc.And(Product._.Pd_Name.Like("%" + searTxt + "%"));
            countSum = Gateway.Default.Count<Product>(wc);
            return Gateway.Default.From<Product>().Where(wc).OrderBy(Product._.Pd_Tax.Asc).ToArray<Product>(size, (index - 1) * size);
        }

        public Product[] ProductPager(int orgid, int? colid, string searTxt, bool? isDel, bool? isUse, bool? isNew, bool? isRec, string type, int size, int index, out int countSum)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Product._.Org_ID == orgid);
            if (colid != null && colid > 0) wc.And(Product._.Col_Id == colid);
            if (isDel != null) wc.And(Product._.Pd_IsDel == (bool)isDel);
            if (isUse != null) wc.And(Product._.Pd_IsUse == (bool)isUse);
            if (isNew != null && isNew != false) wc.And(Product._.Pd_IsNew == (bool)isNew);
            if (isRec != null && isRec != false) wc.And(Product._.Pd_IsRec == (bool)isRec);
            if (searTxt != null && searTxt.Trim() != "")
                wc.And(Product._.Pd_Name.Like("%" + searTxt + "%"));
            countSum = Gateway.Default.Count<Product>(wc);
            type = type.ToLower();
            if (type == "new")
            {
                return Gateway.Default.From<Product>().Where(wc).OrderBy(Product._.Pd_IsNew.Asc && Product._.Pd_Tax.Asc).ToArray<Product>(size, (index - 1) * size);
            }
            if (type == "hot")
            {
                return Gateway.Default.From<Product>().Where(wc).OrderBy(Product._.Pd_Number.Desc && Product._.Pd_Tax.Asc).ToArray<Product>(size, (index - 1) * size);
            }
            if (type == "rec")
            {
                return Gateway.Default.From<Product>().Where(wc).OrderBy(Product._.Pd_IsRec.Desc && Product._.Pd_Tax.Asc).ToArray<Product>(size, (index - 1) * size);
            }
            return Gateway.Default.From<Product>().Where(wc).OrderBy(Product._.Pd_Tax.Asc).ToArray<Product>(size, (index - 1) * size);
        }

        public Product[] ProductCount(int orgid, int? colid, int count, bool? isDel, bool? isUse, string type)
        {
            WhereClip wc = new WhereClip();
            if (orgid > 0) wc.And(Product._.Org_ID == orgid);
            if (colid != null && colid > 0) wc.And(Product._.Col_Id == colid);
            if (isDel != null) wc.And(Product._.Pd_IsDel == isDel);
            if (isUse != null) wc.And(Product._.Pd_IsUse == isUse);
            type = type.ToLower();
            //����ʽ
            OrderByClip order = Product._.Pd_Tax.Asc;
            if (type == "new")
            {
                order = Product._.Pd_IsNew.Asc;
                wc.And(Product._.Pd_IsNew == true);
            }
            if (type == "hot") order = Product._.Pd_Number.Desc;
            if (type == "rec") order = Product._.Pd_IsRec.Asc;
            if (type == "flux") order = Product._.Pd_Number.Desc;
            //ȡ��Ʒ����
            return Gateway.Default.From<Product>().Where(wc).OrderBy(order && Product._.Pd_PushTime.Desc && Product._.Pd_Tax.Asc).ToArray<Product>(count);        
        }
    }
}
