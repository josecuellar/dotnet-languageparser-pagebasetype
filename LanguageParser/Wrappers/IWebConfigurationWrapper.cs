using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageParser.Wrappers
{
    interface IWebConfigurationWrapper
    {

        string GetSettingFromName(string name);

    }
}
