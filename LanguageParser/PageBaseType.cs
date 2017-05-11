using LanguageParser.Services;
using LanguageParser.Wrappers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;

namespace LanguageParser
{
    public abstract class PageBaseType<TModel> : WebViewPage<TModel>
    {

        readonly IWebConfigurationWrapper _configurationWrapper;
        readonly ILanguageTranslationsProvider _translationsProvider;
        readonly IHtmlParser _parser;
        readonly IDictionary<string, string> _tranlations;
        readonly string CurrentCulture = Thread.CurrentThread.CurrentUICulture.Name;

        private bool TranslateEnabled
        {
            get
            {
                bool translateEnabled = false;

                if (CurrentCulture == _configurationWrapper.GetSettingFromName("DefaultLanguageOfKeys"))
                    return translateEnabled;

                bool.TryParse(_configurationWrapper.GetSettingFromName("TranslateEnabled"), out translateEnabled);
                return translateEnabled;
            }
        }

        private bool SavePendingTranslations
        {
            get
            {
                bool savePendingTranslations = false;
                bool.TryParse(_configurationWrapper.GetSettingFromName("SavePendingTranslations"), out savePendingTranslations);
                return savePendingTranslations;
            }
        }

        private bool ClearCommentsAndUnnecesaryFormat
        {
            get
            {
                bool clearCommentsAndUnnecesaryFormat = false;
                bool.TryParse(_configurationWrapper.GetSettingFromName("ClearCommentsAndUnnecesaryFormat"), out clearCommentsAndUnnecesaryFormat);
                return clearCommentsAndUnnecesaryFormat;
            }
        }


        public PageBaseType() : base()
        {
            _configurationWrapper = new Wrappers.Impl.WebAppSettings();
            _translationsProvider = new Services.Impl.JsonLanguageTranslationsProvider();
            _parser = new Services.Impl.HtmlParser();

            if (TranslateEnabled)
                _tranlations = _translationsProvider.LoadDictionaryFromCulture(CurrentCulture);
        }


        public override void Write(object value)
        {
            if (value != null && TranslateEnabled)
                value = new MvcHtmlString(Execute(value.ToString()));

            base.Write(value);
        }


        public override void WriteLiteral(object value)
        {
            if (value != null && TranslateEnabled)
                value = Execute(value.ToString());

            base.WriteLiteral(value);
        }


        private string Execute(string input)
        {

            if (ClearCommentsAndUnnecesaryFormat)
                input = _parser.ClearCommentsAndUnnecesaryFormat(input);

            HashSet<string> toTranslate = _parser.ExtractTextFromHTML(input);

            if (toTranslate.Count == 0)
                return input;

            HashSet<string> pendingTranslations = new HashSet<string>();

            foreach (string textToTranslate in toTranslate)
            {
                if (this._tranlations.ContainsKey(textToTranslate) 
                    && !string.IsNullOrWhiteSpace(this._tranlations[textToTranslate]))
                {
                    input = input.Replace(textToTranslate, this._tranlations[textToTranslate]);
                    continue;
                }

                if (!this._tranlations.ContainsKey(textToTranslate) 
                    && SavePendingTranslations)
                    pendingTranslations.Add(textToTranslate);
            }

            if (SavePendingTranslations)
                _translationsProvider.SavePendingTranslations(pendingTranslations, CurrentCulture);

            return input;
        }
    }

}
