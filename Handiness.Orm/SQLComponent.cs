using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    /// SQL字符串以及SQL参数的组合，并提供对SQL字符串的常用处理
    /// </summary>
    public class SQLComponent
    {
        public String SQL { get { return this._sqlBuilder.ToString(); } }
        public List<DbParameter> Parameters { get; private set; } = new List<DbParameter>();

        private StringBuilder _sqlBuilder = new StringBuilder();


        public SQLComponent() { }
        public SQLComponent(String sql, IEnumerable<DbParameter> parameters = null)
        {
            this._sqlBuilder.Append(sql);
            this.Parameters.AddRange(parameters);
        }
        /// <summary>
        /// 附加指定SQL与参数信息到组件中
        /// </summary>
        public void Append(String sql, IEnumerable<DbParameter> parameters)
        {
            this.AppendSQL(sql);
            this.AddParameters(parameters);
        }
        public void AppendSQLFormat(String format,params Object[] paras)
        {
            this._sqlBuilder.AppendFormat(format, paras);
        }
        /// <summary>
        /// 附加指定的SQL到组件中，此函数不会对SQL做任何处理只是单纯的附加的现有SQL末尾或头部
        /// </summary>
        public void AppendSQL(String sql, Boolean isHead = false)
        {
            if (isHead)
                this._sqlBuilder.Insert(0, sql);
            else
                this._sqlBuilder.Append(sql);
        }
        /// <summary>
        /// 清除组件当前的SQL信息，并使用新的SQL填充组件
        /// </summary>
        public void ClearSQL(String sql=null)
        {
            this._sqlBuilder.Clear();
            if (sql != null)
            {
                this._sqlBuilder.Append(sql);
            }
        }
        /// <summary>
        /// 添加指定的 <see cref="DbParameter"/>对象到组件中,空的参数对象并不会被添加
        /// </summary>
        public void AddParameter(DbParameter parameter)
        {
            if (parameter != null)
            {

                this.Parameters.Add(parameter);
            }
        }
        /// <summary>
        /// 添加一批参数到组件中
        /// </summary>
        /// <param name="parameters"></param>
        public void AddParameters(IEnumerable<DbParameter> parameters)
        {
            if (parameters != null)
            {
                this.Parameters.AddRange(parameters);
            }
        }
        /// <summary>
        /// 将另一个<see cref="SQLComponent"/>组件包含的SQ、L参数等信息附加到末尾
        /// </summary>
        /// <param name="component"></param>
        public void Append(SQLComponent component)
        {
            this.AppendSQL(component.SQL);
            this.AddParameters(component.Parameters);
        }

        /// <summary>
        /// 移除SQL结尾处的逗号
        /// </summary>
        public void TrimEndComma()
        {
            this._sqlBuilder.Remove(0, this._sqlBuilder.Length - SqlKeyWord.COMMA.Length);
        }
        /// <summary>
        /// 在SQL组件末尾处附加 <see cref="SqlKeyWord.WHERE"/> 关键词，若存在则附加 <see cref="SqlKeyWord.AND"/> 或者 <see cref="SqlKeyWord.OR"/>关键词
        /// </summary>
        public void AppendWhere(Boolean appendAnd = true)
        {
            String currentSQL = this.SQL;
            if (-1 == currentSQL.IndexOf(SqlKeyWord.WHERE))
            {
                this._sqlBuilder.Append(SqlKeyWord.WHERE);
            }
            else
            {
                if (appendAnd)
                {
                    this._sqlBuilder.Append(SqlKeyWord.AND);
                }
                else
                {
                    this._sqlBuilder.Append(SqlKeyWord.OR);
                }
            }
         
        }
        /// <summary>
        /// 使用指定的SQL字符串与参数集合创建一个<see cref="SQLComponent"/>对象
        /// </summary>
        public static SQLComponent Create(String sql, IEnumerable<DbParameter> parameters = null)
        {
            return new SQLComponent(sql, parameters);
        }


        public static SQLComponent operator +(SQLComponent left, SQLComponent right)
        {
            left.Append(right);
            return left;
        }
    }
}
