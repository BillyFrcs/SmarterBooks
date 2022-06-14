var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "name", "width": "50%"
            },
            {
                "data": "author", "width": "50%"
            },
            {
                "data": "isbn", "width": "50%"
            },
            {
                "data": "id",
                "render": function(data) {
                    return `
                    <div class="text-center">  
                     <a href="/Books/Edit?id=${data}" class='btn btn-success text-white' style='cursor: pointer; width: 100px;'>
                       Edit
                     </a>
                     &nbsp;
                     <a class='btn btn-danger text-white' style='cursor: pointer; width: 100px; onClick=Delete('/api/book?id='+${data})'>
                       Delete
                     </a>
                    </div>`;
                },
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found" 
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure want to delete?",
        text: "You will lose your data!",
        icon: "warning",
        dangerMode: true
    }).then((deleted) => {
        if (deleted) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function(data) {
                    if (data.success) {
                        toastr.success(message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(message);
                    }
                }
            });
        }
    });
}