'use strict';

const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const UserSchema = Schema({

   cif: String,

   nombre: String,

   apelido1: String,

   apellido2: String,

   tipo_via: String,

   nombre_via: String,

   numero: String,

   piso: String,

   puerta: String,

   cod_postal: String,

   muncipio: String,

   provincia: String,

   pais: String,

   telefono1: String,

   telefono2: String,

   email: String,

   persona_contacto: String,

   tipo: Number,

   observaciones: String,

   fecha_inicio: Date,

   fecha_final: Date,

   tienda: Number,

   cargo: Number

});

module.exports = mongoose.model('User', UserSchema);