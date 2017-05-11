<html>
<body>
<h2>Simple Language Translation Parsing And HTML Cleaner for MVC</h2>

Configuration: <br>

<code>
    <add key="TranslateEnabled" value="true"/> -> Enable text translation on the fly
    <add key="ClearCommentsAndUnnecesaryFormat" value="true"/> -> Clear and compress HTML
    <add key="SavePendingTranslations" value="true"/> --> Save pending text translations
    <add key="DefaultLanguageOfKeys" value="es-ES"/> --> Your default current culture
</code>

The library get text of your HTML for translate on the fly.<br>

Implement your custom provider for translations dictionary.<br>
JSON Default. Create all JSON file by language:<br>

<pre>
-- ca-ES.json
-- en-GB.json
</pre>

<u>Example of content. Keys are the default text in default language culture configured:</u><br>

<code>
{
  "Inicio": "Inici",
  "Bienvenido": "Benvingut",
  "Proyecto demo": "Projecte demo"
}
</code>

All pending translation save in the same location json files with the next format:

-- ca-ES.Pending.json

<u>Example of content:</u>

<code>
{
  "Ejemplo 1": "<write translation and move element to ca-ES.json>",
  "Ejemplo 1 texto.": "<write translation and move element to ca-ES.json>",
}
</code>


Only need replace in Views\web.config the next line:<br>

<code>
    <!--<pages pageBaseType="System.Web.Mvc.WebViewPage">-->
    <pages pageBaseType="LanguageParser.PageBaseType">
</code>

<br><br>

Feel free for fork and contribute!<br>
Thanks!

</body>
</html>



