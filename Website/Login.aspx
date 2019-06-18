<%@ Page Title="Login" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Website.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Login</h5>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="inputUsername">username</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputUsername" placeholder="user name" required />
                        </div>
                        <div class="form-group">
                            <label for="inputPassword">password</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputPassword" placeholder="password" type="password" required />
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Login" OnClick="Login_Click" />
                    <asp:Label runat="server" Text="" ID="txtResult" ForeColor="Red" readonly />

                </div>
            </div>
        </div>

    </div>
</asp:Content>
