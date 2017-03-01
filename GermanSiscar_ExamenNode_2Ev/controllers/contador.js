'use strict';
const Contador = require('../models/contador');
const moment = require('moment');
const jwt = require('jwt-simple');
const express = require('express');
const app = express();
const fs = require('fs');
const url = require('url');
const ip = require('ip');
var i=0;
app.set('jwtTokenSecret','secretvalue');

function resetContador(req,res){
		Contador.find({ user: 'examen' }, (err, cont) => {
		if(err) return res.status(500).send({message: `Error en la petecion ${err}`});
		if( Object.keys(cont).length === 0){
			let contador = new Contador({user:'examen',counter:0});
						console.log("cont "+contador);

			contador.save((err, contStored)=>{
				if(err){
					res.status(500).send({message:`Error al guardar usuario ${err}`});
						res.end();
				}
				else {
					res.status(200).send({contador: contStored});
						res.end();
				}
			});
			}
			else{
				Contador.findOneAndUpdate({ user: 'examen' }, {counter: 0 }).exec(function(err, cont) { 
 	
				if(err) return res.status(500).send({message: `Error en la petecion ${err}`});
  				 else { 
  				   console.log("cont " +cont); 
  				   res.status(200).send(cont);
  				   res.end();
  				 } 
 				});
			}	
	});
		log(url.parse(req.url).pathname);
}

function incrementarUnidad(req,res){
	Contador.findOneAndUpdate({ user: 'examen' }, { $inc: { counter: 1 }}).exec(function(err, cont) { 
 
	if(err) return res.status(500).send({message: `Error en la petecion ${err}`});
    else { 
      console.log(cont); 
      res.status(200).send(cont);
      res.end();
    } 
  });
	log(url.parse(req.url).pathname);
}
function incrementarUnidadValor(req,res){
		let valor = req.params.numberToIncrement;
		Contador.findOneAndUpdate({ user: 'examen' }, { $inc: { counter: valor }}).exec(function(err, cont) { 
		if(err) return res.status(500).send({message: `Error en la petecion ${err}`});
 		  else { 
 		    console.log(cont); 
 		    res.status(200).send(cont);
 		    res.end();
 		  } 
 		});
 		log(url.parse(req.url).pathname);
}
function getContador(req,res){
		Contador.find({ user: 'examen' }, (err, cont) => {
			if(err) return res.status(500).send({message: `Error en la petecion ${err}`});
			res.status(200).send(cont);
			console.log(cont);
			res.end();

		});
		log(url.parse(req.url).pathname);
}
function getToken(req,res){
	Contador.findOne({user:'examen'}, function(err, contador){
			if(err) res.send('Authentication error - No usuario', 401); 
					var expires = moment().add('days', 7).valueOf();
					var token = jwt.encode({ iss: contador.user, exp: expires}, app.get('jwtTokenSecret'));
					res.json({token: token, expires: expires, contador: contador.toJSON()});
					res.end();
			});
	log(url.parse(req.url).pathname);
}
function checkToken(req,res){
	res.send('Has entrado en secret');
	res.end();
	log(url.parse(req.url).pathname);
}

		function log(ruta)
		{
				i++;
				var logger = fs.createWriteStream('log.txt', {flags: 'a' });
				logger.write("PID: "+process.pid+" NºRequest: "+ i+" Timestamp: "+ Date.now() +" Ruta: "+ruta+" Direccion ip: "+ ip.address()+"\n");
		}
module.exports ={resetContador,incrementarUnidad,incrementarUnidadValor,getContador,getToken,checkToken};