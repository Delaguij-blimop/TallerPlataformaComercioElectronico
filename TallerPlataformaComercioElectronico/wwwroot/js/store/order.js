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
        url: '/Store/GetOrders',
        type: "GET",
        data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.list != null) {
                $.each(data.list, function (i, v) {

                    var header = $("<div>").addClass("list-item-grouper__header").append(
                        $("<h2>").addClass("list-item-grouper__text").append(
                            $("<span>").addClass("bf-ui-rich-text bf-ui-rich-text--bold").text("Orden N° " + zeroFill(v.id, 6)),
                            $("<p>").addClass("list-item__description").append(
                                $("<span>").addClass("bf-ui-rich-text").text("(" + formatDate(v.date) + ")")
                            )
                        )
                    )

                    if (v.payments === null || v.payments.length == 0) {
                        header.append(
                            $("<div>").addClass("list-item__data").append(
                                $("<button>").addClass("andes-button bf-ui-button andes-button--medium andes-button--loud btn-pagar")
                                    .text(" Pagar")
                                    .attr({ "type": "button" })
                                    .data("informacionOrden", { order: v })
                            )
                        )
                    }

                    var article = $("<article>").addClass("list-item-grouper").attr("Id", "list_item_grouper_" + v.id).append(
                        header
                    );


                    $.each(v.detail, function (x, dc) {
                        var articledetail = $("<div>").addClass("list-item").append(
                            $("<div>").addClass("list-item__product").append(
                                $("<h3>").addClass("list-item__image").append(
                                    $("<img>").addClass("bf-ui-image bf-ui-image--default")
                                        .attr({ "src": "data:image/" + dc.product.extension + ";base64," + dc.product.base64, "decoding": "async", "width": "50" })
                                ),
                                $("<div>").addClass("list-item__data").append(
                                    $("<span>").addClass("bf-ui-rich-text").text(dc.product.description),
                                    $("<hr>").addClass("hr-m0"),
                                    $("<p>").addClass("list-item__description").append(
                                        $("<span>").addClass("bf-ui-rich-text").text("Cantidad: " + dc.quantity)
                                    ),
                                    $("<p>").addClass("list-item__description").append(
                                        $("<span>").addClass("bf-ui-rich-text").text("Importe: $ " + dc.amount)
                                    )
                                )
                            )
                        );
                        article.append(articledetail);
                    });

                    var totales = $("<div>").addClass("list-item__product").append(
                        $("<div>").addClass("list-item__data").append(
                            $("<p>").addClass("list-item__description").append(
                                $("<span>").addClass("bf-ui-rich-text").text("Cantidad de productos: " + v.totalQuantity)
                            )
                        ), 
                        $("<div>").addClass("list-item__data").append(
                            $("<p>").addClass("list-item__description").append(
                                $("<span>").addClass("bf-ui-rich-text").text("Importe Total: $ " + v.totalAmount)
                            )
                        )
                    )

                    var estado = $("<span>").text((v.payments === null || v.payments.length == 0 ? 'Pendiente de pago' : 'Pagada'))
                    if (v.payments != null && v.payments.length > 0) {
                        estado.addClass("bf-ui-rich-text bf-ui-rich-text--success")
                    }
                    else {
                        estado.addClass("bf-ui-rich-text bf-ui-rich-text--pending")
                    }
                    totales.append(
                        $("<div>").addClass("list-item__data").append(
                            $("<p>").addClass("list-item__description").append(
                                $("<span>").text("Estado: "),
                                estado
                            )
                        )
                    )
                    article.append(totales);

                    $("#listItemContainer").append(article);
                });
            }
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        },
        beforeSend: function () {
            $(".modal-body").LoadingOverlay("show");
        },
    });
})

$(document).on('click', '.btn-pagar', function (event) {

    var json = $(this).data("informacionOrden");

    $("#mdprocesopago").modal("show");
    $(".modal-body").LoadingOverlay("hide");
    $("#procesoPagoModalLabel").text("Procesar Pago - Orden N° " + zeroFill(json.order.id, 6));
    $("#totalaPagar").text("$ " + json.order.totalAmount);
    $("#btnProcesarPago").data("informacionPago", { order: json.order })

});

$("#mdprocesopago").on("hidden.bs.modal", function () {
    window.location.href = "/Store/Order"
});