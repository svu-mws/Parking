<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Website.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Add a car</h5>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <label for="inputUsername">username</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="inputUsername" placeholder="user name" required />
                            </div>
                            <div class="form-group">
                                <label for="inputPassword">password</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="inputPassword" placeholder="password" required />
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Login" OnClick="Login_Click"/>
                        <asp:Label runat="server" Text="TEST" ID="txtResult" ForeColor="Red" readonly/>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
