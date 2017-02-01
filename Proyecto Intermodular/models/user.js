'use strict';

const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const UserSchema =new Schema({
   typeUser:[],
   nif:{type:String},
   cif: {type:String},
   nombre: {type:String},
   apellido1: {type:String},
   apellido2: {type:String},
   tipo_via:{type:String},
   nombre_via: {type:String},
   numero: {type:Number},
   piso: {type:String},
   puerta: {type:String},
   cod_postal:{type:String},
   muncipio: {type:String},
   provincia: {type:String},
   pais: {type:String},
   telefono1: {type:String},
   telefono2: {type:String},
   fax: {type:String},
   email: {type:String,lowercase:true},
   persona_contacto:{type:String,lowercase:true},
   tipo_cliente:{type:String,lowercase:true},
   password:{type:String,select:false},
   fecha_inicio: {type:Date,default:Date.now()},
   fecha_fin:  {type:Date,default:Date.now()},
   cargo:{type:String},
   lastLogin:{type:Date},
   observaciones: {type:String},

});

module.exports = mongoose.model('User', UserSchema);