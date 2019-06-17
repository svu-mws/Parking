<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RegisteredCars.aspx.cs" Inherits="Website.ResgisteredCars" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Remove A Car</h2>
        <table class="shadow cars-table table table-hover">
            <thead class="thead-light">
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">ID</th>
                    <th scope="col">City</th>
                    <th scope="col">Company</th>
                    <th scope="col">ArrivalTime</th>
                    <th scope="col">LeavingTime</th>
                    <th scope="col">ParkID</th>
                    <th scope="col">Manage</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <script>
        $(document).ready(function () {

            $.ajax({
                url: "api/cars", success: function (result) {
                    console.log(result);
                    let html = result.map((elem, index) => `<tr>
                                    <th scope="row">${index} </th>
                                    <td>${getContent(elem,"ID")}</td>
                                    <td>${getContent(elem,"City")}</td>
                                    <td>${getContent(elem,"Company")}</td>
                                    <td>${getContent(elem,"ArrivalTime")}</td>
                                    <td>${getContent(elem,"LeavingTime")}</td>
                                    <td>${getContent(elem,"ParkID")}</td>
                                    <td><button data-id=${getContent(elem,"ID")} type="button" class="btn-remove btn btn-danger">&times;</button></td>
                                </tr>`);
                    $(".cars-table tbody").append(html);
                    $('.btn-remove').click((e) => {
                        let carID = $(e.currentTarget).data('id');
                        $.ajax({
                            url: `api/cars/${carID}`,
                            type: 'DELETE',
                            success: (result) => {
                                console.log(result);
                                // if success 
                                location.reload();
                            },
                            error: e => alert(e.responseJSON.Message)
                        });
                    });

                }
            });
        });
    </script>
</asp:Content>
