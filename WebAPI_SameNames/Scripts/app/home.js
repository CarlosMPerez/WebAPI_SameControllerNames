$(document).ready(function () {
});

function llamadaAPIExterna() {

    var datosIn = { Nombre: $('#txtNombreExterno').val() };
    var llamada = $.ajax({
        type: "POST",
        data: JSON.stringify(datosIn), 
        contentType: "application/json; charset=utf-8",
        url: "External/Saludo/ObtenerSaludo"
    });

    llamada.done(function (data) {
        $('#lblResultadoExterno').val(data.TextoSaludo);
    });

    llamada.fail(function (xhr, status, error) {
        alert(xhr);
    });
}

function llamadaAPIInterna() {

    var datosIn = { Nombre: $('#txtNombreInterno').val() };
    var llamada = $.ajax({
        type: "POST",
        data: JSON.stringify(datosIn), 
        contentType: "application/json; charset=utf-8",
        url: "Internal/Saludo/ObtenerSaludo"
    });

    llamada.done(function (data) {
        $('#lblResultadoInterno').val(data.TextoSaludo);
    });

    llamada.fail(function (xhr, status, error) {
        alert(xhr);
    });
}