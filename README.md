<html>
<body>
<h2>Very simple language translation and HTML Cleaner for MVC</h2>
<h3>The library get text of your HTML for translate to all languages configured and clean unnecesary formats one on the fly.</h3>

<u>Configuration:</u> <br>

```
    <add key="TranslateEnabled" value="true"/> -> Enable text translation on the fly
    <add key="ClearCommentsAndUnnecesaryFormat" value="true"/> -> Clear and compress HTML
    <add key="SavePendingTranslations" value="true"/> --> Save pending text translations
    <add key="DefaultLanguageOfKeys" value="es-ES"/> --> Your default current culture
```


Implement your custom provider for translations dictionary.<br>
JSON Default. Create all JSON file by language:<br>

<pre>
-- ca-ES.json
-- en-GB.json
</pre>

<u>Example of content. Keys are the default text in default language culture configured:</u><br>

<pre>
{
  "Inicio": "Inici",
  "Bienvenido": "Benvingut",
  "Proyecto demo": "Projecte demo"
}
</pre>

All pending translation save in the same location json files with the next format:

<pre>
-- ca-ES.Pending.json
</pre>

<u>Example of content:</u>

<pre>
{
  "Ejemplo 1": "<write translation and move element to ca-ES.json>",
  "Ejemplo 1 texto.": "<write translation and move element to ca-ES.json>",
}
</pre>


Only need replace in Views\web.config the next line:<br>

<pre>
    <!--<pages pageBaseType="System.Web.Mvc.WebViewPage">-->
    <pages pageBaseType="LanguageParser.PageBaseType">
</pre>

<br><br>

Feel free for fork and contribute!<br>
Thanks!

</body>
</html>



