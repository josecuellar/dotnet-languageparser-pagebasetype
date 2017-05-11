
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageParser.Services
{
    interface ILanguageTranslationsProvider
    {

        IDictionary<string, string> LoadDictionaryFromCulture(string cultureName);

        void SavePendingTranslations(HashSet<string> pendings, string cultureName);

    }
}
