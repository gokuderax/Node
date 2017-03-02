'use strict';
const User = require('../models/user');
const moment = require('moment');
const jwt = require('jwt-simple');
const express = require('express');
const app = express();

app.set('jwtTokenSecret', 'secretvalue');

function getUsers(req,res){
		User.find({}, (err, users) => {
		if(err) return res.status(500).send({message: 'Error en petición ${err}' });
		if(!users) return res.status(404).send({message: 'No se han encontrado usuarios'});
		res.status(200).send(users);
		res.end();
});
}
function getUser(req, res) {
    let userId = req.params.userId;
    User.findById(userId, (err, users) => {
        if(err) return res.status(500).send({message: `Error en petición ${err}` });
        if(!users) return res.status(404).send({message: 'No se han encontrado usuarios'});
        res.status(200).send([users]);
        res.end();
    });
}
function saveUser(req,res){
	console.log(req.body);
		let user = new User(req.body);
		user.save((err, userStored) => {

		if(err){
		 res.status(500).send({message:`Error al guardar usuario ${err}`});
		 console.log(err);
		}
		else{
			//console.log(userStored);
			res.status(200).send([userStored]);
		}
		
		 res.end();

	
	});
}
function updateUser(req,res){
		let userId = req.params.userId;
		let update = req.body;
		User.findByIdAndUpdate(userId,update, (err, productUpdated)=>{
			if(err) res.status(500).send({message:`Error al actualizar usuario ${err}`});
		res.status(200).send([productUpdated]);
		res.end();
		});
}
function deleteUser(req,res){
		let userId = req.params.userId;
		User.findByIdAndRemove(userId, (err, productDelete)=>{
			 if(err) res.status(500).send({message:`No ${userId}`});
			 if(err) res.status(500).send({message:`Error al eliminar el usuario con id ${userId}`});
			 	res.status(200).send({message: `el usuario ${userId} ha sido eliminado`});
		});
		
}
function getToken(req, res){
	console.log("xiENTRAMOS en GET /token"); 
		
	if(req.headers.email && req.headers.password){
	console.log(req.headers.email );
	console.log(req.headers.password);
		User.findOne({email: req.headers.email}, function(err, user){
			if(err){
			 res.send('Authentication error - No usuario', 401); }
			else {
				user.comparePassword(req.headers.password, function(err, isMatch){
				if(err) res.send('Error in password', 401); 	
				if(isMatch){
					var expires = moment().add('days', 7).valueOf();
					var token = jwt.encode({ iss: user.id, exp: expires}, app.get('jwtTokenSecret'));
					res.json({token: token, expires: expires, user: user.toJSON()});
				}else{
					res.send('Autenthication error - No coinciden passwords', 401);	
				}
			});
			}

		});
	}else{
		//No username provided, or invalid POST request. For simplicity, just return a 401 code
		res.send('Aunthentication error - No username provided - Invalid POST request', 401);
	}
}

module.exports = {getUsers,getUser,saveUser,updateUser,deleteUser,getToken};
