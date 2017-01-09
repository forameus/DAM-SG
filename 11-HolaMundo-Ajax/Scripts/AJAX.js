document.getElementById("btnPedirHolaMundo").addEventListener("click", pedirHolaMundo);
document.getElementById("btnPedirDesplegable").addEventListener("click", pedirDesplegable);
document.getElementById("btnPedirXML").addEventListener("click", pedirXML);
document.getElementById("btnPedirTabla").addEventListener("click", pedirTabla);


function llamada(valor) {
    //1-Instanciamos el objeto
    var oXML = new XMLHttpRequest();
    document.getElementById("txtContenedor").innerHTML = "Cargando...";

    //2-Definimos el método open
    switch (valor) {
        case 1:
            oXML.open("GET", "../Server/HolaMundo.html");
            break;
        case 2:
            oXML.open("GET", "../Server/Desplegable.html");
            break;
        case 3:
        case 4:
            oXML.open("GET", "../Server/personas.xml");
            break;
    }    

    //3-Establecemos Cabeceras (Opcional)

    //4-Definimos que hacermos cuando va cambiando el objeto
    oXML.onreadystatechange = function () {        

        if (oXML.readyState < 4) {
            document.getElementById("txtContenedor").innerHTML = "Cargando..."
        }
        else if(oXML.readyState==4 && oXML.status == 200){
            //6-Tratamiento de datos
            if (valor == 3) {
                var respXML = oXML.responseXML;
                escribirPersona(respXML);
            } else if (valor == 4) {
                var respXML = oXML.responseXML;
                escribirPersonas(respXML);
            }else
                document.getElementById("txtContenedor").innerHTML = oXML.responseText;

            
        } else if (oXML.status == 404) {
            document.getElementById("txtContenedor").innerHTML = "Error 404: Archivo not found.";
        }

    }

    //5-Enviar la solicitud
    oXML.send();

}

function pedirHolaMundo() { llamada(1); }
function pedirDesplegable() { llamada(2); }
function pedirXML() { llamada(3); }
function pedirTabla() { llamada(4); }


function escribirPersona(respXML) {
    document.getElementById("txtContenedor").innerHTML = respXML.getElementsByTagName("nombre")[0].childNodes[0].nodeValue;
}



function escribirPersonas(respXML) {
    var tabla = document.createElement("TABLE");
    tabla.border = 2;
    tabla.borderColor = "red";
    tabla.bgColor = "black";    
    var pFila = document.createElement("TR");
    var pColumna = document.createElement("TH");
    var pTexto = document.createTextNode("Nombre");
    pColumna.appendChild(pTexto);
    pFila.appendChild(pColumna);

    pColumna = document.createElement("TH");
    pTexto = document.createTextNode("Apellidos");
    pColumna.appendChild(pTexto);
    pFila.appendChild(pColumna);
    tabla.appendChild(pFila);
    

    //Añadir personas
    var personas = respXML.getElementsByTagName("persona");
    for (var i = 0; i < personas.length; i++) {        
        var miFila = document.createElement("TR");
        //Añadir Nombres
        var miColumna = document.createElement("TD");
        var miTexto = document.createTextNode(personas[i].firstElementChild.textContent);
        miColumna.appendChild(miTexto);
        miFila.appendChild(miColumna);

        //Añadir Apellidos
        miColumna = document.createElement("TD");
        miTexto = document.createTextNode(personas[i].lastElementChild.textContent);
        miColumna.appendChild(miTexto);
        miFila.appendChild(miColumna);

        tabla.appendChild(miFila);
    }       
      
    
    document.getElementById("txtContenedor").innerText = "";
    document.getElementById("txtContenedor").appendChild(tabla);
}