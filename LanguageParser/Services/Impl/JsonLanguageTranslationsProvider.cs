using LanguageParser.Wrappers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;

namespace LanguageParser.Services.Impl
{
    class JsonLanguageTranslationsProvider : ILanguageTranslationsProvider
    {

        readonly IWebHttpContextWrapper _contextWrapper;

        public JsonLanguageTranslationsProvider()
        {
            _contextWrapper = new Wrappers.Impl.WebHttpContext();
        }

        public IDictionary<string, string> LoadDictionaryFromCulture(string cultureName)
        {
            var json = File.ReadAllText(_contextWrapper.MapPath(@"~/App_Data/" + cultureName + ".json"));

            if (!string.IsNullOrWhiteSpace(json))
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return new Dictionary<string, string>();
        }

        public void SavePendingTranslations(HashSet<string> pendings, string cultureName)
        {
            if (pendings.Count == 0 || string.IsNullOrWhiteSpace(cultureName))
                return;

            var filePath = _contextWrapper.MapPath(@"~/App_Data/" + cultureName + ".Pending.json");

            Dictionary<string, string> pendingsLoaded = new Dictionary<string, string>();
            string jsonData = string.Empty;

            if (File.Exists(filePath))
            {
                jsonData = File.ReadAllText(filePath);

                pendingsLoaded = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData)
                                                      ?? new Dictionary<string, string>();
            }

            bool flagAdded = false;
            foreach (string pending in pendings)
            {
                if (!string.IsNullOrWhiteSpace(pending) && !pendingsLoaded.ContainsKey(pending))
                {
                    pendingsLoaded.Add(pending, "<write translation and move element to " + cultureName + ".json>");
                    flagAdded = true;
                }
            }

            if (flagAdded)
            {
                jsonData = JsonConvert.SerializeObject(pendingsLoaded);
                File.WriteAllText(filePath, jsonData);
            }
        }

    }
}
