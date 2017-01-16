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
		res.status(200).send({message: `get /api/product`});
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
		product.save((err, productStore)=>{
			if(err) res.status(500).send({message: `Error al insertar ${err}`});
			res.status(200).send({message: `Producto insertado`, product :productStore});
		});
		res.status(200).send({message: `post /api/product`});
});
mongoose.connect('mongodb://localhost:27017/shop', (err, res)=>{
		if(err){ return console.log(`Error al conectar a la DB ${err}`)}
		app.listen(3000, () => {
			console.log(`Levantado el servidor ${port}`);
		});	
});
   