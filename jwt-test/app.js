'use strict';

const express = require('express');
const jwt = require('jwt-simple');
const moment = require('moment');
const bodyParser = require('body-parser');
const jwtauth = require('./lib/jwtauth');
const app = express();

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

var requireAuth = function(req,res,next){
	if(!req.user){res.end('No estas autoridado a ver esta ruta')}
	else {
		console.log("Has llegado a la zona privada");
		next();}
}
app.get('/secret',jwtauth,requireAuth,(req,res)=>{
	console.log('GET /secret');
	res.send(req.user+ ' Has entrado a la seccion privada');
	res.end();
});
app.get('/token', (req, res)=>{
    console.log('GET /token');
    const payload = {iss:'APIpspV1', sub:'usuario', iat:moment.unix(), exp: moment().add(7, 'days').valueOf()};
    const token = jwt.encode(payload, 'textoSecreto');
    console.log('token');
    res.send(token);
    res.end();
});


app.listen(3000);