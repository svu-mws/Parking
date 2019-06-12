<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Parking Website</h1>
        <p class="lead">Welcome ^_^</p>
    </div>

    <div class="row">
        <div class="col-md-12" style="margin: 10px">
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addCarModal">Add Car »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#deleteCarModal">Delete a car »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#freePositionModal">Free Positions »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#carPositionModal">Car position »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#nearestPositionModal">Nearest Position »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#vipModal">VIP »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#registeredCarModal">Registered Car »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#vipBillModal">Bill (VIP) »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#nonVipBillModal">Bill (Non VIP) »</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#mapModal">Map »</button>

        </div>
    </div>

    <!-- Add Car Modal -->
    <div class="modal fade" id="addCarModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Add a car</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="inputCity">City</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputCity" placeholder="Enter city"/>
                        </div>
                        <div class="form-group">
                            <label for="inputCompany">Company</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputCompany" placeholder="Enter company"/>
                        </div>
                        <div class="form-group">
                            <label for="inputColor">Color</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputColor" placeholder="Enter color"/>
                        </div>
                        <div class="form-group">
                            <label class="form-check-label" for="dateArrival">Arrival time</label>
                            <div class="input-group date" data-target-input="nearest">
                                <asp:TextBox runat="server" CssClass="form-control datetimepicker-input" ID="inputArrival" data-target="#inputArrival"/>

                                <div class="input-group-append" data-target="#dateArrival" data-toggle="datetimepicker">
                                    <div class="input-group-text">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="form-check-label" for="dateLeaving">Leaving time</label>
                            <div class="input-group date" id="dateLeaving" data-target-input="nearest">
                                <asp:TextBox runat="server" CssClass="form-control datetimepicker-input" ID="inputLeaving" data-target="#dateLeaving"/>
                                
                                <div class="input-group-append" data-target="#dateLeaving" data-toggle="datetimepicker">
                                    <div class="input-group-text">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </form>
                    <script type="text/javascript">
                        $(function() {
                            $('.date').datetimepicker();
                        });
                    </script>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Save changes" OnClick="addCarBtn_Click"/>

                </div>
            </div>
        </div>
    </div>

</asp:Content>