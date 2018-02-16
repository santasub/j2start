j2start

Build this VB.net project with VisualStudio or use the allredy build on in j2start\j2start\bin\Debug
You need the j2start.exe and the j2start.exe.config

Make your default settings in the j2start.exe.config
You are able to set the "JAVAexe" path witch will be used to run your jnlp file by default
You are also able to set the location wehre te file will be donloaded to

Example Configuration:
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
      <add key="JAVAexe" value="C:\Program Files\Java\jre7\bin\javaws.exe" />
      <add key="jnlpFile" value="C:\temp\bofiles\boclient.jnlp" />
    </appSettings>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
    </startup>
</configuration>

run the tool from the command line wuth --help to see this help file.
