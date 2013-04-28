function IDlogg() {
     if (CojerCookie("loginID") != -1) {
         document.getElementById('IDlabel').innerHTML = CojerCookie("loginID");
     }
 }


 function Cerrar_sesion() {
     document.cookie = 'loginID' + '=' + '' + '' + '; path=/';
     window.open('login.aspx', '_self', false);
 }


 function CojerCookie(nombre) {
     var galleta = document.cookie;
     var arg = nombre + "=";
     var alen = arg.length;
     var glen = galleta.length;

     var i = 0;
     while (i < glen) {
         var j = i + alen;
         if (galleta.substring(i, j) == arg)
             return CojerValorCookie(j);

         i = galleta.indexOf(" ", i) + 1;
         if (i == 0)
             break;
     }
     return null;
 } 

function CojerValorCookie(indice) {   
    var galleta = document.cookie;
    var finDeCadena = galleta.indexOf(";", indice);
    if (finDeCadena == -1)  
        finDeCadena = galleta.length;
  
    return unescape(galleta.substring(indice, finDeCadena));
}

