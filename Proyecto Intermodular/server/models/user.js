'use strict';

const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const bcrypt = require('bcrypt');
var SALT_WORK_FACTOR = 10;
mongoose.Promise = global.Promise;


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
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   apellido1: {
      type:String,
      required: true,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   apellido2: {
      type:String,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]      
   },
   tipo_via:{
      type:String,      
      required: true
   },
   nombre_via: {
      type:String,     
      required: true,
      minlength:[3,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   numero: {
      type:String,      
      required: true
   },
   piso: {
      type:String,      
      required: true
   },
   puerta: {
      type:String,      
      required: true
   },
   cod_postal:{
      type:String,      
      required: true
   },
   municipio: {
      type:String,      
      required: true,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   provincia: {
      type:String,      
      required: true,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   pais: {
      type:String,      
      required: true,
      minlength:[2,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   telefono1: {
      type:String,      
      required: true,
      minlength:[8,"Nombre muy corto"], 
      maxlength:[10,"Nombre muy largo"]
   },
   telefono2: {
      type:String,
      minlength:[8,"Nombre muy corto"], 
      maxlength:[10,"Nombre muy largo"]
   },
   fax: {
      type:String,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   email: {
      type:String,
      lowercase:true,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   persona_contacto:{
      type:String,
      lowercase:true,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   tipo_cliente:{
      type:String,
      lowercase:true,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   password:{
      type:String,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
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
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },
   lastLogin:{
      type:Date
   },
   observaciones: {
      type:String,
      minlength:[5,"Nombre muy corto"], 
      maxlength:[20,"Nombre muy largo"]
   },

});
UserSchema.pre('save', function(next){
   var user = this; 
   if(!user.isModified('password')) return next();//hasheamos si camb
   bcrypt.genSalt(SALT_WORK_FACTOR, function(err, salt){
      if(err) return next(err);
      bcrypt.hash(user.password, salt, function(err, hash){
         if(err) return next(err); 
         user.password = hash;
         next();
      });
   });
});
UserSchema.methods.comparePassword = function(candidatePassword, cb){
   bcrypt.compare(candidatePassword, this.password, function(err, isMatch){
   if(err) return cb(err);
   cb(null, isMatch);
   });
};
UserSchema.statics.findByUsername = function(username, cb){
   this.findOne({username: username}, cb);
}
module.exports = mongoose.model('User', UserSchema);