
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

server.listen(4001);