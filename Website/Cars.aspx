<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Cars.aspx.cs" Inherits="Website.Cars" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Cars</h2>
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
                    let html = result.map((elem, index) => {
                        
                    let ID = getContent(elem,"ID");
                    let City = getContent(elem,"City");
                    let Company = getContent(elem,"Company");
                    let ArrivalTime = getContent(elem,"ArrivalTime");
                    let LeavingTime = getContent(elem,"LeavingTime");
                    let ParkID = getContent(elem,"ParkID");
                    return `<tr>
                                    <th scope="row">${index} </th>
                                    <td>${ID}</td>
                                    <td>${City}</td>
                                    <td>${Company}</td>
                                    <td>${ArrivalTime}</td>
                                    <td>${LeavingTime}</td>
                                    <td>${ParkID}</td>
                                    <td>
                                        <button data-id=${ID} type="button" class="btn-remove btn btn-danger"><i class="fas fa-times-circle"></i></button>
                                        ${LeavingTime === null ?`<button data-id=${ID} data-pid=${ParkID} type="button" class="btn-checkout btn btn-success"><i class="fas fa-sign-out-alt"></i></button>`:''}
                                    </td>
                                </tr>`
                                                    }
);
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
                    $('.btn-checkout').click((e) => {
                        let parkID = $(e.currentTarget).data('pid');
                        $.ajax({
                            url: `api/cars/${parkID}`,
                            type: 'PUT',
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