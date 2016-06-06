(function() {
    'use strict';
    angular
        .module('app')
        .controller('TrackController', TrackController);

    TrackController.$inject = ['TrackFactory', 'toastr'];
      var vm = this;
        vm.title = 'TrackController';

    function TrackController(TrackFactory, toastr) {

        vm.getTrack = function() {
            TrackFactory.getTrack().then(function(response) {

                vm.tracks = response.data;
                console.log(vm.tracks);
               /* console.log(vm.items);*/
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

        vm.addTrack = function(track) {
            TrackFactory.addTrack(Track).then(function(response) {
                vm.Tracks.push(response.data);
                vm.Track = {};
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

        vm.deleteTrack = function(track) {
            TrackFactory.deleteTrack(Track).then(function(response) {
                var index = vm.Tracks.indexOf(Track);
                vm.Tracks.splice(index, 1);
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

        vm.updateTrack = function(track) {
            TrackFactory.updateTodo(Track).then(function(response) {
            }, function(error) {
                toastr.error('There has been an error');
            });
        };

    }

})();
