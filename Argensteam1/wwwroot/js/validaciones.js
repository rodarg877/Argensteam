using String.prototype.match;

function validarNombre(nombreUsuario) {
    var pudo = false;
    if (nombreUsuario.length <= 6 && nombreUsuario.length >= 30) {
        document.getElementById("ususarioInv").style.visibility = "visible";
    } else {
        document.getElementById("ususarioInv").style.visibility = "hidden";
        pudo = true;
    }
}

function validarContrasenia(contrasenia) {
    var pudo = false;
    if (contrasenia <= 8 && !contrasenia.match(/\d/)) {
        document.getElementById("contraseniaInv").style.visibility = "visible";
    } else {
        document.getElementById("contraseniaInv").style.visibility = "hidden";
        pudo = true;
    }
}

function validarFormulario(event) {
    var nombreVal = validarNombre(document.getElementById("contrasenia"));
    var contrVal = validarContrasenia(document.getElementById("ususario"));

    if (!nombreVal || !contrVal) {
        event.preventDefault();
    }

}