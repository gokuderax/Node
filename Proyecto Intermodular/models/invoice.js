'use strict'
const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const InvoiceSchema = new Schema({
        id:{
                type:String
                },
        id_client:{
                type:String
                },
        id_shop:{
                type:String
                },
        id_salesperson: {
                type:String
                },
        taxes: {
                type:String
                },
        base_total:{
                type:String
                },
        base_advanced:{
                type:String
                },
        observations: {
                type:String
                },
        validated: {
                type:String 
       
                },
        date:{
                type:String 

                },
        products: Array
});
module.exports = mongoose.model('Invoice', InvoiceSchema);
