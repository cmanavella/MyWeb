$(document).ready(function(){
    //$('#btnValidarSignIn').click(function () {
        //var email = $('#user-email').val();
        //var pass = $('#user-pass').val();
        //var form = document.getElementsByTagName('frmSignIn');

        //alert('Hola Mundo');
        

        //$.ajax({
        //    type: "GET",
        //    url: "/Usuarios/ValidarUsuario",
        //    success: function (data) {
        //        alert('Bienvenido ' + data.Nombre + ' ' + data.Apellido + ' a nuestro sitio.');
        //    },
        //    failure: function (response) {
        //        alert(response.d);
        //    }
        //});
    //});

    $('#frmSignIn').submit(function () {
        var form = $(this);

        form.validate();
        if (form.valid()) {
            form.ajaxSubmit({
                dataType: 'JSON',
                type: 'POST',
                url: form.attr('action'),
                success: function (r) {
                    if (r.Valida) {
                        alert('Bienvenido ' + r.Modelo.Nombre + ' ' + r.Modelo.Apellido + ' a nuestro sitio.');
                        $('#Email').val('');
                        $('#Password').val('');
                    } else {
                        $('#signin-validation').text(r.Error).show();
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
        return false;
    });
});