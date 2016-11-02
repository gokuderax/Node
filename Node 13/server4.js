var moment = require('moment');
var server = require('net').createServer(function(socket) {
	console.log('new conecction');

	socket.setEncoding('utf8');

	socket.write("Hello! You can start typing. Type 'Quit' to exit.\n");
	var tiempo= moment().format("ss");
	socket.on('data', function(data) {
		if(data.trim().toLowerCase()==='quit'){
			socket.write('bye bye!');
			return socket.end();
		}
		socket.write(data);
	});

		//tiempo=tiempo-moment().fromNow();
		console.log(tiempo);
		//var timeout = 2000;
		//socket.setTimeout(timeout);
		socket.on('timeout', function(){
			socket.write('idle timeout, disconnecting, bye!');
			socket.end();
	});

	socket.on('end',function(){
		console.log('Client connection ended');
	});
}).listen(4001);


