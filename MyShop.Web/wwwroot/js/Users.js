
$(document).ready(function () {
    loadData();
});


function loadData() {
    $('#myTable').DataTable({
        "ajax": {
            "url": '/Admin/Users/GetData'
        },
        "columns": [
            { "data": "name" },
            { "data": "email" },
            
            {
              
                "data": "id",
                "render": function (data, dataLock) { //date is id because it's the id last
                    const date_Time = new Date();
                
                    console.log(dataLock);
                    var x = 1;
                    if (dataLock == null || date_Time > dataLock) {
                        return
                        `<a href="/Admin/Users/LockUnLock/${data}" class="btn btn-success"> 
                        <i class="fas fa-lock-open"></i>
                        </a>`;
                    }
                    else {
                        return `<a href="/Admin/Users/LockUnLock/${data}" class="btn btn-danger"> 
                        <i class="bi bi-7-square-fill"></i>
                        </a>`;
                    }
                }
            }
        ]
    });
}

