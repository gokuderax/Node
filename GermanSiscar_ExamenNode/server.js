var http = require('http');
var url = require('url');
var fs = require('fs');
var querystring = require("querystring");
var process = require('process');
var moment = require('moment');
var ip = require('ip');
var peticion = {};
var i=0;
var objToJson = { };
var ruta
var puerto

function iniciar(enrutar, request){
		function arrancarServidor(peticion, respuesta) {

				i++;
				respuesta.setHeader('Content-Type', 'text/html');
				ruta = url.parse(peticion.url).pathname;
				if (ruta.length >= 1){
						
						 puerto = ruta.split("/")[2];						
				}
				
				log();
				if (ruta == "/detener") {
					console.log("Fin del servidor");
					process.exit(1);
				}

				if(ruta == "/arrancarServidorExtra/"+puerto)
				{
					if (puerto != null)
					http.createServer(ServidorExtra).listen(puerto);
					else
					http.createServer(ServidorExtra).listen(8091);
					
					
				}
	
				
				if(ruta == "/arrancarchat/"+puerto){

					if(puerto != null)
					http.createServer(ServidorChat).listen(puerto);
					else 
					http.createServer(ServidorExtra).listen(8092);
		
				}
				if(ruta == "/tiempoLevantado")
				{
					 respuesta.write(moment().format());
				}


				if(ruta == "/numeroDeRequests")
				{
					objToJson.response = respuesta;
					respuesta.write(JSON.stringify("El numero de requests es: "+i));	
					console.log(""+i);
				}
				if(ruta == "/obtenerLOG")
				{
					objToJson.response = respuesta;
					var readStream = fs.createReadStream("log.txt");
					readStream.pipe(respuesta);

					//ERRROR CIRCULAR
					// JSON.stringify(readStream.pipe(respuesta));

					
				}
				if(ruta == "/borrarLOG")
				{
					if(fs.exists('log.txt'))
				  fs.unlinkSync('log.txt');		 
				}

				respuesta.end();

	}




		function log()
		{
				var logger = fs.createWriteStream('log.txt', {flags: 'a' });
				logger.write("PID: "+process.pid+" NºRequest: "+ i+" Timestamp: "+ Date.now() +" Ruta: "+ruta+" Direccion ip: "+ ip.address()+"\n");
		}

		function ServidorExtra(peticion,respuesta)
		{
				process.exit(1);
		}
		function ServidorChat(peticion, respuesta)
		{
			var net = require('net');
			var ip = require('ip');
			const chalk = require('chalk');
			const colors = [chalk.red, chalk.yellow, chalk.pink, chalk.green, chalk.blue, chalk.orange];
			var server = net.createServer();
			var sockets = [];
			var chatLog = [];
			var ids=0;
			var clients = [];
			var aux=0;

			server.on('connection', function(socket){
					data =null;
					socket.id = ids;
					const random = Math.floor(Math.random() * (5 - 0)) + 0;
					console.log(random+" " +typeof(random));
				var client = {
					id:ids,
					nombre:null,
					ip: ip.address(),
					color:colors[random]
				};
				console.log("got a net connection: " +client.ip);
				
				clients[socket.id]=client;
				ids++;
				aux++;
			
				if(chatLog != null){
					for(var texto in chatLog){
					socket.write(chatLog[texto].toString());
					}
				}
				socket.write("Introduce un nombre de usuario: ");	
			
				sockets.push(socket);
				socket.on('data', function(data){
					if(aux==1){
						clients[socket.id].nombre=data.toString();
						aux=0;
					}
					else {
					console.log(clients[socket.id].color('got data from ip',clients[socket.id].ip,':', data.toString()));
					chatLog.push(data);	
					sockets.forEach(function(otherSocket){
						if (otherSocket !== socket) {
							otherSocket.write(clients[socket.id].nombre+': '+data);
						}
			
				});
				}
			});
				socket.on('close', function(){
					console.log('connection closed');
					var index = sockets.indexOf(socket);
					sockets.spllice(index, 1);
				}); 
			}); 
			
			server.on('error', function(err) {
				console.log('Server error:', err.message);
			});
			
			server.on('close', function(){
				console.log('Server closed');
			});
			
}

http.createServer(arrancarServidor).listen(8090);
console.log("Primera Conexion");


}
iniciar(peticion);
			