'use strict';
const Shop = require('../models/shop');

function getShops(req,res){
		Shop.find({}, (err, shops) => {
		if(err) return res.status(500).send({message: 'Error en petición ${err}' });
		if(!shops) return res.status(404).send({message: 'No se han encontrado usuarios'});
		res.status(200).send({shops});
		res.end();
});
}
function getShop(req, res) {
    let shopId = req.params.shopId;
    Shop.findById(shopId, (err, shops) => {
        if(err) return res.status(500).send({message: `Error en petición ${err}` });
        if(!shops) return res.status(404).send({message: 'No se han encontrado usuarios'});
        res.status(200).send({shops});
        res.end();
    });
}
function saveShop(req,res){

		let shop = new Shop(req.body);

		shop.save((err, shopStored) => {
		if(err)
		 res.status(500).send({message:`Error al guardar usuario ${err}`});
		else
		res.status(200).send({shop: shopStored});

	res.end();
	});
}
function updateShop(req,res){
		let shopId = req.params.shopId;
		let update = req.body;
		Shop.findByIdAndUpdate(shopId,update, (err, productUpdated)=>{
			if(err) res.status(500).send({message:`Error al actualizar usuario ${err}`});
		res.status(200).send({product: productUpdated});
		res.end();
		});
}
function deleteShop(req,res){
		let shopId = req.params.shopId;
		Shop.findByIdAndRemove(shopId, (err, productDelete)=>{
			 if(err) res.status(500).send({message:`No ${shopId}`});
			 if(err) res.status(500).send({message:`Error al eliminar el usuario con id ${shopId}`});
			 	res.status(200).send({message: `el usuario ${shopId} ha sido eliminado`});
		});
		
}

module.exports = {getShops,getShop,saveShop,updateShop,deleteShop};