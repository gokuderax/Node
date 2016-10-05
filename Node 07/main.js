var events = require('events');
var eventEmitter = new events.EventEmitter();


var listner1= function listner1(){
	console.log('listner1 executed.');
}

var listner2= function listner2(){
	console.log('listner2 executed.');
}

eventEmitter.addListener('connection' listner1);