var http = require('http');


var server = http.createServer(function(request,response) {
	var headers = request.headers;
	var method = request.method;
	var url = request.url;
	var body = [];
	
	request.on('error', function(err) {
		console.log(err);
	}).on('data',function(chunk) {
		body.push(chunk);
		
	}).on('end',function() {
		body = Buffer.concat(body).toString();
		console.log(headers);
		console.log(method);
		console.log(url);
		console.log(body);
	});
}).listen(8080);
