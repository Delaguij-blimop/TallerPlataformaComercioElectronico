function zeroFill(number, width) {
    width -= number.toString().length;
    if (width > 0) {
        return new Array(width + (/\./.test(number) ? 2 : 1)).join('0') + number;
    }
    return number + ""; // always return a string
}

function formatDate(date) {

    const monthNames = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];

    var d = new Date(date),
        month = (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return day + ' de ' + monthNames[month] + ', ' + year;
}

$(document).ready(function () {
    $(".btn-ver-categoria").hide();
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
                                        $("<button>").addClass("btn btn-outline-secondary btn-restar rounded-0").append($("<i>").addClass("fas fa-minus")).attr({ "type": "button" }).data("informacionRestar", { _shoppingCartId: item.id, _productId: item.product.id }),
                                        $("<input>").addClass("form-control input-cantidad p-1 text-center rounded-0").css({ "width": "40px" }).attr({ "disabled": "disabled" }).val(item.quantity).data("price", item.product.price).data("productId", item.product.id),
                                        $("<button>").addClass("btn btn-outline-secondary btn-sumar rounded-0").append($("<i>").addClass("fas fa-plus")).attr({ "type": "button" }).data("informacionSumar", { _shoppingCartId: item.id, _productId: item.product.id })
                                    )
                                ),
                                $("<div>").addClass("col-1").append(
                                    $("<button>").addClass("btn btn-outline-danger btn-eliminar").append($("<i>").addClass("far fa-trash-alt")).data("informacion", { _shoppingCartId: item.id, _productId: item.product.id }),
                                )
                            )
                        )
                    ).appendTo("#productos-seleccionados");
                })
                getTotalAmount();
                getProductsQuantity();
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $.LoadingOverlay("show");
        },
    });
    GetCountries();
})

$(document).on('click', '.btn-sumar', function (event) {
    var div = $(this).parent("div.controles");
    var input = $(div).find("input.input-cantidad");
    var cantidad = parseInt($(input).val()) + 1;
    $(input).val(cantidad);

    var json = $(this).data("informacionSumar");
    let formData = {
        shoppingCartId: json._shoppingCartId,
        quantity: cantidad
    }

    jQuery.ajax({
        url: '/Store/UpdateProductQuantity',
        type: "POST",
        data: formData,
        success: function (data) {
            if (data.result) {
                getTotalAmount()
            }
        },
        error: function (error) {
            console.log(error)
        }
    });

});

$(document).on('click', '.btn-restar', function (event) {
    var div = $(this).parent("div.controles");
    var input = $(div).find("input.input-cantidad");
    var cantidad = parseInt($(input).val()) - 1;

    if (cantidad >= 1) {
        $(input).val(cantidad);

        var json = $(this).data("informacionRestar");
        let formData = {
            shoppingCartId: json._shoppingCartId,
            quantity: cantidad
        }

        jQuery.ajax({
            url: '/Store/UpdateProductQuantity',
            type: "POST",
            data: formData,
            success: function (data) {
                if (data.result) {
                    getTotalAmount()
                }
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
});

$(document).on('click', '.btn-eliminar', function (event) {
    var json = $(this).data("informacion");
    var card_producto = $(this).parents("div.card-producto");

    let formData = {
        shoppingCartId: json._shoppingCartId
    }

    jQuery.ajax({
        url: '/Store/DeleteProductFromShoppingCart',
        type: "POST",
        data: formData,
        success: function (data) {
            if (data.result) {
                card_producto.remove();
                getTotalAmount();
                getProductsQuantity();
                obtenerCantidad();
            } else {
                $("#mensaje-error").text("No se pudo eliminar");
                $('#toast-alerta').toast('show');
            }
        },
        error: function (error) {
            console.log(error)
        }
    });

})

function getTotalAmount() {
    var total = 0;
    $("input.input-cantidad").each(function (index) {
        var precio = parseFloat($(this).val()) * parseFloat($(this).data("price"));
        total = total + precio;
    });
    $("#totalPagar").text("$ " + total.toString());
}

function getProductsQuantity() {
    $("#cantidad-articulos").text(" " + $("#productos-seleccionados > div.card").length.toString() + " ");

    if ($("#productos-seleccionados > div.card").length == 0) {
        $("#btnConfirmarCompra").prop("disabled", true);
    }
}

$("#btnConfirmarCompra").on("click", function (e) {

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
        Detail: detalle
    }

    jQuery.ajax({
        url: '/Store/GenerateOrder',
        type: "POST",
        data: request,
        success: function (data) {
            if (data.result) {
                Swal.fire({
                    icon: "success",
                    title: "Compra Generada",
                    text: "Realiza el pago para completar el proceso",
                    showConfirmButton: false,
                    timer: 5000
                }).then((value) => {
                    $("#mdprocesopago").modal("show");
                    $("#procesoPagoModalLabel").text("Procesar Pago - Orden N° " + zeroFill(data.order.id, 6));
                    $("#totalaPagar").text("$ " + data.order.totalAmount);
                    $("#btnProcesarPago").data("informacionPago", { order: data.order })
                    $("#mdprocesopago").on("hidden.bs.modal", function () {
                        window.location.href = "/Store/ShoppingCart"
                    });
                });
            } else {
                Swal.fire({
                    icon: "warning",
                    title: "Lo sentimos",
                    text: "No se pudo completar la compra",
                    showConfirmButton: false,
                    timer: 3000
                });
            }
        },
        error: function (error) {
            console.log(error)
        }
    });
})


