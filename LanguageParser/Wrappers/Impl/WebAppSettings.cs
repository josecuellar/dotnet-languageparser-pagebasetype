using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageParser.Wrappers.Impl
{
    class WebAppSettings : IWebConfigurationWrapper
    {

        public string GetSettingFromName(string name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }

    }
}
