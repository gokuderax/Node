'use strict';
const Product = require('../models/product');

function getProducts(req,res){
		Product.find({}, (err, products) => {
		if(err) return res.status(500).send({message: 'Error en petición ${err}' });
		if(!products) return res.status(404).send({message: 'No se han encontrado productos'});
		res.status(200).send({products});
		res.end();
});
}
function getProduct(req, res) {
    let productId = req.params.productId;
    Product.findById(productId, (err, products) => {
        if(err) return res.status(500).send({message: `Error en petición ${err}` });
        if(!products) return res.status(404).send({message: 'No se han encontrado productos'});
        res.status(200).send({products});
        res.end();
    });
}
function saveProduct(req,res){
		let product = new Product();
		product.name = req.body.name;
		product.picture = req.body.picture;
		product.price = req.body.price;
		product.category = req.body.category;
		product.description = req.body.description;

		product.save((err, productStored) => {
		if(err) res.status(500).send({message:`Error al guardar producto ${err}`});
		res.status(200).send({product: productStored});

});
}
function updateProduct(req,res){
		let productId = req.params.idproduct;
		let update = req.body;
		Product.findByIdAndUpdate(productId,update, (err, productUpdated)=>{
			if(err) res.status(500).send({message:`Error al actualizar producto ${err}`});
		res.status(200).send({product: productUpdated});
		res.end();
		});
}
function deleteProduct(req,res){
		let productId = req.params.idproduct;
		Product.findByIdAndRemove(productId, (err, productDelete)=>{
			 if(err) res.status(500).send({message:`No ${productiD}`});
			 if(err) res.status(500).send({message:`Error al eliminar el producto con id ${productId}`});
			 	res.status(200).send({message: `el prodcuto ${productId} ha sido eliminado`});
		});
		
}

module.exports = {getProducts,getProduct,saveProduct,updateProduct,deleteProduct};