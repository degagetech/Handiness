using System.ComponentModel;

namespace Handiness.Orm
{
    /// <summary>
    ///数据库关键词
    /// </summary>
    public enum SqlKeyWord
    {
        [Description("SELECT")]
        Select = 0,
        [Description("INSERT")]
        Insert,
        [Description("UPDATE")]
        Update,
        [Description("DELETE")]
        Delete,
        [Description("WHERE")]
        Where,
        [Description("FROM")]
        From,
        [Description("INTO")]
        Into,
        [Description("SET")]
        Set,
        [Description("VALUES")]
        Values,
        [Description("(")]
        LeftBracket,
        [Description(")")]
        RightBracket,
        /// <summary>
        /// 逗号
        /// </summary>
        [Description(",")]
        Comma,
        [Description(">=")]
        GreaterThanOrEqual,
        [Description(">")]
        GreaterThan,
        [Description("<=")]
        LessThanOrEqual,
        [Description("<")]
        LessThan,
        [Description("=")]
        Equal,
        [Description("!=")]
        NotEqual,
        [Description("AND")]
        And,
        [Description("OR")]
        Or,
        [Description("*")]
        AllColumn,
        /// <summary>
        /// 分号
        /// </summary>
        [Description(";")]
        Semicolon,
        [Description("LIKE")]
        Like
    }
}
