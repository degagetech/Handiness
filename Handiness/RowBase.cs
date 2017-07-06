using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Reflection;
namespace Handiness
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/6 15:31:31
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：此类是数据库每行记录所映射到类的实例的基类，
 * 提供了一些基本的操作方法例如删除，更新，查询
 *  -------------------------------------------------------------------------*/

    public class RowBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 提供一个直接修改实例属性值的方法，此方法存在较大的性能损耗
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="newValue">新的值</param>
        public void NotifyPropertyValue(String propertyName, Object newValue)
        {
            Type type = this.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance|BindingFlags.SetProperty);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(this, newValue, null);
            }
        }
        /// <summary>
        /// 当前实例的属性值变跟记录
        /// </summary>
        protected Dictionary<String, Object> _notifyLog = new Dictionary<String, Object>();
        protected RowStateType State { get; set; } = RowStateType.Normal;
        /**************/
        protected void OnNotifyPropertyChanged(
            String proteryName,
            Object newValue)
        {
            this.WriteNotifLog(proteryName, newValue);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proteryName));
        }
        protected void WriteNotifLog(String proteryName, Object newValue)
        {
            if (!this._notifyLog.ContainsKey(proteryName))
            {
                this._notifyLog.Add(proteryName, newValue);
            }
            else
            {
                this._notifyLog[proteryName] = newValue;
            }
        }
        /// <summary>
        /// 判断当前实例是否可用
        /// </summary>
        /// <returns></returns>
        protected Boolean IsUsable()
        {
            return (this.State != RowStateType.Deleted);
        }
    }
    /// <summary>
    /// 当前行对象实例的状态
    /// </summary>
    public enum RowStateType
    {
        /// <summary>
        /// 正常的
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 表示此实例在数据库中已被删除，不应当继续使用
        /// </summary>
        Deleted = 1
    }
}
