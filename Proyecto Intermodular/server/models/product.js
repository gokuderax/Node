'use strict'
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const ProductSchema = Schema({
	id: {
		type:String, 
	    required: true, 
	    unique: true
		},
	referencia: {
		type:String,
		required: true,
	    unique: true
		},
	nombre: {
		type:String,  
		required: true, 
		minlength:[3,"Nombre muy corto"], 
		maxlength:[15,"Nombre muy largo"]
		},
	modelo: {
		type:String,  
		required: true, 
		minlength:[15,"Nombre muy corto"], 
		maxlength:[50,"Nombre muy largo"]
		},
	descripcion: {
		type:String,  
		required: true,
		minlength:[15,"Nombre muy corto"], 
		maxlength:[250,"Nombre muy largo"]
		},
	categoria: {
		type:String, 
		required: true, 
		unique: true, 
		enum: ['phones','computers','accesories']
		},
	importe: {
		type:Number,
		required: true, 
		min:[0,"No puede ser negativo"]
		},
	iva: {
		type:Number,
		default:21
	},
	proveedor: {
		type:String,
		required: true,
	},
	tienda_stock: []
});

	ProductSchema.path('tienda_stock').validate(function(value) {
  return value.length;
},"tienda_stock' no puede estar vacio");

module.exports = mongoose.model('product', ProductSchema);