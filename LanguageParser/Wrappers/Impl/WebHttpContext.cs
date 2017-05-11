using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LanguageParser.Wrappers.Impl
{
    class WebHttpContext : IWebHttpContextWrapper
    {

        public string MapPath(string virtualPath)
        {
            return HttpContext.Current.Request.MapPath(virtualPath);
        }

    }
}
