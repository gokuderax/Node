'use strict'
var url=require('url');
var jwt=require('jwt-Simple');
module.exports = (req,res,next)=>{
	let parsed_url=url.parse(req.url,true);
	let token = (req.body && req.body.acces_token)||(parsed_url.query.acces_token)||(req.headers['x-acces-token']);
	console.log("El token recibido es: "+token);
	if (token){
		try{
			var decoded = jwt.decode(token, 'textoSecreto');
			if(decoded.exp <= Date.now()){res.end('Ha expidado',400);}
			console.log("No ha expirado: "+decoded.sub);
			req.user =decoded.sub;
			return next();
		}
		catch(err){
			console.log(err); return next();
		}
	}
	else{
		next();
	}
};