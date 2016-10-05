var servidor = require('./server');
var enrutador = require('./router.js');
var manejador = require('./handler');
var peticion = {};

peticion["/"] = manejador.inicio;
peticion["/inicio"] = manejador.inicio;
peticion["/pagina1"] = manejador.pagina1;
peticion["/salida"] = manejador.salida;
peticion["/favicon.ico"] = manejador.favicon;
servidor.iniciar(enrutador.enrutar, peticion);