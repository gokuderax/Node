var express = require ('express');
var app = express();

app.get('/',function(req,res){
	res.send("Detectado verbo GET");
});
app.post('/', function(req,res){
	res.send("Detectado verbo Post");
});
app.put('/', function(req,res){
	res.send("Detectado verbo Put");
});
app.delete(' /', function(req,res){
	res.send("Detectado verbo Delete");
});
app.listen(3000, function(){
	console.log("App listening en el puerto 3000");
});
