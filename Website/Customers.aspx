<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AllCustomers.aspx.cs" Inherits="Website.AllCustomers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Customers</h2>
        <table class="shadow cars-table table table-hover">
            <thead class="thead-light">
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">ID</th>
                    <th scope="col">Name</th>
                    <th scope="col">VIP</th>
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
                url: "api/customer", success: function (result) {
                    console.log(result);
                    let html = result.map((elem, index) => {
                        
                    let ID = getContent(elem,"ID");
                    let Name = getContent(elem,"Name");
                    let Vip = getContent(elem,"Vip");return `<tr>
                                    <th scope="row">${index} </th>
                                    <td>${ID}</td>
                                    <td>${Name}</td>
                                    <td>  <input class="form-check-input" type="checkbox" ${Vip===1?'checked':''} disabled></td>
                                    <td>  <button data-id=${ID} type="button" class="btn-remove btn btn-danger"><i class="fas fa-times-circle"></i></button></td>
                                </tr>`                    
                    });
                    $(".cars-table tbody").append(html);
                    $('.btn-remove').click((e) => {
                        let carID = $(e.currentTarget).data('id');
                        $.ajax({
                            url: `api/customer/${carID}`,
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
