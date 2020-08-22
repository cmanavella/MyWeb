$(document).ready(function(){
    //Función que permite validar una cuenta de usuario para su posterior inicio de sesión mediante el uso
    //JQuery y Ajax.
    //Capturo el evento Submit del Formulario.
    $('#frmSignIn').submit(function () {
        var form = $(this); //Cargo el formulario para hacerlo más maleable.

        form.validate(); //Valido los campos ingresados según lo que definí en el modelo.
        if (form.valid()) { //Pregunto si todos los campos están validados.
            form.ajaxSubmit({ //Envío el Formulario al Controlador mediante el evento Submit con Ajax.
                dataType: 'JSON',
                type: 'POST',
                url: form.attr('action'),
                success: function (r) {
                    if (r.Valida) { //Como en el controlador hay otra validación más, es necesario saber si fue exitosa.
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
        return false; //Esto lo hago para que la página no se actualice.
    });
});