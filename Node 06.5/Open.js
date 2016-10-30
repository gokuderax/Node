var fs =require("fs");

console.log("Abriendo archivo");
fs.open("fichero.txt", 'r+', function(err, fd){

	if (err){
		return console.error(err);
	}
	console.log("File opened successfully");
});