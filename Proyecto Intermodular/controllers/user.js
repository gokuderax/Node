'use strict';
const User = require('../models/user');

function getUsers(req,res){
		User.find({}, (err, users) => {
		if(err) return res.status(500).send({message: 'Error en petición ${err}' });
		if(!users) return res.status(404).send({message: 'No se han encontrado usuarios'});
		res.status(200).send({users});
		res.end();
});
}
function getUser(req, res) {
    let userId = req.params.userId;
    User.findById(userId, (err, users) => {
        if(err) return res.status(500).send({message: `Error en petición ${err}` });
        if(!users) return res.status(404).send({message: 'No se han encontrado usuarios'});
        res.status(200).send({users});
        res.end();
    });
}
function saveUser(req,res){

		let user = new User(req.body);

		user.save((err, userStored) => {
		if(err)
		 res.status(500).send({message:`Error al guardar usuario ${err}`});
		else
		res.status(200).send({user: userStored});

	res.end();
	});
}
function updateUser(req,res){
		let userId = req.params.userId;
		let update = req.body;
		User.findByIdAndUpdate(userId,update, (err, productUpdated)=>{
			if(err) res.status(500).send({message:`Error al actualizar usuario ${err}`});
		res.status(200).send({product: productUpdated});
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

module.exports = {getUsers,getUser,saveUser,updateUser,deleteUser};