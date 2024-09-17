$(document).ready(function () {
    obtenerCantidad();
})

function obtenerCantidad() {
    jQuery.ajax({
        url: '/Store/GetShoppingCartsQuantity',
        type: "GET",
        data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $(".contador-carrito").text(data.response);
        },
        error: function (error) {
            console.log(error)
        }
    });
}

$(document).on('click', '.btn-agregar-carrito', function (event) {
    let formData = {
        productId: $(this).data("productid")
    }

    jQuery.ajax({
        url: '/Store/InsertShoppingCart',
        type: "POST",
        data: formData,
        success: function (data) {
            var actual = parseInt($(".contador-carrito").text());
            if (data.respuesta != 0) {
                actual = actual + 1;
                $(".contador-carrito").text(actual);
                $('#toast-carrito').toast('show');
            }
        },
        error: function (error) {
            console.log(error)
        }
    });
});
