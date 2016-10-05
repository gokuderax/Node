var moment = require('moment');
function enrutar(ruta, request, respuesta) {

		console.log("Rutear a " + ruta +" a las " + moment().format() + "\n\n");
		if(typeof request[ruta] === "function"){
			
			return request[ruta](respuesta);
	}else{
			console.log("No");
			respuesta.writeHead(404,{"content-Type":"text/html"});
			respuesta.write("<h1> 404 - No se ha encontrado: " +ruta);
			respuesta.end();
	}

}
exports.enrutar = enrutar;

