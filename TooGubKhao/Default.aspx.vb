Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class _Default
    Inherits System.Web.UI.Page
    Dim ObjMain As New ClsMain
    Dim Ds As DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ObjMain.Sql = "SELECT 1"
        Ds = ObjMain.Execute


        'HyperLink1.NavigateUrl = "https://access.line.me/oauth2/v2.1/authorize?response_type=code&client_id=2005819917&redirect_uri=https://tgk.thaimetal.net/Callback.aspx&state=" & state & "&scope=profile%20openid%20email"
    End Sub


    Protected Sub btnLoginLine_Click(sender As Object, e As EventArgs) Handles btnLoginLine.Click
        Dim state As String = Guid.NewGuid().ToString()
        Session("oauth_state") = state
        Response.Redirect("https://access.line.me/oauth2/v2.1/authorize?response_type=code&client_id=2005819917&redirect_uri=https://tgk.thaimetal.net/Callback.aspx&state=" & state & "&scope=profile%20openid%20email")
    End Sub
End Class