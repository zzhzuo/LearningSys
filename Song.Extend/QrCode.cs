using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using WeiSha.Common;

using Song.ServiceInterfaces;
using Song.Entities;
using WeiSha.Common.Param;

namespace Song.Extend
{
    /// <summary>
    /// ���ɶ�ά��
    /// </summary>
    public class QrCode
    {
        /// <summary>
        /// ͨ��ʵ�壬���ɶ�ά��
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="template">��ά������ģ��</param>
        /// <param name="wh">���</param>
        /// <param name="qrcodeImgPath">��ά���ļ�·��</param>
        /// <returns></returns>
        public static string Creat4Entity(WeiSha.Data.Entity entity, string template, string qrcodeImgPath, int wh)
        {
            Type info = entity.GetType();
            //��ȡ����������б�
            PropertyInfo[] properties = info.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo pi = properties[i];
                //��ǰ���Ե�ֵ
                object obj = info.GetProperty(pi.Name).GetValue(entity, null);
                string patt = @"{\#\s*{0}\s*}";
                patt = patt.Replace("{0}", pi.Name);
                Regex re = new Regex(patt, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
                template = re.Replace(template, obj == null ? "" : obj.ToString());
            }
            template = QrCode.tranUrl(template);
            //�Ƿ���������logo
            bool isCenterImg = Business.Do<ISystemPara>()["IsQrConterImage"].Boolean ?? true;
            string color = Business.Do<ISystemPara>()["QrColor"].String; 
            System.Drawing.Image image=null;
            if (isCenterImg)
            {
                string centerImg = Upload.Get["Org"].Physics + "QrCodeLogo.png";
                image = WeiSha.Common.QrcodeHepler.Encode(template, wh, centerImg, color, null);
            }
            else
            {
                image = WeiSha.Common.QrcodeHepler.Encode(template, wh, color, null);
            }
            image.Save(qrcodeImgPath);
            return qrcodeImgPath;
        }             
        /// <summary>
        /// �����ά��ģ��ĳ����ӣ���~תΪ��·��
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string tranUrl(string url)
        {
            Song.Entities.Organization org = Business.Do<IOrganization>().OrganDefault();
            //��ҵ��վ����
            string domain = org.Org_WebSite;
            if (domain != null && domain != "" && domain.Length >= 7)
            {
                if (domain.Substring(0, 7).ToLower() != "http://")
                {
                    domain = "http://" + domain;
                }
            }
            url = url.Replace("~", domain);
            return url;
        }
    }
}
