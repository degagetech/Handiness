using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/27 18:24:46
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用以在SQLNode之间传递已有的SQL与SQL参数
 *  -------------------------------------------------------------------------*/
    public class SQLCourier:IEnumerable
    {
        public String SQL { get { return this._sqlStringBuilder.ToString(); } }
        private StringBuilder _sqlStringBuilder = null;

        public IDictionary<String, Object> SQLParameters { get; private set; }

        public SQLCourier(String sql, IDictionary<String, Object> parameters)
        {
            this._sqlStringBuilder = new StringBuilder(sql);
            this.SQLParameters = parameters;
        }

        /// <summary>
        /// 向参数字典中添加新的参数对，如果存在则会更新原有值
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        public void Add(String name, Object value)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return;
            }
            if (this.SQLParameters.ContainsKey(name))
            {
                this.SQLParameters[name] = value;
            }
            else
            {
                this.SQLParameters.Add(name, value);
            }
        }
        /// <summary>
        /// 将指定SQL插入到现有SQL的指定位置，默认插入到末尾
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="sql">现有SQL</param>
        public void Insert(String sql, Int32 index = -1)
        {
            if (String.IsNullOrWhiteSpace(sql))
            {
                return;
            }
            if (-1 == index)
            {
                this._sqlStringBuilder.Append(sql);
            }
            else
            {
                this._sqlStringBuilder.Insert(index, sql);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.SQLParameters.GetEnumerator();
        }
    }
}
