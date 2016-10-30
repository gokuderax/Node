var fs =require("fs");

console.log("Going to get file info!");
fs.stat("fichero.txt", function(err, stats){

	if (err){
		return console.error(err);
	}
	console.log(stats);
	console.log("File opened successfully");

	console.log("isFile ? " + stats.isFile());
	console.log("isDirectory ? " + stats.isDirectory());
});