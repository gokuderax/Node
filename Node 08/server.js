var http = require('http');
var url = require('url');
var fs = require('fs');
var querystring = require("querystring");

function iniciar(enrutar, request){
		function arrancarServidor(peticion, respuesta) {
			console.log("Se ha conectado un cliente.");
			
			var ruta = url.parse(peticion.url).pathname;
			//enrutar(ruta, request, respuesta);
			
			if (ruta== "/")
			
				ruta ="inicio.html";
			
			var html = fs.readFileSync("www/"+ruta);
			
			var archivo_accesos = fs.createWriteStream("accesos.txt",{"flags":"a"});
			archivo_accesos.write(ruta + "\n");
			
			if (peticion.method == "POST") {
					var posDate = null;
					peticion.setEncoding("utf8");

					peticion.on("data", function(data) {
						posData = querystring.parse(data);
							html = html.toString();
							html = html.replace("{nombre}",posData.nombre);
							html = html.replace("{apellido}",posData.apellido);
							html = html.replace("{correo}",posData.correo);
							html = html.replace("{sugerencia}",posData.sugerencia);

			respuesta.writeHead(200,{"Content-Type":"text/html"});
			respuesta.write(html)
			respuesta.end();
		}); 
		} else {
			respuesta.writeHead(200,{"Content-Type":"text/html"});
			respuesta.write(html)
			respuesta.end();
		}
	}
		
		http.createServer(arrancarServidor).listen(8080);
		console.log("Servidor web iniciado");
		
		
		}
	exports.iniciar = iniciar;