'use strict';
const express = require('express');
const productController = require('../controllers/product');
const userController = require('../controllers/user');
const shopController = require('../controllers/shop');
const invoiceController = require('../controllers/invoice');
var jwtauth = require('../lib/jwtauth');
var requireAuth = require('../lib/requireAuth');

const api = express.Router();
//Listening
api.get('/product', productController.getProducts);
api.get('/product/:productId', productController.saveProduct);
api.post('/product',productController.saveProduct);
api.put('/product/:productId',jwtauth, requireAuth, productController.updateProduct);
api.delete('/product/:productId',jwtauth, requireAuth,productController.deleteProduct);

api.post('/token', userController.getToken);
api.get('/user', userController.getUsers);
api.get('/user/:userId', userController.getUser);
api.post('/user', userController.saveUser);
api.put('/user/:userId',userController.updateUser);
api.delete('/user/:userId',userController.deleteUser);

api.get('/shop', shopController.getShops);
api.get('/shop/:shopId',jwtauth, requireAuth,shopController.getShop);
api.post('/shop',shopController.saveShop);
api.put('/shop/:shopId',shopController.updateShop);
api.delete('/shop/:shopId', shopController.deleteShop);


api.get('/invoice',jwtauth, requireAuth, invoiceController.getInvoices);
api.get('/invoice/:invoiceId',jwtauth, requireAuth,invoiceController.getInvoice);
api.post('/invoice',jwtauth, requireAuth,invoiceController.saveInvoice)
api.put('/invoice/:invoiceId',jwtauth, requireAuth,invoiceController.updateInvoice)
api.delete('/invoice/:invoiceId',jwtauth, requireAuth, invoiceController.deleteInvoice);

module.exports = api;