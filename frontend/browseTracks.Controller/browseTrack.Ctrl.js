(function() {
    'use strict';

    angular
        .module('app')
        .controller('browseTracksCtrl', browseTracksCtrl);

    browseTracksCtrl.$inject = ['TrackFactory', 'toastr'];

    /* @ngInject */
    function browseTracksCtrl(TrackFactory, toastr) {
        var vm = this;
        vm.title = 'browseTracksCtrl';
        var tracksUrl = "http://localhost:57079/api/tracks";
        var modulesUrl = "http://localhost:57079/api/tracks";



        ////////////////


        vm.getTracks = function() {
            TrackFactory.getTrack(tracksUrl).then(function(response) {
                vm.tracks = response.data;
                /* console.log($scope.items);*/
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

        vm.getModules = function() {
            TrackFactory.getTrack(modulesUrl).then(function(response) {
                vm.modules = response.data;
                /* console.log($scope.items);*/
            }, function(error) {
                toastr.error('There has been an error');
            });
        };


        vm.updateModule = function(module) {
            module.likeCount += 1;
            TrackFactory.updateModule(modulesUrl, module).then(function(response) {}, function(error) {
                toastr.error('There has been an error');
            });
        };
        vm.sortItems = function(order) {
            vm.items = $filter('orderBy')(vm.items, order);
        };




    }
})();
