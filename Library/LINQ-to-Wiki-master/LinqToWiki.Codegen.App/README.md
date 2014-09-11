The `linqtowiki-codegen` application
====================================

`linqtowiki-codegen` is a simple console application
that can be used to access the functionality of LinqToWiki.Codegen.
In other words, it can generate a library for accessing a specific wiki using LinqToWiki.

Using its command-line arguments, one can specify the URL of the wiki,
the directory to where the files will be generated, the namespace of the generated types,
the name of the generated assembly and the location of the props default file.

Some of the more advanced features of LinqToWiki.Codegen,
such as writing the generated C# code to a specific directory,
are not available from this application.

The application writes a short usage note when run without arguments:

```
Usage:    linqtowiki-codegen url-to-api [namespace [output-name]] [-d output-directory] [-p props-file-path]
Examples: linqtowiki-codegen en.wikipedia.org LinqToWiki.Enwiki linqtowiki-enwiki -d C:\Temp -p props-defaults-sample.xml
          linqtowiki-codegen https://en.wikipedia.org/w/api.php
```
