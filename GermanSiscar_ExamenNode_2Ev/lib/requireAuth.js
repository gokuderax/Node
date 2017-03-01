module.exports = function(req, res, next){ //MIDDLEWARE RESTRINGIR
	if(!req.user){
		res.end('Not authorized', 401);
	}else{
		next();
	}
}