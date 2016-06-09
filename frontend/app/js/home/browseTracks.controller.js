(function() {
    'use strict';

    angular
        .module('app')
        .controller('BrowseTracksController', BrowseTracksController);

    BrowseTracksController.$inject = ['trackFactory', 'moduleFactory', 'toastr'];

    /* @ngInject */
    function BrowseTracksController(trackFactory, moduleFactory, toastr) {
        var vm = this;
        vm.title = 'BrowseTracksController';

        ////////////////

        vm.getTracks = function() {
            trackFactory.getAll().then(function(response) {
                vm.tracks = response.data;
                /* console.log($scope.items);*/
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

        vm.getModules = function() {
            moduleFactory.getAll().then(function(response) {
                vm.modules = response.data;
                /* console.log($scope.items);*/
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

        vm.updateModule = function(module) {
            module.likeCount += 1;
            moduleFactory.update(module.moduleId, module).then(function(response) {}, function(error) {
                toastr.error('There has been an error');
            });
        };
    }
})();
