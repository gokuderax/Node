var fs = require("fs");

console.log("Going to write into existing file");
fs.writeFile('fichero.txt', 'añadiendo texto', function(err){
	if(err) {
		return console.error(err);
	}
		console.log("Data written successfully!");
		console.log("let's read newly written data");
		fs.readFile('fichero.txt', function(err, data){
			if (err) {
				return console.error(err);
			}
			console.log("Asynchronous read: "+data.toString());
		});
});