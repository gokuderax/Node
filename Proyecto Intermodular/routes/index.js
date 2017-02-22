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
api.get('/product',jwtauth, requireAuth, productController.getProducts);
api.get('/product/:productId',jwtauth, requireAuth, productController.saveProduct);
api.post('/product',jwtauth, requireAuth, productController.saveProduct);
api.put('/product/:productId',jwtauth, requireAuth, productController.updateProduct);
api.delete('/product/:productId',jwtauth, requireAuth,productController.deleteProduct);

api.post('/token', userController.getToken);
api.get('/user',jwtauth, requireAuth, userController.getUsers);
api.get('/user/:userId',jwtauth, requireAuth, userController.getUser);
api.post('/user',userController.saveUser);
api.put('/user/:userId',jwtauth, requireAuth,userController.updateUser);
api.delete('/user/:userId',jwtauth, requireAuth, userController.deleteUser);

api.get('/shop',jwtauth, requireAuth, shopController.getShops);
api.get('/shop/:shopId',jwtauth, requireAuth,shopController.getShop);
api.post('/shop',jwtauth, requireAuth,shopController.saveShop);
api.put('/shop/:shopId',shopController.updateShop);
api.delete('/shop/:shopId', shopController.deleteShop);


api.get('/invoice',jwtauth, requireAuth, invoiceController.getInvoices);
api.get('/invoice/:invoiceId',jwtauth, requireAuth,invoiceController.getInvoice);
api.post('/invoice',jwtauth, requireAuth,invoiceController.saveInvoice)
api.put('/invoice/:invoiceId',jwtauth, requireAuth,invoiceController.updateInvoice)
api.delete('/invoice/:invoiceId',jwtauth, requireAuth, invoiceController.deleteInvoice);

module.exports = api;