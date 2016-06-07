(function() {
    'use strict';

    angular
        .module('app')
        .factory('TrackFactory', TrackFactory);

    TrackFactory.$inject = ["$http", "$q", 'toastr'];

    /* @ngInject */
    function TrackFactory($http, $q, toastr) {
        var url = "http://localhost:57079/api/tracks";
        var service = {
            getTrack: getTrack,
            addTrack: addTrack,
            deleteTrack: deleteTrack,
            updateTrack: updateTrack
        };
        return service;

        ////////////////

    function getTrack () {
         var defer = $q.defer();

        $http({
            method: 'GET',
            url: url
        }).then(function(response) {
                    defer.resolve(response);
                }),function(error) {
                    defer.reject(error);
                     toastr.error('error: '+ error.data + '<br/>status: ' + error.statusText);
                }
                return defer.promise;
            };

        function addTrack(track) {
        	var defer = $q.defer();
        	
            $http ({
                    method: "POST",
                    url: url,
                    data: track
                }).then(function(response) {
                    defer.resolve(response);
                }),function(error) {
                    defer.reject(error);
                    
                }
                return defer.promise;
            };

        function deleteTrack (track) {    
            var defer = $q.defer();

        $http({
            method: 'DELETE',
            url: url +'/' + track.trackId
        }).then(function(response) {
                    defer.resolve(response.data);
                }),function(error) {
                    defer.reject(error);
                    
                }
                return defer.promise;
            };

        function updateTrack (track) {
         var defer = $q.defer();

        $http({
            method: 'PUT',
            url: url +'/' + track.trackId,
            data: track
        }).then(function(response) {
                    defer.resolve(response);
                }),function(error) {
                    defer.reject(error);
                }
                return defer.promise;
            };
    }
})();





