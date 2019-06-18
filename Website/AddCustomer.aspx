<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddCustomer.aspx.cs" Inherits="Website.AddCustomer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Add A Customer</h5>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="inputColor">Customer Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputCustomer" placeholder="Customer name" required />
                        </div>
                        
                        <div class="form-group">
                            <label for="inputColor">Customer Password</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputPassword" type="password" required />
                        </div>
                        
                        <div class="form-group">
                            <label for="inputColor">VIP</label>
                            <asp:CheckBox runat="server" CssClass="form-control" ID="chkVIP" placeholder="Enter color" required />
                        </div>
                        
                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Save changes" OnClick="addCarBtn_Click" />

                </div>
            </div>
        </div>

    </div>
</asp:Content>
