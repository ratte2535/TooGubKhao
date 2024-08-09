Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class LinePayService




    Public Function ConfirmPayment(transactionId As String, amount As Decimal, currency As String) As Boolean
        Try
            ' Prepare the request URL
            Dim requestUrl As String = ConfirmUrl.Replace("{transactionId}", transactionId)

            ' Create the request object
            Dim request As HttpWebRequest = CType(WebRequest.Create(requestUrl), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.Headers.Add("X-LINE-ChannelId", MerchantId)
            request.Headers.Add("X-LINE-ChannelSecret", ChannelSecret)

            ' Prepare the request body
            Dim requestBody As New Dictionary(Of String, Object) From {
                {"amount", amount},
                {"currency", currency}
            }
            Dim requestBodyString As String = JsonConvert.SerializeObject(requestBody)
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestBodyString)

            ' Write the request body to the request stream
            Using dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
            End Using

            ' Get the response
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using responseStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(responseStream)
                    Dim responseString As String = reader.ReadToEnd()
                    ' Process the response here
                    ' Check if the payment was successful
                    Dim responseJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseString)
                    If responseJson("returnCode").ToString() = "0000" Then
                        ' Payment confirmed successfully
                        Return True
                    Else
                        ' Handle error
                        Console.WriteLine("Error: " & responseJson("returnMessage"))
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception
            Console.WriteLine("Exception: " & ex.Message)
            Return False
        End Try
    End Function

End Class
