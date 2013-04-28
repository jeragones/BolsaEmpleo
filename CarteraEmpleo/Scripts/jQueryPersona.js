function Idiomas(lista) {
    var list = lista.split(",");
    var tmp = "idioma";
    var code = '<table>';
    for (var i = 0; i < list.length; i++) {
        code += '<tr id="idioma' + i + '">' +
                '<td>' + list[i] + '</td>' +
                '<td><a href="javascript:QuitarIdioma(idioma' + i + ')"><img src="/Images/eliminar.png" width="20" height="20" /></a></td>' +
                '</tr>';
        // <button type="button" width="20" height="20" onClick="QuitarIdioma(' + 'idioma' + i + ')">
    } // 
    code += '</table>';
    //alert('funciona idiomas');
    document.getElementById("Idiomas").innerHTML = code;
}

function Telefonos(lista) {
    var list = lista.split(",");
    var code = '<table>';
    for (var i = 0; i < list.length; i++) {
        code += '<tr>' +
                '<td><div id="telefono' + i + '">' + list[i] + '</div></td>' +
                '<td><img src="/Images/eliminar.png" width="20" height="20" onclick="QuitarTelefono" /></td>' +
                '</tr>';
    }
    code += '</table>';
    //alert('funciona telefonos');
    document.getElementById("Telefonos").innerHTML = code;
}

function QuitarIdioma(idioma) {
    document.getElementById(idioma.id).innerHTML = '<div></div>';
}


// Metodos de la clases
