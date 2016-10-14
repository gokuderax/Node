var http = require('http');
var url = require('url');
var fs = require('fs');
var querystring = require("querystring");
var peticion = {};
var i=0;

function iniciar(enrutar, request){
		function arrancarServidor(peticion, respuesta) {


			
			var ruta = url.parse(peticion.url).pathname;
			console.log("Se pide la ruta: " +ruta);
			console.log("Total de visitas: "+(++i));

				if (ruta == "/closeserver") {
					console.log("Fin del servidor");
					process.exit(1);
				}
	
				

	}
		
		http.createServer(arrancarServidor).listen(8090);
		console.log("Primera Conexion");
		
		
		}
		iniciar(peticion);
