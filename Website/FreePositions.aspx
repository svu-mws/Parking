<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FreePositions.aspx.cs" Inherits="Website.FreePositions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Free Positions</h2>
    <table id="freePositions" class="display table-sm table-striped table-bordered shadow" style="width: 100%">
        <thead>
            <tr>
                <th>ID</th>
                <th>Floor</th>
                <th>Department</th>
                <th>Place</th>
                <th class="no-filter">Booked</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>

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
                    <form>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email address</label>
                            <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Password</label>
                            <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {

            var table = $('#freePositions').DataTable({
                orderCellsTop: true,
                fixedHeader: true,
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
                    result.map(elem => table.row.add([getContent(elem,"ID"), getContent(elem,"Floor"), getContent(elem,"Department"), getContent(elem,"Place"), `<td><button data-id=${getContent(elem, "ID")} type="button" class="btn-book btn btn-sm btn-success">Book</button></td>`]));
                    table.draw();
                    // Setup - add a text input to each footer cell

                    $('.btn-book').click((e) => {
                    });

                }
            });


        });
    </script>
</asp:Content>
