'use strict';
const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const bcrypt = require('bcrypt');
var SALT_WORK_FACTOR = 10;	

const ContadorSchema = new Schema({
		user : {type:String},
		counter : {type:Number}
});
ContadorSchema.pre('save', function(next){
   var contador = this; 
   if(!contador.isModified('_id')) return next();//hasheamos si camb
   bcrypt.genSalt(SALT_WORK_FACTOR, function(err, salt){
      if(err) return next(err);
      bcrypt.hash(user._id, salt, function(err, hash){
         if(err) return next(err); 
         user.user = hash;
         next();
      });
   });
}); 
ContadorSchema.methods.compareUsername = function(candidateUser, cb){
   bcrypt.compare(candidateUser, this.user, function(err, isMatch){
   if(err) return cb(err);
   cb(null, isMatch);
   });
};
ContadorSchema.statics.findByUsername = function(user, cb){
   this.findOne({user: user}, cb);
}
module.exports = mongoose.model('Contador', ContadorSchema);