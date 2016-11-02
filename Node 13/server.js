var server = require('net').createServer(function(socket) {
	console.log('new conecction');

	socket.setEncoding('utf8');

	socket.write("Hello! You can start typing. Type 'Quit' to exit.\n");

	socket.on('data', function(data) {
		if(data.trim().toLowerCase()==='quit'){
			socket.write('bye bye!');
			return socket.end();
		}
		socket.write(data);
	});
	socket.on('end',function(){
		console.log('Client connection ended');
	});
}).listen(4001);