(function() {
    'use strict';

    angular
        .module('app')
        .controller('BootcampModuleController', BootcampModuleController);

    BootcampModuleController.$inject = ['dataHolderService', 'moduleFactory', '$stateParams', 'toastr'];

    /* @ngInject */
    function BootcampModuleController(dataHolderService, moduleFactory, $stateParams, toastr) {
        var vm = this;
        vm.title = 'BootcampModuleController';
        vm.modules = dataHolderService.modules;
        vm.module = {};
        console.log(vm.modules);
        //vm.availableTags = ["C#", ".NET", "JavaScript"];



        vm.getBootCamp();
        vm.getBootCamp = function() {
            bootcampFactory.getById($stateParams.bootcampId)
                .then(function(response) {
                        vm.bootcamp = response;
                        dataHolderService.modules = response.modules;
                        vm.modules = dataHolderService.modules;
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };

        vm.getModule = function() {
            moduleFactory.getById()
                .then(function(response) {
                        vm.bootcamp = response;
                        //vm.bootcamp.tags = [];
                        console.log(vm.bootcamp);
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };

        vm.addBootCamp = function(bootcamp) {
            moduleFactory.create(bootcamp)
                .then(function(response) {
                        vm.bootcamps.push(data);
                        console.log(data);

                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };

        vm.deleteBootCamp = function(bootcamp) {
            moduleFactory.remove(bootcamp)
                .then(function(response) {
                        var index = vm.bootcamps.indexOf(bootcamp);
                        vm.tracks.splice(index, 1);
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };


        vm.updateBootCamp = function(bootcamp) {
            moduleFactory.update(bootcamp.bootcampId, bootcamp)
                .then(function(response) {
                        //add code here when db is up to date
                    },
                    function(error) {
                        toastr.error('There has been an error');
                    });
        };
    }
})();
