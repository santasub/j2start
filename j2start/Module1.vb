Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

Module Module1
    Private Structure NameCommandLineStuct
        Dim Name As String
        Dim Value As String
    End Structure
    Private CommandLineArgs As New List(Of NameCommandLineStuct)

    Dim JAVAexe As String = ConfigurationSettings.AppSettings("JAVAexe")
    Dim jnlpFile As String = ConfigurationSettings.AppSettings("jnlpFile")

    Sub Main()
        Dim JNLPurl As String = ""
        If ParseCommandLine() Then
            For Each commandItem As NameCommandLineStuct In CommandLineArgs
                Select Case commandItem.Name.ToLower
                    Case "javapath"
                        'Console.Write(String.Format("Javapath is {0}", commandItem.Value + vbCrLf))
                        'This Overrides the JAVAexe path form the config file if the param is set
                        JAVAexe = commandItem.Value
                    Case "jnlpurl"
                        'Console.Write(String.Format("jnlpurl two is {0}", commandItem.Value + vbCrLf))
                        JNLPurl = commandItem.Value
                End Select
            Next

            OpenJBO(CleanUpStrings(JAVAexe), CleanUpStrings(JNLPurl))

        End If
    End Sub

    Function OpenJBO(JAVAexe, JNLPurl)
        Try
            DelOldFiles(jnlpFile)

            'Download Jnlp file
            My.Computer.Network.DownloadFile(JNLPurl, jnlpFile)
            'Open BO

            Dim sp As New ProcessStartInfo(JAVAexe, jnlpFile)
            sp.WindowStyle = ProcessWindowStyle.Hidden
            sp.CreateNoWindow = True
            Process.Start(sp)
        Catch ex As Exception
            Console.Write(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Function DelOldFiles(JNLPFile)
        If IO.File.Exists(JNLPFile) Then
            Try
                IO.File.Delete(JNLPFile)
            Catch ex As Exception
                Console.Write(ex.Message)
                Return False
            End Try
        End If
        Return True
    End Function

    Private Function CleanUpStrings(String2Clean) As String
        'Remove double quotes
        Dim CleanString As String = String2Clean.Replace("""", "")
        Return CleanString
    End Function

    Function ShowOpts()
        Console.Write("Loads a jnlp file from a remote location and open it with the predefined javaws.exe" + vbCrLf)
        Console.Write("" + vbCrLf)
        Console.Write("j2start --jnlpurl=""http://removeteserver.com:8096/jnlp/jnlpfile.jnlp""" + vbCrLf)
        Console.Write("" + vbCrLf)
        Console.Write("  Parameters:" + vbCrLf)
        Console.Write("  --help shows this help message" + vbCrLf)
        Console.Write("  --jnlpurl set a jnlp file URL to download" + vbCrLf)
        Console.Write("  --javapath overrides the standart javaws to use for this call" + vbCrLf)
        Console.Write("" + vbCrLf)
        Console.Write("HINT: Configure the standart javaws.exe path in the j2start.exe.config file.")
        Return True
    End Function

    Function ParseCommandLine() As Boolean
        'step one, Do we have a command line?
        If String.IsNullOrEmpty(Command) Then
            'If Command is empty
            Return False
        End If
        'aktivieren um zu Sehen mit welchen parametern die exe aufgerufen wurde
        'MsgBox(Command)
        'does the command line have at least one named parameter?
        If Not Command.Contains("--") Then
            'give up if we don't
            Return False
        End If

        If Command.Contains("--help") Then
            ShowOpts()
            Return False
        End If

        'Split the command line on our slashes.  
        Dim Params As String() = Split(Command, "--")

        'Iterate through the parameters passed
        For Each arg As String In Params

            'only process if the argument is not empty
            If Not String.IsNullOrEmpty(arg) Then
                'and contains an equal 
                If arg.Contains("=") Then
                    Dim tmp As NameCommandLineStuct
                    'find the equal sign
                    Dim idx As Integer = arg.IndexOf("=")
                    'if the equal isn't at the end of the string
                    If idx < arg.Length - 1 Then
                        'parse the name value pair
                        tmp.Name = arg.Substring(0, idx).Trim()
                        tmp.Value = arg.Substring(idx + 1).Trim()
                        'add it to the list.
                        CommandLineArgs.Add(tmp)
                    End If
                End If
            End If

        Next
        Return True
    End Function
End Module
