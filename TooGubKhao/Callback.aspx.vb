Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class Callback
    Inherits System.Web.UI.Page
    Dim ObjMain As New ClsMain
    Dim Ds As DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            Dim code As String = Request.QueryString("code")
            If Not String.IsNullOrEmpty(code) Then
                Dim tokenResponse As String = GetAccessToken(code)
                Dim accessToken As String = ParseAccessToken(tokenResponse)
                Dim profile As String = GetUserProfile(accessToken)
                'Label1.Text = "Profile: " & profile

                Dim json As JObject = JObject.Parse(profile)
                Dim UserID As String = json("userId").ToString
                Dim DisplayName As String = json("displayName").ToString
                Dim PictureURL As String = json("pictureUrl").ToString

                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('UserID=" & UserID & "\nDisplayName=" & DisplayName & "\nPictureURL=" & PictureURL & "\n');", True)



                'Debug.Print(URI)
                'Response.Redirect(URI)

                If UserID.Trim.ToString = "" Then
                    Response.Redirect("Default.aspx?Error=UserID Not found")

                Else

                    ObjMain.UserID = UserID
                    Ds = ObjMain.Sp_Users_Select



                    If Ds.Tables(0).Rows.Count > 0 Then
                        'มี ให้ Update
                        ObjMain.UserID = UserID
                        ObjMain.DisplayName = DisplayName
                        ObjMain.PictureURL = PictureURL
                        ObjMain.Sp_Users_Update()

                    Else
                        'ไม่มีให้ Insert
                        ObjMain.UserID = UserID
                        ObjMain.DisplayName = DisplayName
                        ObjMain.PictureURL = PictureURL
                        ObjMain.Sp_Users_Insert()



                    End If




                    'ตรวจ User ว่ายืนยันครบยังถ้ายังใส่ระบุเพิ่ม
                    ObjMain.UserID = UserID
                    Ds = ObjMain.Sp_Users_Select



                    If Ds.Tables(0).Rows.Count > 0 Then
                        Session("UserID") = UserID

                        If Ds.Tables(0).Rows(0)("EmailConfirm").ToString = "N" Or Ds.Tables(0).Rows(0)("MobileConfirm").ToString = "N" Or Ds.Tables(0).Rows(0)("FirstName").ToString = "" Or Ds.Tables(0).Rows(0)("LastName").ToString = "N" Then
                            'ต้องระบุข้อมูล



                            Response.Redirect("ProfileManage.aspx")
                        Else
                            Response.Redirect("TooGubKhao.aspx")

                        End If


                    End If

                End If

            Else


                Response.Redirect("Default.aspx?Error=No Code Received")

            End If
        End If
    End Sub

    Private Function GetAccessToken(ByVal code As String) As String
        Dim request As WebRequest = WebRequest.Create("https://api.line.me/oauth2/v2.1/token")
        request.Method = "POST"
        Dim postData As String = String.Format("grant_type=authorization_code&code={0}&redirect_uri={1}&client_id={2}&client_secret={3}", code, "https://tgk.thaimetal.net/Callback.aspx", "2005819917", "b3a1bac7d8e62837cf1c060a3aed675f")
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length

        Using dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
        End Using

        Dim response As WebResponse = request.GetResponse()
        Using dataStream As Stream = response.GetResponseStream()
            Using reader As New StreamReader(dataStream)
                Return reader.ReadToEnd()
            End Using
        End Using
    End Function

    Private Function ParseAccessToken(ByVal response As String) As String
        Dim json As JObject = JObject.Parse(response)
        Return json("access_token").ToString()
    End Function

    Private Function GetUserProfile(ByVal accessToken As String) As String
        Dim request As WebRequest = WebRequest.Create("https://api.line.me/v2/profile")
        request.Method = "GET"
        request.Headers("Authorization") = "Bearer " & accessToken

        Dim response As WebResponse = request.GetResponse()
        Using dataStream As Stream = response.GetResponseStream()
            Using reader As New StreamReader(dataStream)
                Return reader.ReadToEnd()
            End Using
        End Using
    End Function

End Class
