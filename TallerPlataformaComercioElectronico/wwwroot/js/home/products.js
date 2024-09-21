var tabladata;
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#productImage')
                .attr('src', e.target.result)
                .width(200)
                .height(198);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

$(document).ready(function () {
    tabladata = $('#tabla').DataTable({
        responsive: true,
        "ajax": {
            "url": '/Home/GetProductsWithIncludes',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "description" },
            { "data": "brand.description" },
            { "data": "category.description" },
            { "data": "price" },
            { "data": "stock" },
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
    $("#productImage").attr({ "src": "" });
    $("#Description").val("");

    $("#BrandId").val("");
    $("#CategoryId").val("");

    $("#Price").val("");
    $("#Stock").val("");

    if (json != null) {
        console.log(json)
        $("#Id").val(json.id);
        $("#productImage").attr({ "src": "data:image/" + json.extension + ";base64," + json.base64 });
        $("#Description").val(json.description);

        $("#BrandId").val(json.brandId);
        $("#CategoryId").val(json.categoryId);

        $("#Price").val(json.price);
        $("#Stock").val(json.stock);
    }

    $('#FormModal').modal('show');
}

$(document).on('click', '.btn-eliminar', function (event) {
    if (confirm('¿Esta seguro de eliminar el producto?')) {
        var json = $(this).data("informacion")
        let formData = { id: json.id }
        jQuery.ajax({
            url: '/Home/DeleteProduct',
            type: "POST",
            data: formData,
            success: function (data) {

                if (data.result) {
                    tabladata.ajax.reload();
                } else {
                    alert("No se pudo eliminar")
                }
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
});

$(document).on('click', '#btnSubmit', function (event) {

    event.preventDefault();

    var imageFile = ($("#imgproducto"))[0].files[0];
    var product = {
        Id: $("#Id").val(),
        Description: $("#Description").val(),
        BrandId: $("#BrandId").val(),
        CategoryId: $("#CategoryId").val(),
        Price: $("#Price").val(),
        Stock: $("#Stock").val(),
        RutaImagen: ""
    }

    var request = new FormData();
    request.append("imageFile", imageFile);
    request.append("oproduct", JSON.stringify(product));

    $.ajax({
        url: "/Home/SaveProduct",
        type: "POST",
        data: request,
        processData: false,
        contentType: false,
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

$.fn.inputFilter = function (inputFilter) {
    return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
        if (inputFilter(this.value)) {
            this.oldValue = this.value;
            this.oldSelectionStart = this.selectionStart;
            this.oldSelectionEnd = this.selectionEnd;
        } else if (this.hasOwnProperty("oldValue")) {
            this.value = this.oldValue;
            this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
        } else {
            this.value = "";
        }
    });
};

$("#txtstock").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});

$("#txtprecio").inputFilter(function (value) {
    return /^-?\d*[.]?\d{0,2}$/.test(value);
});
