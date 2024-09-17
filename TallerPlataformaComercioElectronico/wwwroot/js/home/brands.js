var tabladata;
$(document).ready(function () {
    tabladata = $('#tabla').DataTable({
        responsive: true,
        "ajax": {
            "url": '/Home/GetBrands',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "description" },
            {
                "data": "id", "render": function (data, type, row, meta) {

                    return $("<button>").addClass("btn btn-primary btn-editar btn-sm").append(
                        $("<i>").addClass("fas fa-pen")
                    ).attr({ "data-informacion": JSON.stringify(row) })[0].outerHTML
                        +
                        $("<button>").addClass("btn btn-danger btn-eliminar btn-sm ms-2").append(
                            $("<i>").addClass("fas fa-trash")
                        ).attr({ "data-informacion": JSON.stringify(row) })[0].outerHTML;

                },
                "orderable": false,
                "searchable": false,
                "width": "120px"
            }

        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        }
    });
});

$(document).on('click', '.btn-editar', function (event) {
    var json = $(this).data("informacion")
    abrirModal(json)
});

function abrirModal(json) {
    $("#Id").val(0);
    $("#Description").val("");

    if (json != null) {
        $("#Id").val(json.id);
        $("#Description").val(json.description);
    }
    $('#FormModal').modal('show');
}

$(document).on('click', '.btn-eliminar', function (event) {
    var json = $(this).data("informacion")
    let formData = {
        id: json.id
    }

    $.ajax({
        url: "/Home/DeleteBrand",
        type: "POST",
        data: formData,
        success: function (response) {
            if (response.result) {
                tabladata.ajax.reload();
                $('#FormModal').modal('hide');
            } else {
                alert("No se pudo eliminar")
            }
        },
        error: function (request, status, error) {
            console.log(error)
        }
    });

});

$(document).on('click', '#btnSubmit', function (event) {

    event.preventDefault();

    let formData = {
        Id: $("#Id").val(),
        Description: $("#Description").val()
    }

    $.ajax({
        url: "/Home/SaveBrand",
        type: "POST",
        data: formData,
        success: function (response) {
            if (response.result) {
                tabladata.ajax.reload();
                $('#FormModal').modal('hide');
            } else {
                alert("No se pudo guardar los cambios")
            }
        },
        error: function (request, status, error) {
            console.log(error)
        }
    });
});
