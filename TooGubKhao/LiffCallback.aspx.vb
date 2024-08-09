Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Web.Services

Partial Public Class LiffCallback
    Inherits System.Web.UI.Page
    Dim UserIDvalue As String = ""
    <WebMethod>
    Public Shared Sub SaveUserProfile(userId As String, displayName As String, pictureUrl As String)
        ' Process data here (e.g., save to database)
        Console.WriteLine($"Received data - UserID: {userId}, DisplayName: {displayName}, PictureUrl: {pictureUrl}")
        'UserIDvalue = userId
        ' Example of saving to a database (pseudo-code)
        ' Dim db As New YourDatabaseContext()
        ' Dim user As New User()
        ' user.UserId = userId
        ' user.DisplayName = displayName
        ' user.PictureUrl = pictureUrl
        ' db.Users.Add(user)
        ' db.SaveChanges()
        ' ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('" & userId & "');", True)

    End Sub
    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    '        Dim liffId As String = "2005819917-lPLkov3Z"
    '        Dim state As String = Session("oauth_state") 'Request.QueryString("state")
    '        Dim code As String = "" 'Request.QueryString("code")

    '        If Not String.IsNullOrEmpty(state) Then
    '            ' Initialize LIFF
    '            Dim liff As New LineLiffHelper(liffId)
    '            Dim profileResponse As String = liff.GetProfile()
    '            Dim email As String = liff.GetEmail()

    '            ' Display user profile and email
    '            lblProfile.Text = profileResponse
    '            lblEmail.Text = email
    '        Else
    '            lblProfile.Text = "Invalid state or no code received."
    '        End If
    '    End Sub
    'End Class

    'Public Class LineLiffHelper
    '    Private Property LiffId As String

    '    Public Sub New(ByVal liffId As String)
    '        Me.LiffId = liffId
    '    End Sub

    '    Public Function GetProfile() As String
    '        Dim profileJson As String = ""
    '        Dim liff As New LineLiff(Me.LiffId)
    '        Dim profile As String = liff.GetProfile()
    '        If Not String.IsNullOrEmpty(profile) Then
    '            Dim json As JObject = JObject.Parse(profile)
    '            profileJson = $"User ID: {json("userId")}, Display Name: {json("displayName")}, Picture URL: {json("pictureUrl")}"
    '        End If
    '        Return profileJson
    '    End Function

    '    Public Function GetEmail() As String
    '        Dim email As String = ""
    '        Dim liff As New LineLiff(Me.LiffId)
    '        Dim idToken As String = liff.GetDecodedIDToken()
    '        If Not String.IsNullOrEmpty(idToken) Then
    '            Dim json As JObject = JObject.Parse(idToken)
    '            email = json("email").ToString()
    '        End If
    '        Return email
    '    End Function
    'End Class

    'Public Class LineLiff
    '    Private Property LiffId As String
    '    Private Const ApiEndpoint As String = "https://api.line.me/liff/v1/apps/"

    '    Public Sub New(ByVal liffId As String)
    '        Me.LiffId = liffId
    '    End Sub

    '    Public Function GetProfile() As String
    '        Dim profile As String = ""
    '        Dim requestUrl As String = $"{ApiEndpoint}{Me.LiffId}/profile"
    '        Try
    '            Dim request As Net.HttpWebRequest = Net.WebRequest.Create(requestUrl)
    '            request.Method = "GET"
    '            request.Headers.Add("Authorization", $"Bearer {HttpContext.Current.Session("LineAccessToken")}")

    '            Using response As Net.HttpWebResponse = request.GetResponse()
    '                Using reader As New StreamReader(response.GetResponseStream())
    '                    profile = reader.ReadToEnd()
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            ' Handle exception
    '        End Try
    '        Return profile
    '    End Function

    '    Public Function GetDecodedIDToken() As String
    '        Dim idToken As String = ""
    '        Dim requestUrl As String = $"{ApiEndpoint}{Me.LiffId}/id/token"
    '        Try
    '            Dim request As Net.HttpWebRequest = Net.WebRequest.Create(requestUrl)
    '            request.Method = "GET"
    '            request.Headers.Add("Authorization", $"Bearer {HttpContext.Current.Session("LineAccessToken")}")

    '            Using response As Net.HttpWebResponse = request.GetResponse()
    '                Using reader As New StreamReader(response.GetResponseStream())
    '                    idToken = reader.ReadToEnd()
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            ' Handle exception
    '        End Try
    '        Return idToken
    '    End Function
End Class
