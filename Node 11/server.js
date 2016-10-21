var buf = new Buffer('Hello world!');

var buf2 = new Buffer('8b76fde713ce','base64');

var buf3 = new Buffer(1024);

//console.log(buf.length);

for(var i=0;i<buf.length;i++){
	buf[i]=i;
	console.log(buf[i]);
}