
var net = require('net');

var server = net.createServer();
var sockets = [];
var chatLog = [];
var ids=0;
var clients = [];
var aux;
server.on('connection', function(socket){
	console.log("got a net connection");
	var client = {
		id:ids++,
		nombre:""
	};
	clients[socket.id]=client;
	aux++;
	socket.write("Introduce un nombre de usuario: ");	
	if(chatLog != null){
		for(var texto in chatLog){
		socket.write(chatLog[texto].toString());
		}
	}
	sockets.push(socket);
	socket.on('data', function(data){
		if(aux==1){
			clients[socket.id].nombre=data.toString();
		}
		else {
		console.log('got data:', data.toString());
						console.log(clients[socket.id]);
		chatLog.push(data);	
		sockets.forEach(function(otherSocket){
			if (otherSocket !== socket) {
				otherSocket.write(clients[socket.id].nombre+": "+data);
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