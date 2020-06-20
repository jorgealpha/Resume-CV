'use strict'

var Project = require('../models/project');

var controller = {

    home: function(req , res){

        return req.status(200).send({

            message: 'SOy Home'
        });
    },

    test: function(req , res){

        return req.status(200).send({

            message: 'SOy metodo test de accion controller '
        });

    },

    saveProject: function(req , res){

        var project = new Project();

        return req.status(200).send({

            message: 'Soy metodo Save Project de accion controller '
        });

    }

};

module.exports = controller;