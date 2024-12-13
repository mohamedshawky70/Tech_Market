


var DataTable;
$(document).ready(function () {
    loadData();
});
function loadData() {
    DataTable = $("#myTable").DataTable({
        "ajax": {
            "url": '/Admin/Product/GetData'
        },
        "columns": [  //array
            { "data": "name" },
            { "data": "description" },  //first letter small 
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return ` 
                    
                    <a href="/Admin/Product/Update/${data}" class="btn btn-primary"><i class="bi bi-pencil-square"></i> </a>
                    <a OnClick=DeleteItem("/Admin/Product/Delete/${data}") class="btn btn-danger"><i class="bi bi-trash3"></i> </a> 
                    
                    `
                }
            },
        ]
    });
}



function DeleteItem(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {            //yes, delete it
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {      /* لو حذف تمم شغل هذه الفنكشن*/
                    DataTable.ajax.reload();
                }
            })
            Swal.fire({  //لما تكلك
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });
}