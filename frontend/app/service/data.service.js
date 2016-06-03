(function() {
    'use strict';

    angular
        .module('app')
        .factory('DataService', DataService);

    DataService.$inject = ['$http', '$q'];

    /* @ngInject */
    function Service($http, $q) {
        var service = {
        	DataService: DataService
        };

        return service;

        ////////////////

        function func(data) {
        	var defer = $q.defer();
        	$http(data).then(function(response){
        		defer.resolve(response);
        	}, function(error){
        		defer.reject(error);
        	});

        	return defer.promise;
        }
    }
})();