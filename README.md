j2start

Build this VB.net project with VisualStudio or use the allredy build on in j2start\j2start\bin\Debug
You need the j2start.exe and the j2start.exe.config

Make your default settings in the j2start.exe.config.
The config file needs to be in the same directory as the exe.

You are able to set the "JAVAexe" path which will be used to run your jnlp file by default.
You are also able to set the location where the file will be downloaded to. This directory does not need to exist and will be created.


Sample Configuration File:
``` xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
      <add key="JAVAexe" value="C:\Program Files\Java\jre7\bin\javaws.exe" />
      <add key="jnlpFile" value="C:\temp\jnlpfiles\sample.jnlp" />
    </appSettings>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
    </startup>
</configuration>
```
Run the tool from the command line with --help to see this help file:
``` bash
Loads a jnlp file from a remote location and open it with the predefined javaws.exe

j2start --jnlpurl="http://removeteserver.com:8096/jnlp/jnlpfile.jnlp"

  Parameters:
  --help shows this help message
  --jnlpurl set a jnlp file URL to download
  --javapath overrides the standart javaws to use for this call

HINT: Configure the standart javaws.exe path in the j2start.exe.config file.
```
