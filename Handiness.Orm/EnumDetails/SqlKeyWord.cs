using System.ComponentModel;

namespace Handiness.Orm
{
    /// <summary>
    ///数据库关键词
    /// </summary>
    public enum SqlKeyWord
    {
        [Description("select")]
        Select = 0,
        [Description("insert")]
        Insert,
        [Description("update")]
        Update,
        [Description("delete")]
        Delete,
        [Description("where")]
        Where,
        [Description("from")]
        From,
        [Description("into")]
        Into,
        [Description("set")]
        Set,
        [Description("values")]
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
        [Description("and")]
        And,
        [Description("or")]
        Or,
        [Description("*")]
        AllColumn,
        /// <summary>
        /// 分号
        /// </summary>
        [Description(";")]
        Semicolon,
        [Description("like")]
        Like
    }
}
