using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;
using System.Data;
using WeiSha.Common;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ģ�����
    /// </summary>
    public interface ITemplate : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ����Webģ��
        /// </summary>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank[] WebTemplates();
        /// <summary>
        /// �����ֻ�ģ��
        /// </summary>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank[] MobiTemplates();
        /// <summary>
        /// �����ĵ�ǰwebģ��
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank WebCurrTemplate(int orgid);
        WeiSha.Common.Templates.TemplateBank WebCurrTemplate();
        /// <summary>
        /// �����ĵ�ǰ�ֻ�ģ��
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank MobiCurrTemplate(int orgid);
        WeiSha.Common.Templates.TemplateBank MobiCurrTemplate();
        /// <summary>
        /// ���õ�ǰwebģ��
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank SetWebCurr(int orgid, string tag);
        /// <summary>
        /// ���õ�ǰ�ֻ�ģ��
        /// </summary>
        /// <param name="orgid"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank SetMobiCurr(int orgid, string tag);
        /// <summary>
        /// ͨ��ģ���ʶ��ȡwebģ��
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank GetWebTemplate(string tag);
        /// <summary>
        /// ͨ��ģ���ʶ��ȡ�ֻ�ģ��
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank GetMobiTemplate(string tag);
        /// <summary>
        /// ����ģ����Ϣ
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        WeiSha.Common.Templates.TemplateBank Save(WeiSha.Common.Templates.TemplateBank tmp);
        
    }
}
