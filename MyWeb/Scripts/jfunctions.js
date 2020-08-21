$(document).ready(function(){
    $('#btnValidarSignIn').click(function () {
        var email = $('#user-email').val();
        var pass = $('#user-pass').val();

        $.ajax({
            type: "GET",
            url: "/Usuarios/ValidarUsuario",
            success: function (data) {
                alert('Bienvenido ' + data.Nombre + ' ' + data.Apellido + ' a nuestro sitio.');
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    });
});