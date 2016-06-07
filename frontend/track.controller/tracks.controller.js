(function() {
    'use strict';
    angular
        .module('app')
        .controller('TracksController', TracksController);

    TracksController.$inject = ['TrackFactory', 'toastr'];
        var vm = this;
        vm.title = 'TracksController';

    function TracksController(TrackFactory, toastr) {

       vm.getTrack = function() {
            TrackFactory.getTrack().then(function(response) {
               vm.tracks = response.data;
               /* console.log($scope.items);*/
            }, function(error) {
                toastr.error('There has been an error');
            });
        };


       vm.addTrack = function(track) {
            TrackFactory.addTrack(track).then(function(response) {
               vm.tracks.push(response.data);
               vm.Track = {};
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

       vm.deleteTrack = function(track) {
            TrackFactory.deleteTrack(track).then(function(response) {
                var index =vm.tracks.indexOf(track);
               vm.tracks.splice(index, 1);
            }, function(error) {
                toastr.error('There has been an error');
            });
        };


       vm.updatetrack = function(track) {
            TrackFactory.updateTrack(track).then(function(response) {
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

    }

})();
