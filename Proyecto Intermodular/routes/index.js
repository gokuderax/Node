'use strict';
const express = require('express');
const productController = require('../controllers/product');
const userController = require('../controllers/user');
const shopController = require('../controllers/shop');
const invoiceController = require('../controllers/invoice');
const api = express.Router();
//Listening
api.get('/product', productController.getProducts);
api.get('/product/:productId', productController.saveProduct);
api.post('/product', productController.saveProduct);
api.put('/product/:productId', productController.updateProduct);
api.delete('/product/:productId',productController.deleteProduct);

api.get('/user', userController.getUsers);
api.get('/user/:userId', userController.getUser);
api.post('/user',userController.saveUser);
api.put('/user/:userId',userController.updateUser);
api.delete('/user/:userId', userController.deleteUser);

api.get('/shop', shopController.getShops);
api.get('/shop/:shopId',shopController.getShop);
api.post('/shop',shopController.saveShop);
api.put('/shop/:shopId',shopController.updateShop);
api.delete('/shop/:shopId', shopController.deleteShop);


api.get('/invoice', invoiceController.getInvoices);
api.get('/invoice/:invoiceId',invoiceController.getInvoice);
api.post('/invoice',invoiceController.saveInvoice)
api.put('/invoice/:invoiceId',invoiceController.updateInvoice)
api.delete('/invoice/:invoiceId', invoiceController.deleteInvoice);

module.exports = api;