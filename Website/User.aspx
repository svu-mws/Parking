<%@ Page Title="Dashboard" Language="C#" AutoEventWireup="true" MasterPageFile="~/UserSite.Master" CodeBehind="User.aspx.cs" Inherits="Website.User" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div>
        <h2>Your Cars</h2>
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
    <!-- Modal -->
        <div class="modal fade" id="billModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <h2>Bill:</h2><h2 id="billVal"></h2>
             
                    </div>
                </div>
            </div>
        </div>

    <script>
        $(document).ready(function () {
        var userID = parseInt($('#userID').text());
                        
            $.ajax({
                url: "api/cars", success: function (result) {
                    console.log(result);
                    result = result.filter(car=>car['<CustomerID>k__BackingField'] ===userID);
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
                                        <button data-id=${ID} type="button" class="btn-bill btn btn-danger">GET BILL</button>
                                    </td>
                                </tr>`
                                                    }
);
                    $(".cars-table tbody").append(html);
                    
                    $('.btn-bill').click((e) => {
                        var userID = $('#userID').text();
                        let carID = $(e.currentTarget).data('id');
                        console.log(userID,carID);
                        $('#billModal').modal('toggle');
/**
                        $.ajax({
                            url: `api/bill/${carID}`,
                            type: 'GET',
                            success: (result) => {
                                console.log(result);
                                // if success 
                                location.reload();
                            },
                            error: e => alert(e.responseJSON.Message)
                        });
**/
                    });
                }
            });
        });
    </script>
</asp:Content>
