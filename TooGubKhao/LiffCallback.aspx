<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LiffCallback.aspx.vb" Inherits="TooGubKhao.LiffCallback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <script src="https://static.line-scdn.net/liff/edge/2/sdk.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            initializeLiff();
        };

        function initializeLiff() {
            liff.init({
                liffId: 'YOUR_LIFF_ID' // Replace with your LIFF ID
            }).then(() => {
                if (!liff.isLoggedIn()) {
                    liff.login();
                }
            }).catch((err) => {
                console.error('LIFF initialization failed', err);
            });
        }

        function getUserProfile() {
            liff.getProfile().then((profile) => {
                document.getElementById('userId').innerText = profile.userId;
                document.getElementById('displayName').innerText = profile.displayName;
                document.getElementById('pictureUrl').src = profile.pictureUrl;
                 document.getElementById('Text1').innerText = profile.userId
            }).catch((err) => {
                console.error('Error getting profile', err);
            });
        }

        function sendToServer() {
            var userId = document.getElementById('userId').innerText;
            var displayName = document.getElementById('displayName').innerText;
            var pictureUrl = document.getElementById('pictureUrl').src;

            // AJAX request to send data to server
            var xhr = new XMLHttpRequest();
            xhr.open('POST', 'Default.aspx/SaveUserProfile', true);
            xhr.setRequestHeader('Content-Type', 'application/json');
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    console.log('Data sent successfully');
                }
            };
            xhr.send(JSON.stringify({ userId: userId, displayName: displayName, pictureUrl: pictureUrl }));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          
            <button onclick="getUserProfile()">Get User Profile</button>
            <h3>User ID: <span id="userId"></span></h3>
        <h3>Display Name: <span id="displayName"></span></h3>
        <img id="pictureUrl" src="" alt="Profile Picture" style="width: 100px; height: 100px;" />
        </div>
    </form>
</body>
</html>
