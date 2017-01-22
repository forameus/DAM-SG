window.addEventListener("load", start);

function start() {
    document.getElementById("btnSubmit").addEventListener("click", crear);
    listar();
}

function listar() {
    document.getElementById("txtContenedor").innerText = "Cargando..."
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
                document.getElementById("txtContenedor").innerHTML += p.nombre + " " + p.apellidos + " - <button id=\"btnMod"+p.id+"\" onclick=\"editar(" + p.id + ")\">Editar</button>   <button id=\"btnBorrar"+p.id+"\" onclick=\"borrar(" + p.id + ")\">Borrar</button><br/> ";
            }           
            
        } else {
            document.getElementById("txtContenedor").innerText = "Cargando..."
        };
    }
    oXML.send();
}

//Deprecated
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

function borrar(id) {
    //Comprobar si la Id está vacía   
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

//Mostrar datos en el form
function editar(id) {    
    var oXML = new XMLHttpRequest();
    oXML.open("GET", "../api/persona/"+id);    
    oXML.onreadystatechange = function () {
        if (oXML.readyState == 4 && oXML.status == 200) {
            var respXML = oXML.response;
            var dato = JSON.parse(oXML.responseText);            
            var p = new Persona();
            p = dato;
            document.getElementById("txtPNombre").value = p.nombre;
            document.getElementById("txtPApellidos").value = p.apellidos;
            document.getElementById("txtPFechaNamicion").value = new Date(p.fechaNac);
            document.getElementById("txtPDireccion").value = p.direccion;
            document.getElementById("txtPTelefono").value = p.telefono;
            var fecha = new Date(p.fechaNac);
            var year = fecha.getFullYear();
            var month = fecha.getMonth();
            var day = fecha.getDay();
            var fechaBien(fecha.get);
            alert(fechadate);
        } 
            
    };    
    oXML.send();
}
    
   
function actualizar() {
    var oActualizar = new XMLHttpRequest();
    
    //Crear objeto persona    
    var nombre = document.getElementById("txtPNombre").value;
    var apellidos = document.getElementById("txtPApellidos").value;
    var fechaNac = document.getElementById("txtPFechaNamicion").value;
    var direccion = document.getElementById("txtPDireccion").value;
    var telefono = document.getElementById("txtPTelefono").value;
    
    //Comprobar persona válida
    if (nombre != "" && apellidos != "" && fechaNac != null && direccion != "" && telefono != "") {
        alert("Datos válidos");
        var p = new Persona(nombre, apellidos, 0, fechaNac, direccion, telefono);
        var json = JSON.stringify(p);

        //Reinsertar persona en la sociedad
        var oXML = new XMLHttpRequest();
        var res = true;
        oXML.open("PUT", "../api/Persona/" + id, true);
        oXML.setRequestHeader("Content-Type", "application/json")        
        oXML.send(json);

        setTimeout(listar, 1000);
    }  
}
