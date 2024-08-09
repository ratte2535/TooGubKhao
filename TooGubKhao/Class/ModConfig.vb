Module ModConfig
    Public Const returnUrl As String = "https://tgk.thaimetal.net/PaymentForm.aspx?Status=Success"
    Public Const cancelUrl As String = "https://tgk.thaimetal.net/PaymentForm.aspx?Status=Failed"
    Public Const ApiUrl As String = "https://api-pay.line.me/v2/payments/request"
    Public Const ApiUrlConfirm As String = "https://api-pay.line.me/v2/$$$/confirm"
    Public Const ConfirmUrl As String = "https://api-pay.line.me/v2/payments/{transactionId}/confirm"
    Public Const MerchantId As String = "2005613584"
    Public Const ChannelSecret As String = "aaec90540e1d9c62271dc5cd1471b71e"
    Public Const Currency As String = "THB"
End Module
