using LanguageParser.Wrappers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace LanguageParser.Services.Impl
{
    class HtmlParser : IHtmlParser
    {

        private readonly Regex regexRegex = new Regex(@"(>\s+<)", RegexOptions.Compiled);

        private readonly Regex regexAll = new Regex(@"(\s+|\t\s+|\n\s*|\r\s+)", RegexOptions.Compiled);

        private readonly Regex regexComments = new Regex(@"<!--(?!\[if).*?-->", RegexOptions.Compiled);


        public HashSet<string> ExtractTextFromHTML(string html)
        {
            HashSet<string> innerText = new HashSet<string>();

            MatchCollection matches = Regex.Matches(html, @"(?<=\>)(.*?)(?=\<)");

            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    if (!string.IsNullOrWhiteSpace(m.Groups[1].ToString()))
                        innerText.Add(m.Groups[1].ToString());
                }
            }

            return innerText;                
        }

        public string ClearCommentsAndUnnecesaryFormat(string html)
        {
            html = this.regexRegex.Replace(html, "><");
            html = this.regexAll.Replace(html, " ");
            html = this.regexComments.Replace(html, "");

            return html;
        }

    }
}
