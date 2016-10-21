var http = require('http');


http.createServer(function(request, response){

		process.nextTick(function nexTick1() {
			var a = 0;
			while(true) {
				a++;
				console.log(a);
			}
		});

		process.nextTick(function nexTick2(){
			console.log("next tick");
		});

		setTimeout(function timeout(){
			console.log("timeout");
		}, 1000);
  /*  var twoSeconds = 2000 * 1;

    var fiveSeconds = 5000 * 1;

    setInterval(function(){
        console.log("2 segundos mas.");
        response.write("<p>2 segundos</p>");
        response.end();

    }, twoSeconds);*/

}).listen(8080);