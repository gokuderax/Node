var mongoose = require('mongoose');

var colors = require('colors');

var UserModel = require('./models/user');

mongoose.connect('mongodb://localhost/jwtest');

var db = mongoose.connection;

db.on('error', console.error.bind(console, 'Failed to connect to database!'.red));
db.once('open', function callback(){

    var user = new UserModel();

    user.username = 'bob';

    user.password = 'password';

    user.save(function(err){

        if(err){

            console.log('Could not save user.'.red);

        }else{

            console.log('Database seeded'.green);

        }

        process.exit();

    });

});