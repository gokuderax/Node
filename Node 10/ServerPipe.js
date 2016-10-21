var http = require('http');

http.createServer(function(request,response) {
/*
	request.on('error', function(err){
		console.error(err);
		response.statusCode = 400;
		response.end();
	});
	response.on('error', function(err){
		console.error(err);
	});*/
		console.log(request.headers);
	if(request.method === 'POST' && request.url === '/echo')
	{
		request.pipe(response);

		
	}
	else
	{
		response.statusCode = 404;
		response.end();
	}

}).listen(8080);