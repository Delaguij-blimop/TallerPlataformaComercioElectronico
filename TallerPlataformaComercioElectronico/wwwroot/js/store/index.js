$(".btn-ver-categoria").click(function () {
    jQuery.ajax({
        url: '/Store/GetCategories',
        type: "GET",
        data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $(".row-categoria").html("");
            $(".modal-body").LoadingOverlay("hide");
            if (data.data != null) {
                $("<div>").addClass("col-4").append(
                    $("<button>").addClass("btn btn-outline-primary btn-categoria m-1 w-100").text("Ver Todos").attr({ "onclick": "GetProducts(0)" })
                ).appendTo(".row-categoria")

                $.each(data.data, function (i, item) {
                    $("<div>").addClass("col-4").append(
                        $("<button>").addClass("btn btn-outline-primary btn-categoria m-1 w-100").text(item.description).attr({ "onclick": "GetProducts(" + item.id + ")" })
                    ).appendTo(".row-categoria")
                });
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $(".modal-body").LoadingOverlay("show");
        }
    });
    $('#exampleModal').modal('show');
});

$(document).ready(function () {
    GetProducts(0);
})

$(document).on('click', '.btn-detalle', function (event) {
    var json = $(this).data("elemento")
    window.location.href = "/Store/ProductDetail" + "?productId=" + json.id;
});

$(document).on('click', '.btn-categoria', function (event) {
    $('#exampleModal').modal('hide');
});

function GetProducts(_categoryId) {

    let formData = {
        categoryId: _categoryId
    }

    jQuery.ajax({
        url: '/Store/GetProductsByCategory',
        type: "POST",
        data: formData,
        success: function (data) {
            $("#catalogo-productos").html("");

            $("#catalogo-productos").LoadingOverlay("hide");
            if (data.data != null) {
                $.each(data.data, function (i, item) {
                    //catalogo-productos
                    $("<div>").addClass("col mb-5").append(
                        $("<div>").addClass("card h-100").append(
                            $("<img>").addClass("card-img-top").attr({ "src": "data:image/" + item.extension + ";base64," + item.base64 }),
                            //Product details
                            $("<div>").addClass("card-body p-4").append(
                                $("<div>").addClass("text-center").append(
                                    $("<h5>").addClass("fw-bolder").text(item.description),
                                    "$ " + item.price
                                )
                            ),
                            //Product actions
                            $("<div>").addClass("card-footer p-4 pt-0 border-top-0 bg-transparent").append(
                                $("<div>").addClass("d-grid d-md-grid gap-2 d-md-block align-items-center text-center").append(
                                    $("<button>").addClass("btn btn-outline-dark mt-auto btn-detalle").text("Ver Detalle").attr({ "data-elemento": JSON.stringify(item) }),
                                    $("<button>").addClass("btn btn-outline-dark mt-auto btn-agregar-carrito").data("productId", item.id).text("Agregar al carrito")
                                )
                            )
                        )
                    ).appendTo("#catalogo-productos");
                });
            }
        },
        error: function (error) {
            console.log(error)
        }
    });
}
