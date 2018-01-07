using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Handiness.CodeBuild
{
    /// <summary>
    ///用以帮助管理客户端的配置文件中的信息
    /// </summary>
    public sealed class ConfigurationAssistor
    {
        private static String _ConnectionStringKey = "ConnectionString";
        private static String _NameSpaceKey = "NameSpace";
        public static String ConnectionString
        {
            get
            {
                return GetKey(_ConnectionStringKey);
            }
            set
            {
                SaveKey(_ConnectionStringKey,value);
            }
        }
        public static String NameSpace
        {
            get
            {
                return GetKey(_NameSpaceKey);
            }
            set
            {
                SaveKey(_NameSpaceKey, value);
            }
        }



        public static void SaveKey(String key, String value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

        }
        public static String GetKey(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
