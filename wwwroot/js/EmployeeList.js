var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({ // This DataTable was Added within Javascript Link "https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"
        "ajax": {
            "url": "/api/employee", // Same Name refrenced in Employee Controller
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "15%" }, // First Name Has Always to be lower-cases so instead of Name --> name is used 
            { "data": "team", "width": "10%" },
            { "data": "position", "width": "10%" },
            { "data": "branch", "width": "5%" },
            { "data": "email", "width": "10%" },
            { "data": "telphone", "width": "10%" },
            { "data": "address", "width": "10%" },
            {
                "data": "id", // Employee ID
                "render": function (data) { // The Two Options : DELETE & EDIT
                    return `<div class="text-center">
                        <a href="/EmployeeList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/employee?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "50%"
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
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}