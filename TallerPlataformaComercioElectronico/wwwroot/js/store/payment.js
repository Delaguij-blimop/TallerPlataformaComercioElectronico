// Selección de los campos de entrada
const inputTarjeta = document.getElementById("trj_numero");
const inputFecha = document.getElementById("trj_vigencia");
const inputCVV = document.getElementById("trj_cvv");

// Definición de las máscaras para formato de entrada
const mascaraNumero = "####-####-####-####";
const mascaraFecha = "##/##";
const mascaraCVV = "####";

// Arreglos para almacenar los valores ingresados
let TarjetaNumero = [];
let FechaNumero = [];
let cvvNumero = [];

// Manejo del campo de número de tarjeta
inputTarjeta.addEventListener("keydown", (e) => {
    if (e.key === "Tab") return; // Ignorar tecla Tab
    e.preventDefault();
    ingresoDatos(mascaraNumero, e.key, TarjetaNumero);
    inputTarjeta.value = TarjetaNumero.join(""); // Actualizar el campo con el formato
});

// Manejo del campo de fecha
inputFecha.addEventListener("keydown", (e) => {
    if (e.key === "Tab") return; // Ignorar tecla Tab
    e.preventDefault();
    ingresoDatos(mascaraFecha, e.key, FechaNumero);
    inputFecha.value = FechaNumero.join(""); // Actualizar el campo con el formato
});

// Manejo del campo de CVV
inputCVV.addEventListener("keydown", (e) => {
    if (e.key === "Tab") return; // Ignorar tecla Tab
    e.preventDefault();
    ingresoDatos(mascaraCVV, e.key, cvvNumero);
    inputCVV.value = cvvNumero.join(""); // Actualizar el campo con el formato
});

// Función para manejar la entrada de datos según la máscara
function ingresoDatos(mascara, key, arreglo) {
    const numeros = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    if (key === "Backspace" && arreglo.length > 0) {
        arreglo.pop(); // Eliminar el último carácter
        return;
    }

    if (numeros.includes(key) && arreglo.length + 1 <= mascara.length) {
        let textoActual = arreglo.join("");
        let textoFinal = textoActual + key;

        // Añadir el carácter y el separador de la máscara
        if (mascara[arreglo.length] === "-" || mascara[arreglo.length] === "/") {
            arreglo.push(mascara[arreglo.length], key);
        } else {
            arreglo.push(key);
        }

        // Validación específica para el campo de fecha
        if (mascara === "##/##") {
            let mes = parseInt(textoFinal.substring(0, 2));
            if (mes > 12) {
                arreglo.pop(); // Eliminar carácter si el mes es mayor a 12
            }
        }
    }
}

$(document).ready(function () {
    $("#datosPaypal").hide();
    GetCountries();
})

$("#btnProcesarPago").on("click", function (e) {
    var falta_ingresar_datos = false;

    $(".control-validar").removeClass("border border-danger");

    // IDs de los divs a validar
    const ids = ['#datosDireccion', '#datosTarjeta', '#datosPaypal'];

    // Itera sobre cada ID
    ids.forEach(id => {
        const contenedor = $(id);

        // Verifica si el div está visible
        if (contenedor.is(':visible')) {
            // Selecciona los inputs y selects dentro del div que tienen la clase control-validar
            contenedor.find('.control-validar').each(function () {
                if ($(this).is('input')) {
                    if ($(this).val() === "") {
                        $(this).addClass("border border-danger");
                        falta_ingresar_datos = true;
                    }
                } else if ($(this).is('select')) {
                    if ($(this).children("option:selected").val() === "00") {
                        $(this).addClass("border border-danger");
                        falta_ingresar_datos = true;
                    }
                }
            });
        }
    });

    if ($("#txtRazonSocial").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar un nombre o razón social");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#cboPais").val() == null || $("#cboPais").val().trim() == "") {
        $("#mensaje-error").text("Debe seleccionar un país");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#cboEstado").val() == null || $("#cboEstado").val() == null) {
        $("#mensaje-error").text("Debe seleccionar un estado");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#cboCiudad").val() == null || $("#cboCiudad").val() == null) {
        $("#mensaje-error").text("Debe seleccionar una ciudad");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#txtDireccion").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar una dirección");
        $('#toast-alerta').toast('show');
        return;
    } else if ($("#txtCodigoPostal").val().trim() == "") {
        $("#mensaje-error").text("Debe ingresar un código postal");
        $('#toast-alerta').toast('show');
        return;
    }

    if ($('input[name="paymentMethodType"]:checked').val() === '1') {
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
    } else if ($('input[name="paymentMethodType"]:checked').val() === '2') {
        if ($("#ppal_correo").val() == null) {
            $("#mensaje-error").text("Debe ingresar un correo para paypal");
            $('#toast-alerta').toast('show');
            return;
        }
    }

    if (!falta_ingresar_datos) {

        var json = $(this).data("informacionPago");

        var request = {
            Amount: json.order.totalAmount,
            Currency: "ARS",
            OrderId: json.order.id,
            CustomerId: json.order.userName,
            BillingAddress:
            {
                Name: $("#txtRazonSocial").val(),
                Street: $("#txtDireccion").val(),
                Country: $("#cboPais option:selected").text(),
                State: $("#cboEstado option:selected").text(),
                City: $("#cboCiudad option:selected").text(),
                CityId: $("#cboCiudad").val(),
                PostalCode: $("#txtCodigoPostal").val()
            },
            PaymentMethod:
            {
                Type: $('input[name="paymentMethodType"]:checked').val(),
                CardNumber: $("#trj_numero").val(),
                ExpirationDate: $("#trj_vigencia").val(),
                CVV: $("#trj_cvv").val(),
                CardholderName: $("#trj_nombre").val(),
                Email: $("#trj_nombre").val()
            }
        };

        jQuery.ajax({
            url: '/Payment/ProcessPayment',
            type: "POST",
            data: request,
            success: function (data) {
                if (data.result.status === "success") {
                    Swal.fire({
                        icon: "success",
                        title: "Proceso de Compra Finalizado",
                        text: data.result.message,
                        showConfirmButton: false,
                        timer: 5000
                    }).then((value) => {
                        window.location.href = "/Store/Order"
                    });
                } else {
                    Swal.fire({
                        icon: "warning",
                        title: "No se pudo completar la compra",
                        text: data.result.message,
                        showConfirmButton: false,
                        timer: 5000
                    });
                }
            },
            error: function (error) {
                var err = error.responseText;
                console.log(err)
            }
        });
    }
})

function GetCountries() {
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
            GetStates();
        },
        error: function (error) {
            console.log(error)
        }
    });
}

$("#cboPais").on("change", function () {
    GetStates();
});

function GetStates() {

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
            GetCities();
        },
        error: function (error) {
            console.log(error)
        }
    });
}

$("#cboEstado").on("change", function () {
    GetCities();
});

function GetCities() {

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
        }
    });
}

$("input[name='paymentMethodType']").click(function () {
    if ($(this).attr("id") == "creditCard") {
        $("#datosTarjeta").show();
        $("#datosPaypal").hide();
    } else {
        $("#datosTarjeta").hide();
        $("#datosPaypal").show();
    }
});
