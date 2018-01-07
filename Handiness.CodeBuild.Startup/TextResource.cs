using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/8/7 17:43:05
 * 版本号：v1.0
 * .NET 版本：4.6
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    public class TextResource
    {
        /// <summary>
        /// 命令标题
        /// </summary>
        public const String CommandTitle = "实体类生成";
        public const String BuildAssistPacketWithEmpty = "数据异常";

        public static String CodeTemplateFilesPath = @"CodeTemplate\";
        public static String TypeMappingFilesPath = @"TypeMapping\";

        public const String BuildButtonTextWithConnection = "连接中";
        public const String BuildButtonTextWithNormal = "组建";
        public const String BuildButtonTextWithBuilding = "组建中";

    }
}
