'use strict'

var mongoose = require('mongoose');
var app = require('./app');
var port = 3700;

mongoose.Promise = global.Promise;

mongoose.connect('mongodb://localhost:27017/portfolio')
        .then(() => {
            console.log('Hola sirvio conexion!');

            // Creacion del servidor 

             app.listen(port, () => {

                console.log('Corriendo servidor !');

             });
            
        })
        .catch(err => console.log(err));
