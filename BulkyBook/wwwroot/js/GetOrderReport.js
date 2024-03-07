let datatable;

$(document).ready(function () {

    $('#searchButton').click(function (e) {
        e.preventDefault();
        var StartDate = $("#start-date").val();
        var EndDate = $("#end-date").val();

        if (StartDate === "") {
            Swal.fire("Error", "Please Enter Start Date", "error");
        }
        if (StartDate <= EndDate) {
            loadDataTable(StartDate, EndDate);
        } else {
            Swal.fire("Error", "Start date must be less than or equal to End date", "error");
        }
    });
});

function loadDataTable(StartDate, EndDate) { 
    if (datatable) {
        datatable.clear().draw();
        datatable.ajax.url('/Admin/Report/GetOrderReport?StartDate=' + StartDate + '&EndDate=' + EndDate).load();
        return;
    }
    datatable = $('#tblData').DataTable({
        "ajax": {
            url: '/Admin/Report/GetOrderReport?StartDate=' + StartDate + '&EndDate=' + EndDate,
            type: 'GET',
            dataType: 'json'
        },
        "columns": [
         
            { data: 'userName', "width": "15%" },
            { data: 'userPhoneNumber', "width": "15%" },
            { data: 'applicationUser.email', "width": "20%" },
            { data: 'orderStatus', "width": "20%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'orderDate',
                width: '20%',
                render: function (data, type, row) {
                    var date = new Date(data);
                    var day = date.getDate().toString().padStart(2, '0');
                    var month = (date.getMonth() + 1).toString().padStart(2, '0');
                    var year = date.getFullYear();
                    var formattedDate = day + ' - ' + month + ' - ' + year;
                    return formattedDate;
                }
            }
        ]
    });
}
