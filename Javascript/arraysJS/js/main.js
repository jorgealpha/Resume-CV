"use strict";

/* 

-Pida 6 numeros y agregarlo a un array 
-Mostrar el array entero en el body y consola 
-Sacar el array ordenado y mostrarlo en body
-Invertir el orden del array en el body 
-mostrar cuantos elementos tiene el array 
-busqueda de un valor introducido por el user
y que diga si esta y el indice 


*/

function mostrarArray(elementos, textoCustom = "") {
  document.write("<h1>Contenido del array" + textoCustom + "</h1>");
  document.write("<ul>");
  elementos.forEach((elemento, index) => {
    document.write("<li>" + elemento + "</li>");
  });
  document.write("</ul>");
}

var numeros = new Array(6);

//pedir numeros

for (var i = 0; i <= 5; i++) {
  numeros.push(parseInt(prompt("Introduce el numero : ", 0)));
}

mostrarArray(numeros);

console.log(numeros);

numeros.sort(function (a, b) {
  return a - b;
});

mostrarArray(numeros, "Ordenado");

console.log(numeros);

numeros.reverse();

mostrarArray(numeros, "Revertido");

document.write(
  "<h1>El array tiene : " + numeros.length + " elementos" + "</h1>"
);

var busqueda = parseInt(prompt("Busca numero", 0));

var posicion = numeros.findIndex((numero) => numero == busqueda);

if (posicion && posicion != -1) {
  document.write("<h1>Encuentra : " + busqueda + "</h1>");

  document.write("<h1>Encontrado : " + posicion + "</h1>");
} else {
  document.write("No encontrado : " + busqueda + "</h1>");
}
