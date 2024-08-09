Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Public Class LinePayHelper


    Public Async Function RequestPaymentAsync(orderId As String, productName As String, productImageUrl As String, amount As Integer, currency As String, returnUrl As String, cancelUrl As String, ByVal Type As String) As Task(Of String)
        Using client As New HttpClient()
            Dim requestContent = New With {
                .amount = amount,
                .currency = "THB", ' Set currency to THB
                .orderId = orderId,
                .productName = productName,
                .productImageUrl = productImageUrl,
                    .confirmUrl = returnUrl,
                    .cancelUrl = cancelUrl
                            }

            Dim jsonContent = JsonConvert.SerializeObject(requestContent)
            Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")

            client.DefaultRequestHeaders.Add("X-LINE-ChannelId", MerchantId)
            client.DefaultRequestHeaders.Add("X-LINE-ChannelSecret", ChannelSecret)

            Dim ApiURLValue As String = ""
            If Type = "Request" Then
                ApiURLValue = ApiUrl
            ElseIf Type = "Confirm" Then
                ApiURLValue = ApiUrlConfirm
            End If
            Dim response = Await client.PostAsync(ApiURLValue, content)
            Dim responseString = Await response.Content.ReadAsStringAsync()

            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Error Code: {response.StatusCode}, Error Message: {responseString}")
            End If

            Return responseString
        End Using
    End Function


End Class

