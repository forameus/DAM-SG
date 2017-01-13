window.addEventListener("load", listar);

function listar() {
    
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../api/persona/");
    oXML.onreadystatechange = function () {
        if (oXML.readyState == 4 && oXML.status == 200) {
            var respXML = oXML.response;
            //document.getElementById("txtContenedor").innerHTML = oXML.responseText;
            var datos = JSON.parse(oXML.responseText);
            document.getElementById("txtContenedor").innerText = "";            
            var p = new Persona();
            for (var i = 0; i < datos.length; i++) {
                p = datos[i];
                document.getElementById("txtContenedor").innerHTML += p.nombre+" "+p.apellidos+" "+"<br/> ";
            }           
            
        } else {
            document.getElementById("txtContenedor").innerText = "Cargando..."
        };
    }
    oXML.send();
}

function borrar() {
}

class Persona {
    constructor(nombre, apellidos, id, fechaNac, direccion, telefono) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.id = id;
        this.fechaNac = fechaNac;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}