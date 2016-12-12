function saludo() {
    document.getElementById("boton").addEventListener("click", boton);
}

function boton() {
    var nombre = document.getElementById("txbNombre").value;
    var apellidos = document.getElementById("txbApellido").value;
    var ok = true;

    if (nombre === "") {
        document.getElementById("errorNombre").innerText = "El nombre no puede estar vácio.";
        ok = false;
    } else
        document.getElementById("errorNombre").innerText = "";

    if (apellidos===""){
        document.getElementById("errorApellido").innerText = "El nombre no puede estar vácio.";
        ok = false;
    }else
        document.getElementById("errorApellido").innerText = "";

    if(ok)
        document.getElementById("divMensaje").innerText = "Hola "+ nombre+" "+apellidos+", eres un caranchoa.";

}