'use strict';

const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const UserSchema =new Schema({
   typeUser:[],
   nifcif:{
      type:String,
      required: true,
      unique: true
   },
   nombre: {
      type:String,
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   apellido1: {
      type:String,
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   apellido2: {
      type:String,,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]      
   },
   tipo_via:{
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   nombre_via: {
      type:String,     
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   numero: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   piso: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   puerta: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   cod_postal:{
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[10,"Nombre muy largo"]
   },
   muncipio: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   provincia: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   pais: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   telefono1: {
      type:String,      
      required: true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   telefono2: {
      type:String,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   fax: {
      type:String,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   email: {
      type:String,
      lowercase:true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   persona_contacto:{
      type:String,
      lowercase:true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   tipo_cliente:{
      type:String,
      lowercase:true,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   password:{
      type:String,
      select:false,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   fecha_inicio: {
      type:Date,
      default:Date.now()
   },
   fecha_fin:  {
      type:Date,
      default:Date.now()
   },
   cargo:{
      type:String,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },
   lastLogin:{
      type:Date
   },
   observaciones: {
      type:String,
      minlength[5,"Nombre muy corto"], 
      maxlength[20,"Nombre muy largo"]
   },

});

module.exports = mongoose.model('User', UserSchema);