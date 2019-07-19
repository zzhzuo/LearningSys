using System;
using System.Collections.Generic;
using System.Text;
using Song.Entities;

namespace Song.ServiceInterfaces
{
    /// <summary>
    /// ֧���ӿڹ���
    /// </summary>
    public interface IPayInterface : WeiSha.Common.IBusinessInterface
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void PayAdd(PayInterface entity);
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void PaySave(PayInterface entity);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        void PayDelete(PayInterface entity);
        /// <summary>
        /// ɾ����������ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        void PayDelete(int identify);
        /// <summary>
        /// ��ȡ��һʵ����󣬰�����ID��
        /// </summary>
        /// <param name="identify">ʵ�������</param>
        /// <returns></returns>
        PayInterface PaySingle(int identify);
        /// <summary>
        /// ��ȡ���У�
        /// </summary>
        /// <param name="orgid">����id</param>
        /// <param name="platform">�ӿ�ƽ̨������Ϊweb���ֻ�Ϊmobi</param>
        /// <param name="isEnable">�Ƿ�����</param>
        /// <returns></returns>
        PayInterface[] PayAll(int orgid, string platform, bool? isEnable);
        /// <summary>
        /// ��ǰ���������Ƿ�����
        /// </summary>
        /// <param name="entity">ҵ��ʵ��</param>
        /// <returns></returns>
        PayInterface PayIsExist(int orgid, PayInterface entity);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool PayRemoveUp(int id);
        /// <summary>
        /// ����ǰ��Ŀ�����ƶ������ڵ�ǰ�����ͬ���ƶ�����ͬһ���ڵ��µĶ�����ǰ�ƶ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns>����Ѿ����ڶ��ˣ��򷵻�false���ƶ��ɹ�������true</returns>
        bool PayRemoveDown(int id);
    }
}
