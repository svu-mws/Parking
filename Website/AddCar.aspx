<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddCar.aspx.cs" Inherits="Website.AddCar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" xmlns="http://www.w3.org/1999/html">
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
                        <div class="form-group">
                            <label for="inputColor">Register ? </label>
                            <asp:CheckBox runat="server" CssClass="form-control" ID="chkRegistered" required />
                        </div>

                        <div class="form-group">
                            <label class="form-check-label" for="inputPositon">Position</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputPosition" placeholder="Nearest Position" />
                            <div id="btnNearest" data-toggle="modal" data-target="#bookModal" class="btn btn-primary btn-success">Choose Positions</div>
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Save changes" OnClick="addCarBtn_Click" />

                </div>
            </div>
        </div>


        <!-- Modal -->
        <div class="modal fade" id="bookModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <h2>Free Positions</h2>
                        <table id="freePositions" class="display table-sm table-striped table-bordered shadow" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Floor</th>
                                    <th>Department</th>
                                    <th>Place</th>
                                    <th>Book</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>

        <script>
            $(document).ready(function () {

                $.ajax({
                    url: "api/NearestPositions", success: function (result) {
                        console.log(result);
                        let id = getContent(result, "ID");
                        if (id !== '')
                            $("#MainContent_inputPosition").val(id);

                    }
                });

                var table = $('#freePositions').DataTable({
                    orderCellsTop: true,
                    fixedHeader: true,
                });
                $('#freePositions').on('draw.dt', function () {
                    let $btn = $('.btn-book');
                    $btn.off('click').on('click', (e) => {
                        let positionID = $(e.currentTarget).data('id');
                        console.log(positionID);
                        $("#MainContent_inputPosition").val(positionID);
                        $('#bookModal').modal('toggle');
                    });
                });
                let header = $('#freePositions thead tr').clone(true);
                header.find("th").removeClass("sorting_asc sorting_des sorting");
                header.appendTo('#freePositions thead');
                $('#freePositions thead tr:eq(1) th:not(.no-filter)').each(function (i) {
                    var title = $(this).text();
                    $(this).html('<input type="text" class="form-control" placeholder="Search ' + title + '" />');

                    $('input', this).on('keyup change', function () {
                        console.warn(typeof table.column(i).search());
                        console.warn(typeof this.value);
                        if (table.column(i).search() !== this.value) {
                            table
                                .column(i)
                                .search(this.value)
                                .draw();
                        }
                    });
                });
                table.order().draw;

                $.ajax({
                    url: "api/positions", success: function (result) {
                        console.log(result);
                        result.map(elem => table.row.add([getContent(elem, "ID"), getContent(elem, "Floor"), getContent(elem, "Department"), getContent(elem, "Place"), `<td><button data-id=${getContent(elem, "ID")} type="button" class="btn-book btn btn-sm btn-success">Book</button></td>`]));
                        table.draw();
                        // Setup - add a text input to each footer cell

                    }
                });
            });

        </script>
    </div>
</asp:Content>
