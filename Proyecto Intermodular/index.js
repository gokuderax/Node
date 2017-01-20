'use strict'
const express = require('express');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');
const Product = require('./models/product');
const port = process.env.PORT || 3000
const app = express();
//Middleware
app.use(bodyParser.urlencoded({extended:false}));
app.use(bodyParser.json());
/*//Rutas
app.get('/hola/:nombre',(req,res)=>{
	res.send({message: `Hola ${req.params.nombre}`});
});*/
app.get('/api/product', (req,res)=>{
		Product.find({}, (err, products) => {
		if(err) return res.status(500).send({message: 'Error en petición ${err}' });
		if(!products) return res.status(404).send({message: 'No se han encontrado productos'});
		res.status(200).send({products});
		res.end();
});
});
app.get('/api/product/:idproduct', (req,res)=>{
		res.status(200).send({message: `get /api/product/:idproduct`});
});
app.put('/api/product/:idproduct', (req,res)=>{
		res.status(200).send({message: `put /api/product/:idproduct`});
});
app.delete('/api/product/:idproduct', (req,res)=>{
		res.status(200).send({message: `delete /api/product/:idproduct`});
});
app.post('/api/product/', (req,res)=>{
		let product = new Product();
		product.name = req.body.name;
		product.picture = req.body.picture;
		product.price = req.body.price;
		product.category = req.body.category;
		product.description = req.body.description;

		product.save((err, productStored) => {
		if(err) res.status(500).send({message: 'Error al guardar producto ${err}'});
		res.status(200).send({product: productStored});

});
});
mongoose.Promise = global.Promise;
mongoose.connect('mongodb://localhost:27017/shop', (err, res) => {
if (err) {
return console.log('Error al conectar a la BD: ${err}');
}
console.log('Conexión establecida a la BD');
app.listen(port, () => {
console.log('Levantado ${port}');
});
});
/*mongoose.connect('mongodb://localhost:27017/shop', (err, res)=>{
		if(err){ return console.log(`Error al conectar a la DB ${err}`)}
		app.listen(3000, () => {
			console.log(`Levantado el servidor ${port}`);
		});	
});*/
   
