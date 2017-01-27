'use strict';
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

function compruebaPrecio(price){
	return price >0;
}
const ProductSchema = Schema({
    name: String,
    picture: String,
    price: {type: Number,
    	    default:0,
    	    validate:[compruebaPrecio,'El precio tiene que ser mayor que 0']},
    category: {type: String, enum:['computers', 'phones', 'accesories']},
    description : String
});
module.exports = mongoose.model('Product', ProductSchema);