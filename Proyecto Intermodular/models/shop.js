'use strict'
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const TiendaSchema = Schema({
	id: {
		type: String, 
		require:true, 
		unique:true
	},
	nombre_tienda: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	tipo_via: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	nombre_via: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	numero: {
		type: Number,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	cod_postal: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	municipio: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	provincia: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	pais: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	telefono: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	fax: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	email: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]
	},
	encargado: {
		type: String,
		required: true,
      	minlength:[5,"Nombre muy corto"], 
      	maxlength:[20,"Nombre muy largo"]}
});

module.exports = mongoose.model('Tienda', TiendaSchema);