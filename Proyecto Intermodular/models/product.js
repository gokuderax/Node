'use stritct'
const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const ProductSchema= Schema({
	name:String,
	pictute:String,
	price: {type: Number, default:0},
	categoria: {type: String, enum:['computers','phones','accesories']},
	description: String
});
module.exports=mongoose.model('Product', ProductSchema);