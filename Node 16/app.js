var express = require('express');
var app = express();

app.get('/', function (req,res) {
	res.send('Hello World!');
});

app.get('/name/:user_name', function(req,res){
	res.status(200);
	res.set('Content-type', 'text/html');
	res.send('<html> <body>'+'<h1> Hello '+req.params.user_name + '</h1>'+'</body></html>');
});

app.listen(3000, function(){
	console.log('Example app listening on port 3000!');
});