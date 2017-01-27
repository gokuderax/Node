'use strict';
const express = require('express');
const productController = require('../controllers/product');
const userController = require('../controllers/user');
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

module.exports = api;