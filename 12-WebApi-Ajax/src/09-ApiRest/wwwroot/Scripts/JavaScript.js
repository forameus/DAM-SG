window.addEventListener("load", start);

function start() {
    document.getElementById("btnSubmit").addEventListener("click", crear);
    listar();
}

function listar() {    
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../api/persona/");
    oXML.onreadystatechange = function () {
        if (oXML.readyState == 4 && oXML.status == 200) {
            var respXML = oXML.response;
            var datos = JSON.parse(oXML.responseText);
            document.getElementById("txtContenedor").innerText = "";            
            var p = new Persona();
            for (var i = 0; i < datos.length; i++) {
                p = datos[i];
                document.getElementById("txtContenedor").innerHTML += p.nombre+" "+p.apellidos+" - <button id=\"btnMod\" onclick=\"editar("+p.id+")\">Editar</button> <br/> ";
            }           
            
        } else {
            document.getElementById("txtContenedor").innerText = "Cargando..."
        };
    }
    oXML.send();
}


function borrar() {
    //Comprobar si la Id está vacía
    var id = document.getElementById("txbIDBorrar").value;
    if (id != "") {
        var oXML = new XMLHttpRequest();
        var res = true;
        oXML.open("DELETE", "../api/persona/" + id);
        oXML.onreadystatechange = function () {
            res = (oXML.readyState == 4 && oXML.status == 200);
        }
        oXML.send();        
        setTimeout(listar, 1000);
    }    
}

function crear(e) {
    e.preventDefault();
    //Crear objeto persona    
    var nombre = document.getElementById("txtPNombre").value;
    var apellidos = document.getElementById("txtPApellidos").value;
    var fechaNac = document.getElementById("txtPFechaNamicion").value;
    var direccion = document.getElementById("txtPDireccion").value;
    var telefono = document.getElementById("txtPTelefono").value;

    if (nombre != "" && apellidos != "" && fechaNac != null && direccion != "" && telefono != "") {
        alert("Datos válidos");
        var p = new Persona(nombre, apellidos, 0, fechaNac, direccion, telefono);
        var json = JSON.stringify(p);

        //Insertar persona
        var oXML = new XMLHttpRequest();
        var res = true;
        oXML.open("POST", "../api/persona/");
        oXML.setRequestHeader("Content-Type", "application/json")        
        oXML.send(json);

        setTimeout(listar, 1000);
    }    
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

function convertirFecha(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}