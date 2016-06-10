(function() {
    'use strict';

    angular
        .module('app')
        .controller('BootcampProfileController', BootcampProfileController);

    BootcampProfileController.$inject = ['bootcampFactory', '$stateParams','toastr'];

    /* @ngInject */
    function BootcampProfileController(bootcampFactory, $stateParams,toastr) {
        var vm = this;
        vm.title = 'BootCampProfileController';
        vm.bootcamps = [];
        vm.bootcamp = {};

        //vm.availableTags = ["C#", ".NET", "JavaScript"];

        vm.getBootCamp = function() {
            bootcampFactory.getById($stateParams.bootcampId)
                .then(function(response) {
                        vm.bootcamp = response;
                        //vm.bootcamp.tags = [];
                        console.log(vm.bootcamp);
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };

        vm.getBootCamp();


        vm.addBootCamp = function(bootcamp) {
            bootcampFactory.create(bootcamp)
                .then(function(response) {
                        vm.bootcamps.push(data);
                        console.log(data);
                        
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };

        vm.deleteBootCamp = function(bootcamp) {
            bootcampFactory.remove(bootcamp)
                .then(function(response) {
                        var index = vm.bootcamps.indexOf(bootcamp);
                        vm.tracks.splice(index, 1);
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };


        vm.updateBootCamp = function(bootcamp) {
            bootcampFactory.update(bootcamp.bootcampId, bootcamp)
                .then(function(response) {
                    //add code here when db is up to date
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };
    }
})();