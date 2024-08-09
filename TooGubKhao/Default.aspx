<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="TooGubKhao._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>TooGubKhao</title>
    <link href="Assets/css/styles.css" rel="stylesheet" />
    <script src="Assets/js/all.js"></script>
      <script src="https://static.line-scdn.net/liff/edge/2/sdk.js"></script>
</head>
<body class="bg-primary">
    <form id="form1" runat="server">
         <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header"><h3 class="text-center font-weight-light my-4">TooGubKhao Login ...</h3></div>
                                    <div class="card-body">
                                        <%-- <form>--%>
                                            <div class="form-floating mb-3" style="text-align:center">
                                                <br /><br />
                                                <%-- <input class="form-control" id="inputEmail" type="email" placeholder="name@example.com" />--%>                                                <%--<label for="inputEmail">Email address</label>--%>                                                <%--<asp:HyperLink ID="HyperLink1" runat="server">--%>
                                                <asp:Button ID="btnLoginLine" runat="server" Text="Log in with LINE account" BackColor="#5ABA0C" Font-Bold="False" ForeColor="White" Height="40px" BorderColor="#55AF0C" BorderStyle="None" Font-Size="Large" Width="250px" />
                                                <%--/asp:HyperLink>--%>
                                                <br /><br />
                                            </div>
                                        <%--<div class="form-floating mb-3">--%>                                                <%--<input class="form-control" id="inputPassword" type="password" placeholder="Password" />--%>                                               <%-- <label for="inputPassword">Password</label>
                                            </div>--%>                                        <%-- <div class="form-check mb-3">
                                                <input class="form-check-input" id="inputRememberPassword" type="checkbox" value="" />
                                                <label class="form-check-label" for="inputRememberPassword">Remember Password</label>
                                            </div>--%>
                                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                                <asp:Label ID="lbError" runat="server"></asp:Label>
                                            </div>
                                        <%-- </form>--%>
                                    </div>
                                    <div class="card-footer text-center py-3">
                                        <%--<div class="small"><a href="register.html">About </a></div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
            <div id="layoutAuthentication_footer">
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; TooGubKhao 2024</div>
                            <%--    <div>
                                <a href="#">Privacy Policy</a>
                                &middot;
                                <a href="#">Terms &amp; Conditions</a>
                            </div>--%>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
      <script src="Assets/js/bootstrap.bundle.min.js"></script>
      <script src="Assets/js/scripts.js"></script>
         <script src="liffApp.js"></script>
    </form>
</body>
</html>
