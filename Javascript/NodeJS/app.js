'use strict'

var express = require('express');

var bodyParser = require('body-parser');

var app = express();


// files routes

var project_routes = require('./routes/project');


//middlewares


app.use(bodyParser.urlencoded({extended:false}));

app.use(bodyParser.json());


//CORS


// routes 

app.use('/api',project_routes);


//Export

module.exports = app;