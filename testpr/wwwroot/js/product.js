var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
        dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns":[
            { data: "name", "width": "15%" },
            { data: "isbn", "width": "15%" },
            { data: "price", "width": "15%" },
            { data: "author", "width":"15%"},
            { data: "category.name", "width": "15%" },
            {
                data: "id",
                "render": function (data) {
                    return`
                    <a class="btn btn-primary mx-2" href="/Admin/Product/Upsert?id=${data}"><i class="bi bi-pencil-square"></i> Edit </a>
                    <a class="btn btn-secondary mx-2 btn btn-d" > <i class="bi bi-trash"></i> Delete </a>    
                `
                },"width" : "15.99%"
            },
        ]
    });
}