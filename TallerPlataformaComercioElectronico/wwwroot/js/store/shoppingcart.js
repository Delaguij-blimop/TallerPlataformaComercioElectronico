$(document).ready(function () {
    jQuery.ajax({
        url: '/Store/GetShoppingCarts',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $.LoadingOverlay("hide");
            if (data.list != null) {
                $.each(data.list, function (i, item) {
                    $("<div>").addClass("card mb-2 card-producto").append(

                        $("<div>").addClass("card-body").append(

                            $("<div>").addClass("row").append(
                                $("<div>").addClass("col-1").append(
                                    $("<img>").addClass("rounded").attr({ "src": "data:image/" + item.product.extension + ";base64," + item.product.base64, "width": "50" })
                                ),
                                $("<div>").addClass("col-7").append(
                                    $("<div>").addClass("ml-2").append(
                                        $("<span>").addClass("font-weight-bold d-block").text(item.product.brand.description),
                                        $("<span>").addClass("spec").text(item.product.description),
                                        $("<span>").addClass("float-end").text("Precio : $ " + item.product.price)
                                    )
                                ),
                                $("<div>").addClass("col-3").append(
                                    $("<div>").addClass("d-flex justify-content-end controles").append(
                                        $("<button>").addClass("btn btn-outline-secondary btn-restar rounded-0").append($("<i>").addClass("fas fa-minus")).attr({ "type": "button" }),
                                        $("<input>").addClass("form-control input-cantidad p-1 text-center rounded-0").css({ "width": "40px" }).attr({ "disabled": "disabled" }).val("1").data("price", item.product.price).data("productId", item.product.id),
                                        $("<button>").addClass("btn btn-outline-secondary btn-sumar rounded-0").append($("<i>").addClass("fas fa-plus")).attr({ "type": "button" })
                                    )
                                ),
                                $("<div>").addClass("col-1").append(
                                    $("<button>").addClass("btn btn-outline-danger btn-eliminar").append($("<i>").addClass("far fa-trash-alt")).data("informacion", { _shoppingCartId: item.id, _productId: item.product.id }),
                                )
                            )
                        )
                    ).appendTo("#productos-seleccionados");
                })
                obtenerPreciosPago();
                obtenerCantidadProductos();
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $.LoadingOverlay("show");
        },
    });
    ListarPaises();
})

$(document).on('click', '.btn-sumar', function (event) {
    var div = $(this).parent("div.controles");
    var input = $(div).find("input.input-cantidad");
    var cantidad = parseInt($(input).val()) + 1;
    $(input).val(cantidad);
    obtenerPreciosPago()
});

$(document).on('click', '.btn-restar', function (event) {
    var div = $(this).parent("div.controles");
    var input = $(div).find("input.input-cantidad");
    var cantidad = parseInt($(input).val()) - 1;
    if (cantidad >= 1) {
        $(input).val(cantidad);
    }
    obtenerPreciosPago()
});

$(document).on('click', '.btn-eliminar', function (event) {
    var json = $(this).data("informacion");
    var card_producto = $(this).parents("div.card-producto");

    let formData = {
        shoppingCartId: json._shoppingCartId,
        productId: json._productId
    }

    jQuery.ajax({
        url: '/Store/DeleteShoppingCart',
        type: "POST",
        data: formData,
        success: function (data) {
            if (data.resultado) {
                card_producto.remove();
                obtenerPreciosPago();
                obtenerCantidadProductos();
                obtenerCantidad();
            } else {
                alert("No se pudo eliminar")
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

})

function obtenerPreciosPago() {
    var total = 0;
    $("input.input-cantidad").each(function (index) {
        var precio = parseFloat($(this).val()) * parseFloat($(this).data("price"));
        total = total + precio;
    });
    $("#totalPagar").text("$ " + total.toString());
}

function obtenerCantidadProductos() {
    $("#cantidad-articulos").text(" " + $("#productos-seleccionados > div.card").length.toString() + " ");

    if ($("#productos-seleccionados > div.card").length == 0) {
        $("#btnProcesarPago").prop("disabled", true);
    }
}

function ListarPaises() {
    jQuery.ajax({
        url: '/Store/GetCountries',
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("<option>").attr({ "value": "00", "disabled": "disabled", "selected": "true" }).text("Seleccionar").appendTo("#cboPais");
            if (data.lista != null) {
                $.each(data.lista, function (i, v) {
                    $("<option>").attr({ "value": v.id }).text(v.description).appendTo("#cboPais");
                });
            }
            ListarEstados();
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
}

$("#cboPais").on("change", function () {
    ListarEstados();
});

function ListarEstados() {

    let formData = {
        countryId: $("#cboPais option:selected").val()
    }

    jQuery.ajax({
        url: '/Store/GetStates',
        type: "POST",
        data: formData,
        success: function (data) {
            $("#cboEstado").html("");
            $("<option>").attr({ "value": "00", "disabled": "disabled", "selected": "true" }).text("Seleccionar").appendTo("#cboEstado");
            if (data.lista != null) {
                $.each(data.lista, function (i, v) {
                    $("<option>").attr({ "value": v.id }).text(v.description).appendTo("#cboEstado");
                });
            }
            ListarCiudades();
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
}

$("#cboEstado").on("change", function () {
    ListarCiudades();
});

function ListarCiudades() {

    let formData = {
        stateId: $("#cboEstado option:selected").val()
    }

    jQuery.ajax({
        url: '/Store/GetCities',
        type: "POST",
        data: formData,
        success: function (data) {
            $("#cboCiudad").html("");
            $("<option>").attr({ "value": "00", "disabled": "disabled", "selected": "true" }).text("Seleccionar").appendTo("#cboCiudad");
            if (data.lista != null) {
                $.each(data.lista, function (i, v) {
                    $("<option>").attr({ "value": v.id }).text(v.description).appendTo("#cboCiudad");
                });
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
}

$("#btnProcesarPago").on("click", function (e) {
    $(".control-validar").removeClass("border border-danger");
    $(".control-validar").each(function (i) {
        if ($(this).is('input')) {
            if ($(this).val() == "") {
                $(this).addClass("border border-danger")
                falta_ingresar_datos = true;
            }
        } else if ($(this).is('select')) {
            if ($(this).children("option:selected").val() == "00") {
                $(this).addClass("border border-danger")
                falta_ingresar_datos = true;
            }
        }
    });

    if ($("#cboPais").val() == null) {
        $("#mensaje-error").text("Debe seleccionar un país");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#cboEstado").val() == null) {
        $("#mensaje-error").text("Debe seleccionar un estado");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#cboCiudad").val() == null) {
        $("#mensaje-error").text("Debe seleccionar una ciudad");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#txtDireccion").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar una dirección");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#txtContacto").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar un nombre de contacto");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#txtTelefono").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar un teléfono");
        $('#toast-alerta').toast('show');
        return;
    }
    $("#mdprocesopago").modal("show");
})

$("#btnConfirmarCompra").on("click", function (e) {

    var falta_ingresar_datos = false;

    $(".control-validar").removeClass("border border-danger");

    if ($("#trj_nombre").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar nombre del titular");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#trj_numero").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar número de la tarjeta");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#trj_vigencia").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar vigencia de la tarjeta");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#trj_cvv").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar CVV de la tarjeta");
        $('#toast-alerta').toast('show');
        return;
    }

    if (!falta_ingresar_datos) {
        var detalle = [];
        var total = 0;
        $("input.input-cantidad").each(function (index) {
            var precio = parseFloat($(this).val()) * parseFloat($(this).data("price"));
            detalle.push({
                ProductId: parseInt($(this).data("productId")),
                Quantity: parseInt($(this).val()),
                Amount: precio
            });
            total = total + precio;
        });

        var request = {
            TotalQuantity: $("#productos-seleccionados > div.card").length,
            TotalAmount: total,
            Contact: $("#txtContacto").val(),
            Phone: $("#txtTelefono").val(),
            BillingAddress: {
                Street: $("#txtDireccion").val(),
                PostalCode: $("#txtCodigoPostal").val(),
                CityId: $("#cboCiudad").val()
            },
            Detail: detalle
        }

        jQuery.ajax({
            url: '/Store/InsertOrder',
            type: "POST",
            data: request,
            success: function (data) {
                if (data.resultado) {
                    swal("Compra Realizada", "Pronto te informaremos la entrega de tu pedido", "success").then((value) => {
                        window.location.href = "/Store/Index"
                    });
                } else {
                    swal("Lo sentimos", "No se  pudo completar la compra", "warning");
                }
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
})
