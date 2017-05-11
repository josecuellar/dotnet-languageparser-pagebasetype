using System.Collections.Generic;

namespace LanguageParser.Services
{
    interface IHtmlParser
    {

        HashSet<string> ExtractTextFromHTML(string html);

        string ClearCommentsAndUnnecesaryFormat(string html);

    }
}
