'use strict';
const express = require('express');
const contadorController = require('../controllers/contador');
const jwtauth = require('../lib/jwtauth');
const requireAuth = require('../lib/requireAuth');

const api = express.Router();

api.get('/initialize', contadorController.resetContador);
api.get('/increment', contadorController.incrementarUnidad);
api.get('/increment/:numberToIncrement', contadorController.incrementarUnidadValor);
api.get('/counter', contadorController.getContador);
api.get('/token', contadorController.getToken);
api.get('/secret', contadorController.checkToken);

module.exports = api;