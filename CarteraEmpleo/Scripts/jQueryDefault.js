function Sesion(usuario, tipo) {
    var user;
    switch (tipo) {
        case '0':
            document.getElementById("Login").innerHTML = '';
            break;
        case '1':
            user = '<div class="UsuarioLink"><a href="/Interfaz/ModPerfilAdministrador.aspx">' + usuario + '</a></div>';
            document.getElementById("Login").innerHTML = user;
            break;
        case '2':
            user = '<div class="UsuarioLink"><a href="/Interfaz/ModPerfilEmpresa.aspx">' + usuario + '</a></div>';
            document.getElementById("Login").innerHTML = user;
            break;
        case '3':
            user = '<div class="UsuarioLink"><a href="/Interfaz/ModPerfilPersona.aspx">' + usuario + '</a></div>';
            document.getElementById("Login").innerHTML = user;
            break;
    }
    //alert('funciona sesion')
}