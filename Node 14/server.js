
var net = require('net');

var server = net.createServer();
var sockets = [];
var chatLog = [];

server.on('connection', function(socket){
	console.log("got a net connection");
	if(chatLog != null){
		for(var texto in chatLog){
		socket.write(chatLog[texto].toString());
		}
	}
	sockets.push(socket);
	socket.on('data', function(data){
		console.log('got data:', data.toString());
		chatLog.push(data.toString());	
		sockets.forEach(function(otherSocket){
			if (otherSocket !== socket) {
				otherSocket.write(data);
			}
	});
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