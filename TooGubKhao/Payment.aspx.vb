Imports Newtonsoft.Json.Linq

Public Class Payment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Async Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Try
            Dim orderId As String = "999999" 'Guid.NewGuid().ToString()
            Dim productName As String = "Example Product"
            Dim productImageUrl As String = "https://yourwebsite.com/images/product.jpg"
            Dim amount As Integer = 1 ' Example amount
            Dim linePayHelper As New LinePayHelper()
            Dim responseReturn = Await linePayHelper.RequestPaymentAsync(orderId, productName, productImageUrl, amount, Currency, returnUrl, cancelUrl, "Request")

            ' Process response
            ' Redirect user to the Line Pay checkout page or handle errors
            'MsgBox(response)
            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('" & response & "');", True)
            'Dim tokenJson = JsonConvert.SerializeObject(tokenJsonString)

            'Debug.Print(responseReturn)
            Dim json As JObject = JObject.Parse(responseReturn)
            'Dim URI As String = json("info")("paymentUrl")("app").ToString
            Dim URI As String = json("info")("paymentUrl")("web").ToString

            'Debug.Print(URI)
            Response.Redirect(URI)
        Catch ex As Exception
            ' Log and display error
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('" & ex.Message & "');", True)

            'MsgBox("Error: " & ex.Message)
            'Debug.Print(ex.Message)
        End Try
    End Sub


    Private Sub PaymentForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Request.QueryString("Status")) = False Then
            If Request.QueryString("Status").ToString.Trim <> "" Then
                If Request.QueryString("Status") = "Success" Then
                    Dim orderId As String = "999999" 'Guid.NewGuid().ToString()
                    Dim productName As String = "Example Product"
                    Dim productImageUrl As String = "https://yourwebsite.com/images/product.jpg"
                    Dim amount As Integer = 1 ' Example amount



                    Dim linePayService As New LinePayService()
                    Dim transactionId As String = Request.QueryString("transactionId")


                    Dim isPaymentConfirmed As Boolean = linePayService.ConfirmPayment(transactionId, amount, Currency)
                    If isPaymentConfirmed Then
                        'Console.WriteLine("Payment confirmed successfully.")
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('Payment confirmed successfully.');", True)

                    Else
                        ' Console.WriteLine("Payment confirmation failed.")
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('Payment confirmation failed.');", True)

                    End If

                    'Dim linePayHelper As New LinePayHelper()
                    'Dim responseReturn = Await linePayHelper.RequestPaymentAsync(orderId, productName, productImageUrl, amount, currency, returnUrl, cancelUrl, "Confirm")

                    'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('" & responseReturn & "');", True)

                    ' ConfirmPaymentAsync("", 1, 1)
                End If


                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowStatus", "javascript:alert('" & Request.QueryString("Status").ToString.Trim & "');", True)
            End If
        End If


    End Sub
End Class