(function() {
    'use strict';

    angular
        .module('app')
        .factory('TrackFactory', TrackFactory);

    TrackFactory.$inject = ["$http", "$q"];

    /* @ngInject */
    function TrackFactory($http, $q) {
        
        var service = {
            getTrack: getTrack,
            addTrack: addTrack,
            deleteTrack: deleteTrack,
            updateTrack: updateTrack
        };
        return service;

        ////////////////

    function getTrack (url) {
         var defer = $q.defer();

        $http({
            method: 'GET',
            url: url
        }).then(function(response) {
                    defer.resolve(response);
                }),function(error) {
                    defer.reject(error);
                }
                return defer.promise;
            };

        function addTrack(url,track) {
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

        function deleteTrack (url, track) {    
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

        function updateTrack (url, track) {
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





