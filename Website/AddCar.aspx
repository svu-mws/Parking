<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddCar.aspx.cs" Inherits="Website.AddCar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Add a car</h5>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="inputColor">Customer</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputCustomer" placeholder="Customer name" required />
                        </div>

                        <div class="form-group">
                            <label for="inputCity">City</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputCity" placeholder="Enter city" required />
                        </div>
                        <div class="form-group">
                            <label for="inputCompany">Company</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputCompany" placeholder="Enter company" required />
                        </div>
                        <div class="form-group">
                            <label for="inputColor">Color</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputColor" placeholder="Enter color" required />
                        </div>
                        <div class="form-group">
                            <label class="form-check-label" for="dateArrival">Arrival time</label>
                            <div class="input-group date" data-target-input="nearest">
                                <asp:TextBox runat="server" ID="inputArrival" CssClass="datetimepicker" required />

                            </div>
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
