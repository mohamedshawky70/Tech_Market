var DataTable;
$(document).ready(function () {
    loadData();
});
function loadData() {
    DataTable = $("#myTable").DataTable({
        "ajax": {
            "url": '/Admin/Order/GetData'
        },
        "columns": [  //array
            { "data": "id" },
            { "data": "name" },
            { "data": "email" },  //small
            { "data": "phone" },
            { "data": "orderDate" },
            { "data": "orderStatus" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a href="/Admin/Order/Details/${data}" class="btn btn-info"></i> Details</a>
                                    
                           `
                }
            },
        ]
    });
}
