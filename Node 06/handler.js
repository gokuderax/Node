function inicio(respuesta){
	console.log("Solicitud para inicio");
	respuesta.writeHead(200, {"Content-Type":"text/html"});
		respuesta.write("<h1>Contenido de inicio</h1>");
		respuesta.end();

}
function pagina1(respuesta){
	console.log("Solicitud para pagina1");
	respuesta.writeHead(200, {"Content-Type":"text/html"});
		respuesta.write("<h1>Contenido de pagina1</h1>");
		respuesta.end();

}
function salida(respuesta){
	console.log("Solicitud para salida");
	respuesta.writeHead(200, {"Content-Type":"text/html"});
		respuesta.write("<h1>Contenido de salida</h1>");
		respuesta.end();

}
function favicon(respuesta){
	console.log("Solicitud para favicon");
	respuesta.writeHead(200, {"Content-Type":"text/html"});
		respuesta.write("<h1>Contenido de favicon</h1>");
		respuesta.end();

}

exports.inicio = inicio;
exports.pagina1 = pagina1;
exports.salida = salida;
exports.favicon = favicon;