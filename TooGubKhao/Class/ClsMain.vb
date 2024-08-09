Imports System.Data.SqlClient
Public Class ClsMain
    Public Sql As String
    Public UserID As String
    Public DisplayName As String
    Public PictureURL As String

    Public Function Execute() As DataSet

        Dim obj As New ClsDB
        Dim Conn As New SqlConnection()
        Dim cmd As New SqlCommand()

        Try
            obj.SqlConnTGKDB(Conn)

            cmd.Connection = Conn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = Sql
            cmd.CommandTimeout = 300
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@SqlCommand", System.Data.SqlDbType.NVarChar)).Value = Sql

            Dim cmdReader As SqlDataReader = Nothing
            Dim Ds As New DataSet()
            Dim DT As New DataTable()
            cmdReader = cmd.ExecuteReader()

            DT.Load(cmdReader)

            Ds.Tables.Add(DT)
            cmd.Dispose()
            Conn.Close()
            Conn.Dispose()

            Return Ds
        Catch ex As Exception
            'Response.Redirect("ErrorPage.aspx?error=พารามิเตอร์ไม่ถูกต้อง")
            'Throw ex
            'ScriptManager.RegisterStartupScript([GetType](), "Startup", "<script language='javascript'>alert('" & ex.Message & "');</script>")
            'MsgBox(ex.Message)
        Finally
            obj.CloseSqlConn()
            Conn.Dispose()
            Conn.Close()
            Conn.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function Sp_Users_Select()
        Dim obj As New ClsDB()
        Dim Conn As New SqlConnection()
        Dim cmd As New SqlCommand()


        Try
            obj.SqlConnTGKDB(Conn)

            cmd.Connection = Conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "Sp_Users_Select"
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()

            cmd.Parameters.Add(New SqlParameter("@UserID", Data.SqlDbType.NVarChar)).Value = UserID



            Dim cmdReader As SqlDataReader = Nothing
            Dim Ds As New DataSet()
            Dim DT As New DataTable()
            cmdReader = cmd.ExecuteReader()

            DT.Load(cmdReader)

            Ds.Tables.Add(DT)
            cmd.Dispose()


            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSqlConn()
            Conn.Dispose()
            Conn.Close()
            Conn.Dispose()
        End Try
    End Function

    Public Function Sp_Users_Insert()
        Dim obj As New ClsDB()
        Dim Conn As New SqlConnection()
        Dim cmd As New SqlCommand()


        Try
            obj.SqlConnTGKDB(Conn)

            cmd.Connection = Conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "Sp_Users_Insert"
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()

            cmd.Parameters.Add(New SqlParameter("@UserID", Data.SqlDbType.NVarChar)).Value = UserID
            cmd.Parameters.Add(New SqlParameter("@DisplayName", Data.SqlDbType.NVarChar)).Value = DisplayName
            cmd.Parameters.Add(New SqlParameter("@PictureURL", Data.SqlDbType.NVarChar)).Value = PictureURL



            Dim cmdReader As SqlDataReader = Nothing
            Dim Ds As New DataSet()
            Dim DT As New DataTable()
            cmdReader = cmd.ExecuteReader()

            DT.Load(cmdReader)

            Ds.Tables.Add(DT)
            cmd.Dispose()


            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSqlConn()
            Conn.Dispose()
            Conn.Close()
            Conn.Dispose()
        End Try
    End Function


    Public Function Sp_Users_Update()
        Dim obj As New ClsDB()
        Dim Conn As New SqlConnection()
        Dim cmd As New SqlCommand()


        Try
            obj.SqlConnTGKDB(Conn)

            cmd.Connection = Conn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "Sp_Users_Update"
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()

            cmd.Parameters.Add(New SqlParameter("@UserID", Data.SqlDbType.NVarChar)).Value = UserID
            cmd.Parameters.Add(New SqlParameter("@DisplayName", Data.SqlDbType.NVarChar)).Value = DisplayName
            cmd.Parameters.Add(New SqlParameter("@PictureURL", Data.SqlDbType.NVarChar)).Value = PictureURL



            Dim cmdReader As SqlDataReader = Nothing
            Dim Ds As New DataSet()
            Dim DT As New DataTable()
            cmdReader = cmd.ExecuteReader()

            DT.Load(cmdReader)

            Ds.Tables.Add(DT)
            cmd.Dispose()


            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSqlConn()
            Conn.Dispose()
            Conn.Close()
            Conn.Dispose()
        End Try
    End Function
End Class
