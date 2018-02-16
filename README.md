j2start

Build this VB.net project with VisualStudio or use the allredy build on in j2start\j2start\bin\Debug
You need the j2start.exe and the j2start.exe.config

Make your default settings in the j2start.exe.config
You are able to set the "JAVAexe" path witch will be used to run your jnlp file by default
You are also able to set the location wehre te file will be donloaded to

run the tool from the command line with --help to see this help file.

Loads a jnlp file from a remote location and open it with the predefined javaws.exe

j2start --jnlpurl="http://removeteserver.com:8096/jnlp/jnlpfile.jnlp"

  Parameters:
  --help shows this help message
  --jnlpurl set a jnlp file URL to download
  --javapath overrides the standart javaws to use for this call

HINT: Configure the standart javaws.exe path in the j2start.exe.config file.
