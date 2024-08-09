Imports System.Data.SqlClient
Imports System.Reflection

Public Class ClsDB



    Dim web As Assembly = Assembly.GetExecutingAssembly
    Dim webName As AssemblyName = web.GetName

    Private Conn As New SqlConnection



    Public Sub CloseSqlConn()
        Conn.Close()
        Conn.Dispose()
    End Sub


    Public Function SqlConnTGKDB(ByVal Conn As SqlConnection)
        Try
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("TGKDBConnectionString").ToString() & "Application Name=TGK [" & webName.Version.ToString() & "];"
            Conn.Open()
        Catch ex As Exception
            Return "Error while connecting to SQL Server." & ex.Message
        End Try
        Return Conn.ConnectionString
    End Function





End Class
